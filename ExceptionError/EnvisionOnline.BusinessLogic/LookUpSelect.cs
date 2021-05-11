using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic
{
    public class LookUpSelect
    {
        public LookUpSelect()
        {

        }
        public DataSet SelectPatientDestination(string AccessionNo)
        {
            _LookUpSelect prc = new _LookUpSelect();
            return prc.SelectPatientDestination(AccessionNo);
        }
        public bool FixDataOnline()
        {
            _LookUpSelect prc = new _LookUpSelect();
            prc.FixDataOnline();
            return true;
        }
    }
}
