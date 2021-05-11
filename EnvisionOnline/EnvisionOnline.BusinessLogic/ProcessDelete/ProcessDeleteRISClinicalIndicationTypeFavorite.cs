using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISClinicalIndicationTypeFavorite : IBusinessLogic
    {
        public RIS_CLINICALINDICATIONTYPE RIS_CLINICALINDICATIONTYPE { get; set; }

        public ProcessDeleteRISClinicalIndicationTypeFavorite()
        {
            RIS_CLINICALINDICATIONTYPE = new RIS_CLINICALINDICATIONTYPE();
        }

        public void Invoke()
        {
            RISClinicalIndicationTypeFavoriteDeleteData data = new RISClinicalIndicationTypeFavoriteDeleteData();
            data.RIS_CLINICALINDICATIONTYPE = this.RIS_CLINICALINDICATIONTYPE;
            data.Delete();
        }
    }
}
