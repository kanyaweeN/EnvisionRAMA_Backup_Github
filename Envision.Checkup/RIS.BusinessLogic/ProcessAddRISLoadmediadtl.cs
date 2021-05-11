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
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data.SqlClient;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISLoadmediadtl : IBusinessLogic
	{
		private RISLoadmediadtl _risloadmediadtl;
        private SqlTransaction tran = null;

		public ProcessAddRISLoadmediadtl()
		{
			_risloadmediadtl = new  RISLoadmediadtl();
		}
        public ProcessAddRISLoadmediadtl(SqlTransaction transaction)
        {
            _risloadmediadtl = new RISLoadmediadtl();
            tran = transaction;
        }
		public RISLoadmediadtl RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public void Invoke()
		{
			RISLoadmediadtlInsertData _proc=new RISLoadmediadtlInsertData();
			_proc.RISLoadmediadtl=this.RISLoadmediadtl;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
		}
	}
}

