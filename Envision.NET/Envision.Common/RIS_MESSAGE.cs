using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_MESSAGE
    {
        public int MSG_ID { get; set; }
        public int SENDER_ID { get; set; }
        public string MSG_TEXT { get; set; }
        public string MSG_STATUS { get; set; }
        public string ACCESSION_NO { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
    }
}
