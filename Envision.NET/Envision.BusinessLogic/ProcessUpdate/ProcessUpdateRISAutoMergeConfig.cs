using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISAutoMergeConfig : IBusinessLogic
    {
        public RIS_AUTOMERGECONFIG RIS_AUTOMERGECONFIG { get; set; }
        public ProcessUpdateRISAutoMergeConfig()
        {
            RIS_AUTOMERGECONFIG = new RIS_AUTOMERGECONFIG();
        }
        public void Invoke()
        {
            RISAutoMergeConfigUpdate proc = new RISAutoMergeConfigUpdate();
            proc.RIS_AUTOMERGECONFIG = RIS_AUTOMERGECONFIG;
            proc.Update();
        }
    }
}
