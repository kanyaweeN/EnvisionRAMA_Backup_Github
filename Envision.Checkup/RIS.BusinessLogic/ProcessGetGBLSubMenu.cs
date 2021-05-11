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
    public class ProcessGetGBLSubMenu : IBusinessLogic
    {
        private DataSet _resultset;
        private string _uid = "";
        private string _pid = "";
        private int _sp;

        private GBLEnvVariable env = new GBLEnvVariable();
        
        public ProcessGetGBLSubMenu()
        {
        }

        public void Invoke()
        {
            GBLSubMenuSelectData menudata = new GBLSubMenuSelectData();
            ResultSet = menudata.Get(env.OrgID, _uid, _sp, _pid);
        }

        public submenuObjectCollection SelectData()
        {
            try
            {
                GBLSubMenuSelectData menudata = new GBLSubMenuSelectData();
                ResultSet = menudata.Get(env.OrgID, "", 1, "");
                DataTable dt = ResultSet.Tables[0];
                submenuObjectCollection item = new submenuObjectCollection();
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    GBLSubMenu itemValue = new GBLSubMenu();

                    itemValue.MenuID = Convert.ToInt32(dt.Rows[k]["MENU_ID"].ToString());
                    itemValue.MenuUID = (dt.Rows[k]["MENU_UID"].ToString());

                    itemValue.SubMenuAddToHome = (dt.Rows[k]["ADD_TO_HOME"].ToString());
                    itemValue.SubMenuID = Convert.ToInt32(dt.Rows[k]["SUBMENU_ID"].ToString());
                    itemValue.SubMenuUID = (dt.Rows[k]["SUBMENU_UID"].ToString());
                    itemValue.SubMenuType = (dt.Rows[k]["SUBMENU_TYPE"].ToString());
                    itemValue.SubMenuClassName = (dt.Rows[k]["SUBMENU_CLASS_NAME"].ToString());
                    itemValue.SubMenuNameSys = (dt.Rows[k]["SUBMENU_NAME_SYS"].ToString());
                    itemValue.SubMenuNameUser = (dt.Rows[k]["SUBMENU_NAME_USER"].ToString());
                    itemValue.SubMenuParent = Convert.ToInt32(dt.Rows[k]["PARENT"].ToString());
                    itemValue.SubMenuDesc = (dt.Rows[k]["DESCR"].ToString());
                    itemValue.SubMenuSlNo = Convert.ToInt32(dt.Rows[k]["SL_NO"].ToString());
                    itemValue.SubMenuIsActive = (dt.Rows[k]["IS_ACTIVE"].ToString());
                    itemValue.SubMenuCanView = (dt.Rows[k]["CAN_VIEW"].ToString());
                    itemValue.SubMenuCanModify = (dt.Rows[k]["CAN_MODIFY"].ToString());
                    itemValue.SubMenuCanCreate = (dt.Rows[k]["CAN_CREATE"].ToString());
                    itemValue.SubMenuCanRemove = (dt.Rows[k]["CAN_REMOVE"].ToString());

                    /*
                    itemValue.MenuName = (dt.Rows[k]["MENU_NAME"].ToString());
                    itemValue.MenuNameSpace = (dt.Rows[k]["MENU_NAMESPACE"].ToString());
                    itemValue.MenuDesc = (dt.Rows[k]["DESCR"].ToString());
                    itemValue.MenuParent = Convert.ToInt32(dt.Rows[k]["PARENT"].ToString());
                    itemValue.MenuSLNo = Convert.ToInt32(dt.Rows[k]["SL_NO"].ToString());
                    itemValue.MenuIsActive = (dt.Rows[k]["IS_ACTIVE"].ToString());
                     */
                    
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
