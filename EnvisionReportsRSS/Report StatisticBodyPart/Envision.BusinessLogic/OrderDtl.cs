using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class OrderDtl
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }
        public OrderDtl()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
        }
        public DataSet Select()
        {
            ProcessReadOrderDtl procRead = new ProcessReadOrderDtl();
            procRead.RIS_ORDERDTL = this.RIS_ORDERDTL;
            return procRead.Select();
        }
        public DataSet SelectByDateAndModality(DateTime date_start,DateTime date_end,int MODALITY_ID)
        {
            ProcessReadOrderDtl procRead = new ProcessReadOrderDtl();
            procRead.RIS_ORDERDTL = this.RIS_ORDERDTL;
            procRead.RIS_ORDERDTL.EXAM_DT = date_start;
            procRead.RIS_ORDERDTL.EXAM_DT = date_end;
            procRead.RIS_ORDERDTL.MODALITY_ID = MODALITY_ID;
            return procRead.SelectByDateAndModality();
        }

    }
}
