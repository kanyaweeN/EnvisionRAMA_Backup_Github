using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteRISAutoMergeConfig : IBusinessLogic
    {
        private string config_name;
        public string Config_Name
        {
            get { return config_name; }
            set { config_name = value; }
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISAutoMergeConfigDelete proc = new RISAutoMergeConfigDelete();
            proc.Config_Name = config_name;
            proc.Delete();
        }

        #endregion
    }
}
