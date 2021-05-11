using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_MPPS
    {
        public RIS_MPPS()
        {
            DateForm = new DateTime();
            DateTo = new DateTime();
        }

        public DateTime DateForm { get; set; }
        public DateTime DateTo { get; set; }
    }
}
