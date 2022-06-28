using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteGBLRadexperience : IBusinessLogic
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; } 
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteGBLRadexperience()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
            Transaction = null;
		}
		
		public void Invoke()
        {
            GBL_RADEXPERIENCEDeleteData _proc = new GBL_RADEXPERIENCEDeleteData();
            _proc.GBL_RADEXPERIENCE = GBL_RADEXPERIENCE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

