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
    public class ProcessGetGBLRole : IBusinessLogic
    {
        private DataSet _resultset;
        private string _uid = "";
        private string _pid = "";
        private int _sp;

        private GBLEnvVariable env = new GBLEnvVariable();
        
        public ProcessGetGBLRole()
        {
        }

        public void Invoke()
        {
            GBLRoleSelectData menudata = new GBLRoleSelectData();
            ResultSet = menudata.Get(env.OrgID, _uid, _sp);
        }

        public roleObjectCollection SelectData()
        {
            try
            {
                GBLRoleSelectData menudata = new GBLRoleSelectData();
                ResultSet = menudata.Get(env.OrgID, "", 1);
                DataTable dt = ResultSet.Tables[0];
                roleObjectCollection item = new roleObjectCollection();
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    GBLRole itemValue = new GBLRole();

                    itemValue.SubMenuID = Convert.ToInt32(dt.Rows[k]["SUBMENU_ID"].ToString());
                    //itemValue.SubMenuUID = (dt.Rows[k]["SUBMENU_UID"].ToString());
                    //itemValue.SubMenuNameUser = (dt.Rows[k]["SUBMENU_NAME_USER"].ToString());

                    //itemValue.ObjectID = Convert.ToInt32(dt.Rows[k]["OBJECT_ID"].ToString());
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
        public DataTable SelectData(int mode)
        {
            try
            {
                GBLRoleSelectData menudata = new GBLRoleSelectData();
                ResultSet = menudata.Get(env.OrgID, "", mode);
                DataTable dt = ResultSet.Tables[0];
                return dt;
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
