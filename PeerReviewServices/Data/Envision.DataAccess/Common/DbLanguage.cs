using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbLanguage
    {
        public DbLanguage(){
            dbItem = new GBL_LANGUAGE();
            Item = new Language();
        }

        private GBL_LANGUAGE dbItem { get; set; }
        public Language Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_LANGUAGE.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.LANG_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_LANGUAGE.Find(Item.Id);
                if (obj != null)
                {
                    obj.LANG_UID = Item.Code;
                    obj.LANG_NAME = Item.Name;
                    obj.IS_DEFAULT = Item.IsDefault;
                    obj.IS_ACTIVE = Item.IsActive;
                    obj.IS_UPDATED = "Y";
                    obj.IS_DELETED = Item.IsDelete;
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
                var obj = dbContext.GBL_LANGUAGE.Find(Item.Id);
                if (obj != null)
                {
                    obj.IS_ACTIVE = "N";
                    obj.IS_UPDATED = "Y";
                    obj.IS_DELETED = "Y";
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Language> GetAllValidData()
        {
            List<Language> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_LANGUAGE
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" 
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Language>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<Language> GetAll() {
            List<Language> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_LANGUAGE
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Language>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public Language GetById() {
            Language obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_LANGUAGE.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Language GetByCode() {
            Language obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.GBL_LANGUAGE
                                  where data.ORG_ID == Item.OrgId
                                        && data.LANG_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new Language();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private GBL_LANGUAGE ConvertType(Language item) {
            GBL_LANGUAGE obj = null;
            if (item != null)
            {
                obj = new GBL_LANGUAGE();

                obj.LANG_ID = item.Id;
                obj.LANG_UID = item.Code;
                obj.LANG_NAME = item.Name;
                obj.IS_DEFAULT = item.IsDefault;
                obj.IS_ACTIVE = item.IsActive;
                obj.IS_UPDATED = item.IsUpdate;
                obj.IS_DELETED = item.IsDelete;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Language ConvertType(GBL_LANGUAGE item) {
            Language obj = null;
            if (item != null)
            {
                obj = new Language();

                obj.Id = item.LANG_ID;
                obj.Code = item.LANG_UID;
                obj.Name = item.LANG_NAME;
                obj.IsDefault = item.IS_DEFAULT;
                obj.IsActive = item.IS_ACTIVE;
                obj.IsUpdate = item.IS_UPDATED;
                obj.IsDelete = item.IS_DELETED;
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