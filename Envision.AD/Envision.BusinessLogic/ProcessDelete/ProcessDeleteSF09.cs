using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteSF09 : IBusinessLogic
    {
        public RISSF09Data RISSF09Data { get; set; }

        public ProcessDeleteSF09()
        {
            RISSF09Data = new RISSF09Data();
        }

        public void Invoke()
        {
            RISSF09DeleteData objdata = new RISSF09DeleteData();
            objdata.RISSF09Data = this.RISSF09Data;
            objdata.Delete();

        }
    }
}
