using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using NSA_Corporate_Application;

namespace NSATest {

    [TestClass]
    public class CorporateDataTest {

        private string DBServer = "54.186.234.139";
        private string DBName = "nsa_database";
        private string DBUser = "trae";
        private string DBPassword = "";

        [TestMethod]
        public void TestInitializer_WithParameters() {
            // arrange
            bool loadExpected = true;

            //act - initalize
            CorporateData CorpData = new CorporateData(DBServer, DBName, DBUser, DBPassword);

            // assert
            bool actual = CorpData.Connected();
            Assert.AreEqual(loadExpected, actual, "Should be connected bute is not. Server " + DBServer + " using nsa-database with user root and no password");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidServer() {
            // Act
            CorporateData CorpData = new CorporateData("Bad Server", DBName, DBUser, DBPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidDB() {
            // Act
            CorporateData NSADB = new CorporateData(DBServer, "BAD-DB", DBUser, DBPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidUser() {
            // Act
            CorporateData NSADB = new CorporateData(DBServer, DBName, "BAD-USER", DBPassword);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInitializer_WithParameters_InvalidPass() {
            // Act
            CorporateData NSADB = new CorporateData(DBServer, DBName, DBUser, "BADPASS");
        }

        [TestMethod]
        public void TestStoresData() {
            // arrange
            CorporateData CorpData = new CorporateData(DBServer, DBName, DBUser, DBPassword);
            List<string>[] Stores;
            int StoresCount = -1;
            bool expected = true;

            //Act
            StoresCount = CorpData.StoresData(out Stores);

            //Assert
            bool actual = StoresCount>0;
            Assert.AreEqual(expected, actual, "Number of stores is not expected");

        }

        [TestMethod]
        public void TestCorporateSaveManagerAccount() {
            // arrange
            CorporateData CorpData = new CorporateData(DBServer, DBName, DBUser, DBPassword);
            bool expected = true;

            //Act
            bool actual = CorpData.CorporateSaveManagerAccount("SAm", "Test", "STest", "123", "1");

            //Assert
            Assert.AreEqual(expected, actual, "Manager could not be saved");

        }

        [TestMethod]
        public void TestDeleteManager() {
            // arrange
            CorporateData CorpData = new CorporateData(DBServer, DBName, DBUser, DBPassword);
            bool expected = true;

            //Act
            CorpData.CorporateSaveManagerAccount("SAm", "Test", "STest", "123", "1");
            bool actual = CorpData.CorporatDeleteManagerAccount("STest");

            //Assert
            Assert.AreEqual(expected, actual, "Manager conld not be Deleted");

        }

    }
}
