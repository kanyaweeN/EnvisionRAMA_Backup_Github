using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public  class ProcessDeleteSRUserpreference : IBusinessLogic
    {
        public SR_USERPREFERENCE SR_USERPREFERENCE { get; set; }

        public ProcessDeleteSRUserpreference() {
            SR_USERPREFERENCE = new SR_USERPREFERENCE();
        }

        public void Invoke()
        {
            SR_USERPREFERENCEDeleteData proc = new SR_USERPREFERENCEDeleteData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            proc.Delete();
        }
        public void DeleteByTemplateId() {
            SR_USERPREFERENCEDeleteData proc = new SR_USERPREFERENCEDeleteData();
            proc.SR_USERPREFERENCE = SR_USERPREFERENCE;
            proc.DeleteByTemplateId();
        }
    }
}
