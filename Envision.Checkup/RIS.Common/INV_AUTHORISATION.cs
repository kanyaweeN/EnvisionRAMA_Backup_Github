using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_AUTHORISATION
    {
        public INV_AUTHORISATION()
        { 
        }

        private int _AUTH_ID;
        private DateTime _AUTH_DT;
        private int _REQUISITION_ID;
        private int _ITEM_ID;
        private int _EMP_ID;
        private int _QTY;
        private int _ORG_ID;

        public int AUTH_ID
        {
            get { return _AUTH_ID; }
            set { _AUTH_ID = value; }
        }
        public DateTime AUTH_DT
        {
            get { return _AUTH_DT; }
            set { _AUTH_DT = value; }
        }
        public int REQUISITION_ID
        {
            get { return _REQUISITION_ID; }
            set { _REQUISITION_ID = value; }
        }
        public int ITEM_ID
        {
            get { return _ITEM_ID; }
            set { _ITEM_ID = value; }
        }
        public int EMP_ID
        {
            get { return _EMP_ID; }
            set { _EMP_ID = value; }
        }
        public int QTY
        {
            get { return _QTY; }
            set { _QTY = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }

    }
}
