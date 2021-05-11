using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Update;

namespace EnvisionOnline.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISExamFavorite: IBusinessLogic
    {
        public RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }

        public ProcessUpdateRISExamFavorite()
        {
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
        }

        public void Invoke()
        {
            RISExamFavoriteUpdateData update = new RISExamFavoriteUpdateData();
            update.RIS_EXAMFAVORITE = this.RIS_EXAMFAVORITE;
            update.update();
        }
    }
}
