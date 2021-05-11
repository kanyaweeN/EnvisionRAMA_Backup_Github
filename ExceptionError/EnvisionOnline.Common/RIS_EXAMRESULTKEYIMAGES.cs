using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class RIS_EXAMRESULTKEYIMAGES
    {
        public string ACCESSION_NO { get; set; }
        public byte SL_NO { get; set; }
        public Byte[] KEY_IMAGE { get; set; }
        public int ORG_ID { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }

    }
}
