using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

public class ReturnOperation
    {
        private string type;
        private string message;
        private DataSet dsAccession;

        public ReturnOperation()
        {
            type = string.Empty;
            message = string.Empty;
        }
        public ReturnOperation(string Type, string Message)
        {
            type = Type;
            message = Message;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public DataSet Accession
        {
            get { return dsAccession; }
            set { dsAccession = value; }
        }

    }
