using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_SCHEDULECONFIG
    {
        public int  SCHEDULE_CONFIG_ID {get;set;}
	    public int  SCHEDULE_CONFIRM_TIME{get;set;}
	    public string CAN_OVERLAP {get;set;}
	    public string CAN_EXCEED_MAX {get;set;}
	    public string SHOW_ALERT {get;set;}
	    public string NEED_CONFIRMATION {get;set;}
	    public string DEFAULT_SEARCH {get;set;}
	    public string DEFAULT_ONLINE_ACTION {get;set;}
	    public TimeSpan START_WORK_TIME {get;set;}
	    public TimeSpan END_WORK_TIME {get;set;}
	    public string WORK_TIME_IS_CHECKED{get;set;}
	    public string DEFAULT_CALENDAR_VIEW{get;set;}
	    public int ORG_ID{get;set;}
	    public int CREATED_BY{get;set;}
	    public DateTime CREATED_ON{get;set;}
	    public int LAST_MODIFIED_BY{get;set;}
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
