using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateHISRegistration : IBusinessLogic
	{
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateHISRegistration()
		{
            HIS_REGISTRATION = new HIS_REGISTRATION();
            Transaction = null;
		}
        public ProcessUpdateHISRegistration(DbTransaction tran)
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            Transaction = tran;
        }
		public void Invoke()
		{
            HISRegistrationUpdateData _proc = new HISRegistrationUpdateData();
            _proc.HIS_REGISTRATION = this.HIS_REGISTRATION;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
        public void UpdateAllergies()
        {
            HISRegistrationUpdateData _proc = new HISRegistrationUpdateData();
            _proc.HIS_REGISTRATION = this.HIS_REGISTRATION;
            if (Transaction == null)
                _proc.UpdateAllergies();
            else
                _proc.UpdateAllergies(Transaction);
        }
        public void UpdateFromArrival()
        {
            HISRegistrationUpdateData _proc = new HISRegistrationUpdateData();
            _proc.HIS_REGISTRATION = this.HIS_REGISTRATION;
            if (Transaction == null)
                _proc.UpdateFromArrival();
            else
                _proc.UpdateFromArrival(Transaction);
        }
	}
}

