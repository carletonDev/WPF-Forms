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
    public static class DataAccess
    {
        private static readonly string con = ConfigurationManager.ConnectionStrings["User"].ConnectionString;

        public static void InsertUser(User user)
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
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<User> GetUsers()
        {
            List<User> getUsers = new List<User>();
            using(SqlConnection connection = new SqlConnection(con))
            {
                using (SqlCommand command = new SqlCommand("GetUsers", connection))
                {
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        if (read.HasRows)
                        {

                            while (read.Read())
                            {
                                try
                                {
                                    User user = new User();
                                    if(read["userId"] != DBNull.Value)
                                    {
                                        user.UserId = Convert.ToInt32(read["userId"]);
                                    }
                                    else { }
                                    if (read["firstName"] != DBNull.Value)
                                    {
                                        user.FirstName = read["firstName"].ToString();
                                    }
                                    else { }
                                    if (read["lastName"] != DBNull.Value)
                                    {
                                        user.LastName = read["lastName"].ToString();
                                    }
                                    else { }
                                    if(read["dob"] != DBNull.Value)
                                    {
                                        user.DOB = Convert.ToDateTime(read["dob"]);
                                    }
                                    else { }
                                    if (read["city"] != DBNull.Value)
                                    {
                                        user.City = read["city"].ToString();
                                    }
                                    else { }
                                    if (read["state"] != DBNull.Value)
                                    {
                                        user.State = read["state"].ToString();
                                    }
                                    else { }
                                    if (read["zip"] != DBNull.Value)
                                    {
                                        user.Zip = Convert.ToInt32(read["zip"]);
                                    }
                                    else { }
                                    //add to user list
                                    getUsers.Add(user);
                                }
                                catch (Exception Ex)
                                {

                                }
                            }
                        }
                        else
                        {
                            Exceptions exception = new Exceptions();
                            exception.Message = "Reader returned no rows";
                        }
                    }
                }
            }
            return getUsers;
        }
    }
}
