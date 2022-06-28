using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler.Services;
using DevExpress.XtraScheduler.Drawing;

namespace Envision.NET.Forms.Schedule
{
    public class CustomHeaderCaptionService : HeaderCaptionServiceWrapper
    {
        public CustomHeaderCaptionService(IHeaderCaptionService service)
            : base(service)
        {
        }
        #region IHeaderCaptionService Members
        public override string GetDayColumnHeaderCaption(DayHeader header)
        {
            DateTime date = header.Interval.Start.Date;
            if (date.Month == 1 && date.Day == 1)
                return "{0:yyyy} Happy New Year!";
            else
                return base.GetDayColumnHeaderCaption(header);
        }
        #endregion
    }
}
