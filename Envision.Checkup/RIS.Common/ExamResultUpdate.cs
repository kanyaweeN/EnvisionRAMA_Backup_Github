using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class ExamResultUpdate
    {
        private string _accessionno;
        private string _resultstatus;
        private string _resulttexthtml;
        private int _lastmodifiedby;
        private string _hl7text;
        private string _hl7send;
        private string _resulttextplain;
        private int _finalizedby;

        public ExamResultUpdate()
        {
        }

        public int FinalizedBy
        {
            get { return _finalizedby; }
            set { _finalizedby = value; }
        }

        public string AccessionNo
        {
            get { return _accessionno; }
            set { _accessionno = value; }
        }

        public string ResultStatus
        {
            get { return _resultstatus; }
            set { _resultstatus = value; }
        }

        public string ResultTextHtml
        {
            get { return _resulttexthtml; }
            set { _resulttexthtml = value; }
        }

       
        public int LastModifiedBy
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
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
