using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSCE_4444_Reports_Testing {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            //create report object .. this should be done as a global object of the form so multiple stations can be added on demand.
            Reports rept = new Reports();

            //loop over number reports.
            for (int i = 0; i < rept.NumberReportsAvalaible(); i++) { 
                //add report names to list box
                listReports.Items.Add(rept.ReportName(i));
            }

            listReports.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e) {
            //create instance of report object.
            Reports rept = new Reports(1);

            //Add a second store ID to reports object;
            rept.AddStore(2);

            // generate the report and place it into a Webbrowser window.
            string report = rept.GenerateReport(listReports.SelectedIndex);
            webReport.Navigate("about:blank");
            if (webReport.Document != null) {
                webReport.Document.Write(string.Empty);
            }
            webReport.DocumentText = report;

        }

    }
}
