using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessReadModality
    {
        private RISModalitySelectData selecting { get; set; }
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public ProcessReadModality()
        {
            RIS_MODALITY = new RIS_MODALITY();
            selecting = new RISModalitySelectData();
        }
        public DataSet Select()
        {
            selecting.RIS_MODALITY = this.RIS_MODALITY;
            return selecting.Select();
        }
    }
}
