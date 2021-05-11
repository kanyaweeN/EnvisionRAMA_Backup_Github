using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateGBLProduct : IBusinessLogic
	{
        public GBL_PRODUCT GBL_PRODUCT { get; set; }

		public ProcessUpdateGBLProduct()
		{
            GBL_PRODUCT = new GBL_PRODUCT();
		}
		public void Invoke()
		{
			GBLProductUpdateData _proc=new GBLProductUpdateData();
            _proc.GBL_PRODUCT = this.GBL_PRODUCT;
			_proc.Update();
		}
	}
}

