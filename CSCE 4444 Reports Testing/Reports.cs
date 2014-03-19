///////////////////////////////////////////////////////////////////////////////
//Module Name:  DatabaseConnection.cs
//Project:      NSA Applications - Reports Object
//Developer:    Trae Watkins
//Last Changes: 3/19/2014 - Trae Watkins
//
//     This is a Report generation class for our project for CSCE4444
//
//     This class is used to generate the reports that are avaliable to the 
//     program.
//
//     Currently this class will only generate 3 reports
//          SalesByDay - 
//          SalesByWeek - 
//          SalesByMonth - 
//
//      These will be generated according accorsing to the choice made and for
//          allof the stores that have been added.
//
//      To use this class:
//          NumberReportsAvalaible() - returns the number of reports
//          ReportName (ReportID) - returns the name of report with ID ReportID
//          AddStore(StoreID) - add a store ID
//          NumberStores() - Shows the number of stores added.
//          GenerateReport (ReportID) - generates and returns the report 
//              with ID ReportID. A store must have been added.
//          
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCE_4444_Reports_Testing {
    class Reports {

        //Ids of the various reports avaliable
        public enum ReportIDs {
            SalesByDay,
            SalesByWeek,
            SalesByMonth,
            NumberReports
        }

        //the names of the reports that are avaliable
        private string[] ReportNames = { "Sales by Day", "Sales by Week", "Sales by Month" };

        //storage for a list of stores
        private List<int> Stores;

        //Default construcor
        public Reports() {
            //create instance of the list of stores 
            Stores = new List<int>();

        }

        //Constructor that will initialize the Class ith the station ID passed in
        public Reports(int storeid) {
            //create instance of the list of stores 
            Stores = new List<int>();
            //Add the store
            Stores.Add(storeid);
        }

        //Add stores to the reports to be generated
        public void AddStore(int storeid) {
            if (storeid > 0) {
                Stores.Add(storeid);
            } else {
                throw new Exception("Invalid store ID, Store ID must be greater than 0.");
            }
            
        }

        //How many stores have been added
        public int NumberStores() {
            return Stores.Count();
        }

        //Clear all stores from the Report generator.
        public void ClearStores() {
            Stores.Clear();
        }

        //Return the number of reports that are avaliable 
        public int NumberReportsAvalaible() {
            return (int)ReportIDs.NumberReports;
        }

        //return the name of the report at the given ID 
        public string ReportName(ReportIDs idrequested) {
            return ReportNames[(int)idrequested];
        }

        //return the name of the report at the given ID 
        public string ReportName(int idrequested) {
            if ((idrequested >= 0) && (idrequested < (int)ReportIDs.NumberReports)) {
                return ReportNames[(int)idrequested];
            } else {
                throw new Exception("Index out of Range.");
            }
        }

        //Public method to access the creation of the requested report 
        public string GenerateReport(int reportidrequested) {
            //check to see if the requested report ID is in the correct range
            if ((reportidrequested >= 0) && (reportidrequested < (int)ReportIDs.NumberReports)) {
                return CreateReport((ReportIDs)reportidrequested);
            } else {
                throw new Exception("Index out of Range.");
            }
        }

        //Public method to access the creation of the requested report  
        public string GenerateReport(ReportIDs reportidrequested) {
            return CreateReport(reportidrequested);
        }

        //Generate the preport requested and return a string taht is the report.
        private string CreateReport(ReportIDs reportid) {

            if (Stores.Count() > 0) {
                StringBuilder SB = new StringBuilder("Report has not been created yet for ");
                SB.AppendLine(ReportNames[(int)reportid]);

                SB.AppendLine("Stores:");
                for (int i = 0; i < Stores.Count(); i++) {
                    SB.AppendLine("  " + Stores[i].ToString());
                }
                return SB.ToString();

            } else {
                throw new Exception("No stations have been added.");
            }
        }
    }
}
