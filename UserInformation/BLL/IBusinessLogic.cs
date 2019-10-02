using DatabaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public interface IBusinessLogic
    {
        void InsertUser(User user);

        List<User> GetUsers();

        List<Exceptions> GetExceptions();

        void StoreExceptions(Exceptions exception);
    }
}
