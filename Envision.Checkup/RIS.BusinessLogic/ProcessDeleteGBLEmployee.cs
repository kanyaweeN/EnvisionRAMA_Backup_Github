using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLEmployee
    {
        GBLEmployee _gblemployee;

        public ProcessDeleteGBLEmployee()
        { 
            
        }

        public void Invoke()
        {
            GBLEmployeeDeleteData gbldata = new GBLEmployeeDeleteData();
            gbldata.GBLEmployee = GBLEmployee;
            gbldata.Delete();
        }

        public GBLEmployee GBLEmployee
        {
            get { return _gblemployee; }
            set { _gblemployee = value; }
        }

    }
}
