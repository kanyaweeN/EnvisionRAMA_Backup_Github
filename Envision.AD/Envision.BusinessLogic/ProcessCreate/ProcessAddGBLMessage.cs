using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLMessage : IBusinessLogic
    {
        public int MsgID { get; set; }
        public GBL_MESSAGE Columns { get; set; }

        public ProcessAddGBLMessage()
        {
            Columns = new GBL_MESSAGE();
        }

        public void Invoke()
        {
            GBLMessageInsertData _prc = new GBLMessageInsertData()
            {
                Columns = this.Columns
            };

            MsgID = _prc.Add();
        }
    }
}
