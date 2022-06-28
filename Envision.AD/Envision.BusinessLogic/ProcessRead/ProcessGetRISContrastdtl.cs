using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISContrastdtl
    {
        public RIS_CONTRASTDTL RIS_CONTRASTDTL { get; set; }
        private DataSet _resultset;

        public ProcessGetRISContrastdtl()
        {
            RIS_CONTRASTDTL = new RIS_CONTRASTDTL();
        }
        public DataSet GetData()
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            return contrast.GetData();
        }
        public DataSet GetDataByOrderId()
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            contrast.RIS_CONTRASTDTL = RIS_CONTRASTDTL;
            return contrast.GetDataByOrderId();
        }
        public DataSet GetDataByScheduleId()
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            contrast.RIS_CONTRASTDTL = RIS_CONTRASTDTL;
            return contrast.GetDataByScheduleId();
        }
        public DataSet GetDataByDate(DateTime dateFrom,DateTime dateTo)
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            return contrast.GetDataByDate(dateFrom,dateTo);
        }
        public DataSet GetReactionData()
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            return contrast.GetReactionData();
        }
        public DataSet GetDataByRegId(int regId)
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            return contrast.GetDataByRegId(regId);
        }
        public DataSet GetDataByHN(string hn)
        {
            RISContrastDtlSelectData contrast = new RISContrastDtlSelectData();
            return contrast.GetDataByHN(hn);
        }
    }
}