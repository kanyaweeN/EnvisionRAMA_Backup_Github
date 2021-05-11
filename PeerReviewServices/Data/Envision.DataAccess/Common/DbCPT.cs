using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbCPT
    {
        public DbCPT(){
            dbItem = new HIS_CPT();
            Item = new CPT();
        }

        private HIS_CPT dbItem { get; set; }
        public CPT Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HIS_CPT.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.CPT_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HIS_CPT.Find(Item.Id);
                if (obj != null)
                {
                    obj.CPT_UID = Item.Code;
                    obj.CPT_DESC = Item.Description;
                    obj.CPT_VERSION = Item.Version;
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
        public bool? Delete() {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HIS_CPT.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.HIS_CPT.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }
        
        public List<CPT> GetAllData()
        {
            List<CPT> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_CPT
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<CPT>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public List<CPT> GetActiveData()
        {
            List<CPT> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_CPT
                                  where data.ORG_ID == Item.OrgId && data.IS_DELETED == "N"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<CPT>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public CPT GetById() {
            CPT obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HIS_CPT.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public CPT GetByCode() {
            CPT obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.HIS_CPT
                                  where data.ORG_ID == Item.OrgId
                                        && data.CPT_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new CPT();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private HIS_CPT ConvertType(CPT item) {
            HIS_CPT obj = null;
            if (item != null)
            {
                obj = new HIS_CPT();

                obj.CPT_ID = item.Id;
                obj.CPT_UID = item.Code;
                obj.CPT_DESC = item.Description;
                obj.CPT_VERSION = item.Version;
                obj.IS_UPDATED = item.IsUpdate.TryToString();
                obj.IS_DELETED = item.IsDelete.TryToString();
                obj.ORG_ID = Item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private CPT ConvertType(HIS_CPT item) {
            CPT obj = null;
            if (item != null)
            {
                obj = new CPT();

                obj.Id = item.CPT_ID;
                obj.Code = item.CPT_UID;
                obj.Description = item.CPT_DESC;
                obj.Version = item.CPT_VERSION;
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