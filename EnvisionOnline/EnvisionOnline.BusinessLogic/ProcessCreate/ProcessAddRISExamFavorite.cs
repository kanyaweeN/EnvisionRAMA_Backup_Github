using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Insert;

namespace EnvisionOnline.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamFavorite : IBusinessLogic
    {
        public RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }

        public ProcessAddRISExamFavorite()
        {
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
        }

        public void Invoke()
        {
            RISExamFavoriteInsertData insert = new RISExamFavoriteInsertData();
            insert.RIS_EXAMFAVORITE = this.RIS_EXAMFAVORITE;
            insert.Add();
        }
    }
}
