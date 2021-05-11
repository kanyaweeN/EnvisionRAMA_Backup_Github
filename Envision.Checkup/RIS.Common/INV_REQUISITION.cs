using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_REQUISITION
    {
        public INV_REQUISITION()
        { 
        }

        private int _REQUISITION_ID;
        private string _REQUISITION_TYPE;
        private string _GENERATE_MODE;
        private int _FROM_UNIT;
        private int _TO_UNIT;
        private int _GENERATED_BY;
        private DateTime _GENERATED_ON;
        private string _STATUS;
        private int _ORG_ID;

        public int REQUISITION_ID
        {
            get { return _REQUISITION_ID; }
            set { _REQUISITION_ID = value; }
        }
        public string REQUISITION_TYPE
        {
            get { return _REQUISITION_TYPE; }
            set { _REQUISITION_TYPE = value; }
        }
        public string GENERATE_MODE
        {
            get { return _GENERATE_MODE; }
            set { _GENERATE_MODE = value; }
        }
        public int FROM_UNIT
        {
            get { return _FROM_UNIT; }
            set { _FROM_UNIT = value; }
        }
        public int TO_UNIT
        {
            get { return _TO_UNIT; }
            set { _TO_UNIT = value; }
        }
        public int GENERATED_BY
        {
            get { return _GENERATED_BY; }
            set { _GENERATED_BY = value; }
        }
        public DateTime GENERATED_ON
        {
            get { return _GENERATED_ON; }
            set { _GENERATED_ON = value; }
        }
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }

    }
}
