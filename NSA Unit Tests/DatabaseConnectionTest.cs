///////////////////////////////////////////////////////////////////////////////
//Module Name:  DatabaseConnectionTest.cs
//Project:      NSA Lobby Application - UNIT TESTs
//Developer:    Trae Watkins
//Last Changes: 3/26/2014 - Trae Watkins
//
//     Class that is used with Visual Studio 2013 to perform units on the 
//     NSADatabase class.
//
///////////////////////////////////////////////////////////////////////////////
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data;
using NSA;

namespace NSATest {

    [TestClass]
    public class DatabaseConnecitonTest {

        //Save the connection info to class private properties.
        private string DBServer = "54.186.234.139";
        private string DBName = "nsa_database";
        private string DBUser = "trae";
        private string DBPassword = "";

        [TestMethod]
        public void TestInitializer_WithParameters() {
            // arrange
            bool loadExpected = true;

            //act - initalize
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);
            
            // assert
            bool actual = NSADB.Connected();
            Assert.AreEqual(loadExpected, actual, "Should be connected bute is not. Server localhost using nsa-database with user root and no password");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidServer() {
            // Act
            NSADatabase NSADB = new NSADatabase("NA", DBName, DBUser, DBPassword, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidDB() {
            // Act
            NSADatabase NSADB = new NSADatabase(DBServer, "BAD-DB", DBUser, DBPassword, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidUser() {
            // Act
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, "BAD-USER", DBPassword, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidPass() {
            // Act
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, "BADPASS", 1);
        }

        [TestMethod]
        public void TestOpenConnection() {
            // arrange
            bool Expected = true;
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);
            NSADB.CloseConnection();

            //act
            bool actual = NSADB.OpenConnection();

            //assert
            Assert.AreEqual(Expected, actual, "Should be connected bute is not. Server localhost using nsa-database with user root and no password");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestOpenConnection_AlreadyOpen_Execption() {
            // arrange
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);
            
            //act
            bool actual = NSADB.OpenConnection();
        }

        [TestMethod]
        public void TestCloseConnection() {
            // arrange
            bool Expected = true;
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);

            //act
            bool actual = NSADB.CloseConnection();

            //Assert
            Assert.AreEqual(Expected, actual, "Should be closed but is not. Server localhost using nsa-database with user root and no password");
        }

        [TestMethod]
        public void TestLobbyOrdersData() {
            // arrange
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);
            List<string>[] data;   //List for data to be in

            //request the Records to display on the lobby window
            int actual = NSADB.LobbyOrdersData(out data);

            //Assert
            Assert.IsTrue(actual >=0, "Should return 0 or more records.");

        }

        [TestMethod]
        public void TestLobbyOrdersData_ClosedConnection() {
            // arrange
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);
            List<string>[] data;   //List for data to be in
            int expected = -1;
            NSADB.CloseConnection();

            //request the Records to display on the lobby window
            int actual = NSADB.LobbyOrdersData(out data);

            //Assert
            Assert.AreEqual(expected, actual, "Should return -1 cause teh DB is closed");
        }

        [TestMethod]
        public void TestCustomQuery() {
            // arrange
            NSADatabase NSADB = new NSADatabase(DBServer, DBName, DBUser, DBPassword, 1);
            string query = "SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA='nsa-database';";
            bool expected = true;
            MySqlDataReader data = NSADB.CustomQuery(query);

            //request the Records to display on the lobby window
            bool actual = data.HasRows;

            //Assert
            Assert.AreEqual(expected, actual, "Should have at least one row.");
        }

    }

}
