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
        private string _selectItemsByGenre_sql = "select available, title from Items i left outer join Item_Genre ig on ig.item_id=i.item_id left outer join Genres g on g.genre_id=ig.genre_id where g.genre like @genre_like";
        MySqlCommand _selectItemsByGenre;
        private string _selectBooksByGenre_sql = "select available, title from Books b join Items i on i.item_id=b.item_id join Item_Genre ig on ig.item_id=i.item_id join Genres g on g.genre_id=ig.genre_id where g.genre like @genre_like";
        MySqlCommand _selectBooksByGenre;
        private string _selectMoviesByGenre_sql = "select available, title from Movies m join Items i on i.item_id=m.item_id join Item_Genre ig on ig.item_id=i.item_id join Genres g on g.genre_id = ig.genre_id where g.genre like @genre_like";
        MySqlCommand _selectMoviesByGenre;
        private string _selectItemsByPerson_sql = "select available, title from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where p.first_name like @name_like or p.last_name like @name_like2";
        MySqlCommand _selectItemsByPerson;
        private string _selectBooksByPerson_sql = "select available, title from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where i.item_id in (select b.item_id from Books b) and p.first_name like @name_like or p.last_name like @name_like2";
        MySqlCommand _selectBooksByPerson;
        private string _selectMoviesByPerson_sql = "select available, title from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where i.item_id in (select m.item_id from Movies m) and p.first_name like @name_like or p.last_name like @name_like2";
        MySqlCommand _selectMoviesByPerson;

        private string _selectItemsUnavailable_sql = "select title from Items where available=false";
        MySqlCommand _selectItemsUnavailable;
        private string _showTotalAmtOwed_sql = "select sum(f.amount) from Fines f join Owes o on o.fine_id=f.fine_id where f.paid=false and o.c_id = @curUser_int";
        MySqlCommand _showTotalAmtOwed;
        private string _showAllFinesForUser_sql = "select amount, paid, due_date, description from Fines f join Owes o on o.fine_id=f.fine_id where o.c_id=@curUser_int";
        MySqlCommand _showAllFinesForUser;
        private string _searchCardholders_sql = "select username, name, c_id from Cardholders where username like @username_like";
        MySqlCommand _searchCardholders;
        private string _checkUniqueUsername_sql = "SELECT username FROM Cardholders WHERE username = @username";
        MySqlCommand _checkUniqueUsername;
        private string _deleteCustomer_sql = "DELETE FROM Cardholders WHERE username = @username";
        MySqlCommand _deleteCustomer;
        private string _deleteItem_sql = "DELETE FROM Items WHERE item_id = @item_id";
        MySqlCommand _deleteItem;
        private string _updateFine_sql = "UPDATE Fines SET paid = 1 WHERE fine_id = @fine_id";
        MySqlCommand _updateFine;
        private string _deleteFineOwed_sql = "DELETE FROM Owes WHERE fine_id = @fine_id";
        MySqlCommand _deleteFineOwed;
        private string _selectAllFinesForUser_sql = "SELECT fine_id FROM Owes WHERE c_id = @c_id";
        MySqlCommand _selectAllFinesForUser;
        private string _selectIndividualFine_sql = "SELET fine_id FROM Owes WHERE fine_id = @fine_id";
        MySqlCommand _selectIndividualFine;
        private string _selectUsernamePassword_sql = "SELECT username, password FROM Cardholders WHERE username = @username";
        MySqlCommand _selectUsernamePassword;

        private string _selectAllAwards_sql = "SELECT award_id, name FROM Awards";
        MySqlCommand _selectAllAwards;

        private string _selectAllGenres_sql = "SELECT genre_id, genre FROM Genres";
        MySqlCommand _selectAllGenres;

        private string _selectAllRoles_sql = "SELECT role_code, role FROM Roles";
        MySqlCommand _selectAllRoles;

        private string _selectAllContributors_sql = "SELECT person_id, first_name, last_name, birth_date, death_date, twitter FROM People";
        MySqlCommand _selectAllContributors;

        private string _selectCheckedOutItem_sql = "SELECT item_id FROM Cardholder_Item WHERE item_id = @item_id";
        MySqlCommand _selectCheckedOutItem;

        private string _returnItem_sql = "UPDATE Items SET available = 1 WHERE item_id = @item_id;" +
                                         "DELETE FROM Cardholder_Item WHERE item_id = @item_id_1";
        MySqlCommand _returnItem;

        private string _setAvailable_sql = "begin update Items set available = status where item_id = @item_id; return true; end";
        MySqlCommand _setAvailable;

        private string _deleteFromCI_sql = "begin delete from Cardholder_Item where item_id = @item_id; return true; end";
        MySqlCommand _deleteFromCI;

        private string _checkItemAvailability_sql = "SELECT available FROM Items WHERE item_id = @item_id";
        MySqlCommand _checkItemAvailability;

        private string _updateAvailabilityCheckedout_sql = "UPDATE Items SET available = 0 WHERE item_id = @item_id";
        MySqlCommand _updateAvailabilityCheckedout;

        private void PrepareStatements()
        {
            _selectItemsByTitle = new MySqlCommand(_selectItemsByTitle_sql, _mysqlConnection);
            _selectBooksByTitle = new MySqlCommand(_selectBooksByTitle_sql, _mysqlConnection);
            _selectMoviesByTitle = new MySqlCommand(_selectMoviesByTitle_sql, _mysqlConnection);
            _selectItemsByGenre = new MySqlCommand(_selectItemsByGenre_sql, _mysqlConnection);
            _selectBooksByGenre = new MySqlCommand(_selectBooksByGenre_sql, _mysqlConnection);
            _selectMoviesByGenre = new MySqlCommand(_selectMoviesByGenre_sql, _mysqlConnection);
            _selectItemsByPerson = new MySqlCommand(_selectItemsByPerson_sql, _mysqlConnection);
            _selectBooksByPerson = new MySqlCommand(_selectBooksByPerson_sql, _mysqlConnection);
            _selectMoviesByPerson = new MySqlCommand(_selectMoviesByPerson_sql, _mysqlConnection);

            _selectItemsUnavailable = new MySqlCommand(_selectItemsUnavailable_sql, _mysqlConnection);
            _showTotalAmtOwed = new MySqlCommand(_showTotalAmtOwed_sql, _mysqlConnection);
            _showAllFinesForUser = new MySqlCommand(_showAllFinesForUser_sql, _mysqlConnection);
            _searchCardholders = new MySqlCommand(_searchCardholders_sql, _mysqlConnection);
            _checkUniqueUsername = new MySqlCommand(_checkUniqueUsername_sql, _mysqlConnection);
            _deleteCustomer = new MySqlCommand(_deleteCustomer_sql, _mysqlConnection);
            _deleteItem = new MySqlCommand(_deleteItem_sql, _mysqlConnection);
            _updateFine = new MySqlCommand(_updateFine_sql, _mysqlConnection);
            _selectAllFinesForUser = new MySqlCommand(_selectAllFinesForUser_sql, _mysqlConnection);
            _deleteFineOwed = new MySqlCommand(_deleteFineOwed_sql, _mysqlConnection);
            _selectIndividualFine = new MySqlCommand(_selectIndividualFine_sql, _mysqlConnection);

            _selectUsernamePassword = new MySqlCommand(_selectUsernamePassword_sql, _mysqlConnection);
            _selectAllAwards = new MySqlCommand(_selectAllAwards_sql, _mysqlConnection);
            _selectAllContributors = new MySqlCommand(_selectAllContributors_sql, _mysqlConnection);
            _selectAllGenres = new MySqlCommand(_selectAllGenres_sql, _mysqlConnection);
            _selectAllRoles = new MySqlCommand(_selectAllRoles_sql, _mysqlConnection);


            _setAvailable = new MySqlCommand(_setAvailable_sql, _mysqlConnection);
            _deleteCustomer = new MySqlCommand(_deleteCustomer_sql, _mysqlConnection);
            _updateAvailabilityCheckedout = new MySqlCommand(_updateAvailabilityCheckedout_sql, _mysqlConnection);


            _returnItem = new MySqlCommand(_returnItem_sql, _mysqlConnection);


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

            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            cmd.Transaction = trans;

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    trans.Commit();
                    return true;
                }
                else
                    throw new Exception("System Error Occurred");
            }
            catch (Exception e)
            {
                trans.Rollback();
                return false;
            }

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


            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            cmd.Transaction = trans;

            int modified = -1;
            try
            {
                modified = (int)cmd.ExecuteScalar();
                if (modified != -1)
                {
                    trans.Commit();
                    return modified;
                }
                else
                    throw new Exception("System Error Occurred");
            }
            catch(Exception e)
            {
                trans.Rollback();
                return modified;
            }
        }


        //TODO: Transactions
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
                        {"@item_id", itemID.ToString()  }, //No idea if this'll work but i use it extensively lol
                        {"@num_pages", numberOfPages.ToString() },
                        {"@publisher", publisher },
                        {"@isbn", isbn }
                    };
                    if (Insert(bookSQL, bookValues))
                    {
                        //add to relational tables
                        //Item_people and People_Roles_Items
                        string ipSQL = "INSERT INTO (item_id, person_id) VALUES (@item_id, @person_id);";
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
                errorMessage = "System Error.";
                throw;
            }
        }

        //TODO: Transactions
        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage)
        {
            try
            {
                string strSQL = "INSERT INTO Items(title, available, weekly_fine, damage_fine) OUTPUT INSERTED.item_id VALUES (@title, true, 2.0, 10.0);";
                string[,] itemValues = new string[,] { { "@title", title } };
                int itemID = -1;
                itemID = InsertScalarInt(strSQL, itemValues);
                if (itemID > 0)
                {
                    string movieSQL = "INSERT INTO Movies(item_id, description, duration, studio, barcode_no) VALUES (@item_id, @description, @duration, @studio, @barcode_no);";
                    string[,] bookValues = new string[,]
                    {
                        {"@item_id", itemID.ToString()  }, //No idea if this'll work but i use it extensively lol
                        {"@description", description },
                        {"@duration", duration.ToString() },
                        {"@studio", "disney" },
                        { "@barcode_no", barcode }
                    };
                    if (Insert(movieSQL, bookValues))
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
                        return new Movie(new Condition("Brand New", 0), true, 10, genre, itemID, title, 2, Convert.ToInt32(barcode), "disney", duration, description, contributors);
                    }
                    else throw new Exception("Item not added to table Book");

                }
                else throw new Exception("Item not added to table Item");
            }
            catch (Exception e)
            {
                success = false;
                errorMessage = "System Error.";
                throw;
            }
        }

        //TODO: Transactions
        public Person AddContributor(string firstName, string lastName, string twitterHandle, string dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage)
        {
            try
            {
                string acSQL = "INSERT INTO People(person_id, first_name, last_name, birth_date, death_date, twitter) OUTPUT INSERTED.person_id VALUES (@first_name, @last_name, @birth_date, NULL, @twitter)";
                string[,] peopleValues =
                {
                    { "@first_name", firstName },
                    { "@last_name", lastName },
                    { "@birth_date", dateOfBirth },
                    { "@twitter", twitterHandle }
                };

                int contribID = -1;
                contribID = InsertScalarInt(acSQL, peopleValues);
                if (contribID > 0)
                {
                    //Add to Awards_Won table
                    string awSQL = "INSERT INTO Awards_Won(person_id, award_id, year_won) VALUES (@person_id, @award_id, @year_won)";
                    string[,] awValues =
                    {
                        { "@person_id", contribID.ToString() },
                        { "@award_id", "placeholder" },
                        { "@year_won", "placeholder" }
                    };

                    foreach (Award a in awards)
                    {
                        awValues[1, 1] = a.AwardId.ToString();
                        awValues[2, 1] = a.Year.ToString();
                        if (!(Insert(awSQL, awValues)))
                            throw new Exception("Person's Awards not added to awards table");
                    }

                    success = true;
                    errorMessage = "";
                    // hard code that death date lol
                    return new Person(contribID, firstName, lastName, Convert.ToDateTime(dateOfBirth), twitterHandle, new DateTime(2100, 12, 19), awards, role);
                }
                else throw new Exception("Person not added to People table");
            } catch(Exception e)
            {
                success = false;
                errorMessage = "System Error.";
                throw;
            }
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage)
        {
            string insertCustomer = "INSERT INTO Cardholders(username, password, phone, name, address) VALUES(@username, @password, @phone, @name, @address)";
            _checkUniqueUsername.Parameters.AddWithValue("@username", username);
            MySqlDataReader rdr = _checkUniqueUsername.ExecuteReader();
            if (rdr.Read())
            {
                errorMessage = "Username already taken";
                rdr.Close();
                return false;
            }
            rdr.Close();
            string[,] parameters =
            {
                {"@username", username },
                {"@password", password },
                {"@phone", phoneNumber },
                {"@name", name },
                {"@address", address }
            };

            try
            {
                if (Insert(insertCustomer, parameters))
                {
                    errorMessage = null;
                    return true;
                }
                else
                    throw new Exception("Unknown Error Occurred. Insertion not successful");
            }
            catch (Exception e)
            {
                errorMessage = "System Error.";
                return false;
            }
        }

        public Fine AddFine(string username, int amount, out bool result, out string errorMessage)
        {
            string fine_id;
            string c_id;
            string _insertFine_sql = "INSERT INTO Fines(amount, due_date, paid, description) OUTPUT Inserted.fine_id VALUES(@amount, @due_date, @paid, @description)";
            string[,] parameters =
            {
                {"@amount", amount.ToString() },
                {"@due_date", DateTime.UtcNow.ToString()},
                {"@paid", 0.ToString() },
                {"@description", "test" }
            };

            _checkUniqueUsername.Parameters.AddWithValue("@username", username);
            MySqlDataReader rdr = _checkUniqueUsername.ExecuteReader();
            rdr.Read();
            c_id = rdr["c_id"].ToString();
            fine_id = InsertScalarInt(_insertFine_sql, parameters).ToString();
            rdr.Close();

            if (Int32.Parse(fine_id) == -1)
            {
                errorMessage = "System Error Occurred";
                result = false;
                return null;
            }

            string _insertFineOwed_sql = "INSERT INTO Owes(c_id, fine_id) VALUES(@c_id, @fine_id)";
            string[,] owedParameters =
            {
                {"@c_id", c_id},
                {"@fine_id", fine_id }
            };

            if (Insert(_insertFineOwed_sql, owedParameters))
            {
                result = true;
                errorMessage = null;
                return new Fine(Int32.Parse(fine_id), amount, DateTime.UtcNow, false, "test");
            }
            else
            {
                result = false;
                errorMessage = null;
                return null;
            }
        }


        //TODO
        public bool CheckoutItem(ItemTypes itemType, Customer loggedInCustomer, int itemId, out string errorMessage)
        {
            _checkItemAvailability.Parameters.AddWithValue("@item_id", itemId);
            MySqlDataReader rdr = _checkItemAvailability.ExecuteReader();

            if(Int32.Parse(rdr["item_id"].ToString())==0)
            {
                errorMessage = "Item already checked out";
                return false;
            }

            string insertInCI = "INSERT INTO Cardholders_Items(c_id, item_id, due_date) VALUES(@c_id, @item_id, @due_date)";
            string[,] parameters =
            {
                {"@c_id", loggedInCustomer.CustomerId.ToString() },
                {"@item_id", itemId.ToString() },
                {"@due_date", DateTime.UtcNow.AddDays(14).ToString() }
            };

            rdr.Close();
            if (_updateAvailabilityCheckedout.ExecuteNonQuery() == 0)
            {
                errorMessage = "System Error Occurred. Please Try Again";
                return false;
            }

            if(Insert(insertInCI, parameters))
            {
                errorMessage = null;
                return true;
            }
            else
            {
                errorMessage = "System Error Occurred. Please Try Again";
                return false;
            }
            
        }

        //TODO
        public bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            //If item exsits in cardholder_item, then
            // 1. Remove row from cardholder_item
            // 2. In Items, set available to true
            try
            {
                _selectCheckedOutItem.Parameters.AddWithValue("@item_id", itemId);
                MySqlDataReader rdr = _selectCheckedOutItem.ExecuteReader();

                while (rdr.Read())
                {
                    string[,] returnItemVal = new string[,]
                    {
                        { "@item_id", itemId.ToString() },
                        { "@item_id_1", itemId.ToString() }
                    };
                    //insert works for update
                    if (Insert(_returnItem_sql, returnItemVal))
                    {
                        errorMessage = "";
                        return true;
                    }
                    else
                    {
                        errorMessage = "Item not deleted.";
                        return false;
                    }
                }

                errorMessage = "Item not checked out.";
                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                errorMessage = "System Error.";
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public bool CheckUserLoginCredentials(string username, string password, out string errorMessage)
        {
            try
            {
                _selectUsernamePassword.Parameters.AddWithValue("@username", username);
                MySqlDataReader rdr = _selectUsernamePassword.ExecuteReader();
                while (rdr.Read())
                {
                    string un = rdr["username"].ToString();
                    if (rdr["password"].ToString() == password)
                    {
                        errorMessage = "";
                        rdr.Close();
                        return true;
                    }
                    else
                    {
                        errorMessage = "Invalid username or password";
                        rdr.Close();
                        return false;
                    }
                }

                errorMessage = "No user found";
                return false;
                
            } catch (Exception e)
            {
                throw;
            }
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(string username, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _deleteCustomer.Transaction = transaction;
            _deleteCustomer.Parameters.AddWithValue("@username", username);
            try
            {
                if (_deleteCustomer.ExecuteNonQuery() > 0)
                {
                    errorMessage = null;
                    transaction.Commit();
                    return true;
                }
                else
                    throw new Exception("Unknown Error Occurred. Deletion not successful");
            }
            catch (Exception e)
            {
                errorMessage = "System Error.";
                transaction.Rollback();
                return false;
            }
        }

        public bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _deleteItem.Transaction = transaction;
            _deleteItem.Parameters.AddWithValue("@item_id", itemId);
            try
            {
                if (_deleteItem.ExecuteNonQuery() > 0)
                {
                    errorMessage = null;
                    transaction.Commit();
                    return true;
                }
                else
                    throw new Exception("Unknown Error Occurred. Deletion not successful");
            }
            catch (Exception e)
            {
                errorMessage = "System Error.";
                transaction.Rollback();
                return false;
            }
        }

        public List<Award> GetAllAwards(out bool success, out string errorMessage)
        {
            try
            {
                MySqlDataReader rdr = _selectAllAwards.ExecuteReader();
                List<Award> awards = new List<Award>();

                while (rdr.Read())
                {
                    awards.Add(new Award((int)rdr["award_id"], (string)rdr["name"], 0));
                }

                success = true;
                errorMessage = "";
                rdr.Close();
                return awards;
            } catch (Exception e)
            {
                success = false;
                errorMessage = "System Error.";
                return null;
            }
        }

        public List<Person> GetAllContributors(out bool success, out string errorMessage)
        {



            try
            {
                MySqlDataReader rdr = _selectAllContributors.ExecuteReader();
                List<Person> people = new List<Person>();
                 while (rdr.Read())
                {
                    people.Add(new Person((int)rdr["person_id"], (string)rdr["first_name"], (string)rdr["last_name"], new DateTime(2100, 12, 19), null, new DateTime(2100, 12, 19), null, null));
                }

                success = true;
                errorMessage = "";
                rdr.Close();
                return people;
            } catch (Exception e)
            {
                success = false;
                errorMessage = "System Error.";
                return null;
            }
        }

        public List<Genre> GetAllGenres(out bool success, out string errorMessage)
        {
            try
            {
                MySqlDataReader rdr = _selectAllGenres.ExecuteReader();
                List<Genre> genres = new List<Genre>();

                while (rdr.Read())
                {
                    genres.Add(new Genre(rdr["name"].ToString(), (int)rdr["genre_id"]));
                }

                success = true;
                errorMessage = "";
                rdr.Close();
                return genres;
                
            } catch (Exception e)
            {
                success = false;
                errorMessage = "System Error.";
                return null;
            }
        }

        public List<Role> GetAllRoles(out bool success, out string errorMessage)
        {
            try
            {
                MySqlDataReader rdr = _selectAllRoles.ExecuteReader();
                List<Role> roles = new List<Role>();

                while (rdr.Read())
                {
                    roles.Add(new Role((int)rdr["role_id"], (string)rdr["role_id"]));
                }

                success = true;
                errorMessage = "";
                rdr.Close();
                return roles;

            }
            catch (Exception e)
            {
                success = false;
                errorMessage = "System Error.";
                return null;
            }
        }

        public bool PayFine(string username, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _checkUniqueUsername.Parameters.AddWithValue("@username", username);
            MySqlDataReader rdr = _checkUniqueUsername.ExecuteReader();
            string c_id;
            string fine_id;

            try
            {
                if (rdr.Read())
                {
                    c_id = rdr["c_id"].ToString();
                }
                else
                    throw new Exception("User not found");
            }
            catch (Exception e)
            {
                errorMessage = "System Error.";
                rdr.Close();
                return false;
            }

            rdr.Close();
            rdr = _selectAllFinesForUser.ExecuteReader();
            _updateFine.Transaction = transaction;
            _deleteFineOwed.Transaction = transaction;

            try
            {
               while(rdr.Read())
               {
                    fine_id = rdr["fine_id"].ToString();
                    _updateFine.Parameters.AddWithValue("@fine_id", fine_id);
                    if (_updateFine.ExecuteNonQuery() > 0)
                    {
                        _deleteFineOwed.Parameters.AddWithValue("@fine_id", fine_id);
                        _deleteFineOwed.ExecuteNonQuery();
                    }
                    else
                        throw new Exception("Fine " + fine_id + " not successfully updated");
               }
            }
            catch(Exception e)
            {
                errorMessage = "System Error.";
                transaction.Rollback();
                rdr.Close();
                return false;
            }

            rdr.Close();
            errorMessage = null;
            transaction.Commit();
            return true;     
        }

        public bool PayIndividualFine(string username, Fine fine, out string errorMessage)
        {
            _selectIndividualFine.Parameters.AddWithValue("@fine_id", fine.FineId);
            MySqlDataReader rdr = _selectIndividualFine.ExecuteReader();
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _updateFine.Transaction = transaction;
            _deleteCustomer.Transaction = transaction;

            try
            {
                _updateFine.Parameters.AddWithValue("@fine_id", fine.FineId);
                if (_updateFine.ExecuteNonQuery() > 0)
                {
                    _deleteFineOwed.Parameters.AddWithValue("@fine_id", fine.FineId);
                    _deleteFineOwed.ExecuteNonQuery();
                }
                else
                    throw new Exception("Fine " + fine.FineId + " not successfully updated");
            }
            catch (Exception e)
            {
                errorMessage = "System Error.";
                transaction.Rollback();
                rdr.Close();
                return false;
            }

            errorMessage = null;
            transaction.Commit();
            rdr.Close();
            return true;
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

        public int getTotalAmtOwed(int customerId)
        {
            int balance = -1;
            _showTotalAmtOwed.Parameters.Clear();
            _showTotalAmtOwed.Parameters.AddWithValue("@curUser_int", customerId);
            var reader = _showTotalAmtOwed.ExecuteReader();
            reader.Read();
            balance = Convert.ToInt32(reader.GetString(0));
            return balance;
        }

        public List<object> getFines(int CustomerId)
        {
            List<object> list = new List<object>();
            _showAllFinesForUser.Parameters.Clear();
            _showAllFinesForUser.Parameters.AddWithValue("@curUser_int", CustomerId);
            var reader = _showAllFinesForUser.ExecuteReader();
            while (reader.Read())
            {
                //amt paid due_date description
                bool paid;
                if (Convert.ToInt32(reader.GetString(1)) ==1)
                {
                    paid = true;
                } else
                {
                    paid = false;
                }
                // TODO: GUI says outstanding fines, would like it to say just "Fines"
                list.Add(new Fine(-1, Convert.ToInt32(reader.GetString(0)), Convert.ToDateTime(reader.GetString(2)), paid, reader.GetString(3)));
            }
            reader.Close();
            return list;
        }
        public List<Customer> GetCustomer(string username, out bool success, out string errorMessage)
        {
            List<Customer> customers = new List<Customer>();
            _searchCardholders.Parameters.Clear();
            _searchCardholders.Parameters.AddWithValue("@username_like", '%' + username + '%');
            var reader = _searchCardholders.ExecuteReader();
            while (reader.Read())
            {
                //returns username, name, c_id
                customers.Add(new Customer(Convert.ToInt32(reader.GetString(2)), reader.GetString(0), null, reader.GetString(1), null, null, null, null));
            }
            reader.Close();
            success = true;
            errorMessage = "";
            return customers;
        }
    }
}
