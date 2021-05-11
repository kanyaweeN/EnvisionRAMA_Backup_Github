using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class ExamResultSave
    {
        private int _orderid;
        private int _examid;
        private string _accessionno;
        private string _resulttexthtml;
        private string _resultstatus;
        private int _orgid;
        private int _createdby;
        private string _hl7text;
        private string _hl7send;
        private string _resulttextplain;
        private int _finalizedby;

        public ExamResultSave()
        {
        }

        public int FinalizedBy
        {
            get { return _finalizedby; }
            set { _finalizedby = value; }
        }

        public int OrderId
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public int ExamId
        {
            get { return _examid; }
            set { _examid = value; }
        }


        public string AccessionNo
        {
            get { return _accessionno; }
            set { _accessionno = value; }
        }

        public string ResultTextHtml
        {
            get { return _resulttexthtml; }
            set { _resulttexthtml = value; }
        }

        public string ResultStatus
        {
            get { return _resultstatus; }
            set { _resultstatus = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        public string Hl7Text
        {
            get { return _hl7text; }
            set { _hl7text = value; }
        }

        public string Hl7Send
        {
            get { return _hl7send; }
            set { _hl7send = value; }
        }

        public string ResultTextPlain
        {
            get { return _resulttextplain; }
            set { _resulttextplain = value; }
        }

        

    }

}
