using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using emailLibrary;
using System.Data.SqlClient;

namespace emailFrameworkProject3
{
    public partial class userEmail : System.Web.UI.Page
    {
        DataSet myData = new DataSet();
        DBConnect dbConnect = new DBConnect();
        private static int fromCol = 1;
        private static int subjectCol = 2;
        private static int contentCol = 3;
        //private static int fromCol = 1;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    // if it's the first page load

            {
                //gets the user email stored in sessions from the login aspx and stores it in the variable email
                string email = Session["userEmail"].ToString();//Request["txtEmail"].ToString();

                lblFolderType.Text = "Inbox";
                lblFolderType.Visible = true;

                

                //gets the data with the sql string
                //gets all the email from that user
                DataSet myData = dbConnect.GetDataSet("SELECT * FROM emails WHERE ReceiverEmail = '" + email + "'" + "AND EmailTag = 'Inbox'");

                //binds it into the gridview
                gvInbox.DataSource = myData;
                gvInbox.DataBind();

                //String strSQL = "SELECT * FROM Users ORDER BY ProductNumber";

                //gvProducts.DataSource = objDB.GetDataSet(strSQL);

                //gvProducts.DataBind();

            }
            string avatar = "SELECT * FROM Users WHERE email = '" + Session["userEmail"].ToString() + "'";

            //gets the avatar url in the database 
            DataSet myImage = dbConnect.GetDataSet(avatar);

            //myImage = dbConnect.GetDataSet(myImage);

            //binds the gridview
            gvImage.DataSource = myImage;
            gvImage.DataBind();


        }

        protected void btnCreateEmail_Click(object sender, EventArgs e)
        {
            

            


            txtFrom.Text = Session["userEmail"].ToString();
            gvInbox.Visible = false;

            //txtFrom.Text = "";
            txtTo.Text = "";
            txtSubject.Text = "";
            txtContent.Text = "";

            lblFolderType.Text = "Inbox";

            lblFrom.Visible = true;
            txtFrom.Visible = true;
            txtFrom.ReadOnly = false;
            lblTo.Visible = true;
            txtTo.Visible = true;
            txtTo.ReadOnly = false;
            lblSubject.Visible = true;
            txtSubject.Visible = true;
            txtSubject.ReadOnly = false;
            lblContent.Visible = true;
            txtContent.Visible = true;
            txtContent.ReadOnly = false;

            btnSend.Visible = true;





        }

        //creates an email and sends it to a user
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string email = Session["userEmail"].ToString();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            objCommand.CommandText = "AddEmail";

            string subject = txtSubject.Text;
            string content = txtContent.Text;
            //the current user email
            string from = Session["userEmail"].ToString();
            //txtFrom.Text = Session["userEmail"].ToString();
            string to = txtTo.Text;

            //objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@Subject", subject);
            objCommand.Parameters.AddWithValue("@Content", content);
            objCommand.Parameters.AddWithValue("@SenderId", from);
            objCommand.Parameters.AddWithValue("@ReceiverId", to);
            objCommand.Parameters.AddWithValue("@Date", DateTime.Now);
            objCommand.Parameters.AddWithValue("@EmailTag", "Inbox");

            //adds the email into the database
            dbConnect.DoUpdateUsingCmdObj(objCommand);

            //gets the data with the sql string
            //gets all the email from that user
            //DataSet myData = dbConnect.GetDataSet("SELECT * FROM emails WHERE ReceiverEmail = '" + email + "'" + "AND EmailTag = 'Inbox'");

            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            objCommand.CommandText = "GetInboxEmails";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@emailTag", "Inbox");
            objCommand.Parameters.AddWithValue("@receiverEmail", email);

            DataSet data = dbConnect.GetDataSetUsingCmdObj(objCommand);
            //binds it into the gridview
            gvInbox.DataSource = data;

            //gvInbox.DataSource = data;

            gvInbox.DataBind();

  

            gvInbox.Visible = true;

            lblFrom.Visible = false;
            txtFrom.Visible = false;
            lblTo.Visible = false;
            txtTo.Visible = false;
            lblSubject.Visible = false;
            txtSubject.Visible = false;
            lblContent.Visible = false;
            txtContent.Visible = false;

            btnSend.Visible = false;

