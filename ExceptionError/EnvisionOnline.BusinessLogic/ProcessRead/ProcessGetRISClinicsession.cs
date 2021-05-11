using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using EnvisionOnline.DataAccess.Select;

namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISClinicsession : IBusinessLogic
    {
        public RIS_CLINICSESSION RIS_CLINICSESSION { get; set; }
        private DataSet result;

        public ProcessGetRISClinicsession()
        {
            RIS_CLINICSESSION = new RIS_CLINICSESSION();
        }
        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
        public void Invoke()
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            result = _proc.GetData();
        }
        public DataTable GetClinicSession()
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.GetScheduleSession().Tables[0].Copy();
        }
        public DataTable getSessionTime(bool IsSetOnline)
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.getSessionTime(IsSetOnline).Tables[0].Copy();
        }
        public DataTable getSessionTimeAll()
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.getSessionTimeAll().Tables[0].Copy();
        }
        public DataTable getSessionTimeChildren(int unit_id)
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.getSessionTimeChildren(unit_id).Tables[0].Copy();
        }
        public DataTable getSessionTimeWithUnit(int unit_id,int exam_id,char is_children)
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            return _proc.getSessionWithUnit(unit_id,exam_id,is_children).Tables[0].Copy();
        }
        public int getSessionIDByAppintDate(DateTime appointDate)
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.getSessionIDByAppointDate(appointDate);
        }
        public DataSet getScheduleCountInSession()
        {
            RISClinicsessionSelectData _proc = new RISClinicsessionSelectData();
            _proc.RIS_CLINICSESSION = this.RIS_CLINICSESSION;
            return _proc.getScheduleCountInSession();
        }
    }
}
