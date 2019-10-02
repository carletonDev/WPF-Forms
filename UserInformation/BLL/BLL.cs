using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DatabaseObjects;
namespace BLL
{
    public class BusinessLogic:IBusinessLogic
    {
        private readonly IDataAccess dataAccess;
      public BusinessLogic(IDataAccess access)
        {
            this.dataAccess = access;
        }

        public void InsertUser(User user)
        {
            this.dataAccess.InsertUser(user);
        }

        public List<User> GetUsers()
        {
           return this.dataAccess.GetUsers();
        }

        public List<Exceptions> GetExceptions()
        {
            return this.dataAccess.GetExceptions();
        }

        public void StoreExceptions(Exceptions exception)
        {
            this.dataAccess.StoreExceptions(exception);
        }
    }
}
