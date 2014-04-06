using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSA_Corporate_Application;

namespace NSATest {

    [TestClass]
    public class BoxFormatTest {

        [TestMethod]
        public void TestInitializer() {
            // arrange
            CorporateUI.BoxFormat box = new CorporateUI.BoxFormat("Display", "DataID");
            bool expected = true;

            bool actual = (box.displayText == "Display");

            // assert
            Assert.AreEqual(expected, actual, "Box did not initialize correctly");
        }

        [TestMethod]
        public void TestDisplayText() {
            // arrange
            CorporateUI.BoxFormat box = new CorporateUI.BoxFormat("Display", "DataID");
            bool expected = true;

            bool actual = (box.displayText == "Display");

            // assert
            Assert.AreEqual(expected, actual, "Box did not return the correct value.");
        }

        [TestMethod]
        public void TestDatabaseID() {
            // arrange
            CorporateUI.BoxFormat box = new CorporateUI.BoxFormat("Display", "DataID");
            bool expected = true;

            bool actual = (box.databaseID == "DataID");

            // assert
            Assert.AreEqual(expected, actual, "Box did not return the correct value.");
        }





    }

}