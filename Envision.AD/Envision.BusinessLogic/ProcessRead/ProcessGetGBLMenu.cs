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
    public class ProcessGetGBLMenu : IBusinessLogic
    {
        private DataSet _resultset;
        private string _uid = "";
        private int _sp;

        private GBLEnvVariable env = new GBLEnvVariable();
        
        public ProcessGetGBLMenu()
        {
        }

        public void Invoke()
        {
            GBLMenuSelectData menudata = new GBLMenuSelectData();
            ResultSet = menudata.Get(env.OrgID, _uid, _sp);
        }
        public DataSet GetMenuEMP(int EMP_ID) {
            GBLMenuSelectData menudata = new GBLMenuSelectData();
            DataSet ds = new DataSet();
            ds = menudata.Get(EMP_ID);
            return ds;
        }


        public menuObjectCollection SelectData()
        {
            try
            {
                GBLMenuSelectData menudata = new GBLMenuSelectData();
                ResultSet = menudata.Get(env.OrgID, "", 1);
                DataTable dt = ResultSet.Tables[0];
                menuObjectCollection item = new menuObjectCollection();
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    GBL_MENU itemValue = new GBL_MENU();
                    itemValue.MenuID = Convert.ToInt32(dt.Rows[k]["MENU_ID"].ToString());
                    itemValue.MenuUID = (dt.Rows[k]["MENU_UID"].ToString());
                    itemValue.MenuName = (dt.Rows[k]["MENU_NAME"].ToString());
                    itemValue.MenuNameSpace = (dt.Rows[k]["MENU_NAMESPACE"].ToString());
                    itemValue.MenuDesc = (dt.Rows[k]["DESCR"].ToString());
                    itemValue.MenuParent = Convert.ToInt32(dt.Rows[k]["PARENT"].ToString());
                    itemValue.MenuSLNo = Convert.ToInt32(dt.Rows[k]["SL_NO"].ToString());
                    itemValue.MenuIsActive = (dt.Rows[k]["IS_ACTIVE"].ToString());
                    
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

        public int SPType
        {
            get { return _sp; }
            set { _sp = value; }
        }

    }
}
