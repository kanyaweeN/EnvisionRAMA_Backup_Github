using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISClinicalIndicationFavorite : IBusinessLogic
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessDeleteRISClinicalIndicationFavorite()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
        }
        public void DeleteAll()
        {
            RISClinicalIndicationFavoriteDeleteData data = new RISClinicalIndicationFavoriteDeleteData();
            data.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            data.DeleteAll();
        }
        public void Invoke()
        {
            RISClinicalIndicationFavoriteDeleteData data = new RISClinicalIndicationFavoriteDeleteData();
            data.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            data.Delete();
        }
    }
}
