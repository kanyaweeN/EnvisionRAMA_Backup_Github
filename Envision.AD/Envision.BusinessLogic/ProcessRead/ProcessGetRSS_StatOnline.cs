using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic.ProcessRead
{
   public class ProcessGetRSS_StatOnline
    {
       static string frDate, tDate;
         static string   groupType,modeType, reportType;


         public string GetFromDate
       {
           get
           {
               return frDate;
           }
           set
           {
               frDate = value;
           }
       }

         public string GetToDate
       {
           get
           {
               return tDate;
           }
           set
           {
               tDate = value;
           }
       }

       public string GetGroupType
       {
           get
           {
               return groupType;
           }
           set
           {
               groupType = value;
           }
       }
       public string GetDurationType
       {
           get
           {
               return modeType;
           }
           set
           {
               modeType = value;
           }
       }

       public string GetReportType
       {
           get
           {
               return reportType;
           }
           set
           {
               reportType = value;
           }
       }

    }
}
