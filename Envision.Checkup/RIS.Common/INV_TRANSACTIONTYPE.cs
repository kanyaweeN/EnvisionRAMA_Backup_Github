using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_TRANSACTIONTYPE
    {
        public INV_TRANSACTIONTYPE()
        { 
        
        }

        private int _TRANSACTIONTYPE_ID;
        private string _TRANSACTIONTYPE_UID;
        private string _TRANSACTIONTYPE_NAME;
        private int _ORG_ID;

        public int TRANSACTIONTYPE_ID
        {
            get { return _TRANSACTIONTYPE_ID; }
            set { _TRANSACTIONTYPE_ID = value; }
        }
        public string TRANSACTIONTYPE_UID
        {
            get { return _TRANSACTIONTYPE_UID; }
            set { _TRANSACTIONTYPE_UID = value; }
        }
        public string TRANSACTIONTYPE_NAME
        {
            get { return _TRANSACTIONTYPE_NAME; }
            set { _TRANSACTIONTYPE_NAME = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
