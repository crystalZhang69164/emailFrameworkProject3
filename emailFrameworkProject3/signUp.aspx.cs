using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using emailLibrary;
using System.Data;
using System.Data.SqlClient;


namespace emailFrameworkProject3
{
    public partial class login : System.Web.UI.Page
    {
        DBConnect dbConnect = new DBConnect();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //DBConnect dbConnect = new DBConnect();
            //DataSet myData = new DataSet();

            
        }

        //validates input
        public bool validInput()
        {
            if (txtName.Text != "" && txtStreet.Text != "" && txtState.Text != ""
                && txtZipCode.Text != "" && txtPhoneNumber.Text != "" && txtPassword.Text != ""
                && txtContactEmail.Text != "" && ddlType.Text != "Select Account Type" && radioImage != null)
            {
                return true;

            }
            //if not a valid input
            Response.Write("Please fill in all textboxes");
            return false;
        }

        //incomplete
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {

            SqlCommand objCommand = new SqlCommand();
            

            string sql = "SELECT * FROM Users";
            //gets the data set
            DataSet myData = dbConnect.GetDataSet(sql);
            //gets the first table from the dataset that we got using the sql string
            //Tables[0] gets the first data table, since there is only 1 table the table is the users table
            DataTable myDataTable = myData.Tables[0];
            bool accIsUnique = true;


            if (validInput() == true)
            {
                //gets the image value url from the wfc using request
                string image = Request["image"].ToString();
                string username = txtEmailUsername.Text;
                string password = txtPassword.Text;

                for (int row = 0; row < myDataTable.Rows.Count; row++)
                {
                    DataRow userDataRow = myDataTable.Rows[row];
                    //if username and password matches in the data base
                    if (username == userDataRow["email"].ToString() && password == userDataRow["password"].ToString())
                    {
                        
                        accIsUnique = false;
                        //return;
                    }

      
                }
                //if acc username and password is not in the database
                if (accIsUnique == true)
                {
                    //creates the acc
                    emailLibrary.User.createAcc(txtEmailUsername.Text, txtPassword.Text, txtContactEmail.Text, txtPhoneNumber.Text, txtStreet.Text,
                    txtZipCode.Text, txtCity.Text, image, "active", ddlType.Text);

                    Response.Redirect("login.aspx");
                }
                else
                {
                    Response.Write("Account already exists in the database");
                }
                
                

                
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}