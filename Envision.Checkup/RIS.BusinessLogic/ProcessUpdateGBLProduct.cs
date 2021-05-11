using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateGBLProduct : IBusinessLogic
	{
		private GBLProduct _gblproduct;
		public ProcessUpdateGBLProduct()
		{
			_gblproduct = new GBLProduct();
		}
		public GBLProduct GBLProduct		{
			get{return _gblproduct;}
			set{_gblproduct=value;}
		}
		public void Invoke()
		{
			GBLProductUpdateData _proc=new GBLProductUpdateData();
			_proc.GBLProduct=this.GBLProduct;
			_proc.Update();
		}
	}
}

