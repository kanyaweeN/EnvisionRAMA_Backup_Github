using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetScheduleCatagory : IBusinessLogic
    {
        public GBL_EMPSCHEDULECATEGORY GBL_EMPSCHEDULECATEGORY { get; set; }
        private DataSet _resultset;

        public ProcessGetScheduleCatagory()
        {

        }

        public void Invoke()
        {
            ScheduleCatagorySelectData sccat = new ScheduleCatagorySelectData();
            sccat.GBL_EMPSCHEDULECATEGORY = this.GBL_EMPSCHEDULECATEGORY;
            ResultSet = sccat.Get();

        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
