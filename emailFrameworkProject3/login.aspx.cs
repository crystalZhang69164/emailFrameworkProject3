using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

using System.Data;
using emailLibrary;

namespace emailFrameworkProject3
{
    public partial class login1 : System.Web.UI.Page
    {
        DBConnect dbConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //string accType = Session["ddlAccType"].ToString();
            

            
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
       


            Response.Redirect("signUp.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtEmail.Text;
            string password = txtPassword.Text;
            string sql = "SELECT * FROM Users";
            //gets the data set
            DataSet myData = dbConnect.GetDataSet(sql);
            DataTable myDataTable = myData.Tables[0];

            //SqlCommand objCommand = new SqlCommand();

            //objCommand.CommandType = CommandType.StoredProcedure;
            ////identifies which stored procedure to use
            //objCommand.CommandText = "GetRecord";


            //objCommand.Parameters.AddWithValue("@username", username);
            //objCommand.Parameters.AddWithValue("@password", password);



            if (validInput() == true)
            {

                //stores the value of txtEmail into  the obj userEmail so that other pages can get that value
                Session["userEmail"] = txtEmail.Text;
                //traverses the row in the data table
                for (int row = 0; row < myDataTable.Rows.Count; row++)
                {
                    //traverse the rows
                    DataRow userDataRow = myDataTable.Rows[row];
                    //if username and password matches in the data base
                    if (username == userDataRow["email"].ToString() && password == userDataRow["password"].ToString())
                    {
                        //if the acc type is of type user
                        if (userDataRow["type"].ToString() == "User")
                        {
                            Response.Redirect("userEmail.aspx");
                        }
                        else
                        {
                            //else the acc type is admin
                            //redirect to admin page
                            Response.Redirect("adminPage.aspx");
                        }
                    }

                }
                //else the acc is not in the database
                Response.Write("Account does not exists");
                


            }
           

        }

       
        //checks if the txt boxes are blank
        protected bool validInput()
        {
            
            //if there are no email in the txt box
            if (txtEmail.Text == "")
            {
                Response.Write("Please enter a valid email");
                return false;
            }
            else if (txtPassword.Text == "")
            {
                Response.Write("Please enter a valid password");
                return false;
            }
           

            return true;
        }
        
    }
}