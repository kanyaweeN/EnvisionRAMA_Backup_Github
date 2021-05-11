using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_PODTL
    {
        private int _PO_ID;
        private int _ITEM_ID;
        private double _QTY;
        private string _PO_ITEM_STATUS;
        private int _ORG_ID;

        public INV_PODTL()
        {
        }

        public int PO_ID
        {
            get { return _PO_ID; }
            set { _PO_ID = value; }
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

        public string PO_ITEM_STATUS
        {
            get { return _PO_ITEM_STATUS; }
            set { _PO_ITEM_STATUS = value; }
        }

        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
