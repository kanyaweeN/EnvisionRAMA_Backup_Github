using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbGeneral
    {
        public DbGeneral()
        {
            dbItem = new GBL_GENERAL();
            Item = new General();
            ItemList = new List<GeneralItem>();
        }

        private GBL_GENERAL dbItem { get; set; }
        public General Item { get; set; }
        public List<GeneralItem> ItemList { get; set; }


        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                if (ItemList != null && ItemList.Count > 0)
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_GENERAL.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.GEN_ID;
                    foreach (var item in ItemList)
                    {
                        item.ParentId = dbItem.GEN_ID;
                        GBL_GENERALDTL obj = ConvertType(item);
                        dbContext.GBL_GENERALDTL.Add(obj);
                        dbContext.SaveChanges();
                    }
                }
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_GENERAL.Find(Item.Id);
                if (obj != null)
                {
                    obj.GEN_UID = Item.Code;
                    obj.GEN_TYPE = Item.Type;
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }

                var itemSearch = (from data in dbContext.GBL_GENERALDTL
                                  where data.ORG_ID == Item.OrgId
                                        && data.GEN_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    foreach (var item in ItemList)
                    {
                        if (item.Id == 0)
                        {
                            var objAdd = ConvertType(item);
                            objAdd.GEN_ID = Item.Id;
                            dbContext.GBL_GENERALDTL.Add(objAdd);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            var objUpdate = dbContext.GBL_GENERALDTL.Find(item.Id);
                            objUpdate.GEN_ID = item.ParentId;
                            objUpdate.LANG_ID = item.LangId;
                            objUpdate.GEN_TEXT = item.Text;
                            objUpdate.GEN_TITLE = item.Title;
                            objUpdate.IS_ACTIVE = item.IsActive.TryToString();
                            objUpdate.IS_UPDATED = item.IsUpdate.TryToString();
                            objUpdate.IS_DELETED = item.IsDelete.TryToString();
                            objUpdate.ORG_ID = Item.OrgId;
                            objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                            objUpdate.LAST_MODIFIED_ON = DateTime.Now;

                            dbContext.SaveChanges();
                        }
                    }
                }
                foreach (var item in itemSearch)
                {
                    var element = ItemList.Find(e => e.Id == item.GEN_DTL_ID);
                    if (element != null) continue;

                    var objUpdate = dbContext.GBL_GENERALDTL.Find(item.GEN_DTL_ID);
                    objUpdate.IS_ACTIVE = "N";
                    objUpdate.IS_UPDATED = "Y";
                    objUpdate.IS_DELETED = "Y";
                    objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                    objUpdate.LAST_MODIFIED_ON = DateTime.Now;

                    dbContext.SaveChanges();
                }
            }
            return flag;
        }
        public bool? Delete()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GENERALDTL
                                  where data.ORG_ID == Item.OrgId
                                        && data.GEN_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    foreach (var item in itemSearch)
                    {
                        var obj = dbContext.GBL_GENERALDTL.Find(item.GEN_DTL_ID);
                        if (obj != null)
                        {
                            dbContext.GBL_GENERALDTL.Remove(obj);
                            dbContext.SaveChanges();
                        }
                    }
                }

                var objParent = dbContext.GBL_GENERAL.Find(Item.Id);
                if (objParent != null)
                {
                    dbContext.GBL_GENERAL.Remove(objParent);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }


        public List<General> GetAllData()
        {
            List<General> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GENERAL
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<General>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<GeneralItem> GetItemAllData()
        {
            List<GeneralItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GENERALDTL
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<GeneralItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public General GetById()
        {
            General obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_GENERAL.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public List<GeneralItem> GetItemById()
        {
            List<GeneralItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GENERALDTL
                                  where data.ORG_ID == Item.OrgId && data.GEN_ID == Item.Id 
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GeneralItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<GeneralItem> GetItemActiveDataById()
        {
            List<GeneralItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GENERALDTL
                                  where data.ORG_ID == Item.OrgId && data.GEN_ID == Item.Id && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GeneralItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public General GetByCode()
        {
            General obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GENERAL
                                  where data.ORG_ID == Item.OrgId
                                        && data.GEN_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new General();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public List<GeneralItem> GetItemByCode()
        {
            List<GeneralItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_GENERAL
                                  join dtl in dbContext.GBL_GENERALDTL on mas.GEN_ID equals dtl.GEN_ID
                                  where mas.GEN_UID == Item.Code && mas.ORG_ID == Item.OrgId
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GeneralItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<GeneralItem> GetItemActiveDataByCode()
        {
            List<GeneralItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_GENERAL
                                  join dtl in dbContext.GBL_GENERALDTL on mas.GEN_ID equals dtl.GEN_ID
                                  where mas.GEN_UID == Item.Code && mas.ORG_ID == Item.OrgId && dtl.IS_ACTIVE == "Y"
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GeneralItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public GeneralItem GetItemText()
        {
            GeneralItem item = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_GENERAL
                                  join dtl in dbContext.GBL_GENERALDTL on mas.GEN_ID equals dtl.GEN_ID
                                  where mas.GEN_UID == Item.Code
                                        && mas.ORG_ID == Item.OrgId
                                        && dtl.LANG_ID == Item.LangId
                                        && dtl.IS_ACTIVE == "Y"
                                  select dtl).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    item = new GeneralItem();
                    item = ConvertType(itemSearch[0]);
                }
            }
            return item;
        }

        #region Convert Type.
        private GBL_GENERAL ConvertType(General item)
        {
            GBL_GENERAL obj = null;
            if (item != null)
            {
                obj = new GBL_GENERAL();

                obj.GEN_ID = item.Id;
                obj.GEN_UID = item.Code;
                obj.GEN_TYPE = item.Type;
                obj.ORG_ID = Item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private General ConvertType(GBL_GENERAL item)
        {
            General obj = null;
            if (item != null)
            {
                obj = new General();

                obj.Id = item.GEN_ID;
                obj.Code = item.GEN_UID;
                obj.Type = item.GEN_TYPE;
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }

        private GBL_GENERALDTL ConvertType(GeneralItem item)
        {
            GBL_GENERALDTL obj = null;
            if (item != null)
            {
                obj = new GBL_GENERALDTL();

                obj.GEN_DTL_ID = item.Id;
                obj.GEN_ID = item.ParentId;
                obj.LANG_ID = item.LangId;
                obj.GEN_TEXT = item.Text;
                obj.GEN_TITLE = item.Title;
                obj.IS_ACTIVE = item.IsActive.TryToString();
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
        private GeneralItem ConvertType(GBL_GENERALDTL item)
        {
            GeneralItem obj = null;
            if (item != null)
            {
                obj = new GeneralItem();

                obj.Id = item.GEN_DTL_ID;
                obj.ParentId = item.GEN_ID;
                obj.LangId = item.LANG_ID;
                obj.Text = item.GEN_TEXT;
                obj.Title = item.GEN_TITLE;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
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