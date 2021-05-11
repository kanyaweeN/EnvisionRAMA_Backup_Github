using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_TXNUNIT
    {
        private int _TXN_UNIT_ID;
        private string _TXN_UNIT_UID;
        private string _TXN_UNIT_NAME;
        private string _TXN_UNIT_DESC;
        private int _ORG_ID;

        public INV_TXNUNIT()
        { 
        }

        public int TXN_UNIT_ID
        {
            get { return _TXN_UNIT_ID; }
            set { _TXN_UNIT_ID = value; }
        }

        public string TXN_UNIT_UID
        {
            get { return _TXN_UNIT_UID; }
            set { _TXN_UNIT_UID = value; }
        }

        public string TXN_UNIT_NAME
        {
            get { return _TXN_UNIT_NAME; }
            set { _TXN_UNIT_NAME = value; }
        }

        public string TXN_UNIT_DESC
        {
            get { return _TXN_UNIT_DESC; }
            set { _TXN_UNIT_DESC = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
