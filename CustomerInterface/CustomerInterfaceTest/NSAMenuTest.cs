using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerInterface;
using System.Collections.Generic;

namespace CustomerInterfaceTest
{
    [TestClass]
    public class NSAMenuTest
    {
        [TestMethod]
        public void Component_StoreCorrect_ID()
        {
            //Arrange
            NSAComponent comp = new NSAComponent();
            comp.ComponentID = 3;
            comp.Name = "Swiss";
            comp.Category = "Cheese";

            //Act
            int actual = comp.ComponentID;

            //Assert
            int expected = 3;
            Assert.AreEqual(expected, actual, "Component is not storing ID correctly");
        }

        [TestMethod]
        public void Component_StoresCorrect_Name()
        {
            //Arrange
            NSAComponent comp = new NSAComponent();
            comp.ComponentID = 3;
            comp.Name = "Swiss";
            comp.Category = "Cheese";

            //Act
            string actual = comp.Name;

            //Assert
            string expected = "Swiss";
            Assert.AreEqual(expected, actual, "Component is not storing Name correctly");
        }

        [TestMethod]
        public void Component_StoresCorrect_Category()
        {
            //Arrange
            NSAComponent comp = new NSAComponent();
            comp.ComponentID = 3;
            comp.Name = "Swiss";
            comp.Category = "Cheese";

            //Act
            string actual = comp.Category;

            //Assert
            string expected = "Cheese";
            Assert.AreEqual(expected, actual, "Component is not storing Category correctly");
        }

        [TestMethod]
        public void Component_CanTest_IfEqual()
        {
            //Arrange
            NSAComponent comp = new NSAComponent();
            comp.ComponentID = 3;
            comp.Name = "Swiss";
            comp.Category = "Cheese";

            NSAComponent tester = new NSAComponent();
            tester.ComponentID = 3;
            tester.Name = "American";
            tester.Category = "Cheese";

            //Act
            bool actual = comp.Equals(tester);

            //Assert
            bool expected = true;
            Assert.AreEqual(expected, actual, "Component is not testing if it is equal to another correctly");
        }

        [TestMethod]
        public void Component_CanTest_IfEqualNull()
        {
            //Arrange
            NSAComponent comp = new NSAComponent();
            comp.ComponentID = 3;
            comp.Name = "Swiss";
            comp.Category = "Cheese";

            //Act
            bool actual = comp.Equals(null);

            //Assert
            bool expected = false;
            Assert.AreEqual(expected, actual, "Component is not handling if its equal to null correctly");
        }

        [TestMethod]
        public void Component_ToString_ReturnsName()
        {
            //Arrange
            NSAComponent comp = new NSAComponent();
            comp.ComponentID = 3;
            comp.Name = "Swiss";
            comp.Category = "Cheese";

            //Act
            string actual = comp.ToString();

            //Assert
            string expected = "Swiss";
            Assert.AreEqual(expected, actual, "Component is returning its name with ToString correctly");
        }
    }
}
