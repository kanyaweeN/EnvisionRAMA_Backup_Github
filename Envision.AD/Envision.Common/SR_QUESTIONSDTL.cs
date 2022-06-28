using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Envision.Common
{
    public class SR_QUESTIONSDTL
    {
        public int Q_ID { get; set; }
        public int Q_ID_DTL { get; set; }
        public string LABEL { get; set; }
        public string DEFAULT_VALUE { get; set; }
        public string IS_DEFAULT { get; set; }
        public string HAS_CHILD { get; set; }
        public string IMG_POSITION { get; set; }
        public byte[] IMG_DATA { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string PROP1 { get; set; }
        public string TEXT_SIZE { get; set; }
        public string ANSWER { get; set; }
        public Image Image { get; set; }
        public bool IsHasImage { get; set; }
    }
    
}
