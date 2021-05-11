using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class EmpScheduleCatagory
    {
        private int _sptype;
        private int _catid;
        private int _orgid;


        public EmpScheduleCatagory()
        {
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int SpType
        {
            get { return _sptype; }
            set { _sptype = value; }
        }

        public int CategoryID
        {
            get { return _catid; }
            set { _catid = value; }
        }

   
    }

}
