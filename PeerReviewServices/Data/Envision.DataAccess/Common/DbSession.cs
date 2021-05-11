using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbSession
    {
        public DbSession()
        {
            dbItem = new GBL_SESSION();
            Item = new Session();
        }

        private GBL_SESSION dbItem { get; set; }
        public Session Item { get; set; }

        public int? LogIn()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_SESSION.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.SESSION_ID;
            }
            return Id;
        }
        public bool? LogOut()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.SESSION_GUID == Item.SessionGuid
                                  select data).FirstOrDefault();
                if (itemSearch != null)
                {
                    itemSearch.SESSION_STAT = Item.Status;
                    itemSearch.LOGOUT_TYPE = Item.LogOutType;
                    itemSearch.LOGOUT_DT = Item.LogOutTimeStamp;
                    itemSearch.LAST_MODIFIED_BY = Item.ModifiedBy;
                    itemSearch.LAST_MODIFIED_ON = Item.ModifiedOn;

                    flag = dbContext.SaveChanges() > 0;
                }
            }

            return flag;
        }
        public bool? KillSession()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_SESSION.Find(Item.Id);
                if (obj != null)
                {
                    obj.KILLED_BY = Item.KilledBy;
                    obj.KILL_REASON = Item.KillReason;
                    obj.LOGOUT_DT = DateTime.Now;
                    obj.LOGOUT_TYPE = "K";

                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;
                    flag = dbContext.SaveChanges() > 0;
                }
            }

            return flag;
        }
        public bool? SaveLog(SessionLog log)
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                GBL_SESSIONLOG item = ConvertType(log);
                item.CREATED_ON = DateTime.Now;

                dbContext.GBL_SESSIONLOG.Add(item);
                flag = dbContext.SaveChanges() > 0;
            }
            return flag;
        }
        public void DeactiveSession(int EmpId)
        {
            using (var dbContext = new EnvisionDataModel())
            {
                dbContext.Database.ExecuteSqlCommand("update GBL_SESSION set SESSION_STAT = 'I', LOGOUT_DT= GETDATE(), LOGOUT_TYPE= 'K', KILL_REASON = 'Clear active session' where SESSION_STAT = 'A' and EMP_ID =" + EmpId.ToString());
            }
        }

        public List<Session> GetAllData()
        {
            List<Session> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Session>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<Session> GetAllActiveData()
        {
            List<Session> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.ORG_ID == Item.OrgId && data.SESSION_STAT == "A"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Session>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public Session GetById()
        {
            Session obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_SESSION.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Session GetByGuid()
        {
            Session obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.SESSION_GUID == Item.SessionGuid
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Session();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public Session GetBySID()
        {
            Session obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.ORG_ID == Item.OrgId
                                        && data.SESSION_GUID == Item.SID
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Session();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public Session GetBySerial()
        {
            Session obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.ORG_ID == Item.OrgId
                                        && data.SERIAL_ == Item.Serial
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Session();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public Session GetByEmpId()
        {
            Session obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SESSION
                                  where data.ORG_ID == Item.OrgId
                                        && data.EMP_ID == Item.EmpId
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Session();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }


        #region Convert Type.
        private GBL_SESSION ConvertType(Session item)
        {
            GBL_SESSION obj = null;
            if (item != null)
            {
                obj = new GBL_SESSION();

                obj.SESSION_ID = item.Id;
                obj.SESSION_STAT = item.Status;
                obj.EMP_ID = item.EmpId;
                obj.SESSION_GUID = item.SessionGuid;
                obj.SID = item.SID;
                obj.SERIAL_ = item.Serial;
                obj.LOGON_TYPE = item.LogOnType;
                obj.LOGON_DT = item.LogOnTimeStamp;
                obj.LOGOUT_DT = item.LogOutTimeStamp;
                obj.LOGOUT_TYPE = item.LogOutType;
                obj.KILLED_BY = item.KilledBy;
                obj.KILL_REASON = item.KillReason;
                obj.OS_USER_NAME = item.OSUserName;
                obj.OS_NAME = item.OSName;
                obj.OS_TIMEZONE = item.OSTimezone;
                obj.OS_REGION = item.OSRegion;
                obj.IP_ADDR_OWN = item.IpAddressOwner;
                obj.IP_ADDR_CURR = item.IpAddressCurrent;
                obj.PROD_VERSION = item.ProductVersion;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Session ConvertType(GBL_SESSION item)
        {
            Session obj = null;
            if (item != null)
            {
                obj = new Session();

                obj.Id = item.SESSION_ID;
                obj.Status = item.SESSION_STAT;
                obj.EmpId = item.EMP_ID;
                obj.SessionGuid = item.SESSION_GUID;
                obj.SID = item.SID;
                obj.Serial = item.SERIAL_;
                obj.LogOnType = item.LOGON_TYPE;
                obj.LogOnTimeStamp = item.LOGON_DT;
                obj.LogOutTimeStamp = item.LOGOUT_DT;
                obj.LogOutType = item.LOGOUT_TYPE;
                obj.KilledBy = item.KILLED_BY;
                obj.KillReason = item.KILL_REASON;
                obj.OSUserName = item.OS_USER_NAME;
                obj.OSName = item.OS_NAME;
                obj.OSTimezone = item.OS_TIMEZONE;
                obj.OSRegion = item.OS_REGION;
                obj.IpAddressOwner = item.IP_ADDR_OWN;
                obj.IpAddressCurrent = item.IP_ADDR_CURR;
                obj.ProductVersion = item.PROD_VERSION;
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }

        private GBL_SESSIONLOG ConvertType(SessionLog item)
        {
            GBL_SESSIONLOG obj = null;
            if (item != null)
            {
                obj = new GBL_SESSIONLOG();

                obj.SESSIONLOG_ID = item.Id;
                obj.SESSION_ID = item.SessionId;
                obj.SESSION_GUID = item.SessionGuid;
                obj.SUBMENU_ID = item.SubMenuId;
                obj.ACCESSED_ON = item.AccessedOn;
                obj.ACCESSED_OUT = item.AccessedOut;
                obj.ACTIVITY_DESC = item.ActivityDesciption;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private SessionLog ConvertType(GBL_SESSIONLOG item)
        {
            SessionLog obj = null;
            if (item != null)
            {
                obj = new SessionLog();

                obj.Id = item.SESSIONLOG_ID;
                obj.SessionId = item.SESSION_ID;
                obj.SessionGuid = item.SESSION_GUID;
                obj.SubMenuId = item.SUBMENU_ID;
                obj.AccessedOn = item.ACCESSED_ON;
                obj.AccessedOut = item.ACCESSED_OUT;
                obj.ActivityDesciption = item.ACTIVITY_DESC;
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }
        #endregion
    }
}