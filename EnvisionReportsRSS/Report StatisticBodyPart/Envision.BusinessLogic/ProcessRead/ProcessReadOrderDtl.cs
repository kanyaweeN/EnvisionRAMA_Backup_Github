using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;
using System.Data;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessReadOrderDtl
    {
        private RISOrderDtlSelectData selecting { get; set; }
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public DataSet Select()
        {
            selecting.RIS_ORDERDTL = this.RIS_ORDERDTL;
            return selecting.Select();
        }
        public DataSet SelectByDateAndModality()
        {
            selecting.RIS_ORDERDTL = this.RIS_ORDERDTL;
            return selecting.SelectByDateAndModality();
        }

    }
}
