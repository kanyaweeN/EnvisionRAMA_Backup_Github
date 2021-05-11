using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;


namespace EnvisionOnline.Common
{
    public class HRAccount
    {
        private string _username;
        private string _password;
        private string _passwordencrypt;
        private string _securityquestion;
        private string _securityanswer;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string PasswordEncrypt
        {
            get { return _passwordencrypt; }
            set { _passwordencrypt = value; }
        }

        public string SecurityQuestion
        {
            get { return _securityquestion; }
            set { _securityquestion = value; }
        }

        public string SecurityAnswer
        {
            get { return _securityanswer; }
            set { _securityanswer = value; }
        }
    }
}
