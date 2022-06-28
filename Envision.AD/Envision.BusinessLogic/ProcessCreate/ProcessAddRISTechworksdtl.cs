//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/10/2552 04:17:37
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic
{
	public class ProcessAddRISTechworksdtl : IBusinessLogic
	{
        private RIS_TECHWORKSDTL _ristechworksdtl;
		private bool useTran;
		public ProcessAddRISTechworksdtl()
		{
			_ristechworksdtl = new  RIS_TECHWORKSDTL();
			useTran=false;
		}
        public RIS_TECHWORKSDTL RIS_TECHWORKSDTL
		{
			get{return _ristechworksdtl;}
			set{_ristechworksdtl=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISTechworksdtlInsertData _proc=new RISTechworksdtlInsertData();
            _proc.RIS_TECHWORKSDTL = this.RIS_TECHWORKSDTL;
            //useTran= useTran ? _proc.Add(useTran,true) : 
                _proc.Add();
		}
        public void AddRadGroup()
        {
            RISTechworksdtlInsertData _proc = new RISTechworksdtlInsertData();
            _proc.RIS_TECHWORKSDTL = this.RIS_TECHWORKSDTL;
            _proc.AddRadGroup();
        }
	}
}

