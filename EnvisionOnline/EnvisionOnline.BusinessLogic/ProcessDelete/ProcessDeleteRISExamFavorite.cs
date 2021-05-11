using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using EnvisionOnline.DataAccess.Delete;

namespace EnvisionOnline.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISExamFavorite : IBusinessLogic
    {
        public RIS_EXAMFAVORITE RIS_EXAMFAVORITE { get; set; }

        public ProcessDeleteRISExamFavorite()
        {
            RIS_EXAMFAVORITE = new RIS_EXAMFAVORITE();
        }

        public void Invoke()
        {
            RISExamFavoriteDeleteData _proc = new RISExamFavoriteDeleteData();
            _proc.RIS_EXAMFAVORITE = RIS_EXAMFAVORITE;
            _proc.Delete();
        }
    }
}

