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

        private string _selectItemsByTitle_sql = "SELECT available, title, i.item_id from Items where title like @param1 ";
        MySqlCommand _selectItemsByTitle;
        private string _selectBooksByTitle_sql = "select available, title, i.item_id from Books b join Items i on i.item_id=b.item_id where i.title like @param1";
        MySqlCommand _selectBooksByTitle;
        private string _selectMoviesByTitle_sql = "select available, title, i.item_id from Movies m join Items i on i.item_id=m.item_id where i.title like @param1";
        MySqlCommand _selectMoviesByTitle;
        private string _selectItemsByGenre_sql = "select available, title, i.item_id from Items i left outer join Item_Genre ig on ig.item_id=i.item_id left outer join Genres g on g.genre_id=ig.genre_id where g.genre like @param1";
        MySqlCommand _selectItemsByGenre;
        private string _selectBooksByGenre_sql = "select available, title, i.item_id from Books b join Items i on i.item_id=b.item_id join Item_Genre ig on ig.item_id=i.item_id join Genres g on g.genre_id=ig.genre_id where g.genre like @param1";
        MySqlCommand _selectBooksByGenre;
        private string _selectMoviesByGenre_sql = "select available, title, i.item_id from Movies m join Items i on i.item_id=m.item_id join Item_Genre ig on ig.item_id=i.item_id join Genres g on g.genre_id = ig.genre_id where g.genre like @param1";
        MySqlCommand _selectMoviesByGenre;
        private string _selectItemsByPerson_sql = "select available, title, i.item_id from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where p.first_name like @name_like or p.last_name like @name_like2";
        MySqlCommand _selectItemsByPerson;
        private string _selectBooksByPerson_sql = "select available, title, i.item_id from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where i.item_id in (select b.item_id from Books b) and p.first_name like @name_like or p.last_name like @name_like2";
        MySqlCommand _selectBooksByPerson;
        private string _selectMoviesByPerson_sql = "select available, title, i.item_id from Items i join People_Roles_Items pri on pri.item_id=i.item_id join People p on p.person_id=pri.person_id where i.item_id in (select m.item_id from Movies m) and p.first_name like @name_like or p.last_name like @name_like2";

        internal List<Object> GetUserItemsCheckedOut(int customerId)
        {
            List<Object> itemsOut = new List<Object>();
            string _selectItemsCheckedOutUser_sql = "select i.item_id, i.title, ci.due_date from Cardholder_Item ci join Items i on i.item_id=ci.item_id where ci.c_id=@custId and i.available=false";
            MySqlCommand _selectItemsCheckedOutUser = new MySqlCommand(_selectItemsCheckedOutUser_sql, _mysqlConnection);
            _selectItemsCheckedOutUser.Parameters.Clear();
            _selectItemsCheckedOutUser.Parameters.AddWithValue("@custId", customerId);
            using (MySqlDataReader reader = _selectItemsCheckedOutUser.ExecuteReader())
            {
                while (reader.Read())
                {
                    //no longer displays due date - will do that from the admin side
                    itemsOut.Add(new Book(null, false, -1, null, reader.GetInt32(0), reader.GetString(1), -1, -1, null, -1, null));
                }
                reader.Close();
                return itemsOut;
            }
        }

        MySqlCommand _selectMoviesByPerson;

        private string _selectItemsUnavailable_sql = "select title from Items where available=false";
        MySqlCommand _selectItemsUnavailable;
        private string _showTotalAmtOwed_sql = "select sum(f.amount) from Fines f join Owes o on o.fine_id=f.fine_id where f.paid=false and o.c_id = @curUser_int";
        MySqlCommand _showTotalAmtOwed;
        private string _showAllFinesForUser_sql = "select f.fine_id, amount, paid, due_date, description from Fines f join Owes o on o.fine_id=f.fine_id where o.c_id=@curUser_int";
        MySqlCommand _showAllFinesForUser;
        private string _searchCardholders_sql = "select * from Cardholders where username like @username_like";
        MySqlCommand _searchCardholders;
        private string _checkUniqueUsername_sql = "SELECT username, c_id FROM Cardholders WHERE username = @username";
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
        private string _selectIndividualFine_sql = "SELECT * FROM Fines WHERE fine_id = @fine_id";
        MySqlCommand _selectIndividualFine;
        private string _selectUsernamePassword_sql = "SELECT * FROM Cardholders WHERE username = @username";
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

        private string _checkItemAvailability_sql = "SELECT * FROM Items WHERE item_id = @item_id";
        MySqlCommand _checkItemAvailability;

        private string _updateAvailabilityCheckedout_sql = "UPDATE Items SET available = 0 WHERE item_id = @item_id";
        MySqlCommand _updateAvailabilityCheckedout;

        private string _listAllCustomers_sql = "SELECT * FROM Cardholders";
        MySqlCommand _listAllCustomers;

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
            _listAllCustomers = new MySqlCommand(_listAllCustomers_sql, _mysqlConnection);

            _checkItemAvailability = new MySqlCommand(_checkItemAvailability_sql, _mysqlConnection);
            _returnItem = new MySqlCommand(_returnItem_sql, _mysqlConnection);
            _selectCheckedOutItem = new MySqlCommand(_selectCheckedOutItem_sql, _mysqlConnection);


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
        public bool Insert(string strSQL, string[,] parameterValue, MySqlTransaction trans)
        {
            MySqlCommand cmd = new MySqlCommand(strSQL, _mysqlConnection);

            for (int i = 0; i < (parameterValue.Length / 2); i++)
            {
                cmd.Parameters.AddWithValue(parameterValue[i, 0], parameterValue[i, 1]);
            }

            cmd.Transaction = trans;

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    throw new Exception("System Error Occurred");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        /// <summary>
        /// Insert statement for queries that use OUTPUT on an integer.
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public int InsertScalarInt(string strSQL, string[,] parameterValue, MySqlTransaction trans)
        {
            MySqlCommand cmd = new MySqlCommand(strSQL, _mysqlConnection);

            for (int i = 0; i < (parameterValue.Length / 2); i++)
            {
                cmd.Parameters.AddWithValue(parameterValue[i, 0], parameterValue[i, 1]);
            }

            cmd.Transaction = trans;

            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return Convert.ToInt32(cmd.LastInsertedId);
                }
                else
                    throw new Exception("System Error Occurred");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Convert.ToInt32(cmd.LastInsertedId);
            }
        }

        public int AddItem(string title, int available, int weekly_fine, int damage_fine)
        {
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            try
            {
                string strSQL = "INSERT INTO Items(title, available, weekly_fine, damage_fine) VALUES (@title, @available, @weekly_fine, @damage_fine);";

                string[,] itemValues = new string[,] {
                                                    { "@title", title },
                                                    { "@available", available.ToString() },
                                                    { "@weekly_fine", weekly_fine.ToString() },
                                                    { "@damage_fine", damage_fine.ToString() }
                                                 };

                int itemID = -1;
                itemID = InsertScalarInt(strSQL, itemValues, trans);

                return itemID;
            } catch (Exception e)
            {
                trans.Rollback();
                Console.WriteLine(e.Message);
                throw;
            }

        }

        //TODO: null object reference when accessing people. Says it inserts but doesn't because of transactions
        public Book AddBook(string title, Genre genre, string isbn, string publisher, int numberOfPages, List<Person> contributors, out bool success, out string errorMessage)
        {
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            try
            {
                int itemID = AddItem(title, 1, 5, 10);
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
                    if (Insert(bookSQL, bookValues, trans))
                    {
                        //add to relational tables
                        //Item_people and People_Roles_Items
                        //string ipSQL = "INSERT INTO (item_id, person_id) VALUES (@item_id, @person_id);";
                        //string[,] ipValues = new string[,]
                        //{
                        //    {"@item_id", itemID.ToString() },
                        //    {"@person_id", "placeholder" }
                        //};

                        string priSQL = "INSERT INTO People_Roles_Items(person_id, role_code, item_id) VALUES (@personID, @role_code, @item_id)";
                        string[,] priValues = new string[,]
                        {
                            { "@personID", "placeholder" },
                            { "@role_code", "placeholder" },
                            { "@item_id", itemID.ToString() }
                        };

                        foreach (Person p in contributors)
                        {
                            //ipValues[1, 1] = p.PersonId.ToString();
                            priValues[0, 1] = p.PersonId.ToString();
                            priValues[1, 1] = p.Role.RoleId.ToString();
                            //if (!(Insert(ipSQL, ipValues, trans) && Insert(priSQL, priValues, trans)))
                            if (!(Insert(priSQL, priValues, trans)))
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
                        if (!(Insert(igSQL, igValues, trans) && Insert(icSQL, icValues, trans)))
                            throw new Exception("Item not added to igSQL or icValues");

                        //if you get to here, you've inserted successfully into all tables
                        errorMessage = "no error";
                        success = true;
                        trans.Commit();
                        //return book here
                        return new Book(new Condition("Brand New", 0), true, 10, genre, itemID, title, 5, Convert.ToInt32(isbn), publisher, numberOfPages, contributors);
                    }
                    else throw new Exception("Item not added to table Book");
                    
                }
                else throw new Exception("Item not added to table Item");
            }
            catch (Exception e)
            {
                success = false;
                trans.Rollback();
                errorMessage = e.Message;
                return null;
            }
        }

        //TODO: same as books above ^
        public Movie AddMovie(string title, string description, Genre genre, int duration, string barcode, List<Person> contributors, out bool success, out string errorMessage)
        {
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            try
            {
                string strSQL = "INSERT INTO Items(title, available, weekly_fine, damage_fine) OUTPUT INSERTED.item_id VALUES (@title, true, 2.0, 10.0);";
                string[,] itemValues = new string[,] { { "@title", title } };
                int itemID = -1;
                itemID = InsertScalarInt(strSQL, itemValues, trans);
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
                    if (Insert(movieSQL, bookValues, trans))
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
                            if (!(Insert(ipSQL, ipValues, trans) && Insert(priSQL, priValues, trans)))
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
                        if (!(Insert(igSQL, igValues, trans) && Insert(icSQL, icValues, trans)))
                            throw new Exception("Item not added to igSQL or icValues");

                        //if you get to here, you've inserted successfully into all tables
                        errorMessage = "no error";
                        success = true;
                        trans.Commit();
                        //return book here
                        return new Movie(new Condition("Brand New", 0), true, 10, genre, itemID, title, 5, Convert.ToInt32(barcode), "disney", duration, description, contributors);
                    }
                    else throw new Exception("Item not added to table Book");

                }
                else throw new Exception("Item not added to table Item");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                success = false;
                errorMessage = "System Error.";
                trans.Rollback();
                throw;
            }
        }

        public Person AddContributor(string firstName, string lastName, string twitterHandle, DateTime dateOfBirth, Role role, List<Award> awards, out bool success, out string errorMessage)
        {
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            try
            {
                string acSQL = "INSERT INTO People(person_id, first_name, last_name, birth_date, death_date, twitter) OUTPUT INSERTED.person_id VALUES (@first_name, @last_name, @birth_date, NULL, @twitter)";
                string[,] peopleValues =
                {
                    { "@first_name", firstName },
                    { "@last_name", lastName },
                    { "@birth_date", dateOfBirth.ToString() },
                    { "@twitter", twitterHandle }
                };

                int contribID = -1;
                contribID = InsertScalarInt(acSQL, peopleValues, trans);
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
                        if (!(Insert(awSQL, awValues, trans)))
                            throw new Exception("Person's Awards not added to awards table");
                    }

                    success = true;
                    errorMessage = "";
                    trans.Commit();
                    // hard code that death date lol
                    return new Person(contribID, firstName, lastName, Convert.ToDateTime(dateOfBirth), twitterHandle, new DateTime(2100, 12, 19), awards, role);
                }
                else throw new Exception("Person not added to People table");
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                success = false;
                errorMessage = "System Error.";
                trans.Rollback();
                throw;
            }
        }

        public bool AddCustomer(string username, string password, string name, string address, string phoneNumber, out string errorMessage)
        {
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            string insertCustomer = "INSERT INTO Cardholders(username, password, phone, name, address) VALUES(@username, @password, @phone, @name, @address)";
            _checkUniqueUsername.Parameters.Clear();
            _checkUniqueUsername.Parameters.AddWithValue("@username", username);
            using (MySqlDataReader rdr = _checkUniqueUsername.ExecuteReader())
            {
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
                    if (Insert(insertCustomer, parameters, trans))
                    {
                        errorMessage = null;
                        trans.Commit();
                        return true;
                    }
                    else
                        throw new Exception("Unknown Error Occurred. Insertion not successful");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    errorMessage = "System Error.";
                    trans.Rollback();
                    return false;
                }
            }
        }

        public Fine AddFine(string username, int amount, out bool result, out string errorMessage)
        {
            string fine_id;
            string c_id;
            string description;
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();

            if (amount == 5)
                description = "Weekly Fine";
            else
                description = "Damage Fine";


            string _insertFine_sql = "INSERT INTO Fines(amount, due_date, paid, description) VALUES(@amount, @due_date, 0, @description)";
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            string[,] parameters =
            {
                {"@amount", amount.ToString() },
                {"@due_date", DateTime.UtcNow.ToString(dateFormat)},
                {"@description", description }
            };

            _checkUniqueUsername.Parameters.Clear();
            _checkUniqueUsername.Parameters.AddWithValue("@username", username);
            using (MySqlDataReader rdr = _checkUniqueUsername.ExecuteReader())
            {
                rdr.Read();
                c_id = rdr["c_id"].ToString();
                rdr.Close();
            }
            fine_id = InsertScalarInt(_insertFine_sql, parameters, trans).ToString();

            if (Int32.Parse(fine_id) == -1)
            {
                errorMessage = "System Error Occurred";
                result = false;
                trans.Rollback();
                return null;
            }

            string _insertFineOwed_sql = "INSERT INTO Owes(c_id, fine_id) VALUES(@c_id, @fine_id)";
            string[,] owedParameters =
            {
                    {"@c_id", c_id},
                    {"@fine_id", fine_id }
                };

            if (Insert(_insertFineOwed_sql, owedParameters, trans))
            {
                result = true;
                errorMessage = null;
                trans.Commit();
                return new Fine(Int32.Parse(fine_id), amount, DateTime.UtcNow, false, "test");
            }
            else
            {
                result = false;
                errorMessage = "System Error";
                trans.Rollback();
                return null;
            }
        }


        //TODO
        public bool CheckoutItem(ItemTypes itemType, Customer loggedInCustomer, int itemId, out string errorMessage)
        {
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            _checkItemAvailability.Parameters.Clear();
            _checkItemAvailability.Parameters.AddWithValue("@item_id", itemId.ToString());
            using (MySqlDataReader rdr = _checkItemAvailability.ExecuteReader())
            {
                if (!rdr.Read())
                {
                    errorMessage = "No Book Found";
                    return false;
                }

                if (Int32.Parse(rdr["available"].ToString()) == 0)
                {
                    errorMessage = "Item already checked out";
                    rdr.Close();
                    return false;
                }

                string insertInCI = "INSERT INTO Cardholder_Item(c_id, item_id, due_date) VALUES(@c_id, @item_id, @due_date)";
                string dateFormat = "yyyy-MM-dd HH:mm:ss";
                string[,] parameters =
                {
                    {"@c_id", loggedInCustomer.CustomerId.ToString() },
                    {"@item_id", itemId.ToString() },
                    {"@due_date", DateTime.Now.AddDays(14).ToString(dateFormat) }
                };

                rdr.Close();

                _updateAvailabilityCheckedout.Parameters.Clear();
                _updateAvailabilityCheckedout.Parameters.AddWithValue("@item_id", itemId);

                if (_updateAvailabilityCheckedout.ExecuteNonQuery() == 0)
                {
                    errorMessage = "System Error Occurred. Please Try Again";
                    trans.Rollback();
                    return false;
                }

                //MySqlCommand cmd = new MySqlCommand(insertInCI, _mysqlConnection);

                //cmd.Transaction = trans;
                //cmd.Parameters.AddWithValue("@c_id", loggedInCustomer.CustomerId);
                //cmd.Parameters.AddWithValue("item_id", itemId);
                //cmd.Parameters.AddWithValue("due_date", DateTime.UtcNow.AddDays(14));



                if (Insert(insertInCI, parameters, trans))
                //if (cmd.ExecuteNonQuery() > 0)
                {
                    errorMessage = null;
                    trans.Commit();
                    return true;
                }
                else
                {
                    errorMessage = "System Error Occurred. Please Try Again";
                    trans.Rollback();
                    return false;
                }
            }
            
        }

        //TODO
        public bool ReturnItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            //If item exsits in cardholder_item, then
            // 1. Remove row from cardholder_item
            // 2. In Items, set available to true
            MySqlTransaction trans = _mysqlConnection.BeginTransaction();
            _selectCheckedOutItem.Parameters.Clear();
            _selectCheckedOutItem.Parameters.AddWithValue("@item_id", itemId);
            using (MySqlDataReader rdr = _selectCheckedOutItem.ExecuteReader())
            {
                try
                {


                    while (rdr.Read())
                    {
                        rdr.Close();
                        string[,] returnItemVal = new string[,]
                        {
                        { "@item_id", itemId.ToString() },
                        { "@item_id_1", itemId.ToString() }
                        };
                        //insert works for update
                        if (Insert(_returnItem_sql, returnItemVal, trans))
                        {
                            errorMessage = "";
                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            errorMessage = "Item not deleted.";
                            trans.Rollback();
                            return false;
                        }
                    }
                    rdr.Close();
                    errorMessage = "Item not checked out.";
                    trans.Rollback();
                    return false;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    errorMessage = "System Error.";
                    rdr.Close();
                    trans.Rollback();
                    return false;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public Customer CheckUserLoginCredentials(string username, string password, out string errorMessage, out bool success)
        {
            _selectUsernamePassword.Parameters.Clear();
            _selectUsernamePassword.Parameters.AddWithValue("@username", username);
            using (MySqlDataReader rdr = _selectUsernamePassword.ExecuteReader())
            {
                try
                {

                    while (rdr.Read())
                    {
                        string un = rdr["username"].ToString();
                        string pass = rdr["password"].ToString();
                        if (pass == password)
                        {
                            errorMessage = "";
                            int customerID = Convert.ToInt32(rdr["c_id"].ToString());
                            string phone = rdr["phone"].ToString();
                            string name = rdr["name"].ToString();
                            string address = rdr["address"].ToString();
                            rdr.Close();
                            success = true;
                            return new Customer(customerID, username, password, name, address, phone, null, null);
                        }
                        else
                        {
                            errorMessage = "Invalid username or password";
                            rdr.Close();
                            success = false;
                            return null;
                        }
                    }
                    rdr.Close();
                    errorMessage = "No user found";
                    success = false;
                    return null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    rdr.Close();
                    throw;
                }
            }
        }

        public bool DeleteCustomer(string username, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _deleteCustomer.Transaction = transaction;
            _deleteCustomer.Parameters.Clear();
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
                Console.WriteLine(e.Message);
                errorMessage = "System Error.";
                transaction.Rollback();
                return false;
            }
        }

        public bool DeleteItem(ItemTypes itemType, int itemId, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _deleteItem.Transaction = transaction;
            _deleteItem.Parameters.Clear();
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
                Console.WriteLine(e.Message);
                errorMessage = "System Error.";
                transaction.Rollback();
                return false;
            }
        }

        public List<Award> GetAllAwards(out bool success, out string errorMessage)
        {
            using (MySqlDataReader rdr = _selectAllAwards.ExecuteReader())
            {
                List<Award> awards = new List<Award>();
                try
                {


                    while (rdr.Read())
                    {
                        awards.Add(new Award((int)rdr["award_id"], (string)rdr["name"], 0));
                    }

                    success = true;
                    errorMessage = "";
                    rdr.Close();
                    return awards;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                    errorMessage = "System Error.";
                    rdr.Close();
                    return null;
                }
            }
        }

        public List<Person> GetAllContributors(out bool success, out string errorMessage)
        {

            using (MySqlDataReader rdr = _selectAllContributors.ExecuteReader())
            {
                List<Person> people = new List<Person>();

                try
                {

                    while (rdr.Read())
                    {
                        people.Add(new Person((int)rdr["person_id"], (string)rdr["first_name"], (string)rdr["last_name"], new DateTime(2100, 12, 19), null, new DateTime(2100, 12, 19), null, null));
                    }

                    success = true;
                    errorMessage = "";
                    rdr.Close();
                    return people;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                    errorMessage = "System Error.";
                    rdr.Close();
                    return null;
                }
            }
        }

        public List<Genre> GetAllGenres(out bool success, out string errorMessage)
        {
            using (MySqlDataReader rdr = _selectAllGenres.ExecuteReader())
            {
                List<Genre> genres = new List<Genre>();
                try
                {


                    while (rdr.Read())
                    {
                        genres.Add(new Genre(rdr["genre"].ToString(), (int)rdr["genre_id"]));
                    }

                    success = true;
                    errorMessage = "";
                    rdr.Close();
                    return genres;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                    errorMessage = "System Error.";
                    rdr.Close();
                    return null;
                }
            }
        }

        public List<Role> GetAllRoles(out bool success, out string errorMessage)
        {
            using (MySqlDataReader rdr = _selectAllRoles.ExecuteReader())
            {
                List<Role> roles = new List<Role>();
                try
                {


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
                    Console.WriteLine(e.Message);
                    success = false;
                    errorMessage = "System Error.";
                    rdr.Close();
                    return null;
                }
            }
        }

        public bool PayFine(string username, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _checkUniqueUsername.Parameters.Clear();
            _checkUniqueUsername.Parameters.AddWithValue("@username", username);
            string c_id;
            string fine_id;
            using (MySqlDataReader rdr = _checkUniqueUsername.ExecuteReader())
            {
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
                    Console.WriteLine(e.Message);
                    errorMessage = "System Error.";
                    rdr.Close();
                    return false;
                }

                rdr.Close();
            }
            using (MySqlDataReader rdr = _selectAllFinesForUser.ExecuteReader())
            {
                _updateFine.Transaction = transaction;
                _deleteFineOwed.Transaction = transaction;

                try
                {
                    while (rdr.Read())
                    {
                        fine_id = rdr["fine_id"].ToString();
                        _updateFine.Parameters.Clear();
                        _updateFine.Parameters.AddWithValue("@fine_id", fine_id);
                        if (_updateFine.ExecuteNonQuery() > 0)
                        {
                            _deleteFineOwed.Parameters.Clear();
                            _deleteFineOwed.Parameters.AddWithValue("@fine_id", fine_id);
                            _deleteFineOwed.ExecuteNonQuery();
                        }
                        else
                            throw new Exception("Fine " + fine_id + " not successfully updated");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
        }

        public bool PayIndividualFine(string username, Fine fine, out string errorMessage)
        {
            MySqlTransaction transaction = _mysqlConnection.BeginTransaction();
            _updateFine.Transaction = transaction;

            try
            {
                _updateFine.Parameters.Clear();
                _updateFine.Parameters.AddWithValue("@fine_id", fine.FineId);
                if (_updateFine.ExecuteNonQuery() > 0)
                {
                    errorMessage = null;
                    transaction.Commit();
                    return true;
                }
                else
                    throw new Exception("Fine " + fine.FineId + " not successfully updated");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                errorMessage = "System Error.";
                transaction.Rollback();
                return false;
            }
        }

        public List<object> searchItems(string searchTitle, ItemSearchOptions searchCriteria, out string errorMessage)
        {
            List<object> searchResults = new List<object>();
            MySqlCommand booksQuery = null;
            MySqlCommand moviesQuery = null;
            errorMessage = null;
            // TODO > Add cases for the title, genre, person item search options that can get passed in (about 9 
            // more if statements. ALSO switch case might be better here.

            switch (searchCriteria) {
                case (ItemSearchOptions.GenreAndBookAndMovie):
                    booksQuery = _selectBooksByGenre;
                    moviesQuery = _selectMoviesByGenre;
                    booksQuery.Parameters.Clear();
                    moviesQuery.Parameters.Clear();
                    moviesQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    booksQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    break;
                case (ItemSearchOptions.PersonAndBookAndMovie):
                    booksQuery = _selectBooksByPerson;
                    moviesQuery = _selectMoviesByPerson;
                    booksQuery.Parameters.Clear();
                    moviesQuery.Parameters.Clear();
                    if (searchTitle.Contains(" "))
                    {
                        string[] firstLast = searchTitle.Split(' ');
                        moviesQuery.Parameters.AddWithValue("@name_like", '%' + firstLast[0] + '%');
                        moviesQuery.Parameters.AddWithValue("@name_like2", '%' + firstLast[1] + '%');
                        booksQuery.Parameters.AddWithValue("@name_like", '%' + firstLast[0] + '%');
                        booksQuery.Parameters.AddWithValue("@name_like2", '%' + firstLast[1] + '%');
                    }
                    else
                    {
                        moviesQuery.Parameters.AddWithValue("@name_like", '%' + searchTitle + '%');
                        moviesQuery.Parameters.AddWithValue("@name_like2", '%' + searchTitle + '%');
                        booksQuery.Parameters.AddWithValue("@name_like", '%' + searchTitle + '%');
                        booksQuery.Parameters.AddWithValue("@name_like2", '%' + searchTitle + '%');
                    }
                    break;
                case (ItemSearchOptions.TitleAndBookAndMovie):
                    booksQuery = _selectBooksByTitle;
                    moviesQuery = _selectMoviesByTitle;
                    booksQuery.Parameters.Clear();
                    moviesQuery.Parameters.Clear();
                    moviesQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    booksQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    break;
                case (ItemSearchOptions.PersonAndBook):
                    booksQuery = _selectBooksByPerson;
                    booksQuery.Parameters.Clear();
                    if (searchTitle.Contains(" "))
                    {
                        string[] firstLast = searchTitle.Split(' ');
                        booksQuery.Parameters.AddWithValue("@name_like", '%' + firstLast[0] + '%');
                        booksQuery.Parameters.AddWithValue("@name_like2", '%' + firstLast[1] + '%');
                    }
                    else
                    {
                        booksQuery.Parameters.AddWithValue("@name_like", '%' + searchTitle + '%');
                        booksQuery.Parameters.AddWithValue("@name_like2", '%' + searchTitle + '%');
                    }
                    break;
                case (ItemSearchOptions.TitleAndBook):
                    booksQuery = _selectBooksByTitle;
                    booksQuery.Parameters.Clear();
                    booksQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    break;
                case (ItemSearchOptions.GenreAndBook):
                    booksQuery = _selectBooksByGenre;
                    booksQuery.Parameters.Clear();
                    booksQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    break;
                case (ItemSearchOptions.GenreAndMovie):
                    moviesQuery = _selectMoviesByGenre;
                    moviesQuery.Parameters.Clear();
                    moviesQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    break;
                case (ItemSearchOptions.TitleAndMovie):
                    moviesQuery = _selectMoviesByTitle;
                    moviesQuery.Parameters.Clear();
                    moviesQuery.Parameters.AddWithValue("@param1", '%' + searchTitle + '%');
                    break;
                case (ItemSearchOptions.PersonAndMovie):
                    moviesQuery = _selectMoviesByPerson;
                    moviesQuery.Parameters.Clear();
                    if (searchTitle.Contains(" "))
                    {
                        string[] firstLast = searchTitle.Split(' ');
                        moviesQuery.Parameters.AddWithValue("@name_like", '%' + firstLast[0] + '%');
                        moviesQuery.Parameters.AddWithValue("@name_like2", '%' + firstLast[1] + '%');
                    }
                    else
                    {
                        moviesQuery.Parameters.AddWithValue("@name_like", '%' + searchTitle + '%');
                        moviesQuery.Parameters.AddWithValue("@name_like2", '%' + searchTitle + '%');
                    } 
                    break;
                default:
                    errorMessage = "System error";
                    return searchResults;
            }

            if (moviesQuery != null) {
                var reader = moviesQuery.ExecuteReader();
                while (reader.Read()) {
                    string someStringFromColumnOne = reader.GetString(1);
                    searchResults.Add(new Movie(new Condition("Brand New", 1), (reader.GetString(0) == "1") ? true : false, 10, new Genre("Uknown", 1), Convert.ToInt32(reader.GetString(2)), someStringFromColumnOne, 5, 0, "", 0,"", null));
                }
                reader.Close();
                errorMessage = null;
            }

            if (booksQuery != null)
            {
                var reader = booksQuery.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnOne = reader.GetString(1);
                    searchResults.Add(new Book(new Condition("Brand New", 1), (reader.GetString(0) == "1") ? true : false, 10, new Genre("Uknown", 1), Convert.ToInt32(reader.GetString(2)), someStringFromColumnOne, 5, 0, "", 0, null));
                }
                reader.Close();
                errorMessage = null;
            }
            return searchResults;
        }

        public int getTotalAmtOwed(int customerId)
        {
            int balance = -1;
            _showTotalAmtOwed.Parameters.Clear();
            _showTotalAmtOwed.Parameters.AddWithValue("@curUser_int", customerId);
            using (MySqlDataReader reader = _showTotalAmtOwed.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        balance = reader.GetInt32(0);
                    }
                    else
                    {
                        balance = 0;
                    }
                }
                else
                {
                    balance = 0;
                }
                reader.Close();
            }
            return balance;
        }

        public List<object> getFines(int CustomerId)
        {
            List<object> list = new List<object>();
            _showAllFinesForUser.Parameters.Clear();
            _showAllFinesForUser.Parameters.AddWithValue("@curUser_int", CustomerId);
            using (MySqlDataReader reader = _showAllFinesForUser.ExecuteReader())
            {
                while (reader.Read())
                {
                    //amt paid due_date description
                    bool paid;
                    if (Convert.ToInt32(reader.GetString(2)) == 1)
                    {
                        paid = true;
                    }
                    else
                    {
                        paid = false;
                    }
                    // TODO: GUI says outstanding fines, would like it to say just "Fines"
                    if (!paid)
                        list.Add(new Fine(Convert.ToInt32(reader.GetString(0)), Convert.ToInt32(reader.GetString(1)), Convert.ToDateTime(reader.GetString(3)), paid, reader.GetString(4)));
                }
                reader.Close();
                return list;
            }
        }

        public List<Customer> GetCustomer(string username, out bool success, out string errorMessage)
        {
            List<Customer> customers = new List<Customer>();
            _searchCardholders.Parameters.Clear();
            _searchCardholders.Parameters.AddWithValue("@username_like", '%' + username + '%');
            using (MySqlDataReader reader = _searchCardholders.ExecuteReader())
            {
                while (reader.Read())
                {
                    customers.Add(new Customer(Convert.ToInt32(reader["c_id"].ToString()), reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["address"].ToString(), reader["phone"].ToString(), null, null));
                }
                reader.Close();
                success = true;
                errorMessage = "";
                return customers;
            }
        }

        public List<Customer> GetAllCustomers(out bool success, out string errorMessage)
        {
            List<Customer> customers = new List<Customer>();
            using (MySqlDataReader reader = _listAllCustomers.ExecuteReader())
            {
                while (reader.Read())
                {
                    customers.Add(new Customer(Convert.ToInt32(reader["c_id"].ToString()), reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["address"].ToString(), reader["phone"].ToString(), null, null));
                }
                reader.Close();
                success = true;
                errorMessage = "";
                return customers;
            }
        }

        public List<string> GetItemDetails(Item selectedItem, ItemType itemType)
        {
            throw new NotImplementedException();
        }
    }
}
