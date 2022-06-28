using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSF02 : IBusinessLogic
    {
        public RISSF02Data RISSF02Data { get; set; }

        public ProcessDeleteSF02()
        {
            RISSF02Data = new RISSF02Data();
        }

        public void Invoke()
        {
            RISSF02DeleteData objdata = new RISSF02DeleteData();
            objdata.RISSF02Data = this.RISSF02Data;
            objdata.Delete();

        }
    }
}
