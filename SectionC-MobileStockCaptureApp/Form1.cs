using System;
using System.Data;
using System.Windows.Forms;

namespace SectionC_MobileStockCaptureApp
{
    public partial class Form1 : Form
    {
        DataTable tblMobilePhones = new DataTable();

        public Form1()
        {
            InitializeComponent();

            tblMobilePhones.Columns.Add("MobileCode", typeof(string));
            tblMobilePhones.Columns.Add("Make", typeof(string));
            tblMobilePhones.Columns.Add("Quantity", typeof(int));
        }

        //Q1.2.1 - Add a new record to the DataTable when the "Add" button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            tblMobilePhones.Rows.Add(txtCode.Text, txtMake.Text, Convert.ToInt32(txtQuantity.Text));
            lblOutput.Text = "Record Added";
        }

        //Q1.2.2 - Delete the selected record from the DataTable when the "Delete" button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool isFound = false;

            for (int i = tblMobilePhones.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = tblMobilePhones.Rows[i];
                if (row["MobileCode"].ToString() == txtCode.Text)
                {
                    row.Delete();
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                lblOutput.Text = "Record Found";

            }
            else
            {
                lblOutput.Text = "Record Not found.";
            }
        }

        //Q1.2.3 - Find and display the record with the specified Mobile Code when the "Find" button is clicked
        private void btnFind_Click(object sender, EventArgs e)
        {
            bool isFound = false;

            foreach (DataRow row in tblMobilePhones.Rows)
            {
                if (row["MobileCode"].ToString() == txtCode.Text)
                {
                    txtMake.Text = row["Make"].ToString();
                    txtQuantity.Text = row["Quantity"].ToString();
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                lblOutput.Text = "Record Deleted";
            }
            else
            {
                lblOutput.Text = "Record NOT Found";
            }
        }
    }
}
