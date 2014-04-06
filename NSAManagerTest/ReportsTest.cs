using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using NSA_Manager;

namespace NSATest {

    [TestClass]
    public class ReportsTest {

        private string DBServer = "54.186.234.139";
        private string DBName = "nsa_database";
        private string DBUser = "trae";
        private string DBPassword = "";

        [TestMethod]
        public void TestNumberReportsAvalaible() {
            // arrange
            Reports rept = new Reports(DBServer, DBName, DBUser, DBPassword);
            int expected = 3;

            //act - initalize
            int actual = rept.NumberReportsAvalaible();

            // assert
            Assert.AreEqual(expected, actual, "Unexpected number of reports avaliable.");
        }

        [TestMethod]
        public void TestReports_Report0_Name() {
            // arrange
            Reports rept = new Reports(DBServer, DBName, DBUser, DBPassword);
            string expected = "Sales by Day";

            //act - initalize
            string actual = rept.ReportName(0);

            // assert
            Assert.AreEqual(expected, actual, "Unexpected Report Name.");
        }

        [TestMethod]
        public void TestReports_Report0() {
            // arrange
            Reports rept = new Reports(DBServer, DBName, DBUser, DBPassword);
            rept.AddStore(1);
            bool expected = true;

            //act - initalize
            string report = rept.GenerateReport(0);

            bool actual = report.Contains("<th align=\"center\" colspan=\"4\">Sales By Day</th>");

            // assert
            Assert.AreEqual(expected, actual, "Unexpected Report.");
        }

        [TestMethod]
        public void TestReports_Report1() {
            // arrange
            Reports rept = new Reports(DBServer, DBName, DBUser, DBPassword);
            rept.AddStore(1);
            bool expected = true;

            //act - initalize
            string report = rept.GenerateReport(1);

            bool actual = report.Contains("<th align=\"center\" colspan=\"4\">Sales By Week</th>");

            // assert
            Assert.AreEqual(expected, actual, "Unexpected Report.");
        }

        [TestMethod]
        public void TestReports_Report2() {
            // arrange
            Reports rept = new Reports(DBServer, DBName, DBUser, DBPassword);
            rept.AddStore(1);
            bool expected = true;

            //act - initalize
            string report = rept.GenerateReport(2);

            bool actual = report.Contains("<th align=\"center\" colspan=\"3\">Sales By Month</th>");

            // assert
            Assert.AreEqual(expected, actual, "Unexpected Report.");
        }

    }

}