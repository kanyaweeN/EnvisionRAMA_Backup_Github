using System.Data;

using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLMessage : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public GBL_MESSAGE Columns;

        public ProcessGetGBLMessage()
        {
            Columns = new GBL_MESSAGE();
        }

        public void Invoke()
        {

        }
        public void InvokeByMsgID()
        {
            GBLMessageSelectData _prc = new GBLMessageSelectData()
            {
                Columns = this.Columns
            };

            Result = _prc.GetDataByMsgID();
        }
        public void InvokeByStatus()
        {
            GBLMessageSelectData _prc = new GBLMessageSelectData()
            {
                Columns = this.Columns
            };

            Result = _prc.GetDataByStatus();
        }
        public void InvokeTrash()
        {
            GBLMessageSelectData _prc = new GBLMessageSelectData()
            {
                Columns = this.Columns
            };

            Result = _prc.GetDataTrash();
        }
    }
}
