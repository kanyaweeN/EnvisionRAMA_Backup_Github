using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;


namespace EnvisionOnline.Common
{
    public class OnlineArrivalWorklist
    {
        
        #region Constructor
        public OnlineArrivalWorklist()
        {
        }
        #endregion



        #region Member

        private string _hn;
        private int _selectcase;
        private int _orderid;
        private string _accession;
        private int _examid;
        #endregion


        #region Property


        public string HN
        {
            get { return _hn; }
            set { _hn = value; }
        }
        public int SELECTCASE
        {
            get { return _selectcase; }
            set { _selectcase = value; }
        }
        public int ORDER_ID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        public string ACCESSION_NO
        {
            get { return _accession; }
            set { _accession = value; }
        }
        public int EXAM_ID
        {
            get { return _examid; }
            set { _examid = value; }
        }
        #endregion


        public void Update()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
