using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class ExamAddendum
    {
        private int _orderid;
        private int _examid;
        private string _accesssionno;
        private string _notetext;
        private int _noteby;
        private int _orgid;
        private string _hl7text;
        private string result_text_rtf;


        public ExamAddendum()
        {
        }

        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        public int ExamID
        {
            get { return _examid; }
            set { _examid = value; }
        }


        public string AccessionNo
        {
            get { return _accesssionno; }
            set { _accesssionno = value; }
        }

        public string NoteText
        {
            get { return _notetext; }
            set { _notetext = value; }
        }

        public int NoteBy
        {
            get { return _noteby; }
            set { _noteby = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public string Hl7Text
        {
            get { return _hl7text; }
            set { _hl7text = value; }
        }

        public string RESULT_TEXT_RTF {
            get { return result_text_rtf; }
            set { result_text_rtf = value; }
        
        }
        

    }

}
