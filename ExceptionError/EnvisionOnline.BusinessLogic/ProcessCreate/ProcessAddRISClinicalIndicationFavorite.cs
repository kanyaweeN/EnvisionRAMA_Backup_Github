using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISClinicalIndicationFavorite : IBusinessLogic
    {
        public RIS_CLINICALINDICATION RIS_CLINICALINDICATION { get; set; }

        public ProcessAddRISClinicalIndicationFavorite()
        {
            RIS_CLINICALINDICATION = new RIS_CLINICALINDICATION();
        }

        public void Invoke()
        {
            RISClinicalIndicationFavoriteInsertData insert = new RISClinicalIndicationFavoriteInsertData();
            insert.RIS_CLINICALINDICATION = this.RIS_CLINICALINDICATION;
            insert.Insert();
        }
    }
}
