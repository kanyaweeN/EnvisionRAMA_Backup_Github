using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddInvItemtype
    {
        public INV_ITEMTYPE INV_ITEMTYPE { get; set; }

        public ProcessAddInvItemtype()
        {
            INV_ITEMTYPE = new INV_ITEMTYPE();
        }

        public void Invoke()
        {
            InvItemtypeInsertData insert = new InvItemtypeInsertData();
            insert.INV_ITEMTYPE = this.INV_ITEMTYPE;
            insert.Insert();
        }
    }
}
