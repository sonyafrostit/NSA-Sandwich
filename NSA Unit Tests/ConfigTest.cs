///////////////////////////////////////////////////////////////////////////////
//Module Name:  ConfigTest.cs
//Project:      NSA Lobby Application - UNIT TESTs
//Developer:    Trae Watkins
//Last Changes: 3/26/2014 - Trae Watkins
//
//     Class that is used with Visual Studio 2013 to perform units on the 
//     AppConfig class.
//
///////////////////////////////////////////////////////////////////////////////
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSA;

namespace NSATest {
    [TestClass]
    public class ConfigTest {
        [TestMethod]
        public void ConfigTest_TestInitializer() {
            // arrange
            bool loadExpected = false;

            //act - initalize
            AppConfig ApplicationConfig = new AppConfig();

            // act

            // assert
            bool actual = ApplicationConfig.IsLoaded;
            Assert.AreEqual(loadExpected, actual,"AppConfig is listed as loaded but shouldnt be.");
        }

        [TestMethod]
        public void TestInitializer_WithFile() {
            // arrange
            bool loadExpected = true;
            string filename = "NSAConfig.xml";

            //act - initalize
            AppConfig ApplicationConfig = new AppConfig(filename);

            // act

            // assert
            bool actual = ApplicationConfig.IsLoaded;
            Assert.AreEqual(loadExpected, actual, "AppConfig is listed as loaded but shouldnt be.");
        }

        [TestMethod]
        public void TestLoad() {
            // arrange
            bool loadExpected = true;
            string filename = "NSAConfig.xml";

            //act - initalize
            AppConfig ApplicationConfig = new AppConfig(filename);

            // act

            // assert
            bool actual = ApplicationConfig.IsLoaded;
            Assert.AreEqual(loadExpected, actual, "AppConfig is listed as loaded but shouldnt be.");
        }
        
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLoad_NoFileSpecified_GererateExecption() {
            // arrange

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.Load();
        }

        [TestMethod]
        public void TestLoad_Valid_File() {
            // arrange
            bool loadExpected = true;
            string filename = "NSAConfig.xml";

            //act
            AppConfig ApplicationConfig = new AppConfig();
            bool actual = ApplicationConfig.Load(filename);

            // assert
            Assert.AreEqual(loadExpected, actual, "AppConfig Did not load correctly.");

        } 

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestLoad_Empty_File_GererateExecption() {
            // arrange
            string filename = "";

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.Load(filename);
        }

        [TestMethod]
        public void Test_Property_DatabaseServer() {
            // arrange
            string Expected = "UnitTest";

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.DatabaseServer = "UnitTest";

            string actual = ApplicationConfig.DatabaseServer;
            // assert
            Assert.AreEqual(Expected, actual, "AppConfig Did not load correctly.");

        }

        [TestMethod]
        public void Test_Property_DatabaseName() {
            // arrange
            string Expected = "UnitTest";

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.DatabaseName = "UnitTest";

            string actual = ApplicationConfig.DatabaseName;
            // assert
            Assert.AreEqual(Expected, actual, "AppConfig Did not load correctly.");
        }

        [TestMethod]
        public void Test_Property_DatabaseUserName() {
            // arrange
            string Expected = "UnitTest";

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.DatabaseUserName = "UnitTest";

            string actual = ApplicationConfig.DatabaseUserName;
            // assert
            Assert.AreEqual(Expected, actual, "AppConfig Did not load correctly.");
        }

        [TestMethod]
        public void Test_Property_DatabasePassword() {
            // arrange
            string Expected = "UnitTest";

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.DatabasePassword = "UnitTest";

            string actual = ApplicationConfig.DatabasePassword;
            // assert
            Assert.AreEqual(Expected, actual, "AppConfig Did not load correctly.");
        }

        [TestMethod]
        public void Test_Property_StoreNumber() {
            // arrange
            int Expected = 9999;

            //act
            AppConfig ApplicationConfig = new AppConfig();
            ApplicationConfig.StoreNumber = 9999;

            int actual = ApplicationConfig.StoreNumber;
            // assert
            Assert.AreEqual(Expected, actual, "AppConfig Did not load correctly.");
        }

    }
}
