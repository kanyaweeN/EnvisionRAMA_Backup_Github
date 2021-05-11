using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DevExpress.XtraEditors;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace Envision.NET.Forms.Schedule.Common
{
    public class MyAppointmentFormController : AppointmentFormController
    {
        public MyAppointmentFormController(SchedulerControl control, Appointment apt)
            : base(control, apt)
        {

        }

        public int SCHEDULE_ID
        {
            set { EditedAppointmentCopy.CustomFields["SCHEDULE_ID"] = value; }
            get { return (int)EditedAppointmentCopy.CustomFields["SCHEDULE_ID"]; }
        }
        public string COMMAND
        {
            set { EditedAppointmentCopy.CustomFields["COMMAND"] = value; }
            get { return EditedAppointmentCopy.CustomFields["COMMAND"].ToString(); }
        }
        public int SCHEDULE_ID_PARENT
        {
            set { EditedAppointmentCopy.CustomFields["SCHEDULE_ID_PARENT"] = value; }
            get
            {
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

        public override bool IsAppointmentChanged()
        {
            if (base.IsAppointmentChanged())
                return true;
            else
                return false;

        }
    }
    public enum EnvisionSearchRangeType { 
        ThreeMonth = 1,
        SixMonth=2,
        TwelveMonth=3
    }
}
