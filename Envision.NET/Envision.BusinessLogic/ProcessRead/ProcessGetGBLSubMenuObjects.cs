using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLSubMenuObjects : IBusinessLogic
    {
        private DataSet _resultset;
        private string _uid = "";
        private string _pid = "";
        private int _sp;

        private GBLEnvVariable env = new GBLEnvVariable();
        
        public ProcessGetGBLSubMenuObjects()
        {
        }

        public void Invoke()
        {
            GBLSubMenuObjectsSelectData menudata = new GBLSubMenuObjectsSelectData();
            ResultSet = menudata.Get(env.OrgID, _uid, _sp);
        }

        public submenuobjectsObjectCollection SelectData()
        {
            try
            {
                GBLSubMenuObjectsSelectData menudata = new GBLSubMenuObjectsSelectData();
                ResultSet = menudata.Get(env.OrgID, "", 1);
                DataTable dt = ResultSet.Tables[0];
                submenuobjectsObjectCollection item = new submenuobjectsObjectCollection();
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    GBL_SUBMENUOBJECT itemValue = new GBL_SUBMENUOBJECT();

                    itemValue.SUBMENU_ID = Convert.ToInt32(dt.Rows[k]["SUBMENU_ID"].ToString());
                    itemValue.SubMenuUID = (dt.Rows[k]["SUBMENU_UID"].ToString());
                    itemValue.SubMenuNameUser = (dt.Rows[k]["SUBMENU_NAME_USER"].ToString());

                    itemValue.OBJECT_ID = Convert.ToInt32(dt.Rows[k]["OBJECT_ID"].ToString());
                    itemValue.OBJECT_NAME = (dt.Rows[k]["OBJECT_NAME"].ToString());
                    itemValue.OBJECT_TYPE = (dt.Rows[k]["OBJECT_TYPE"].ToString());
                    
                    item.Add(itemValue);
                    k++;

                }


                return item;
            }
            catch (Exception ex)
            {
                throw ex;
                
                //elog.LogException(ex.ToString(), 1, "F");
            }

        }

        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public string UsID
        {
            get { return _uid; }
            set { _uid = value; }
        }

        public string PsID
        {
            get { return _pid; }
            set { _pid = value; }
        }

        public int SPType
        {
            get { return _sp; }
            set { _sp = value; }
        }

    }
}
