using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class ResultEntryICD
    {
        private int _sptype;
        private int _icdid;
        private string _hn;
        private int _orderno;
        private string _accessionno;
        private string _resultflag;
        private int _orgid;
        private int _createdby;



        public ResultEntryICD()
        {
        }

        public int SpType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public int IcdID
        {
            get { return _icdid; }
            set { _icdid = value; }
        }

        public string PatientID
        {
            get { return _hn; }
            set { _hn = value; }
        }

        public int OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }

        public string AccessionNo
        {
            get { return _accessionno; }
            set { _accessionno = value; }
        }

        public string ResultFlag
        {
            get { return _resultflag; }
            set { _resultflag = value; }
        }

        public int CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

       



    }

}
