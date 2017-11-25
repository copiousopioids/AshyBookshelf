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

        //SQL Statements (Taken from queries.sql)
        private string _itemByGenreSql = "select * from Items i"
                                        + "left outer join Item_Genre ig"
                                        + "on ig.item_id = i.item_id"
                                        + "left outer join Genres g"
                                        + "'on g.genre_id = ig.genre_id"
                                        + "where g.genre like '%genre%';";

        private string _itemByTitle = "select * from Items i where title like '%title%';";

        private string _bookByTitle = "select * from Books b join Items i on i.item_id = b.item_id where title like '%The%';";

        private string _bookByPerson = "select * from Books b"
                                        + "join Items i"
                                        + "on i.item_id = b.item_id"
                                        + "join People_Roles_Items pri"
                                        + "on pri.item_id=i.item_id"
                                        + "join People p"
                                        + "on p.person_id = pri.person_id"
                                        + "where p.first_name like '%Depp%' or p.last_name like '%Depp';";

        private string _bookByGenre =  "select * from Books b"
                                        + "join Items i"
                                        + "on i.item_id = b.item_id"
                                        + "join Item_Genre ig"
                                        + "on ig.item_id = i.item_id"
                                        + "join Genres g"
                                        + "on g.genre_id = ig.genre_id"
                                        + "where g.genre = '%genre%';";

        private string _movieByPerson = "select * from Items i"
                                        + "join People_Roles_Items pri"
                                        + "on pri.item_id = i.item_id"
                                        + "join People p"
                                        + "on p.person_id = pri.person_id"
                                        + "where i.item_id in (select m.item_id from Movies m)"
                                        + "and p.first_name like '%Cameron%' or p.last_name like '%Cameron%';";

        private string _movieByGenre = "select * from Movies m"
                                        + "join Items i"
                                        + "on i.item_id = m.item_id"
                                        + "join Item_Genre ig"
                                        + "on ig.item_id = i.item_id"
                                        + "join Genres g"
                                        + "on g.genre_id = ig.genre_id"
                                        + "where g.genre = %genre%;";


        // Be sure to be on the K-State network or will not be able to connect
        public DatabaseController()
        {
            mysqlConnectionString = "SERVER=mysql.cis.ksu.edu;PORT=3306;DATABASE=zmarcolesco;UID=zmarcolesco;PASSWORD=password;";
            try
            {
                _mysqlConnection = new MySqlConnection();
                _mysqlConnection.ConnectionString = mysqlConnectionString;
                _mysqlConnection.Open();
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
        public bool Insert(string strSQL,string[,] parameterValue)
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
        public int InsertScalarInt(string strSQL,string[,] parameterValue)
        {
            MySqlCommand cmd = new MySqlCommand(strSQL, _mysqlConnection);

            for (int i = 0; i < (parameterValue.Length / 2); i++)
            {
                cmd.Parameters.AddWithValue(parameterValue[i, 0], parameterValue[i, 1]);
            }
            int modified = (int)cmd.ExecuteScalar();
            return modified;
        }

        

        /// <summary>
        /// Adds a book to the database.
        /// 1. Adds book as an Item and gets its ID.
        /// 2. Adds book as a Book with the ID.
        /// 3. Adds contributors to the book/contributors table.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="genre"></param>
        /// <param name="isbn"></param>
        /// <param name="publisher"></param>
        /// <param name="numberOfPages"></param>
        /// <param name="contributors"></param>
        public bool AddBook(string title, string genre, string isbn, string publisher, int numberOfPages, List<Person> contributors)
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

                        foreach (Person p in contributors) {
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
                            { "@genre_id", genre }
                        };

                        //insert item cond and item genre
                        if (!(Insert(igSQL, igValues) && Insert(icSQL, icValues)))
                            throw new Exception("Item not added to igSQL or icValues");

                        //if you get to here, you've inserted successfully into all tables
                        return true;                        
                    }
                    else throw new Exception("Item not added to Book");
                }
                else throw new Exception("Item Not Added to Item");
            } catch
            {
                throw;
            }



        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool AddFine(string username)
        {
            throw new NotImplementedException();
        }

        public bool AddMovie(string title, string description, string genre, string condition, int duration, string barcode, List<Person> contributors)
        {
            throw new NotImplementedException();
        }

        public bool CheckoutItem(ItemTypes itemType, int itemId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string username)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ItemTypes itemType, int itemId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(string username)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(ItemTypes itemType, string searchTitle)
        {
            throw new NotImplementedException();
        }

        public bool PayFine(string username)
        {
            throw new NotImplementedException();
        }

        public bool ReturnItem(ItemTypes itemType, int itemId)
        {
            throw new NotImplementedException();
        }

        public bool VerifyAccount(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
