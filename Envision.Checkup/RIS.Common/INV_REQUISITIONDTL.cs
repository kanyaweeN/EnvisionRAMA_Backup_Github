using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_REQUISITIONDTL
    {
        public INV_REQUISITIONDTL()
        { 
        }

        private int _REQUISITION_ID;
        private int _ITEM_ID;
        private double _QTY;
        private int _ORG_ID;

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
        public double QTY
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
