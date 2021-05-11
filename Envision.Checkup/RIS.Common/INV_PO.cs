using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class INV_PO
    {
        private int _PO_ID;
        private int _REQUISITION_ID;
        private DateTime _GENERATED_ON;
        private int _VENDOR_ID;
        private string _TOC;
        private string _PO_STATUS;
        private int _ORG_ID;

        public INV_PO()
        { 
        }

        public int PO_ID
        {
            get { return _PO_ID; }
            set { _PO_ID = value; }
        }
        public int REQUISITION_ID
        {
            get { return _REQUISITION_ID; }
            set { _REQUISITION_ID = value; }
        }
        public DateTime GENERATED_ON
        {
            get { return _GENERATED_ON; }
            set { _GENERATED_ON = value; }
        }
        public int VENDOR_ID
        {
            get { return _VENDOR_ID; }
            set { _VENDOR_ID = value; }
        }
        public string TOC
        {
            get { return _TOC; }
            set { _TOC = value; }
        }
        public string PO_STATUS
        {
            get { return _PO_STATUS; }
            set { _PO_STATUS = value; }
        }
        public int ORG_ID
        {
            get { return _ORG_ID; }
            set { _ORG_ID = value; }
        }
    }
}
