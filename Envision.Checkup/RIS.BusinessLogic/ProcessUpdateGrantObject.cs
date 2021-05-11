using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGrantObject
    {
        private List<GBLGrantObject> _grantItem = new List<GBLGrantObject>();



        public void Invoke()
        {
            foreach (GBLGrantObject item in _grantItem)
            {
                GBLGrantObjectUpdateData obj = new GBLGrantObjectUpdateData();
                obj.GrantItem = item;
                obj.Get();
            }
        }

        public List<GBLGrantObject> GrantItem
        {
            get { return _grantItem; }
            set { _grantItem = value; }
        }
    }
}
