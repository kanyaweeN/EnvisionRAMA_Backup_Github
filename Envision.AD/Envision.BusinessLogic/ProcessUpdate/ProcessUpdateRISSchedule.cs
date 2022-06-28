using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISSchedule : IBusinessLogic
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISSchedule()
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            Transaction = null;
            RIS_SCHEDULE.SCHEDULE_ID = 0;
        }
        public ProcessUpdateRISSchedule(int schedule_ID)
        {
            RIS_SCHEDULE = new RIS_SCHEDULE();
            Transaction = null;
            RIS_SCHEDULE.SCHEDULE_ID = schedule_ID;
        }
        public void Invoke()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            if (Transaction == null)
            {
                if (RIS_SCHEDULE.SCHEDULE_ID > 0)
                    _proc = new RISScheduleUpdateData(RIS_SCHEDULE);
                _proc.RIS_SCHEDULE = this.RIS_SCHEDULE;
                _proc.Update();
            }
            else
            {
                if (RIS_SCHEDULE.SCHEDULE_ID > 0)
                    _proc = new RISScheduleUpdateData(RIS_SCHEDULE);
                _proc.RIS_SCHEDULE = this.RIS_SCHEDULE;
                _proc.Update(Transaction);
            }
        }

        public void Update() {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateSchedule();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
        public void UpdateCNMI()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateScheduleCNMI();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
        public void UpdatePatientStatus() {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdatePatientStatus();
        }
        public void UpdateBlock()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateScheduleBlock();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
        public void UpdateComments()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateScheduleComments();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
        public void UpdateBlockTimer()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateScheduleTimer();
        }
        public void UpdateModality()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateModality();
            RIS_SCHEDULE.SCHEDULE_ID = _proc.RIS_SCHEDULE.SCHEDULE_ID;
        }
        public void UpdateRecurrence()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateRecurrence();
        }

        public void UpdateWatingList()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateWatingList();
        }
        public void UpdateWatingComments()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateWatingComments();
        }
        public void UpdatePending()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdatePending();
        }
        public void UpdatePendingComments()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdatePendingComments();
        }
        public void UpdatePendingSchedule()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdatePendingSchedule();
        }

        public void UpdateBusy()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateBusy();
        }
        public void UpdateSessionID(int session_id,int schedule_id)
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.UpdateSessionID(session_id, schedule_id);
        }
        public void UpdateTextShow(string textShow, int schedule_id)
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.UpdateTextShow(textShow, schedule_id);
        }
        public void TransferClincalIndication(int schedule_id, int xrayreq_id)
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.TransferClincalIndication(schedule_id, xrayreq_id);
        }
        public void UpdateAppointmentMerge()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateAppointmentMerge();
        }
        public void UpdateRequestResult()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateRequestResult();
        }
        public void UpdateRequestResultCNMI()
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateRequestResultCNMI();
        }
        public void UpdateIsProtocal(string is_protocal, int schedule_id, int emp_id)
        {
            RISScheduleUpdateData _proc = new RISScheduleUpdateData();
            _proc.RIS_SCHEDULE = RIS_SCHEDULE;
            _proc.UpdateIsProtocal(is_protocal, schedule_id, emp_id);
        }
    }
}
