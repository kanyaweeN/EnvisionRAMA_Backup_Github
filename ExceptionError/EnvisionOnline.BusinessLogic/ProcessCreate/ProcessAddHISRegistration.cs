using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddHISRegistration : IBusinessLogic
    {
        public HIS_REGISTRATION HIS_REGISTRATION { get; set; }
        public DbTransaction Transaction { get; set; }
        private int action = 0;
        private bool link = true;
        public ProcessAddHISRegistration()
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            Transaction = null;
            action = 0;
        }
        public ProcessAddHISRegistration(bool linkDown)
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            Transaction = null;
            action = 1;
            link = linkDown;
        }
        public ProcessAddHISRegistration(DbTransaction tran)
        {
            HIS_REGISTRATION = new HIS_REGISTRATION();
            Transaction = tran;
            action = 2;
        }
        public void Invoke()
        {
            HISRegistrationInsertData _proc = new HISRegistrationInsertData();
            _proc.HIS_REGISTRATION = HIS_REGISTRATION;
            if (action == 0)
                HIS_REGISTRATION.REG_ID = _proc.Add();
            else if (action == 1)
            {
                _proc = new HISRegistrationInsertData(link);
                _proc.HIS_REGISTRATION = HIS_REGISTRATION;
                HIS_REGISTRATION.REG_ID = _proc.Add();
            }
            else if (action == 2)
            {
                HIS_REGISTRATION.REG_ID = _proc.Add(Transaction);

            }
        }
        public int CheckHISData(HIS_REGISTRATION his)
        {
            HISRegistrationInsertData _proc = new HISRegistrationInsertData();
            return _proc.CheckHISData(HIS_REGISTRATION);
        }
    }
}
