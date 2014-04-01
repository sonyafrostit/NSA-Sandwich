///////////////////////////////////////////////////////////////////////////////
//Module Name:  Reports.cs
//Project:      NSA Applications - Reports Object
//Developer:    Trae Watkins
//Last Changes: 3/31/2014 - Trae Watkins
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
//      2014/03/31  Changed the namespace to NSA
//          
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data;

namespace NSA{
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

            switch (reportid) {
                case ReportIDs.SalesByWeek:
                    return SalesByWeek();
                case ReportIDs.SalesByMonth:
                    return SalesByMonth();
                case ReportIDs.SalesByDay:
                    return SalesByDay();
                default:
                    return "Report requested is undefined.";
            }

        }

        //Sales by week will generate a HTML formatted report int the form of a string.
        // We will use the NSADatabase Class to retrieve the Data.
        // The Table will be in the following format
        // ┌──────────────────────────┐
        // |      Sales By WeeK       |
        // ├──────────────────────────┤
        // |Store - #                 |
        // ├──────────────────────────|
        // │Week│Date│Num Orders│Sales│
        // ├────┼────┼──────────┼─────┤
        // └────┴────┴──────────┴─────┘
        private string SalesByWeek() {

            //Stringbuilder for creating the Query to use to get the sales data.
            StringBuilder ByWeekQuery = new StringBuilder();
            
            //for readability the query is built via multiple appends rather than a single one.
            ByWeekQuery.Append("SELECT storeid, weekofyear(O.timeplaced) as Week, ");
            ByWeekQuery.Append("STR_TO_DATE(CONCAT(CONCAT( DATE_FORMAT(O.timeplaced,'%Y'), ");
            ByWeekQuery.Append("weekofyear(O.timeplaced) ),' Monday'), '%X%V %W') as WeekDate, ");
            ByWeekQuery.Append("sum(O.total) as Sales, sum(O.tax) as SalesTax, count(orderid) as Orders, refunded ");
            ByWeekQuery.Append("FROM Orders O WHERE O.refunded = 0 AND storeid IN (");

            //loop over all the stations in the list execpt for the last one adding them 
            //to the set of numbers for the in clause
	        for (int i = 0; i < (Stores.Count-1); i++) // Loop through List with for
	        {
                ByWeekQuery.Append(Stores[i].ToString());
                ByWeekQuery.Append(",");
	        }

            //adding the last store to the In clause
            ByWeekQuery.Append(Stores[(Stores.Count - 1)].ToString());

            //add the end of the query
            ByWeekQuery.Append(") GROUP BY storeid , Week, refunded;");
            
            //StringBuilder object.
            StringBuilder ByWeekReport = new StringBuilder();

            //Create and Open the Database Connection.
            NSADatabase DBConnection = new NSADatabase("localhost","nsa-database","root","",1);
     
            //Create Data reader object using the built query with the database object.
            MySqlDataReader ByWeekData = DBConnection.CustomQuery(ByWeekQuery.ToString());

            //Append the top portion of the report again done in multiple appends for readability.
            ByWeekReport.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\"><html><head><title>NSASALES - By Week</title></head>");
            ByWeekReport.Append("<body><table width=\"100%\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" summary=\"Sales By Week\" w>");
            ByWeekReport.Append("<thead><th align=\"center\" colspan=\"4\">Sales By Week</th></thead>");

            int storeid = 0;

            //Read the data and Build the HTML File.
            while (ByWeekData.Read()) {
                //if we hit a new store we need to enter the store Id and header lines.
                if (storeid != (int)ByWeekData["storeid"]) {
                    storeid = (int)ByWeekData["storeid"];
                    ByWeekReport.Append("<tr><th align=\"left\" colspan=\"4\">Store: ");
                    ByWeekReport.Append(storeid.ToString());
                    ByWeekReport.Append("</th></tr>");
                    ByWeekReport.Append("<tr><th>Week</th><th>Date</th><th>Orders per Week</th><th>Sales in dollars Per Week</th></tr>");
                }

                //Add the weeks data row to the report.
                ByWeekReport.Append("<tr><td align=\"center\">");
                ByWeekReport.Append(ByWeekData["Week"]);
                ByWeekReport.Append("</td><td align=\"center\">");
                ByWeekReport.Append(string.Format("{0:MM/dd/yyyy}",ByWeekData["WeekDate"]));
                ByWeekReport.Append("</td><td align=\"center\">");
                ByWeekReport.Append(ByWeekData["Orders"]);
                ByWeekReport.Append("</td><td align=\"center\">");
                ByWeekReport.Append(String.Format("{0:C}", ByWeekData["Sales"]));
                ByWeekReport.Append("</td></tr>");
            }

            //add the closing tags for the report.
            ByWeekReport.Append("</table></body></html>");


            //must remember to close the reader
            ByWeekData.Close();

            //Close the connection
            DBConnection.CloseConnection();

            //return the built report to the calling function.
            return ByWeekReport.ToString();
        }

        //Sales by week will generate a HTML formatted report int the form of a string.
        // We will use the NSADatabase Class to retrieve the Data.
        // The Table will be in the following format
        // ┌───────────────────────────┐
        // |      Sales By Month       |
        // ├───────────────────────────┤
        // |Store - #                  |
        // ├───────────────────────────|
        // │Month│ Num Orders    │Sales│
        // ├─────┼───────────────┼─────┤
        // └─────┴───────────────┴─────┘
        private string SalesByMonth() {

            //Stringbuilder for creating the Query to use to get the sales data.
            StringBuilder ByMonthQuery = new StringBuilder();

            //for readability the query is built via multiple appends rather than a single one.
            ByMonthQuery.Append("SELECT storeid, month(O.timeplaced) as Month, ");
            ByMonthQuery.Append("sum(O.total) as Sales, count(orderid) as Orders, refunded ");
            ByMonthQuery.Append("FROM Orders O WHERE O.refunded = 0 AND storeid IN (");

            //loop over all the stations in the list execpt for the last one adding them 
            //to the set of numbers for the in clause
            for (int i = 0; i < (Stores.Count - 1); i++) // Loop through List with for
	        {
                ByMonthQuery.Append(Stores[i].ToString());
                ByMonthQuery.Append(",");
            }

            //adding the last store to the In clause
            ByMonthQuery.Append(Stores[(Stores.Count - 1)].ToString());

            //add the end of the query
            ByMonthQuery.Append(") GROUP BY storeid , Month;");

            //StringBuilder object.
            StringBuilder ByMonthReport = new StringBuilder();

            //Create and Open the Database Connection.
            NSADatabase DBConnection = new NSADatabase("localhost", "nsa-database", "root", "", 1);

            //Create Data reader object using the built query with the database object.
            MySqlDataReader ByMonthData = DBConnection.CustomQuery(ByMonthQuery.ToString());

            //Append the top portion of the report again done in multiple appends for readability.
            ByMonthReport.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\"><html><head><title>NSASALES - By Month</title></head>");
            ByMonthReport.Append("<body><table width=\"100%\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" summary=\"Sales By Month\" w>");
            ByMonthReport.Append("<thead><th align=\"center\" colspan=\"3\">Sales By Month</th></thead>");

            int storeid = 0;


            //Read the data and Build the HTML File.
            while (ByMonthData.Read()) {
                //if we hit a new store we need to enter the store Id and header lines.
                if (storeid != (int)ByMonthData["storeid"]) {
                    storeid = (int)ByMonthData["storeid"];
                    ByMonthReport.Append("<tr><th align=\"left\" colspan=\"3\">Store: ");
                    ByMonthReport.Append(storeid.ToString());
                    ByMonthReport.Append("</th></tr>");
                    ByMonthReport.Append("<tr><th>Month</th><th>Orders per Month</th><th>Sales in dollars Per Month</th></tr>");
                }

                //Add the weeks data row to the report.
                ByMonthReport.Append("<tr><td align=\"center\">");
                ByMonthReport.Append(Month((int)ByMonthData["Month"]));
                ByMonthReport.Append("</td><td align=\"center\">");
                ByMonthReport.Append(ByMonthData["Orders"]);
                ByMonthReport.Append("</td><td align=\"center\">");
                ByMonthReport.Append(String.Format("{0:C}", ByMonthData["Sales"]));
                ByMonthReport.Append("</td></tr>");
            }

            //add the closing tags for the report.
            ByMonthReport.Append("</table></body></html>");

            //must remember to close the reader
            ByMonthData.Close();

            //Close the connection
            DBConnection.CloseConnection();

            //return the built report to the calling function.
            return ByMonthReport.ToString();
        }

        //Sales by week will generate a HTML formatted report int the form of a string.
        // We will use the NSADatabase Class to retrieve the Data.
        // The Table will be in the following format
        // ┌───────────────────────────┐
        // |      Sales By Day         |
        // ├───────────────────────────┤
        // |Store - #                  |
        // ├───────────────────────────|
        // │Day  │Date│Num Orders│Sales│
        // ├─────┼────┼──────────┼─────┤
        // └─────┴────┴──────────┴─────┘
        private string SalesByDay() {

            //Stringbuilder for creating the Query to use to get the sales data.
            StringBuilder ByDayQuery = new StringBuilder();

            //for readability the query is built via multiple appends rather than a single one.
            ByDayQuery.Append("SELECT storeid, month(O.timeplaced) as Month, day(O.timeplaced) as Day, ");
            ByDayQuery.Append("WEEKDAY(O.timeplaced) as DayOfWeek, DATE_FORMAT(O.timeplaced, '%m/%d/%Y') as Date, ");
            ByDayQuery.Append("sum(O.total) as Sales, count(orderid) as Orders, refunded ");
            ByDayQuery.Append("FROM Orders O WHERE O.refunded = 0 AND storeid IN (");

            //loop over all the stations in the list execpt for the last one adding them 
            //to the set of numbers for the in clause
            for (int i = 0; i < (Stores.Count - 1); i++) // Loop through List with for
	        {
                ByDayQuery.Append(Stores[i].ToString());
                ByDayQuery.Append(",");
            }

            //adding the last store to the In clause
            ByDayQuery.Append(Stores[(Stores.Count - 1)].ToString());

            //add the end of the query
            ByDayQuery.Append(") GROUP BY storeid , Day;");

            //StringBuilder object.
            StringBuilder ByDayReport = new StringBuilder();

            //Create and Open the Database Connection.
            NSADatabase DBConnection = new NSADatabase("localhost", "nsa-database", "root", "", 1);

            //Create Data reader object using the built query with the database object.
            MySqlDataReader ByDayData = DBConnection.CustomQuery(ByDayQuery.ToString());

            //Append the top portion of the report again done in multiple appends for readability.
            ByDayReport.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\"><html><head><title>NSASALES - By Day</title></head>");
            ByDayReport.Append("<body><table width=\"100%\" border=\"1\" cellpadding=\"0\" cellspacing=\"0\" summary=\"Sales By Day\" w>");
            ByDayReport.Append("<thead><th align=\"center\" colspan=\"4\">Sales By Day</th></thead>");

            //There is not a store it < 0
            int storeid = -1;

            //Read the data and Build the HTML File.
            while (ByDayData.Read()) {
                //if we hit a new store we need to enter the store Id and header lines.
                if (storeid != (int)ByDayData["storeid"]) {
                    storeid = (int)ByDayData["storeid"];
                    ByDayReport.Append("<tr><th align=\"left\" colspan=\"4\">Store: ");
                    ByDayReport.Append(storeid.ToString());
                    ByDayReport.Append("</th></tr>");
                    ByDayReport.Append("<tr><th>Date</th><th>Day</th><th>Orders per Day</th><th>Sales in Dollars per Day</th></tr>");
                }

                //Add the weeks data row to the report.
                ByDayReport.Append("<tr><td align=\"center\">");
                ByDayReport.Append(string.Format("{0:MM/dd/yyyy}", ByDayData["Date"]));
                ByDayReport.Append("</td><td align=\"center\">");
                ByDayReport.Append(DayofWeek((int)ByDayData["DayOfWeek"]));
                ByDayReport.Append("</td><td align=\"center\">");
                ByDayReport.Append(ByDayData["Orders"]);
                ByDayReport.Append("</td><td align=\"center\">");
                ByDayReport.Append(String.Format("{0:C}", ByDayData["Sales"]));
                ByDayReport.Append("</td></tr>");
            }

            //add the closing tags for the report.
            ByDayReport.Append("</table></body></html>");

            //must remember to close the reader
            ByDayData.Close();

            //Close the connection
            DBConnection.CloseConnection();

            //return the built report to the calling function.
            return ByDayReport.ToString();
        }

        //Return the Month name by the ID 
        //  0..11 (Jan .. Dec) if OneBased = 0  
        //  1..12 (Jan .. Dec) if OneBased = 1 
        private string Month(int id, int OneBased = 0) {

            switch (id + OneBased) {
                case 0:
                    return "January";
                case 1:
                    return "Feburuary";
                case 2:
                    return "March";
                case 3:
                    return "April";
                case 4:
                    return "May";
                case 5:
                    return "June";
                case 6:
                    return "July";
                case 7:
                    return "August";
                case 8:
                    return "September";
                case 9:
                    return "October";
                case 10:
                    return "November";
                case 11:
                    return "December";
                default:
                    return "NA";
            }
        }

        //return they day week based on the ID 0 .. 6 (Mon .. Sun)
        private string DayofWeek(int id) {

            switch (id) {
                case 0:
                    return "Monday";
                case 1:
                    return "Tuesday";
                case 2:
                    return "Wednesday";
                case 3:
                    return "Thursday";
                case 4:
                    return "Friday";
                case 5:
                    return "Saturday";
                case 6:
                    return "Sunday";
                default:
                    return "NA";
            }
        }
    }
}
