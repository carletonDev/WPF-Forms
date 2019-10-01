using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DatabaseObjects;
namespace BLL
{
    public static class BusinessLogic
    {
        public static void InsertUser(User user)
        {
            DataAccess data = new DataAccess();
            data.InsertUser(user);
        }
        public static List<User> GetUsers()
        {
            DataAccess data = new DataAccess();
            return data.GetUsers();
        }
        public static void StoreExceptions(Exceptions exception)
        {
            DataAccess data = new DataAccess();
            data.StoreExceptions(exception);
        }
    }
}
