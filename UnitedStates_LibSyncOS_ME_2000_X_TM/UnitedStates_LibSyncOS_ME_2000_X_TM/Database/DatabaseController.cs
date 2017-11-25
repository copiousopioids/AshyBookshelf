using System;
using System.Collections.Generic;
using UnitedStates_LibSyncOS_ME_2000_X_TM.Classes;
using MySql.Data.MySqlClient;

namespace UnitedStates_LibSyncOS_ME_2000_X_TM.Database
{
    public class DatabaseController : IControllerFunctions
    {
        private string mysqlConnectionString;
        private MySqlConnection _mysqlConnection;

        private string _selectItemsByTitle_sql = "SELECT available, title from Items where title like @param1 ";
        MySqlCommand _selectItemsByTitle;
        private string _selectBooksByTitle_sql = "select available, title from Books b join Items i on i.item_id=b.item_id where i.title like @param1";
        MySqlCommand _selectBooksByTitle;
        private string _selectMoviesByTitle_sql = "select available, title from Movies m join Items i on i.item_id=m.item_id where i.title like @param1";
        MySqlCommand _selectMoviesByTitle;

        private void PrepareStatements()
        {
            _selectItemsByTitle = new MySqlCommand(_selectItemsByTitle_sql, _mysqlConnection);
            _selectBooksByTitle = new MySqlCommand(_selectBooksByTitle_sql, _mysqlConnection);
            _selectMoviesByTitle = new MySqlCommand(_selectMoviesByTitle_sql, _mysqlConnection);

        }
        
