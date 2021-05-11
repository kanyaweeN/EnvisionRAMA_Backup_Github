using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGrantObject
    {
        public GBL_GRANTOBJECT GBL_GRANTOBJECT { get; set; }
        private List<GBL_GRANTOBJECT> _grantItem { get; set; }

        public void Invoke()
        {
            foreach (GBL_GRANTOBJECT item in _grantItem)
            {
                GBLGrantObjectUpdateData obj = new GBLGrantObjectUpdateData();
                obj.GBL_GRANTOBJECT = item;
                obj.Get();
            }
        }
    }
}
