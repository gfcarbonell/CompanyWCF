using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF.Data
{
    [DataContract]
    public class User
    {
        private int userId;
        private string username;
        private string password;

        [DataMember]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}