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
            //Arrange 
            BusinessLogic bll = new BusinessLogic();
            //Act
            List<User> users = bll.GetUsers();
            //Assert
            Assert.IsTrue(users.Count >= 1);
        }
        [TestMethod]
        public void InsertUsers()
        {
            //Arrange 
            BusinessLogic bll = new BusinessLogic();
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
            bll.InsertUser(user);

            //get a list of users
            List<User> getUser = bll.GetUsers();
            //find Carleton
            User Carleton = getUser.Find(m => m.FirstName == user.FirstName);
            //Assert-Carleton is not a null object and in the database
            Assert.IsNotNull(Carleton);
            
        }
    }
}
