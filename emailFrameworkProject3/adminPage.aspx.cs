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
    public partial class adminPage : System.Web.UI.Page
    {

        DBConnect dbConnect = new DBConnect();
        SqlCommand objCommand = new SqlCommand();
        bool isChecked = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //loads the users gv on first page load
            if (!IsPostBack)
            {
                lblUser.Text = Session["userEmail"].ToString();
                //DataSet myData = dbConnect.GetDataSet("SELECT * FROM Users");

                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = CommandType.StoredProcedure;
                //identifies which stored procedure to use
                //gets all the users in the database
                objCommand.CommandText = "SelectAllFromUsers";

                DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);

                //binds it into the gridview
                gvUsers.DataSource = myData;
                gvUsers.DataBind();

                lblGvType.Text = "Users";
                lblGvType.Visible = true;
                gvUsers.Visible = true;

                string avatar = "SELECT * FROM Users WHERE email = '" + Session["userEmail"].ToString() + "'";

                //gets the avatar url in the database 
                DataSet myImage = dbConnect.GetDataSet(avatar);

                //myImage = dbConnect.GetDataSet(myImage);

                //binds the gridview
                gvImage.DataSource = myImage;
                gvImage.DataBind();


            }
        }
        //views all flagged emails
        protected void btnViewFlagged_Click(object sender, EventArgs e)
        {
            DataSet myData = dbConnect.GetDataSet("SELECT * FROM emails WHERE FlagEmail = 1");

            //binds it into the gridview
            gvAdminInbox.DataSource = myData;
            gvAdminInbox.DataBind();

            lblGvType.Text = "Flagged Emails";
            lblGvType.Visible = true;

            gvUsers.Visible = false;
            gvAdminInbox.Visible = true;
        }

        //views all users in the database
        protected void btnViewUsers_Click(object sender, EventArgs e)
        {
            //DataSet myData = dbConnect.GetDataSet("SELECT * FROM Users");

            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            //gets all the users in the database
            objCommand.CommandText = "SelectAllFromUsers";

            DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);

            //binds it into the gridview
            gvUsers.DataSource = myData;
            gvUsers.DataBind();

            lblGvType.Text = "Users";
            lblGvType.Visible = true;
            gvUsers.Visible = true;
            gvAdminInbox.Visible = false;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        //bans users if the btn is clicked and a check box has been checked
        protected void btnBan_Click(object sender, EventArgs e)
        {
            //string banSQL = "UPDATE";
            for (int row = 0; row < gvUsers.Rows.Count; row++)
            {
                CheckBox chkBox = (CheckBox)gvUsers.Rows[row].FindControl("chkSelect");
                if (chkBox.Checked)
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    objCommand.CommandText = "Ban";

                    //the current user email
                    //string userEmail = Session["userEmail"].ToString();
                    

                    //gets the user email vaule from the gridview in col 3 and uses that value as the input param
                    objCommand.Parameters.AddWithValue("@userId", int.Parse(gvUsers.Rows[row].Cells[1].Text));

                    //adds the email into the database
                    dbConnect.DoUpdateUsingCmdObj(objCommand);

                    DataSet myData = dbConnect.GetDataSet("SELECT * FROM Users");
                    


                    //binds it into the gridview
                    gvUsers.DataSource = myData;
                    gvUsers.DataBind();

                }
                else
                {
                    isChecked = false;
                }
                
            }
            if (isChecked == false)
            {
                Response.Write("Please select a user to ban");
            }
            
        }

        //unbans users
        protected void btnUnban_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < gvUsers.Rows.Count; row++)
            {
                CheckBox chkBox = (CheckBox)gvUsers.Rows[row].FindControl("chkSelect");
                if (chkBox.Checked)
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    objCommand.CommandText = "Unban";

                    //the current user email who is logged in
                    //string userEmail = Session["userEmail"].ToString();

                    //objCommand.Parameters.AddWithValue("@unban", "active");

                    //gets the user id vaule from the gridview in col 3 and uses that value as the input param
                    objCommand.Parameters.AddWithValue("@userId", int.Parse(gvUsers.Rows[row].Cells[1].Text));

                    //adds the email into the database
                    dbConnect.DoUpdateUsingCmdObj(objCommand);

                    DataSet myData = dbConnect.GetDataSet("SELECT * FROM Users");
                    

                    

                    //binds it into the gridview
                    gvUsers.DataSource = myData;
                    gvUsers.DataBind();

                }
                else
                {
                    isChecked = false;
                }
                
            }
            if (isChecked == false)
            {
                Response.Write("Please select a user to unban");
            }
        }
    }
}