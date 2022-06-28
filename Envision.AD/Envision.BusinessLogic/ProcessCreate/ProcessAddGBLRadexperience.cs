//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:16
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddGBLRadexperience : IBusinessLogic
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddGBLRadexperience()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
            Transaction = null;
		}
		public void Invoke()
		{
			GBLRadexperienceInsertData _proc=new GBLRadexperienceInsertData();
            _proc.GBL_RADEXPERIENCE = this.GBL_RADEXPERIENCE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

