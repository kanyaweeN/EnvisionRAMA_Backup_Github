using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISServicetype : IBusinessLogic
	{
        public List<int> DeleteItem { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteRISServicetype() {
            DeleteItem = new List<int>();
            Transaction = null;
        }

		public void Invoke()
		{
            foreach (int item in DeleteItem)
            {
                RIS_SERVICETYPEDeleteData _proc = new RIS_SERVICETYPEDeleteData();
                _proc.ServicetypeID = item;
                _proc.Delete();
            }
		}
	}
}

