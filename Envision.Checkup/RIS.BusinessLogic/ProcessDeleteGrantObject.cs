using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGrantObject:IBusinessLogic
    {
        #region IBusinessLogic Members

        private List<String> _delObj = new List<string>();

        

        public void Invoke()
        {
            foreach (string item in _delObj)
            {
                GBLGrantObjectDeleteData obj = new GBLGrantObjectDeleteData();
                obj.GrantId = item;
                obj.Get();
            }
        }

        public List<String> DeleteItem
        {
            get { return _delObj; }
            set { _delObj = value; }
        }

        #endregion
    }
}
