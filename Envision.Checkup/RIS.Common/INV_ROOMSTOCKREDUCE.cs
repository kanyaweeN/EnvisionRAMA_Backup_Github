using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_ROOMSTOCKREDUCE
    {
        public INV_ROOMSTOCKREDUCE()
        { 
        
        }

        private int _ROOM_ID;
        private int _UNIT_ID;
        private int _SL_NO;
        private int _ORG_ID;

        public int ROOM_ID
        {
            get { return _ROOM_ID; }
            set { _ROOM_ID = value; }
        }
        public int UNIT_ID
        {
            get { return _UNIT_ID; }
            set { _UNIT_ID = value; }
        }
        public int SL_NO
        {
            get { return _SL_NO; }
            set { _SL_NO = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
