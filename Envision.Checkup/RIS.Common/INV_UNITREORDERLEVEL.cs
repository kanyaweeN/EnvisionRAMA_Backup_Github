using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_UNITREORDERLEVEL
    {
        public INV_UNITREORDERLEVEL()
        { 
        
        }

        private int _UNIT_ID;
        private int _ITEM_ID;
        private int _REORDER_DAYS;
        private double _REORDER_QTY;
        private int _ORG_ID;

        public int UNIT_ID
        {
            get { return _UNIT_ID; }
            set { _UNIT_ID = value; }
        }
        public int ITEM_ID
        {
            get { return _ITEM_ID; }
            set { _ITEM_ID = value; }
        }
        public int REORDER_DAYS
        {
            get { return _REORDER_DAYS; }
            set { _REORDER_DAYS = value; }
        }
        public double REORDER_QTY
        {
            get { return _REORDER_QTY; }
            set { _REORDER_QTY = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
