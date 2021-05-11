using System;
using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbAlert
    {
        public DbAlert()
        {
            dbItem = new GBL_ALERT();
            Item = new Alert();
            ItemList = new List<AlertItem>();
        }

        private GBL_ALERT dbItem { get; set; }
        public Alert Item { get; set; }
        public List<AlertItem> ItemList { get; set; }


        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                if (ItemList != null && ItemList.Count > 0)
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_ALERT.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.ALT_ID;
                    foreach (var item in ItemList)
                    {
                        item.ParentId = dbItem.ALT_ID;
                        GBL_ALERTDTL obj = ConvertType(item);
                        dbContext.GBL_ALERTDTL.Add(obj);
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
                var obj = dbContext.GBL_ALERT.Find(Item.Id);
                if (obj != null)
                {

                    obj.ALT_ID = Item.Id;
                    obj.ALT_UID = Item.Code;
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
                var itemSearch = (from data in dbContext.GBL_ALERTDTL
                                  where data.ORG_ID == Item.OrgId
                                        && data.ALT_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    foreach (var item in ItemList)
                    {
                        if (item.Id == 0)
                        {
                            var objAdd = ConvertType(item);
                            objAdd.ALT_ID = Item.Id;
                            dbContext.GBL_ALERTDTL.Add(objAdd);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            var objUpdate = dbContext.GBL_ALERTDTL.Find(item.Id);
                            objUpdate.ALT_ID = item.ParentId;
                            objUpdate.LANG_ID = item.LangId;
                            objUpdate.ALT_TEXT = item.Text;
                            objUpdate.ALT_TYPE = item.Type;
                            objUpdate.ALT_TITLE = item.Title;
                            objUpdate.ALT_BUTTON = item.NumberOfButton;
                            objUpdate.CAPTION_BTN1 = item.TextButton1;
                            objUpdate.CAPTION_BTN2 = item.TextButton2;
                            objUpdate.CAPTION_BTN3 = item.TextButton3;
                            objUpdate.DEFAULT_BTN = item.DefaultButton;
                            objUpdate.TIME_SEC = item.TimeSec;
                            objUpdate.IS_ACTIVE = item.IsActive.TryToString();
                            objUpdate.IS_UPDATED = "Y";
                            objUpdate.IS_DELETED = item.IsDelete.TryToString();
                            objUpdate.ORG_ID = Item.OrgId;
                            objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                            objUpdate.LAST_MODIFIED_ON = DateTime.Now;
                            dbContext.SaveChanges();
                        }
                    }

                    foreach (var item in itemSearch)
                    {
                        var element = ItemList.Find(e => e.Id == item.ALT_DTL_ID);
                        if (element != null) continue;


                        var objUpdate = dbContext.GBL_ALERTDTL.Find(item.ALT_DTL_ID);
                        objUpdate.IS_ACTIVE = "N";
                        objUpdate.IS_UPDATED = "Y";
                        objUpdate.IS_DELETED = "Y";
                        objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                        objUpdate.LAST_MODIFIED_ON = DateTime.Now;

                        dbContext.SaveChanges();
                    }
                }
            }
            return flag;
        }
        public bool? Delete()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ALERTDTL
                                  where data.ORG_ID == Item.OrgId
                                        && data.ALT_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    foreach (var item in itemSearch)
                    {
                        var obj = dbContext.GBL_ALERTDTL.Find(item.ALT_DTL_ID);
                        if (obj != null)
                        {
                            dbContext.GBL_ALERTDTL.Remove(obj);
                            dbContext.SaveChanges();
                        }
                    }
                }

                var objParent = dbContext.GBL_ALERT.Find(Item.Id);
                if (objParent != null)
                {
                    dbContext.GBL_ALERT.Remove(objParent);
                    dbContext.SaveChanges();
                }
            }
            return flag;
        }


        public List<Alert> GetAllData()
        {
            List<Alert> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ALERT
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Alert>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<AlertItem> GetItemAllData()
        {
            List<AlertItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ALERTDTL
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<AlertItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public Alert GetById()
        {
            Alert obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_ALERT.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
       
        public List<AlertItem> GetItemById()
        {
            List<AlertItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ALERTDTL
                                  where data.ORG_ID == Item.OrgId && data.ALT_ID == Item.Id 
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<AlertItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<AlertItem> GetItemActiveDataById()
        {
            List<AlertItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ALERTDTL
                                  where data.ORG_ID == Item.OrgId && data.ALT_ID == Item.Id && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<AlertItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public Alert GetByCode()
        {
            Alert obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ALERT
                                  where data.ORG_ID == Item.OrgId
                                        && data.ALT_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Alert();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public List<AlertItem> GetItemByCode()
        {
            List<AlertItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_ALERT
                                  join dtl in dbContext.GBL_ALERTDTL on mas.ALT_ID equals dtl.ALT_ID
                                  where mas.ALT_UID == Item.Code && mas.ORG_ID == Item.OrgId
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<AlertItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<AlertItem> GetItemActiveDataByCode()
        {
            List<AlertItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_ALERT
                                  join dtl in dbContext.GBL_ALERTDTL on mas.ALT_ID equals dtl.ALT_ID
                                  where mas.ALT_UID == Item.Code && mas.ORG_ID == Item.OrgId && dtl.IS_ACTIVE == "Y"
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<AlertItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public AlertItem GetAlertText()
        {
            AlertItem item = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_ALERT
                                  join dtl in dbContext.GBL_ALERTDTL on mas.ALT_ID equals dtl.ALT_ID
                                  where mas.ALT_UID == Item.Code
                                        && mas.ORG_ID == Item.OrgId
                                        && dtl.LANG_ID == Item.LangId
                                        && dtl.IS_ACTIVE == "Y"
                                  select dtl).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    item = new AlertItem();
                    item = ConvertType(itemSearch[0]);
                }
            }
            return item;
        }

        #region Convert Type.
        private GBL_ALERT ConvertType(Alert item)
        {
            GBL_ALERT obj = null;
            if (item != null)
            {
                obj = new GBL_ALERT();

                obj.ALT_ID = item.Id;
                obj.ALT_UID = item.Code;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Alert ConvertType(GBL_ALERT item)
        {
            Alert obj = null;
            if (item != null)
            {
                obj = new Alert();

                obj.Id = item.ALT_ID;
                obj.Code = item.ALT_UID;
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }

        private GBL_ALERTDTL ConvertType(AlertItem item)
        {
            GBL_ALERTDTL obj = null;
            if (item != null)
            {
                obj = new GBL_ALERTDTL();

                obj.ALT_DTL_ID = item.Id;
                obj.ALT_ID = item.ParentId;
                obj.LANG_ID = item.LangId;
                obj.ALT_TEXT = item.Text;
                obj.ALT_TYPE = item.Type;
                obj.ALT_TITLE = item.Title;
                obj.ALT_BUTTON = item.NumberOfButton;
                obj.CAPTION_BTN1 = item.TextButton1;
                obj.CAPTION_BTN2 = item.TextButton2;
                obj.CAPTION_BTN3 = item.TextButton3;
                obj.DEFAULT_BTN = item.DefaultButton;
                obj.TIME_SEC = item.TimeSec;
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
        private AlertItem ConvertType(GBL_ALERTDTL item)
        {
            AlertItem obj = null;
            if (item != null)
            {
                obj = new AlertItem();

                obj.Id = item.ALT_DTL_ID;
                obj.ParentId = item.ALT_ID;
                obj.LangId = item.LANG_ID;
                obj.Text = item.ALT_TEXT;
                obj.Type = item.ALT_TYPE;
                obj.Title = item.ALT_TITLE;
                obj.NumberOfButton = item.ALT_BUTTON;
                obj.TextButton1 = item.CAPTION_BTN1;
                obj.TextButton2 = item.CAPTION_BTN2;
                obj.TextButton3 = item.CAPTION_BTN3;
                obj.DefaultButton = item.DEFAULT_BTN;
                obj.TimeSec = item.TIME_SEC;
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