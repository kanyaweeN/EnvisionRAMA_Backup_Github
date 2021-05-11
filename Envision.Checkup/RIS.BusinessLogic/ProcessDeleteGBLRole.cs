using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLRole : IBusinessLogic
    {
        private GBLRole _gblrole;

        private List<string> _delObjects = new List<string>();

        public ProcessDeleteGBLRole()
        {

        }

        public void Invoke()
        {
            foreach (string item in _delObjects)
            {
                GBLRoleDeleteData menudata = new GBLRoleDeleteData();
                menudata.ObjectId = item;
                //menudata.GBLRole = item;
                menudata.Delete();
            }
            
        }

        public GBLRole GBLRole
        {
            get { return _gblrole; }
            set { _gblrole = value; }
        }

        public List<string> DeleteItem
        {
            get { return _delObjects; }
            set { _delObjects = value; }
        }
    }
}
