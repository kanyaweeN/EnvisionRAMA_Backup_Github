using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLMessageRecipient : IBusinessLogic
    {
        public GBL_MESSAGERECIPIENT Columns { get; set; }

        public ProcessUpdateGBLMessageRecipient()
        {
            Columns = new GBL_MESSAGERECIPIENT();
        }

        public void Invoke()
        {
            GBLMessageRecipientUpdateData _prc = new GBLMessageRecipientUpdateData()
            {
                Columns = this.Columns
            };

            _prc.Update();
        }
        public void UpdateTime() {
            GBLMessageRecipientUpdateData _prc = new GBLMessageRecipientUpdateData();
            _prc.Columns=this.Columns;
            _prc.UpdateTime();
        }
        public void UpdateStar()
        {
            GBLMessageRecipientUpdateData _prc = new GBLMessageRecipientUpdateData();
            _prc.Columns = this.Columns;
            _prc.UpdateStar();
        }
        public void UpdateTrash()
        {
            GBLMessageRecipientUpdateData _prc = new GBLMessageRecipientUpdateData();
            _prc.Columns = this.Columns;
            _prc.UpdateTrash();
        }
    }
}
