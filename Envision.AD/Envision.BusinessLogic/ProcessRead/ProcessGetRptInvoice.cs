using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRptInvoice : IBusinessLogic
    {
        public FIN_INVOICE FIN_INVOICE { get; set; }
        private DataSet _resultset;

        public ProcessGetRptInvoice()
        {
            FIN_INVOICE = new FIN_INVOICE();
        }

        public void Invoke()
        {

            RISRptInvoiceSelectData stickerdata = new RISRptInvoiceSelectData();
            stickerdata.FIN_INVOICE = FIN_INVOICE;
            ResultSet = stickerdata.Get();
        }
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
    }
}
