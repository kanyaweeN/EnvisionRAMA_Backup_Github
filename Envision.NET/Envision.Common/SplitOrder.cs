using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace Envision.Common
{

    public class SplitOrder
    {
        private int _orderid;
        private string _newaccession;
        private string _accessionno;
        private string _hn;
       

        public SplitOrder()
        {

        }

        public int OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        
        public string NewAccession
        {
            get { return _newaccession; }
            set { _newaccession = value; }
        }
       
        public string AccessionNo
        {
            get { return _accessionno; }
            set { _accessionno = value; }
        }
        public string PatientHN
        {
            get { return _hn; }
            set { _hn = value; }
        }

       
    }

   
}
