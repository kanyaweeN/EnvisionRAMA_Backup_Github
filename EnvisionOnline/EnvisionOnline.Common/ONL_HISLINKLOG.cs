using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class ONL_HISLINKLOG
    {
        public ONL_HISLINKLOG() { }
        public int LINK_ID { get; set; }
        public string HIS_URL { get; set; }
        public string HN { get; set; }
        public string USER_NAME { get; set; }
        public string UNIT { get; set; }
        public string CLINIC { get; set; }
        public string INSR { get; set; }
        public string ROLE { get; set; }
        public string ENC { get; set; }
        public string FORM { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string LOG_DESC { get; set; }
        public string BROWSER_TYPE { get; set; }
        public string USER_HOST_ADDRESS { get; set; }
        public string ACCESSION_NO { get; set; }

    }
}
