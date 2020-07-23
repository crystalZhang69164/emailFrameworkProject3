using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace emailLibrary
{
    public class User
    {
        private string userID;
        private string username;
        private string email;
        private string contactEmail;
        private string phoneNumber; 
        private string password;
        private string addressNum;
        private string streetName;
        private string zipCode;
        private string city;

        public static bool validInput(string username, string password)
        {
            if (username == null)
            {
                //Response.Write("Please enter a valid email");
                return false;
            }
            else if (password == null)
            {
                //Response.Write("Please enter a valid password");
                return false;
            }
            return true;
        }

        public static void createAcc(string emailUsername, string password, string contactEmail, string phoneNumber, string street, string zipCode, string city, string image, string active, string type)
        {
            DBConnect dbConnect = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            //identifies which stored procedure to use
            objCommand.CommandText = "UpdateDatabase";

            //adds acc to the database with these values
            objCommand.Parameters.AddWithValue("@userEmail", emailUsername);
            objCommand.Parameters.AddWithValue("@password", password);
            objCommand.Parameters.AddWithValue("@contactEmail", contactEmail);
            objCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            objCommand.Parameters.AddWithValue("@streetName", street);
            objCommand.Parameters.AddWithValue("@zipCode", zipCode);
            objCommand.Parameters.AddWithValue("@city", city);
            objCommand.Parameters.AddWithValue("@avatar", image);
            objCommand.Parameters.AddWithValue("@active", active);
            objCommand.Parameters.AddWithValue("@type", type);
            //updates to the database
            dbConnect.DoUpdateUsingCmdObj(objCommand);


        }

        public String ID
        {
            get { return userID; }
            set { userID = value; }
        }
        public String ContactEmail
        {
            get { return contactEmail; }
            set { contactEmail = value; }
        }
        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String AddressNum
        {
            get { return addressNum; }
            set { addressNum = value; }
        }

        public String SteetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        public String ZipCode
        {
            get { return zipCode; }
            set { zipCode= value; }
        }

        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public static object Response { get; private set; }
    }
}
