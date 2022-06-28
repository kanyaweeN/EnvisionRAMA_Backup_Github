using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessInsertGrantObject
    {
        public GBL_GRANTOBJECT GBL_GRANTOBJECT { get; set; }
        private List<GBL_GRANTOBJECT> _grantItem { get; set; }

        public ProcessInsertGrantObject()
        {
            GBL_GRANTOBJECT = new GBL_GRANTOBJECT();
            _grantItem = new List<GBL_GRANTOBJECT>();
        }
        public void Invoke()
        {
            foreach (GBL_GRANTOBJECT item in _grantItem)
            {
                GBLGrantObjectInsertData obj = new GBLGrantObjectInsertData();
                obj.GBL_GRANTOBJECT = item;
                obj.Get();
            }
        }

    }
}
