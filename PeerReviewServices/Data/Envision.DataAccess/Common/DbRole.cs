using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.User;

namespace Envision.DataAccess.Common
{
    public class DbRole
    {
        public DbRole()
        {
            dbItem = new GBL_ROLE();
            Item = new Role();
            ItemList = new List<RoleItem>();
        }

        private GBL_ROLE dbItem { get; set; }
        public Role Item { get; set; }
        public List<RoleItem> ItemList { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                if (ItemList != null && ItemList.Count > 0)
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_ROLE.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.ROLE_ID;
                    foreach (var item in ItemList)
                    {
                        item.ParentId = dbItem.ROLE_ID;
                        var obj = ConvertType(item);
                        dbContext.GBL_ROLEDTL.Add(obj);
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
                var obj = dbContext.GBL_ROLE.Find(Item.Id);
                if (obj != null)
                {
                    obj.ROLE_UID = Item.Code;
                    obj.ROLE_NAME = Item.Name;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.DESCR = Item.Description;
                    obj.IS_UPDATED = Item.IsUpdate.TryToString();
                    obj.IS_DELETED = Item.IsDelete.TryToString();
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
                var itemSearch = (from data in dbContext.GBL_ROLEDTL
                                  where data.ORG_ID == Item.OrgId
                                        && data.ROLE_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    foreach (var item in ItemList)
                    {
                        if (item.Id == 0)
                        {
                            var objAdd = ConvertType(item);
                            objAdd.ROLE_ID = Item.Id;
                            dbContext.GBL_ROLEDTL.Add(objAdd);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            var objUpdate = dbContext.GBL_ROLEDTL.Find(item.Id);
                            objUpdate.ROLEDTL_UID = item.Code;
                            objUpdate.ROLE_ID = item.ParentId;
                            objUpdate.SUBMENU_ID = item.SubMenuId;
                            objUpdate.CAN_VIEW = item.CanView.TryToString();
                            objUpdate.CAN_MODIFY = item.CanModify.TryToString();
                            objUpdate.CAN_REMOVE = item.CanRemove.TryToString();
                            objUpdate.IS_UPDATED = item.IsUpdate.TryToString();
                            objUpdate.IS_DELETED = item.IsDelete.TryToString();
                            objUpdate.CAN_CREATE = item.CanCreate.TryToString();
                            objUpdate.ORG_ID = Item.OrgId;
                            objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                            objUpdate.LAST_MODIFIED_ON = item.ModifiedOn;
                            dbContext.SaveChanges();
                        }
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
                var obj = dbContext.GBL_ROLE.Find(Item.Id);
                if (obj != null)
                {
                    obj.IS_UPDATED = "Y";
                    obj.IS_DELETED = "Y";
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Role> GetAllData()
        {
            List<Role> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ROLE
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Role>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<Role> GetAllActiveData()
        {
            List<Role> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ROLE
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Role>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<RoleItem> GetItemAllData()
        {
            List<RoleItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ROLEDTL
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<RoleItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public Role GetById()
        {
            Role obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_ROLE.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public List<RoleItem> GetItemById()
        {
            List<RoleItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ROLEDTL
                                  where data.ORG_ID == Item.OrgId && data.ROLE_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<RoleItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<RoleItem> GetItemActiveDataById()
        {
            List<RoleItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ROLEDTL
                                  where data.ORG_ID == Item.OrgId && data.ROLE_ID == Item.Id && data.IS_DELETED == "N"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<RoleItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public Role GetByCode()
        {
            Role obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_ROLE
                                  where data.ORG_ID == Item.OrgId
                                        && data.ROLE_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Role();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public List<RoleItem> GetItemByCode()
        {
            List<RoleItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_ROLE
                                  join dtl in dbContext.GBL_ROLEDTL on mas.ROLE_ID equals dtl.ROLE_ID
                                  where mas.ROLE_UID == Item.Code && mas.ORG_ID == Item.OrgId
                                  select dtl).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<RoleItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<RoleItem> GetItemActiveDataByCode()
        {
            List<RoleItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_ROLE
                                  join dtl in dbContext.GBL_ROLEDTL on mas.ROLE_ID equals dtl.ROLE_ID
                                  where mas.ROLE_UID == Item.Code && mas.ORG_ID == Item.OrgId && dtl.IS_DELETED == "N"
                                  select dtl).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<RoleItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }


        #region Convert Type.
        private GBL_ROLE ConvertType(Role item)
        {
            GBL_ROLE obj = null;
            if (item != null)
            {
                obj = new GBL_ROLE();

                obj.ROLE_ID = item.Id;
                obj.ROLE_UID = item.Code;
                obj.ROLE_NAME = item.Name;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.DESCR = item.Description;
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
        private Role ConvertType(GBL_ROLE item)
        {
            Role obj = null;
            if (item != null)
            {
                obj = new Role();

                obj.Id = item.ROLE_ID;
                obj.Code = item.ROLE_UID;
                obj.Name = item.ROLE_NAME;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.Description = item.DESCR;
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

        private GBL_ROLEDTL ConvertType(RoleItem item)
        {
            GBL_ROLEDTL obj = null;
            if (item != null)
            {
                obj = new GBL_ROLEDTL();

                obj.ROLEDTL_ID = item.Id;
                obj.ROLEDTL_UID = item.Code;
                obj.ROLE_ID = item.ParentId;
                obj.SUBMENU_ID = item.SubMenuId;
                obj.CAN_VIEW = item.CanView.TryToString();
                obj.CAN_MODIFY = item.CanModify.TryToString();
                obj.CAN_REMOVE = item.CanRemove.TryToString();
                obj.IS_UPDATED = item.IsUpdate.TryToString();
                obj.IS_DELETED = item.IsDelete.TryToString();
                obj.CAN_CREATE = item.CanCreate.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private RoleItem ConvertType(GBL_ROLEDTL item)
        {
            RoleItem obj = null;
            if (item != null)
            {
                obj = new RoleItem();

                obj.Id = item.ROLEDTL_ID;
                obj.Code = item.ROLEDTL_UID;
                obj.ParentId = item.ROLE_ID;
                obj.SubMenuId = item.SUBMENU_ID;
                obj.CanView = item.CAN_VIEW.TryToBoolean();
                obj.CanModify = item.CAN_MODIFY.TryToBoolean();
                obj.CanRemove = item.CAN_REMOVE.TryToBoolean();
                obj.IsUpdate = item.IS_UPDATED.TryToBoolean();
                obj.IsDelete = item.IS_DELETED.TryToBoolean();
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