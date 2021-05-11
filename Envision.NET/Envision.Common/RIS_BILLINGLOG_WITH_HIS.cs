using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_BILLINGLOG_WITH_HIS
    {
        public int ORDER_ID { get; set; }
        public int EXAM_ID { get; set; }
        public string object_id { get; set; }
        public string enc_id { get; set; }
        public string enc_type { get; set; }
        public string mrn { get; set; }
        public string mrn_type { get; set; }
        public string sdloc_id { get; set; }
        public string period { get; set; }
        public string attender { get; set; }
        public string enterer { get; set; }
        public string insurance { get; set; }
        public string pt_acc_id { get; set; }
        public DateTime effectivestartdate { get; set; }
        public DateTime effectiveenddate { get; set; }
        public string statuscode { get; set; }
        public string productcode { get; set; }
        public string clinictype { get; set; }
        public string pricetype { get; set; }
        public Double amtprice { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }



        public string UNIT_UID { get; set; }
        public string CLINIC_TYPE_ALIAS { get; set; }
        public string EXAM_UID { get; set; }
        public string HN { get; set; }
    }
}
