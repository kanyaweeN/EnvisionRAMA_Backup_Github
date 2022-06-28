using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteRISModalitytype : IBusinessLogic
    {

        public List<string> DeleteItem { get; set; }


		public ProcessDeleteRISModalitytype(){}

		public void Invoke()
		{
            foreach (string item in DeleteItem)
            {
                RIS_MODALITYTYPEDeleteData _proc = new RIS_MODALITYTYPEDeleteData();
                _proc.ModalityTypeID = item;
                _proc.Delete();
            }
		}
	}
}

