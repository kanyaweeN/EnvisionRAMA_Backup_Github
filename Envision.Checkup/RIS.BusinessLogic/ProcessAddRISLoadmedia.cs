//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISLoadmedia : IBusinessLogic
	{
		private RISLoadmedia _risloadmedia;
        private SqlTransaction tran = null;
		//private bool useTran;
		public ProcessAddRISLoadmedia()
		{
			_risloadmedia = new  RISLoadmedia();
		}
        public ProcessAddRISLoadmedia(SqlTransaction transaction)
        {
            _risloadmedia = new RISLoadmedia();
            tran = transaction;
        }

		public RISLoadmedia RISLoadmedia
		{
			get{return _risloadmedia;}
			set{_risloadmedia=value;}
		}
		public void Invoke()
		{
			RISLoadmediaInsertData _proc=new RISLoadmediaInsertData();
			_proc.RISLoadmedia=this.RISLoadmedia;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
            this.RISLoadmedia.LOAD_ID = _proc.GetID();
		}
	}
}

