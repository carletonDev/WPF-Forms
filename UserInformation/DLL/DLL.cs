using DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class DataAccess
    {
        private string con = "Data Source=advworkscarl.database.windows.net,1433;Initial Catalog = User; User ID=dev; Password=5611S@ddle;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private string con = ConfigurationManager.ConnectionStrings["Users"].ConnectionString;

        public  void InsertUser(User user)
        {
            using(SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand("InsertUser", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first", user.FirstName);
                    command.Parameters.AddWithValue("@last", user.LastName);
                    command.Parameters.AddWithValue("@dob", user.DOB);
                    command.Parameters.AddWithValue("@city", user.City);
                    command.Parameters.AddWithValue("@st", user.State);
                    command.Parameters.AddWithValue("@zip", user.Zip);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> GetUsers()
        {
            List<User> getUsers = new List<User>();
            using (SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand("GetUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 10;
                    connection.Open();

                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        if (read.HasRows)
                        {

                            while (read.Read())
                            {
                                try
                                {
                                    User user = new User();
                                    if (read["userId"] != DBNull.Value)
                                    {
                                        user.UserId = (int)read["userId"];
                                    }
                                    else { user.UserId = 0; }
                                    if (read["firstName"] != DBNull.Value)
                                    {
                                        user.FirstName = read["firstName"].ToString();
                                    }
                                    else { }
                                    if (read["lastName"] != DBNull.Value)
                                    {
                                        user.LastName = (string)read["lastName"].ToString();
                                    }
                                    else { }
                                    if (read["dob"] != DBNull.Value)
                                    {
                                        user.DOB = (DateTime)read["dob"];
                                    }
                                    else { }
                                    if (read["city"] != DBNull.Value)
                                    {
                                        user.City = (string)read["city"].ToString();
                                    }
                                    else { }
                                    if (read["state"] != DBNull.Value)
                                    {
                                        user.State = (string)read["state"].ToString();
                                    }
                                    else { }
                                    if (read["zip"] != DBNull.Value)
                                    {
                                        user.Zip = (int)read["zip"];
                                    }
                                    else { }
                                    //add to user list
                                    getUsers.Add(user);
                                }
                                catch (Exception Ex)
                                {
                                    Exceptions exception = new Exceptions();
                                    exception.Message = Ex.Message;
                                    StoreExceptions(exception);
                                }
                            }
                        }
                        else
                        {
                            Exceptions exception = new Exceptions();
                            exception.Message = "Reader returned no rows";
                            StoreExceptions(exception);
                        }
                    }
                }
            }
            return getUsers;
        }
        public  List<Exceptions> GetExceptions()
        {
            List<Exceptions> getAll = new List<Exceptions>();
            using (SqlConnection connection = new SqlConnection(con))
            {

                using (SqlCommand command = new SqlCommand("GetExceptions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 10;
                    connection.Open();
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                try
                                {
                                    Exceptions exceptions = new Exceptions();
                                    if (read["exceptionId"] != DBNull.Value)
                                    {
                                        exceptions.ID = (int)read["exceptionId"];
                                    }
                                    else { }
                                    if (read["innerMessage"] != DBNull.Value)
                                    {
                                        exceptions.Message = (string)read["innerMessage"].ToString();
                                    }
                                    else { }
                                    getAll.Add(exceptions);
                                }
                                catch (Exception ex)
                                {
                                    Exceptions exceptions = new Exceptions();
                                    exceptions.Message = ex.Message;
                                    StoreExceptions(exceptions);
                                }
                            }
                        }
                        else
                        {
                            Exceptions exceptions = new Exceptions();
                            exceptions.Message = "Reader Has No Rows";
                            StoreExceptions(exceptions);
                        }
                    }
                }
            }
            return getAll;
        }
        public  void StoreExceptions(Exceptions exception)
        {
            using(SqlConnection connection = new SqlConnection(con))
            {
                using(SqlCommand command = new SqlCommand("StoreExceptions", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mess", exception.Message);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

