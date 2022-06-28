using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISOrderimages : IBusinessLogic
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

        public ProcessAddRISOrderimages() { RIS_ORDERIMAGE = new RIS_ORDERIMAGE(); }

        public void Invoke()
        {
            RISOrderimagesInsertData prc = new RISOrderimagesInsertData();
            prc.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
            prc.Add();
        }
    }
}