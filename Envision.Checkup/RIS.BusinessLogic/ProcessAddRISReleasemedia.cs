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
	public class ProcessAddRISReleasemedia : IBusinessLogic
	{
		private RISReleasemedia _risreleasemedia;
        private SqlTransaction tran = null;
		//private bool useTran;
		public ProcessAddRISReleasemedia()
		{
            _risreleasemedia = new RISReleasemedia();
		}
        public ProcessAddRISReleasemedia(SqlTransaction transaction)
        {
            _risreleasemedia = new RISReleasemedia();
            tran = transaction;
        }

        public RISReleasemedia RISReleasemedia
		{
            get { return _risreleasemedia; }
            set { _risreleasemedia = value; }
		}
		public void Invoke()
		{
            RISReleasemediaInsertData _proc = new RISReleasemediaInsertData();
            _proc.RISReleasemedia = this.RISReleasemedia;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
            this.RISReleasemedia.RELEASE_ID = _proc.GetID();
		}
	}
}