            Response.Write("email has been sent");


        }

        //btn inbox click event
        protected void btnInbox_Click(object sender, EventArgs e)
        {
            //gets all the email for that user
            string email = Session["userEmail"].ToString();
            SqlCommand objCommand = new SqlCommand();

            lblFolderType.Text = "Inbox";
            lblFolderType.Visible = true;

            //gets the data with the sql string
            //DataSet myData = dbConnect.GetDataSet("SELECT * FROM emails WHERE ReceiverEmail = '" + email + "'" + "AND EmailTag = 'Inbox'");




            //THE SELECT STATEMENT PROCEDURES
            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            objCommand.CommandText = "GetInboxEmails";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@emailTag", "Inbox");
            objCommand.Parameters.AddWithValue("@receiverEmail", email);

            DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);



            //binds it into the gridview
            gvInbox.DataSource = myData;
            gvInbox.DataBind();

            gvInbox.Visible = true;

            lblFrom.Visible = false;
            txtFrom.Visible = false;
            lblTo.Visible = false;
            txtTo.Visible = false;
            lblSubject.Visible = false;
            txtSubject.Visible = false;
            lblContent.Visible = false;
            txtContent.Visible = false;

            btnSend.Visible = false;
        }

        //search query
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            lblFolderType.Text = "Search Results";
            lblFolderType.Visible = true;

            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            objCommand.CommandText = "Search";


            objCommand.Parameters.AddWithValue("@Search", txtSearch.Text);

            
            dbConnect.GetDataSetUsingCmdObj(objCommand);

            DBConnect dbconnect = new DBConnect();
            myData = dbConnect.GetDataSetUsingCmdObj(objCommand);

            //binds the gridview
            gvInbox.DataSource = myData;
            gvInbox.DataBind();
            
            if(txtSearch.Text == "")
            {
                string email = Session["userEmail"].ToString();
                //THE SELECT STATEMENT PROCEDURES
                objCommand.CommandType = CommandType.StoredProcedure;
                //identifies which stored procedure to use
                objCommand.CommandText = "GetInboxEmails";

                objCommand.Parameters.Clear();
                objCommand.Parameters.AddWithValue("@emailTag", "Inbox");
                objCommand.Parameters.AddWithValue("@receiverEmail", email);

                DataSet myData = dbconnect.GetDataSetUsingCmdObj(objCommand);

                //gets the data with the sql string
                //DataSet myData = dbConnect.GetDataSet("SELECT * FROM emails WHERE ReceiverEmail = '" + email + "'");

                //binds it into the gridview
                gvInbox.DataSource = myData;
                gvInbox.DataBind();
            }
             


        }

        protected void btnDeleteEmail_Click(object sender, EventArgs e)
        {
            string email = Session["userEmail"].ToString();
            SqlCommand objCommand = new SqlCommand();

            for (int row= 0; row<gvInbox.Rows.Count; row++)
            {
                CheckBox chkBox;
                //gets a reference for the chkselect ctrl in the current row
                chkBox = (CheckBox)gvInbox.Rows[row].FindControl("chkSelect");

                //if the box is checked
                if (chkBox.Checked)
                {


                    //gvInbox.Rows[row].Cells[2].Text is w/e is in the subject col in that row
                    //string mySQL = "UPDATE emails SET EmailTag = 'Trash' WHERE Subject = '" + gvInbox.Rows[row].Cells[subjectCol].Text + "' AND SenderEmail = '" + gvInbox.Rows[row].Cells[fromCol].Text + "'";


                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    //moves to the trash folder
                    objCommand.CommandText = "DeleteEmail";

                    objCommand.Parameters.AddWithValue("@senderEmail", email);
                    objCommand.Parameters.AddWithValue("@subject", gvInbox.Rows[row].Cells[subjectCol].Text);
                    objCommand.Parameters.AddWithValue("@emailTag", "Trash");

                    dbConnect.DoUpdateUsingCmdObj(objCommand);

                    //dbConnect.DoUpdate(mySQL);

                    
                    //THE SELECT STATEMENT PROCEDURES
                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    objCommand.CommandText = "GetInboxEmails";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@emailTag", "Inbox");
                    objCommand.Parameters.AddWithValue("@receiverEmail", email);


                    //shows the new inbox with the deleted one gone
                    //string rebind = "SELECT * FROM emails WHERE EmailTag = 'Inbox'";
                    DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);

                    //shows the updated inbox gv
                    gvInbox.DataSource = myData;
                    gvInbox.DataBind();

                    lblFolderType.Text = "Inbox";
                    lblFolderType.Visible = true;

                    gvInbox.Visible = true;
                    

                }
            }
            

        }

        protected void showInbox()
        {
            lblFolderType.Text = "Inbox";
            lblFolderType.Visible = true;

            gvInbox.Visible = true;

        
        }

        protected void btnTrash_Click(object sender, EventArgs e)
        {
            lblFolderType.Text = "Trash";
            lblFolderType.Visible = true;
            string userEmail = Session["userEmail"].ToString();
            SqlCommand objCommand = new SqlCommand();


            //DataSet myTrash = dbConnect.GetDataSet("SELECT * FROM emails WHERE ReceiverEmail = '" + userEmail + "'" + "AND EmailTag = 'Trash'");
            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            objCommand.CommandText = "ShowTrashFolder";

            objCommand.Parameters.Clear();
            objCommand.Parameters.AddWithValue("@emailTag", "Trash");
            objCommand.Parameters.AddWithValue("@receiverEmail", userEmail);

            DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);

            //binds it into the gridview
            gvInbox.DataSource = myData;
            gvInbox.DataBind();


            CheckBox cBox;

            for (int row = 0; row<gvInbox.Rows.Count; row++)
            {
                cBox = (CheckBox)gvInbox.Rows[row].FindControl("chkSelect");
                if (cBox.Checked)
                {
                    //if (Session["Folder"].Equals("Trash"))
                    //{
                    //string mySQL = "UPDATE emails SET EmailTag = 'Trash' WHERE Subject = '" + gvInbox.Rows[row].Cells[2].Text +"' AND SenderEmail = '" + gvInbox.Rows[row].Cells[1].Text + "'";

                    //dbConnect.DoUpdate(mySQL);

                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    //moves to the trash folder
                    objCommand.CommandText = "DeleteEmail";

                    objCommand.Parameters.Clear();

                    objCommand.Parameters.AddWithValue("@senderEmail", userEmail);
                    objCommand.Parameters.AddWithValue("@subject", gvInbox.Rows[row].Cells[subjectCol].Text);
                    objCommand.Parameters.AddWithValue("@emailTag", "Trash");

                    dbConnect.DoUpdateUsingCmdObj(objCommand);




                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    objCommand.CommandText = "ShowTrashFolder";

                    objCommand.Parameters.Clear();
                    objCommand.Parameters.AddWithValue("@emailTag", "Trash");
                    objCommand.Parameters.AddWithValue("@receiverEmail", userEmail);

                    DataSet myData2 = dbConnect.GetDataSetUsingCmdObj(objCommand);

                    //string rebind = "SELECT * FROM emails WHERE EmailTag = 'Trash'";
                    //DataSet myData2 = dbConnect.GetDataSet(rebind);

                    //shows the trash emails folder
                    gvInbox.DataSource = myData2;
                    gvInbox.DataBind();


                    gvInbox.Visible = true;


            
                }
            }
        }

        protected void btnFlag_Click(object sender, EventArgs e)
        {
            CheckBox cBox;

            //traverse through each row in the gv
            for (int row = 0; row < gvInbox.Rows.Count; row++)
            {
                //gets reference to the ctrl chkSelect
                cBox = (CheckBox)gvInbox.Rows[row].FindControl("chkSelect");
                if (cBox.Checked)
                {


                    SqlCommand objCommand = new SqlCommand();

                    objCommand.CommandType = CommandType.StoredProcedure;
                    //identifies which stored procedure to use
                    objCommand.CommandText = "FlagEmail";

                    //the current user email
                    string from = Session["userEmail"].ToString();
         
                    objCommand.Parameters.AddWithValue("@senderEmail", from);
                    
                    //gets the subject vaule from the gridview in col 3 and uses that value as the input param
                    objCommand.Parameters.AddWithValue("@subject", gvInbox.Rows[row].Cells[2].Text);
                    
                    //sets the flag parameter to 1 which would be true in this case and 0 is false
                    objCommand.Parameters.AddWithValue("@flag", 1);


                    //adds the email into the database
                    dbConnect.DoUpdateUsingCmdObj(objCommand);

             

                    DataSet myData = dbConnect.GetDataSet("SELECT * FROM emails WHERE ReceiverEmail = '" + Session["userEmail"].ToString() + "'");

                    //binds it into the gridview
                    gvInbox.DataSource = myData;
                    gvInbox.DataBind();




                    gvInbox.DataBind();

                    lblFolderType.Text = "Inbox";
                    lblFolderType.Visible = true;
                    gvInbox.Visible = true;


                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        //views the email
        protected void btnViewEmail_Click(object sender, EventArgs e)
        {
            CheckBox chkBox;
            for (int row = 0; row<gvInbox.Rows.Count; row++)
            {
                chkBox = (CheckBox)gvInbox.Rows[row].FindControl("chkSelect");
                if (chkBox.Checked)
                {
                    gvInbox.Visible = false;


                    txtFrom.Text = gvInbox.Rows[row].Cells[fromCol].Text;
                    txtSubject.Text = gvInbox.Rows[row].Cells[subjectCol].Text;
                    txtContent.Text = gvInbox.Rows[row].Cells[contentCol].Text;

                    lblFrom.Visible = true;
                    txtFrom.Visible = true;
                    txtFrom.ReadOnly = true;

                    lblFolderType.Text = "Inbox";
                    lblFolderType.Visible = true;

                    lblSubject.Visible = true;
                    txtSubject.Visible = true;
                    txtSubject.ReadOnly = true;
                    lblContent.Visible = true;
                    txtContent.Visible = true;
                    txtContent.ReadOnly = true;

                }
            }
        }

        protected void btnMove_Click(object sender, EventArgs e)
        {
            CheckBox chkBox;
            SqlCommand objCommand = new SqlCommand();
            string email = Session["userEmail"].ToString();//Request["txtEmail"].ToString();
            

            

            for (int row = 0; row < gvInbox.Rows.Count; row++)
            {
                chkBox = (CheckBox)gvInbox.Rows[row].FindControl("chkSelect");
                if (chkBox.Checked)
                {
                    //if the selected item in the ddl isnt the first value
                    if (ddlMoveTo.Text != ddlMoveTo.Items[0].Value)
                    {
                        string from = Session["userEmail"].ToString();
                        string subject = gvInbox.Rows[row].Cells[subjectCol].Text;
                        string content = gvInbox.Rows[row].Cells[contentCol].Text;
                        string updateInboxSql = "SELECT * FROM emails WHERE EmailTag = '" + ddlMoveTo.Text + "'";

                        objCommand.CommandType = CommandType.StoredProcedure;
                        ////identifies which stored procedure to use
                        //moves the email to the selected folder
                        objCommand.CommandText = "UpdateMoveToFolder";


                        objCommand.Parameters.Clear();
                        objCommand.Parameters.AddWithValue("@emailTag", ddlMoveTo.Text);
                        objCommand.Parameters.AddWithValue("@senderEmail", from);
                        objCommand.Parameters.AddWithValue("@subject", subject);
                        objCommand.Parameters.AddWithValue("@content", content);



                        //SqlParameter outputParameter = new SqlParameter("@");

                        //adds the email into the specified folder
                        dbConnect.DoUpdateUsingCmdObj(objCommand);

                        //objCommand.CommandType = CommandType.StoredProcedure;
                        ////identifies which stored procedure to use
                        //objCommand.CommandText = "GetInboxEmails";

                        //objCommand.Parameters.Clear();
                        //objCommand.Parameters.AddWithValue("@emailTag", "Trash");
                        //objCommand.Parameters.AddWithValue("@receiverEmail", email);

        
                        //dbConnect.GetDataSetUsingCmdObj(objCommand);
                        //DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);
                        DataSet myData = dbConnect.GetDataSet(updateInboxSql);
                        //DataSet myData = dbConnect.GetDataSetUsingCmdObj(objCommand);
                        gvInbox.DataSource = myData;

                        lblFolderType.Text = ddlMoveTo.Text;
                        lblFolderType.Visible = true;
                        //shows the inbox folder gv
                        gvInbox.DataBind();

                    }
                    else
                    {
                        Response.Write("Please select a folder to move to");
                    }
                   
                }
            }
        }

        protected void gvInbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}