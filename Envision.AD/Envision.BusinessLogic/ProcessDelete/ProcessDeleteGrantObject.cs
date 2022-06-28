using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGrantObject:IBusinessLogic
    {

        public List<string> DeleteItem { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGrantObject() {
            DeleteItem = new List<string>();
            Transaction = null;
        }

        public void Invoke()
        {
            foreach (string item in DeleteItem)
            {
                GBLGrantObjectDeleteData obj = new GBLGrantObjectDeleteData();
                obj.GrantID = item;
                obj.Get();
            }
        }
    }
}
