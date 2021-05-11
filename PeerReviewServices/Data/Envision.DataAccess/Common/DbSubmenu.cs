using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.UserForm;

namespace Envision.DataAccess.Common
{
    public class DbSubmenu
    {
        public DbSubmenu(){
            dbItem = new GBL_SUBMENU();
            Item = new Form();
        }

        private GBL_SUBMENU dbItem { get; set; }
        public Form Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_SUBMENU.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.SUBMENU_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_SUBMENU.Find(Item.Id);
                if (obj != null)
                {
                    
                    obj.SUBMENU_ID = Item.Id;
                    obj.SUBMENU_UID = Item.Code;
                    obj.MENU_ID = Item.ParentId;
                    obj.SUBMENU_TYPE = Item.SubmenuType;
                    obj.SUBMENU_CLASS_NAME = Item.ClassMenuName;
                    obj.SUBMENU_NAME_SYS = Item.SystemMenuName;
                    obj.SUBMENU_NAME_USER = Item.UserMenuName;
                    obj.PARENT = Item.Parent;
                    obj.DESCR = Item.Description;
                    obj.SL_NO = Item.SL;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.ADD_TO_HOME = Item.AddToHome.TryToString();
                    obj.CAN_VIEW = Item.CanView.TryToString();
                    obj.CAN_MODIFY = Item.CanModify.TryToString();
                    obj.CAN_REMOVE = Item.CanRemove.TryToString();
                    obj.CAN_CREATE = Item.CanCreate.TryToString();
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
                var obj = dbContext.GBL_SUBMENU.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.GBL_SUBMENU.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Form> GetAllData() {
            List<Form> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SUBMENU
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Form>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public List<Form> GetAllActiveData() {
            List<Form> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SUBMENU
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Form>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public Form GetById() {
            Form obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_SUBMENU.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Form GetByCode() {
            Form obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.GBL_SUBMENU
                                  where data.ORG_ID == Item.OrgId
                                        && data.SUBMENU_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new Form();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private GBL_SUBMENU ConvertType(Form item) {
            GBL_SUBMENU obj = null;
            if (item != null)
            {
                obj = new GBL_SUBMENU();

                obj.SUBMENU_ID = item.Id;
                obj.SUBMENU_UID = item.Code;
                obj.MENU_ID = item.ParentId;
                obj.SUBMENU_TYPE = item.SubmenuType;
                obj.SUBMENU_CLASS_NAME = item.ClassMenuName;
                obj.SUBMENU_NAME_SYS = item.SystemMenuName;
                obj.SUBMENU_NAME_USER = item.UserMenuName;
                obj.PARENT = item.Parent;
                obj.DESCR = item.Description;
                obj.SL_NO = item.SL;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.ADD_TO_HOME = item.AddToHome.TryToString();
                obj.CAN_VIEW = item.CanView.TryToString();
                obj.CAN_MODIFY = item.CanModify.TryToString();
                obj.CAN_REMOVE = item.CanRemove.TryToString();
                obj.CAN_CREATE = item.CanCreate.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Form ConvertType(GBL_SUBMENU item) {
            Form obj = null;
            if (item != null)
            {
                obj = new Form();

                obj.Id = item.SUBMENU_ID;
                obj.Code = item.SUBMENU_UID;
                obj.ParentId = item.MENU_ID;
                obj.SubmenuType = item.SUBMENU_TYPE;
                obj.ClassMenuName = item.SUBMENU_CLASS_NAME;
                obj.SystemMenuName = item.SUBMENU_NAME_SYS;
                obj.UserMenuName = item.SUBMENU_NAME_USER;
                obj.Parent = item.PARENT;
                obj.Description = item.DESCR;
                obj.SL = item.SL_NO;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.AddToHome = item.ADD_TO_HOME.TryToBoolean();
                obj.CanView = item.CAN_VIEW.TryToBoolean();
                obj.CanModify = item.CAN_MODIFY.TryToBoolean();
                obj.CanRemove = item.CAN_REMOVE.TryToBoolean();
                obj.CanCreate = item.CAN_CREATE.TryToBoolean();
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