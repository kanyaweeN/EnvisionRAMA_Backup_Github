using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Envision.Common
{
    public class SR_QUESTIONSANSWERSDTL
    {
        public string ACCESSION_NO { get; set; }
        public int Q_ID { get; set; }
        public int Q_ID_DTL { get; set; }
        public string LABEL { get; set; }
        public string ANSWER { get; set; }
        public string IS_DEFAULT { get; set; }
        public string HAS_CHILD { get; set; }
        public string IMG_POSITION { get; set; }
        public Image IMG_DATA { get; set; }
        public string PROP1 { get; set; }
        public string TEXT_SIZE { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
    }
}
