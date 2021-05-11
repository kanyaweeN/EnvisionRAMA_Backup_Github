using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class HL7Monitoring
    {
        private int _sptype;
        private string _msgtype;
        private int _orgid;
        private DateTime _fromdate;
        private DateTime _todate;
        
        private string _hn;
        private int _ordid;
        private string _accno;
        private int _examid;
        private string _orginalstatus;
        private string _changestatus;
        private int _reqby;
        private string _changepc;
        private int _createdby;
        private string _hl7text;
        

        public HL7Monitoring()
        {
        }

        public int SpType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public string MsgType
        {
            get { return _msgtype; }
            set { _msgtype = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public DateTime FromDate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }

        public DateTime ToDate
        {
            get { return _todate; }
            set { _todate = value; }
        }



        public string PatientID
        {
            get { return _hn; }
            set { _hn = value; }
        }
        
        public int OrderID
        {
            get { return _ordid; }
            set { _ordid = value; }
        }
        public string AccessionNo
        {
            get { return _accno; }
            set { _accno = value; }
        }

        public int ExamID
        {
            get { return _examid; }
            set { _examid = value; }
        }

        public string OriginalStatus
        {
            get { return _orginalstatus; }
            set { _orginalstatus = value; }
        }
        public string ChangeStatus
        {
            get { return _changestatus; }
            set { _changestatus = value; }
        }

        public int RequestBy
        {
            get { return _reqby; }
            set { _reqby = value; }
        }

        public string ChangePC
        {
            get { return _changepc; }
            set { _changepc = value; }
        }

        public int CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        public string Hl7Text
        {
            get { return _hl7text; }
            set { _hl7text = value;}
        }
    }

   

}
