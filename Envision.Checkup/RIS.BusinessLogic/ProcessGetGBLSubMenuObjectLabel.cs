using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RIS.DataAccess.Select;
using RIS.Common;
using RIS.Common.Common;
//using RIS.Operational;


namespace RIS.BusinessLogic
{
    public class ProcessGetGBLSubMenuObjectLabel : IBusinessLogic
    {
        private DataSet _resultset;
        private string _uid = "";
        private int _pid;
        private int _sp;

        private GBLEnvVariable env = new GBLEnvVariable();
        
        public ProcessGetGBLSubMenuObjectLabel()
        {
        }

        public void Invoke()
        {
            GBLSubMenuObjectLabelSelectData menudata = new GBLSubMenuObjectLabelSelectData();
            ResultSet = menudata.Get(env.OrgID, _uid, _sp, _pid);
        }

        public submenuobjectlabelObjectCollection SelectData()
        {
            try
            {
                GBLSubMenuObjectLabelSelectData menudata = new GBLSubMenuObjectLabelSelectData();
                ResultSet = menudata.Get(env.OrgID, "", 1, 0);
                DataTable dt = ResultSet.Tables[0];
                submenuobjectlabelObjectCollection item = new submenuobjectlabelObjectCollection();
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    GBLSubMenuObjectLabel itemValue = new GBLSubMenuObjectLabel();

                    itemValue.SubMenuID = Convert.ToInt32(dt.Rows[k]["SUBMENU_ID"].ToString());
                    itemValue.SubMenuUID = (dt.Rows[k]["SUBMENU_UID"].ToString());
                    //itemValue.SubMenuNameUser = (dt.Rows[k]["SUBMENU_NAME_USER"].ToString());

                    itemValue.ObjectID = Convert.ToInt32(dt.Rows[k]["OBJECT_ID"].ToString());
                    //itemValue.ObjectName = (dt.Rows[k]["OBJECT_NAME"].ToString());
                    //itemValue.ObjectType = (dt.Rows[k]["OBJECT_TYPE"].ToString());
                    
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

        public int PsID
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
