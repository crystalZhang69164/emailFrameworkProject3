using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emailLibrary;
using System.Data;
using System.Data.SqlClient;


namespace emailLibrary
{
    
    public class Email
    {
        List<Email> emailList = new List<Email>();
        private string subject;
        private string content;
        private DateTime date;
        private string senderEmail;
        private string recevierEmail;

        

        //returns the list
        public List<Email> EmailList(List<Email>emailList)
        {
            return emailList;
        }
        public void Add(Email e)
        {
            emailList.Add(e);
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SenderEmail
        {
            get { return senderEmail; }
            set { senderEmail = value; }
        }
        public string ReceiverEmail
        {
            get { return recevierEmail; }
            set { recevierEmail = value; }
        }

        
    }
}
