using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DatabaseObjects;
namespace BLL
{
    public class BusinessLogic
    {
        public void InsertUser(User user)
        {
            DataAccess.InsertUser(user);
        }
        public List<User> GetUsers()
        {
           return DataAccess.GetUsers();
        }
    }
}
