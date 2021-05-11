using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLMessage : IBusinessLogic
    {
        public GBL_MESSAGE Columns { get; set; }

        public ProcessUpdateGBLMessage()
        {
            Columns = new GBL_MESSAGE();
        }

        public void Invoke()
        {
            GBLMessageUpdateData _prc = new GBLMessageUpdateData()
            {
                Columns = this.Columns
            };

            _prc.Update();
        }
        public void InvokeStar()
        {
            GBLMessageUpdateData _prc = new GBLMessageUpdateData()
            {
                Columns = this.Columns
            };

            _prc.UpdateStar();
        }
        public void InvokeTrash()
        {
            GBLMessageUpdateData _prc = new GBLMessageUpdateData()
            {
                Columns = this.Columns
            };

            _prc.UpdateTrash();
        }
    }
}
