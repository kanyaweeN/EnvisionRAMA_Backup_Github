using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace Envision.NET.Forms.ScheduleEmployee
{
    public class MyAppointmentFormController : AppointmentFormController
    {

        //public string CustomName { get { return (string)EditedAppointmentCopy.CustomFields["CustomName"]; } set { EditedAppointmentCopy.CustomFields["CustomName"] = value; } }
        //public string CustomStatus { get { return (string)EditedAppointmentCopy.CustomFields["CustomStatus"]; } set { EditedAppointmentCopy.CustomFields["CustomStatus"] = value; } }

        //string SourceCustomName { get { return (string)SourceAppointment.CustomFields["CustomName"]; } set { SourceAppointment.CustomFields["CustomName"] = value; } }
        //string SourceCustomStatus { get { return (string)SourceAppointment.CustomFields["CustomStatus"]; } set { SourceAppointment.CustomFields["CustomStatus"] = value; } }


        public int SCHEDULE_ID {
            set { EditedAppointmentCopy.CustomFields["SCHEDULE_ID"] = value; }
            get { return (int)EditedAppointmentCopy.CustomFields["SCHEDULE_ID"]; }
        }
        public string COMMAND {
            set { EditedAppointmentCopy.CustomFields["COMMAND"] = value; }
            get { return EditedAppointmentCopy.CustomFields["COMMAND"].ToString(); }
        }
        public int SCHEDULE_ID_PARENT
        {
            set { EditedAppointmentCopy.CustomFields["SCHEDULE_ID_PARENT"] = value; }
            get {
                string val = EditedAppointmentCopy.CustomFields["SCHEDULE_ID_PARENT"].ToString();
                if (string.IsNullOrEmpty(val)) 
                    return 0;
                else
                    return (int)EditedAppointmentCopy.CustomFields["SCHEDULE_ID_PARENT"]; 
            }
        }
        public string RECURRENCEINFO
        {
            set { EditedAppointmentCopy.CustomFields["RECURRENCEINFO"] = value; }
            get { return EditedAppointmentCopy.CustomFields["RECURRENCEINFO"].ToString(); }
        }


        public MyAppointmentFormController(SchedulerControl control, Appointment apt): base(control, apt)
        {
           
        }

        public override bool IsAppointmentChanged()
        {
            if (base.IsAppointmentChanged())
                return true;
            // return SourceCustomName != CustomName ||SourceCustomStatus != CustomStatus;
            else
                return false;
                
        }

        //protected override void ApplyCustomFieldsValues()
        //{
        //    SourceCustomName = CustomName;
        //    SourceCustomStatus = CustomStatus;
        //}
    }
}
