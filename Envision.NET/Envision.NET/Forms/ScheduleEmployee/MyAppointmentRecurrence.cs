using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler.Xml;

namespace Envision.NET.Forms.ScheduleEmployee
{
    public partial class MyAppointmentRecurrence : AppointmentRecurrenceForm// Form
    {
        public MyAppointmentRecurrence(Appointment patern,FirstDayOfWeek firstDayOfWeek):base(patern,firstDayOfWeek)
        {
            btnRemoveRecurrence.Visible = false;
        }

       
        public MyAppointmentRecurrence(Appointment patern, FirstDayOfWeek firstDayOfWeek, AppointmentFormControllerBase controller) : base(patern, firstDayOfWeek,controller) {
            btnRemoveRecurrence.Visible = false;
        }

    
    }
}
