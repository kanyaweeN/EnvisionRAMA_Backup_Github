using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddSRUserPreference : IBusinessLogic
    {
        public SR_USERPREFERENCE SR_USERPREFERENCE { get; set; }

        public ProcessAddSRUserPreference() {
            SR_USERPREFERENCE = new SR_USERPREFERENCE();
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            SR_UserPreferenceInsertData proc = new SR_UserPreferenceInsertData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            proc.Add();
        }

        #endregion

        public void AddDefault() {
            SR_UserPreferenceInsertData proc = new SR_UserPreferenceInsertData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            proc.AddDefault();
        }
    }
}
