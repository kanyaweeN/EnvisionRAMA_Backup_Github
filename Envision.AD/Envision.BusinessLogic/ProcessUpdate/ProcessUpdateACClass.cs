using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateACClass
    {
         public  AC_CLASS AC_CLASS { get; set; }

         public ProcessUpdateACClass()
        {
            AC_CLASS = new AC_CLASS();
        }

        public void Invoke()
        {
            ACClassUpdateData _update = new ACClassUpdateData();
            _update.AC_CLASS = this.AC_CLASS;
            _update.Update();
        }
    }
}
