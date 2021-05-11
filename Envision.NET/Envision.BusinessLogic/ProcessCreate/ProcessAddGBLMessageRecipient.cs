using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLMessageRecipient : IBusinessLogic
    {
        public GBL_MESSAGERECIPIENT Columns { get; set; }

        public ProcessAddGBLMessageRecipient()
        {
            Columns = new GBL_MESSAGERECIPIENT();
        }

        public void Invoke()
        {
            GBLMessageRecipientInsertData _prc = new GBLMessageRecipientInsertData()
            {
                Columns = this.Columns
            };

            _prc.Add();
        }

        public void InvokeSend()
        {
            GBLMessageRecipientInsertData _prc = new GBLMessageRecipientInsertData()
            {
                Columns = this.Columns
            };

            _prc.AddSend();
        }
    }
}
