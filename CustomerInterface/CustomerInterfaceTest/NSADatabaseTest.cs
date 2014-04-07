using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerInterface;
using System.Collections.Generic;

namespace CustomerInterfaceTest
{
    [TestClass]
    public class NSADatabaseTest
    {
        private string server = "54.186.234.139";
        private string name = "nsa_database";
        private string user = "trae";
        private string pass = "";
        private int storeNumber = 1;

        [TestMethod]
        public void Initalizes_WithValid_Parameters()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = database.Connected();

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Cannot connect to " + server + " using nsa_database with user root and no password");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FailsInitialization_WithInvalid_Server()
        {
            //Act
            NSADatabase database = new NSADatabase("FAKE", name, user, pass, storeNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FailsInitialization_WithInvalid_Name()
        {
            //Act
            NSADatabase database = new NSADatabase(server, "FAKE", user, pass, storeNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FailsInitialization_WithInvalid_User()
        {
            //Act
            NSADatabase database = new NSADatabase(server, name, "FAKE", pass, storeNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FailsInitialization_WithInvalid_Pass()
        {
            //Act
            NSADatabase database = new NSADatabase(server, name, user, "FAKE", storeNumber);
        }

        [TestMethod]
        public void CanClose_Connection()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = database.CloseConnection();

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Server is failing to close connection");
        }

        [TestMethod]
        public void Can_Close_Connection()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = database.CloseConnection();

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Server is failing to close connection");
        }

        [TestMethod]
        public void Can_Get_Menu()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = (database.getMenu() is NSAMenuCategory[]);

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Server is failing to close connection");
        }

        [TestMethod]
        public void Can_Get_Menu_Items()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = (database.getMenuItems() is NSAMenuItem[]);

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Server is failing to close connection");
        }

        [TestMethod]
        public void Can_Get_Menu_Categories()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = (database.getCategories() is Dictionary<int, string>);

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Server is failing to close connection");
        }

        [TestMethod]
        public void Can_Get_Components()
        {
            //Arrange
            NSADatabase database = new NSADatabase(server, name, user, pass, storeNumber);

            //Act
            bool actual = (database.getComponents() is NSAComponent[]);

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Server is failing to close connection");
        }
    }
}
