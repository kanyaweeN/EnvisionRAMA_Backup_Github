using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbExceptionLog
    {
        public DbExceptionLog()
        {
            dbItem = new GBL_EXCEPTIONLOG();
            Item = new ExceptionLog();
        }

        private GBL_EXCEPTIONLOG dbItem { get; set; }
        public ExceptionLog Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_EXCEPTIONLOG.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.EXC_ID;
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_EXCEPTIONLOG.Find(Item.Id);
                if (obj != null)
                {
                    obj.EXC_UID = Item.Code;
                    obj.EXC_TYPE = Item.Type;
                    obj.EXC_TEXT = Item.Text;
                    obj.EXC_IP = Item.IP;
                    obj.EXC_PC_NAME = Item.MachineName;
                    obj.CURRENT_FORM_ID = Item.CurrentFormId;
                    obj.CURRENT_LANG_ID = Item.CurrentLangId;
                    obj.CONNECTED_EMP_ID = Item.ConnectEmpId;
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }
        public bool? Delete()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_EXCEPTIONLOG.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.GBL_EXCEPTIONLOG.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<ExceptionLog> GetAllData()
        {
            List<ExceptionLog> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_EXCEPTIONLOG
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<ExceptionLog>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public ExceptionLog GetById()
        {
            ExceptionLog obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_EXCEPTIONLOG.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public ExceptionLog GetByCode()
        {
            ExceptionLog obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_EXCEPTIONLOG
                                  where data.ORG_ID == Item.OrgId
                                        && data.EXC_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new ExceptionLog();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private GBL_EXCEPTIONLOG ConvertType(ExceptionLog item)
        {
            GBL_EXCEPTIONLOG obj = null;
            if (item != null)
            {
                obj = new GBL_EXCEPTIONLOG();

                obj.EXC_ID = item.Id;
                obj.EXC_UID = item.Code;
                obj.EXC_TYPE = item.Type;
                obj.EXC_TEXT = item.Text;
                obj.EXC_IP = item.IP;
                obj.EXC_PC_NAME = item.MachineName;
                obj.CURRENT_FORM_ID = item.CurrentFormId;
                obj.CURRENT_LANG_ID = item.CurrentLangId;
                obj.CONNECTED_EMP_ID = item.ConnectEmpId;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private ExceptionLog ConvertType(GBL_EXCEPTIONLOG item)
        {
            ExceptionLog obj = null;
            if (item != null)
            {
                obj = new ExceptionLog();

                obj.Id = item.EXC_ID;
                obj.Code = item.EXC_UID;
                obj.Type = item.EXC_TYPE;
                obj.Text = item.EXC_TEXT;
                obj.IP = item.EXC_IP;
                obj.MachineName = item.EXC_PC_NAME;
                obj.CurrentFormId = item.CURRENT_FORM_ID;
                obj.CurrentLangId = item.CURRENT_LANG_ID;
                obj.ConnectEmpId = item.CONNECTED_EMP_ID;
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