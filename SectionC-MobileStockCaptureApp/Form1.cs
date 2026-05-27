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
            // TC04 Fix: Check for empty fields
            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtMake.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                lblOutput.Text = "Error: All fields are required.";
                return;
            }

            // TC05 Fix: Check if Quantity is a valid number to prevent crashes
            if (!int.TryParse(txtQuantity.Text, out int qty))
            {
                lblOutput.Text = "Error: Quantity must be a valid number.";
                return;
            }

            tblMobilePhones.Rows.Add(txtCode.Text, txtMake.Text, qty);
            lblOutput.Text = "Record Added";
        }

        //Q1.2.2 - Delete the selected record from the DataTable when the "Delete" button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Validation: Check if the Mobile Code field is empty before trying to delete
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                lblOutput.Text = "Error: Please enter a Mobile Code to delete.";
                return;
            }

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
                //TC02 Fix: Display correct message after deletion and clear input fields
                lblOutput.Text = "Record Deleted";
                txtCode.Clear();
                txtMake.Clear();
                txtQuantity.Clear();

            }
            else
            {
                lblOutput.Text = "Record Not found.";
            }
        }

        //Q1.2.3 - Find and display the record with the specified Mobile Code when the "Find" button is clicked
        private void btnFind_Click(object sender, EventArgs e)
        {
            //Validation: Check if the Mobile Code field is empty before trying to find
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                lblOutput.Text = "Error: Please enter a Mobile Code to search.";
                return;
            }

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
                //TC03 Fix: Display correct message after finding a record
                lblOutput.Text = "Record Found";
            }
            else
            {
                lblOutput.Text = "Record NOT Found";
                txtMake.Clear();
                txtQuantity.Clear();
            }
        }
    }
}
