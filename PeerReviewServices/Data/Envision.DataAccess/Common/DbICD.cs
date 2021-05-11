using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbICD
    {
        public DbICD()
        {
            dbItem = new HIS_ICD();
            Item = new ICD();
        }

        private HIS_ICD dbItem { get; set; }
        public ICD Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HIS_ICD.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.ICD_ID;
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HIS_ICD.Find(Item.Id);
                if (obj != null)
                {
                    obj.ICD_UID = Item.Code;
                    obj.ICD_DESC = Item.Description;
                    obj.ICD_VERSION = Item.Version;
                    obj.IS_UPDATED = Item.IsUpdate.TryToString();
                    obj.IS_DELETED = Item.IsDelete.TryToString();
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
                var obj = dbContext.HIS_ICD.Find(Item.Id);
                if (obj != null)
                {
                    obj.IS_DELETED = "Y";
                    obj.IS_UPDATED = "Y";
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<ICD> GetActiveData()
        {
            List<ICD> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_ICD
                                  where data.ORG_ID == Item.OrgId && data.IS_DELETED == "N"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<ICD>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<ICD> GetAll()
        {
            List<ICD> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_ICD
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<ICD>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public ICD GetById()
        {
            ICD obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HIS_ICD.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public ICD GetByCode()
        {
            ICD obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_ICD
                                  where data.ORG_ID == Item.OrgId
                                        && data.ICD_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new ICD();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public List<ICD> GetByVersion()
        {
            List<ICD> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_ICD
                                  where data.ORG_ID == Item.OrgId && data.ICD_VERSION.Contains(Item.Version)
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<ICD>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        #region Convert Type.
        private HIS_ICD ConvertType(ICD item)
        {
            HIS_ICD obj = null;
            if (item != null)
            {
                obj = new HIS_ICD();

                obj.ICD_ID = item.Id;
                obj.ICD_UID = item.Code;
                obj.ICD_DESC = item.Description;
                obj.ICD_VERSION = item.Version;
                obj.IS_UPDATED = item.IsUpdate.TryToString();
                obj.IS_DELETED = item.IsDelete.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private ICD ConvertType(HIS_ICD item)
        {
            ICD obj = null;
            if (item != null)
            {
                obj = new ICD();

                obj.Id = item.ICD_ID;
                obj.Code = item.ICD_UID;
                obj.Description = item.ICD_DESC;
                obj.Version = item.ICD_VERSION;
                obj.IsUpdate = item.IS_UPDATED.TryToBoolean();
                obj.IsDelete = item.IS_DELETED.TryToBoolean();
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