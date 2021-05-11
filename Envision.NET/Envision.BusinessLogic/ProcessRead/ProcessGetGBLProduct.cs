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
    public class ProcessGetGBLProduct : IBusinessLogic
    {
        
        private GBL_PRODUCT GBL_PRODUCT { get; set; }

        public DataSet ResultSet { get;set; }

        public ProcessGetGBLProduct()
        {
            GBL_PRODUCT = new GBL_PRODUCT();
            ResultSet = new DataSet();
        }

        public void Invoke()
        {
            ProductSelectData proddata = new ProductSelectData();
            ResultSet = proddata.Get();
        }


       

    }
}
