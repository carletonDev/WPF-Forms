using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System.Collections.Generic;
using DatabaseObjects;

namespace UnitTestTDD
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetUsers()
        {

            Assert.IsTrue(BusinessLogic.GetUsers().Count >= 1);
        }
        [TestMethod]
        public void InsertUsers()
        {
            //Act

            //create a new user
            User user = new User();
            user.FirstName = "Carleton";
            user.LastName = "Cabarrus";
            user.State = "Virginia";
            user.City = "Richmond";
            user.DOB = DateTime.Now;
            user.Zip = 23222;

            //insert new user

            BusinessLogic.InsertUser(user);

           // get a list of users
            List<User> getUser = BusinessLogic.GetUsers();
           // find Carleton
            User Carleton = getUser.Find(m => m.FirstName == user.FirstName);
            //Assert-Carleton is not a null object and in the database
            Assert.IsNotNull(Carleton);

        }
        [TestMethod]
        public void StoreExceptions()
        {
            //Arrange 
            Exceptions exception = new Exceptions();
            //Act
            exception.Message = "Test Message";

            BusinessLogic.StoreExceptions(exception);
            //Assert
        }
    }
}
