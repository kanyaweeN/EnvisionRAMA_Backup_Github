//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 08:25:41
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddHREmp : IBusinessLogic
	{
		private HREmp _hremp;
		private bool useTran;
		public ProcessAddHREmp()
		{
			_hremp = new  HREmp();
			useTran=false;
		}
		public HREmp HREmp
		{
			get{return _hremp;}
			set{_hremp=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
            HREmpInsertData _proc = new HREmpInsertData();
            _proc.HREmp = this.HREmp;
            useTran = useTran ? _proc.Add(useTran, true) : _proc.Add();
		}
        public void AddFromHis() {
            HREmpInsertData _proc = new HREmpInsertData();
            _proc.HREmp = this.HREmp;
            _proc.HREmp.EMP_ID = _proc.AddFromHIS();
        }
	}
}

