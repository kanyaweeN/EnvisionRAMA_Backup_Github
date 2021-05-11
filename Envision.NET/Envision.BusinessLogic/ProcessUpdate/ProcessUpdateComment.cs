using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.DataAccess.Update;
using System.Data.Common;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateComment : IBusinessLogic
    {
        public int COMMENT_ID { get; set; }
        public int EMP_ID { get; set; }
        public int MODE { get; set; }
        public string Result { get; set; }
        public DbTransaction Transaction { get; set; }
        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_COMMENT_UPDATE processor = new RIS_COMMENT_UPDATE();
            processor.COMMENT_ID = COMMENT_ID;
            processor.EMP_ID = EMP_ID;
            processor.MODE = MODE;
            if (MODE == 3)
            {
                processor.UpdateTrashComment();
                Result = processor.Result;
            }
            else
            {
                if (Transaction == null)
                    processor.UpdateComment();
                else
                    processor.UpdateComment(this.Transaction);
            }
        }

        #endregion
    }
}