        // Be sure to be on the K-State network or will not be able to connect
        public DatabaseController()
        {
            mysqlConnectionString = "SERVER=mysql.cis.ksu.edu;PORT=3306;DATABASE=zmarcolesco;UID=zmarcolesco;PASSWORD=password;";
            try
            {
                _mysqlConnection = new MySqlConnection();
                _mysqlConnection.ConnectionString = mysqlConnectionString;
                _mysqlConnection.Open();
                PrepareStatements();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Generic insert function for the database.
        /// </summary>
        /// <param name="strSQL">the sql string using parameters.</param>
        /// <param name="parameterValue">A two-dimensional array holding the parameter in the first 'column'
        ///                              (e.g. '@title'), and the value in the second column.</param>
        public bool Insert(string strSQL, string[,] parameterValue)
        {
            MySqlCommand cmd = new MySqlCommand(strSQL, _mysqlConnection);

            for (int i = 0; i < (parameterValue.Length / 2); i++)
            {
                cmd.Parameters.AddWithValue(parameterValue[i, 0], parameterValue[i, 1]);
            }
            int success = -1;
            success = cmd.ExecuteNonQuery();
            if (success > 0) return true;
            else return false;
        }

        /// <summary>
        /// Insert statement for queries that use OUTPUT on an integer.
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public int InsertScalarInt(string strSQL, string[,] parameterValue)
        {
            MySqlCommand cmd = new MySqlCommand(strSQL, _mysqlConnection);

            for (int i = 0; i < (parameterValue.Length / 2); i++)
            {
                cmd.Parameters.AddWithValue(parameterValue[i, 0], parameterValue[i, 1]);
            }
            int modified = (int)cmd.ExecuteScalar();
            return modified;
        }

        public Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success, out string errorMessage)
        {
            try
            {
                string strSQL = "INSERT INTO Items(title, available, weekly_fine, damage_fine) OUTPUT INSERTED.item_id VALUES (@title, true, 2.0, 10.0);";
                string[,] itemValues = new string[,] { { "@title", title } };
                int itemID = -1;
                itemID = InsertScalarInt(strSQL, itemValues);
                if (itemID > 0)
                {
                    string bookSQL = "INSERT INTO Books(item_id, num_pages, publisher, isbn) VALUES (@item_id, @num_pages, @publisher, @isbn);";
                    string[,] bookValues = new string[,]
                    {
                        {"@item_id", itemID.ToString()  }, //No idea if this'll work
                        {"@num_pages", numberOfPages.ToString() },
                        {"@publisher", publisher },
                        {"@isbn", isbn }
                    };
                    if (Insert(bookSQL, bookValues))
                    {
                        //add to relational tables
                        //Item_people and People_Roles_Items
                        string ipSQL = "INSERT INTO Item_People(item_id, person_id) VALUES (@item_id, @person_id);";
                        string[,] ipValues = new string[,]
                        {
                            {"@item_id", itemID.ToString() },
                            {"@person_id", "placeholder" }
                        };

                        string priSQL = "INSERT INTO People_Roles_Items(person_id, role_code, item_id) VALUES (@personID, @role_code, @item_id)";
                        string[,] priValues = new string[,]
                        {
                            { "@personID", "placeholder" },
                            { "@role_code", "placeholder" },
                            { "@item_id", itemID.ToString() }
                        };

                        foreach (Person p in contributors)
                        {
                            ipValues[1, 1] = p.PersonId.ToString();
                            priValues[0, 1] = p.PersonId.ToString();
                            priValues[1, 1] = p.Role.RoleId.ToString();
                            if (!(Insert(ipSQL, ipValues) && Insert(priSQL, priValues)))
                                throw new Exception("Item not added to item_people or people_roles_items");
                        }

                        //Item_condition
                        string icSQL = "INSERT INTO Item_Condition(item_id, code) VALUES (@item_id, @code)";
                        string[,] icValues =
                        {
                            { "@item_id", itemID.ToString() },
                            { "@code", "1" }
                        };


                        //Item_genre
                        string igSQL = "INSERT INTO Item_Genre(item_id, genre_id) VALUES (@item_id, @genre_id)";
                        string[,] igValues =
                        {
                            { "@item_id", itemID.ToString() },
                            { "@genre_id", genre.ID.ToString() }
                        };

                        //insert item cond and item genre
                        if (!(Insert(igSQL, igValues) && Insert(icSQL, icValues)))
                            throw new Exception("Item not added to igSQL or icValues");

                        //if you get to here, you've inserted successfully into all tables
                        errorMessage = "no error";
                        success = true;
                        //return book here
                        return new Book(new Condition("Brand New", 0), true, 10, genre, itemID, title, 2, Convert.ToInt32(isbn), publisher, numberOfPages, contributors);
                    }
                    else throw new Exception("Item not added to table Book");
                    
                }
                else throw new Exception("Item not added to table Item");
            }
            catch (Exception e)
            {
                success = false;
                errorMessage = e.Message;
                throw;
            }
        }

        public Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Fine AddFine(string username, int amount, out bool result, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool CheckoutItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool CheckUserLoginCredentials(string username, string password, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string username, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Award> GetAllAwards(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAllContributors(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Genre> GetAllGenres(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetAllRoles(out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string username, out bool success, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(ItemTypes itemType, string searchTitle)
        {
            throw new NotImplementedException();
        }

        public bool PayFine(string username, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool PayIndividualFine(string username, Fine fine, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria, out string errorMessage)
        {
            List<object> searchResults = new List<object>();
            MySqlCommand query;
            if (searchCriteria == ItemSearchOptions.BookAndMovie)
            {
                query = _selectItemsByTitle;
            } else if (searchCriteria == ItemSearchOptions.Book)
            {
                query = _selectBooksByTitle;
            } else //must be movie
            {
                query = _selectMoviesByTitle;
            }
            query.Parameters.Clear();
            query.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                string someStringFromColumnZero;
                if (Convert.ToInt32(reader.GetString(0)) == 1)
                {
                    someStringFromColumnZero = "Available       ";
                } else
                {
                    someStringFromColumnZero = "Not Available";
                }
                string someStringFromColumnOne = reader.GetString(1);
                searchResults.Add(someStringFromColumnZero + "\t" + someStringFromColumnOne);
            }
            reader.Close();
            errorMessage = "";
            return searchResults;
        }

        public bool VerifyAccount(string username, string password, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
