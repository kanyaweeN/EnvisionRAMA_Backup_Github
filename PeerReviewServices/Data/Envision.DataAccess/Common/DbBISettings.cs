using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbBISettings
    {
        public DbBISettings()
        {
            dbItem = new GBL_BISETTINGS();
            Item = new BISettings();
        }

        private GBL_BISETTINGS dbItem { get; set; }
        public BISettings Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_BISETTINGS.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.BISETTINGS_ID;
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_BISETTINGS.Find(Item.Id);
                if (obj != null)
                {
                    obj.EMP_ID = Item.EmpId;
                    obj.BI_NAME = Item.Name;
                    obj.BI_DESC = Item.Description;
                    obj.BI_TAG = Item.Tag;
                    obj.IS_GLOBAL = Item.IsGlobal.TryToString();
                    obj.BI_FIELD_ORDER = Item.OrderField;
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
                var obj = dbContext.GBL_BISETTINGS.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.GBL_BISETTINGS.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<BISettings> GetAllData()
        {
            List<BISettings> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_BISETTINGS
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<BISettings>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public BISettings GetById()
        {
            BISettings obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_BISETTINGS.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public List<BISettings> GetByEmpId()
        {
            List<BISettings> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_BISETTINGS
                                  where data.ORG_ID == Item.OrgId && data.EMP_ID == Item.EmpId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<BISettings>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<BISettings> GetByEmpIdAndTag()
        {
            List<BISettings> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_BISETTINGS
                                  where data.ORG_ID == Item.OrgId && data.EMP_ID == Item.EmpId && data.BI_TAG.Contains(Item.Tag)
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<BISettings>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<BISettings> GetByTag()
        {
            List<BISettings> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_BISETTINGS
                                  where data.ORG_ID == Item.OrgId && data.BI_TAG.Contains(Item.Tag)
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<BISettings>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        #region Convert Type.
        private GBL_BISETTINGS ConvertType(BISettings item)
        {
            GBL_BISETTINGS obj = null;
            if (item != null)
            {
                obj = new GBL_BISETTINGS();

                obj.BISETTINGS_ID = item.Id;
                obj.EMP_ID = item.EmpId;
                obj.BI_NAME = item.Name;
                obj.BI_DESC = item.Description;
                obj.BI_TAG = item.Tag;
                obj.IS_GLOBAL = item.IsGlobal.TryToString();
                obj.BI_FIELD_ORDER = item.OrderField;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private BISettings ConvertType(GBL_BISETTINGS item)
        {
            BISettings obj = null;
            if (item != null)
            {
                obj = new BISettings();

                obj.Id = item.BISETTINGS_ID;
                obj.EmpId = item.EMP_ID;
                obj.Name = item.BI_NAME;
                obj.Description = item.BI_DESC;
                obj.Tag = item.BI_TAG;
                obj.IsGlobal = item.IS_GLOBAL.TryToBoolean();
                obj.OrderField = item.BI_FIELD_ORDER;
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