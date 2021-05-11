using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvAuthoriser : IBusinessLogic
    {
        public INV_AUTHORISER INV_AUTHORISER { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvAuthoriser()
        {
            INV_AUTHORISER = new INV_AUTHORISER();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_AUTHORISERDeleteData delete = new INV_AUTHORISERDeleteData();
            delete.INV_AUTHORISER = INV_AUTHORISER;
            delete.Delete();
        }
    }
}
