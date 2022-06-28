using System.Data;

using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLMessageRecipient : IBusinessLogic
    {
        public DataSet Result { get; set; }
        public GBL_MESSAGERECIPIENT Columns;

        public ProcessGetGBLMessageRecipient()
        {
            Columns = new GBL_MESSAGERECIPIENT();
        }

        public void Invoke()
        {
            GBLMessageRecipientSelectData _prc = new GBLMessageRecipientSelectData()
            {
                Columns = this.Columns
            };

            Result = _prc.GetData();
        }
        public void InvokeByMsgID()
        {
            GBLMessageRecipientSelectData _prc = new GBLMessageRecipientSelectData()
            {
                Columns = this.Columns
            };

            Result = _prc.GetDataByMsgID();
        }
        public DataTable GetMessage()
        {
            GBLMessageRecipientSelectData _prc = new GBLMessageRecipientSelectData()
            {
                Columns = this.Columns
            };

            return _prc.GetMessage();
        }
    }
}
