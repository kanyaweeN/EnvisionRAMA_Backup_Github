using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class Modality
    {
        public RIS_MODALITY RIS_MODALITY { get; set; }
        public Modality()
        {
            RIS_MODALITY = new RIS_MODALITY();
        }
        public DataSet Select()
        {
            ProcessReadModality procRead = new ProcessReadModality();
            procRead.RIS_MODALITY = this.RIS_MODALITY;
            return procRead.Select();
        }

    }
}
