using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.UserForm;

namespace Envision.DataAccess.Common
{
    public class DbUserForm
    {
        public DbUserForm()
        {
            dbItem = new GBL_MENU();
            Item = new Module();
            ItemList = new List<Form>();
        }

        private GBL_MENU dbItem { get; set; }
        public Module Item { get; set; }
        public List<Form> ItemList { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                if (ItemList != null && ItemList.Count > 0)
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_MENU.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.MENU_ID;
                    foreach (var item in ItemList)
                    {
                        item.ParentId = dbItem.MENU_ID;
                        var obj = ConvertType(item);
                        dbContext.GBL_SUBMENU.Add(obj);
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
                var obj = dbContext.GBL_MENU.Find(Item.Id);
                if (obj != null)
                {
                    obj.MENU_UID = Item.Code;
                    obj.MENU_NAME = Item.Name;
                    obj.MENU_NAMESPACE = Item.Namespace;
                    obj.MENU_ICON = Item.Icon;
                    obj.DESCR = Item.Description;
                    obj.PARENT = Item.Parent;
                    obj.SL_NO = Item.SL;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }


                 var itemSearch = (from data in dbContext.GBL_SUBMENU
                                  where data.ORG_ID == Item.OrgId
                                        && data.MENU_ID == Item.Id
                                  select data).ToList();
                 if (itemSearch != null && itemSearch.Count > 0)
                 {
                     foreach (var item in ItemList)
                     {
                         if (item.Id == 0)
                         {
                             var objAdd = ConvertType(item);
                             objAdd.MENU_ID = Item.Id;
                             dbContext.GBL_SUBMENU.Add(objAdd);
                             dbContext.SaveChanges();
                         }
                         else
                         {
                             var objUpdate = dbContext.GBL_SUBMENU.Find(item.Id);
                             objUpdate.SUBMENU_UID = item.Code;
                             objUpdate.MENU_ID = item.ParentId;
                             objUpdate.SUBMENU_TYPE = item.SubmenuType;
                             objUpdate.SUBMENU_CLASS_NAME = item.ClassMenuName;
                             objUpdate.SUBMENU_NAME_SYS = item.SystemMenuName;
                             objUpdate.SUBMENU_NAME_USER = item.UserMenuName;
                             objUpdate.PARENT = item.Parent;
                             objUpdate.DESCR = item.Description;
                             objUpdate.SL_NO = item.SL;
                             objUpdate.IS_ACTIVE = item.IsActive.TryToString();
                             objUpdate.ADD_TO_HOME = item.AddToHome.TryToString();
                             objUpdate.CAN_VIEW = item.CanView.TryToString();
                             objUpdate.CAN_MODIFY = item.CanModify.TryToString();
                             objUpdate.CAN_REMOVE = item.CanRemove.TryToString();
                             objUpdate.CAN_CREATE = item.CanCreate.TryToString();
                             objUpdate.ORG_ID = item.OrgId;
                             objUpdate.LAST_MODIFIED_BY = item.ModifiedBy;
                             objUpdate.LAST_MODIFIED_ON = DateTime.Now;

                             dbContext.SaveChanges();
                         }
                     }
                 }
                 foreach (var item in itemSearch)
                 {
                     var element = ItemList.Find(e => e.Id == item.SUBMENU_ID);
                     if (element != null) continue;

                     var objUpdate = dbContext.GBL_SUBMENU.Find(item.SUBMENU_ID);
                     objUpdate.IS_ACTIVE = "N";
                     objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                     objUpdate.LAST_MODIFIED_ON = DateTime.Now;

                     dbContext.SaveChanges();
                 }
            }
            return flag;
        }
        public bool? DeleteModule()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_MENU.Find(Item.Id);
                if (obj != null)
                {
                    obj.IS_ACTIVE = "N";
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Module> GetModuleAllData()
        {
            List<Module> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_MENU
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Module>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<Module> GetModuleAllActiveData()
        {
            List<Module> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_MENU
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Module>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public Module GetModuleById()
        {
            Module obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_MENU.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Module GetModuleByCode()
        {
            Module obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_MENU
                                  where data.ORG_ID == Item.OrgId
                                        && data.MENU_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Module();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }


        public List<Form> GetFormAllData()
        {
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
        public List<Form> GetFormAllActiveData()
        {
            List<Form> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SUBMENU
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
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
        public Form GetFormById()
        {
            Form obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_SUBMENU.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Form GetFormByCode()
        {
            Form obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SUBMENU
                                  where data.ORG_ID == Item.OrgId
                                        && data.SUBMENU_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Form();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        public List<Module> GetModuleByUserId(int userId)
        {
            List<Module> lst = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var query = (from grant in dbContext.GBL_GRANTROLE
                             join role in dbContext.GBL_ROLEDTL on grant.ROLE_ID equals role.ROLE_ID
                             join form in dbContext.GBL_SUBMENU on role.SUBMENU_ID equals form.SUBMENU_ID
                             join module in dbContext.GBL_MENU on form.MENU_ID equals module.MENU_ID
                             where grant.EMP_ID == userId
                               && form.IS_ACTIVE == "Y"
                               && module.IS_ACTIVE == "Y"
                             orderby module.SL_NO
                             select new Module()
                             {
                                 Id = module.MENU_ID,
                                 Code = module.MENU_UID,
                                 Name = module.MENU_NAME,
                                 Namespace  = module.MENU_NAMESPACE,
                                 Description = module.DESCR,
                                 Parent = module.PARENT,
                                 SL = module.SL_NO,
                                 IsActive = true
                             }).Distinct().ToList();

                var itemSearch = query.Distinct().ToList();
                if (itemSearch != null)
                {
                    itemSearch = itemSearch.OrderBy(x => x.SL).ToList();
                    lst = new List<Module>();
                    foreach (var obj in itemSearch)
                        lst.Add(obj);
                }
            }
            return lst;
        }
        public List<Form> GetFormByUserId(int userId)
        {
            List<Form> lst = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from grant in dbContext.GBL_GRANTROLE
                                  join role in dbContext.GBL_ROLEDTL on grant.ROLE_ID equals role.ROLE_ID 
                                  join form in dbContext.GBL_SUBMENU on role.SUBMENU_ID equals form.SUBMENU_ID
                                  where grant.EMP_ID == userId 
                                    && form.IS_ACTIVE == "Y"
                                  select  form).Distinct().ToList();
                if (itemSearch != null)
                {
                    lst = new List<Form>();
                    foreach (var obj in itemSearch)
                        lst.Add(ConvertType(obj));
                }
            }

            return lst;
        }

        #region Convert Type.
        private GBL_MENU ConvertType(Module item)
        {
            GBL_MENU obj = null;
            if (item != null)
            {
                obj = new GBL_MENU();

                obj.MENU_ID = item.Id;
                obj.MENU_UID = item.Code;
                obj.MENU_NAME = item.Name;
                obj.MENU_NAMESPACE = item.Namespace;
                obj.MENU_ICON = item.Icon;
                obj.DESCR = item.Description;
                obj.PARENT = item.Parent;
                obj.SL_NO = item.SL;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Module ConvertType(GBL_MENU item)
        {
            Module obj = null;
            if (item != null)
            {
                obj = new Module();

                obj.Id = item.MENU_ID;
                obj.Code = item.MENU_UID;
                obj.Name = item.MENU_NAME;
                obj.Namespace = item.MENU_NAMESPACE;
                obj.Icon = item.MENU_ICON;
                obj.Description = item.DESCR;
                obj.Parent = item.PARENT;
                obj.SL = item.SL_NO;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }

        private GBL_SUBMENU ConvertType(Form item)
        {
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
        private Form ConvertType(GBL_SUBMENU item)
        {
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