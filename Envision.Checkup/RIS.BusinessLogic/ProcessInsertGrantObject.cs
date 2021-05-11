using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessInsertGrantObject
    {

        private List<GBLGrantObject> _grantItem = new List<GBLGrantObject>();

        

        public void Invoke()
        {
            foreach (GBLGrantObject item in _grantItem)
            {
                GBLGrantObjectInsertData obj = new GBLGrantObjectInsertData();
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
