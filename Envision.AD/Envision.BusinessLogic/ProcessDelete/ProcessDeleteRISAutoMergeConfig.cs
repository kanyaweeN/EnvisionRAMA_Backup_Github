using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISAutoMergeConfig : IBusinessLogic
    {
        public string Config_Name { get; set; }
       

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISAutoMergeConfigDelete proc = new RISAutoMergeConfigDelete();
            proc.Config_Name = Config_Name;
            proc.Delete();
        }

        #endregion
    }
}
