using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.User;

namespace Envision.DataAccess.Common
{
    public class DbUserGroup
    {
        public DbUserGroup()
        {
            dbItem = new GBL_USERGROUP();
            Item = new UserGroup();
            ItemList = new List<UserGroupItem>();
        }

        private GBL_USERGROUP dbItem { get; set; }
        public UserGroup Item { get; set; }
        public List<UserGroupItem> ItemList { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                if (ItemList != null && ItemList.Count > 0)
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_USERGROUP.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.GROUP_ID;
                    foreach (var item in ItemList)
                    {
                        item.ParentId = dbItem.GROUP_ID;
                        var obj = ConvertType(item);
                        dbContext.GBL_USERGROUPDTL.Add(obj);
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
                var obj = dbContext.GBL_USERGROUP.Find(Item.Id);
                if (obj != null)
                {
                    obj.GROUP_NAME = Item.Name;
                    obj.GROUP_USER_NAME = Item.UserName;
                    obj.GROUP_PASS = Item.Password;
                    obj.GROUP_TYPE = Item.Type;
                    obj.GROUP_HEAD = Item.Head;
                    obj.GROUP_CONTACT_NO = Item.ContactNo;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
                var itemSearch = (from data in dbContext.GBL_USERGROUPDTL
                                  where data.ORG_ID == Item.OrgId
                                        && data.GROUP_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    foreach (var item in ItemList)
                    {
                        if (item.ParentId == 0)
                        {
                            var objAdd = ConvertType(item);
                            objAdd.GROUP_ID = Item.Id;
                            dbContext.GBL_USERGROUPDTL.Add(objAdd);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            var objUpdateList = (from data in dbContext.GBL_USERGROUPDTL
                                                 where data.MEMBER_ID == item.EmpId && data.GROUP_ID == item.ParentId
                                                 select data).ToList();
                            if (objUpdateList != null)
                            {
                                foreach (var objUpdate in objUpdateList)
                                {
                                    objUpdate.GROUP_ID = item.ParentId;
                                    objUpdate.MEMBER_ID = item.EmpId;
                                    objUpdate.SL = item.SL;
                                    objUpdate.IS_ACTIVE = item.IsActive.TryToString();
                                    objUpdate.ORG_ID = Item.OrgId;
                                    objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                                    objUpdate.LAST_MODIFIED_ON = DateTime.Now;
                                    dbContext.SaveChanges();
                                }
                            }
                        }
                    }
                    foreach (var item in itemSearch)
                    {
                        var element = ItemList.Find(e => e.ParentId == item.GROUP_ID && e.ParentId == item.MEMBER_ID);
                        if (element != null) continue;

                        var objUpdateList = (from data in dbContext.GBL_USERGROUPDTL
                                             where data.MEMBER_ID == item.MEMBER_ID && data.GROUP_ID == item.GROUP_ID
                                             select data).ToList();
                        if (objUpdateList != null)
                        {
                            foreach (var objUpdate in objUpdateList)
                            {
                                objUpdate.IS_ACTIVE = "N";
                                objUpdate.LAST_MODIFIED_BY = Item.ModifiedBy;
                                objUpdate.LAST_MODIFIED_ON = DateTime.Now;
                                dbContext.SaveChanges();
                            }
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
                var obj = dbContext.GBL_USERGROUP.Find(Item.Id);
                if (obj != null)
                {
                    obj.IS_ACTIVE = "N";
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<UserGroup> GetAllData()
        {
            List<UserGroup> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUP
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserGroup>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserGroup> GetAllActiveData()
        {
            List<UserGroup> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserGroup>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public List<UserGroupItem> GetItemAll()
        {
            List<UserGroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUPDTL
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserGroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserGroupItem> GetItemActiveData()
        {
            List<UserGroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUPDTL
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "N"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserGroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public UserGroup GetById()
        {
            UserGroup obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_USERGROUP.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public List<UserGroupItem> GetItemById()
        {
            List<UserGroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUPDTL
                                  where data.ORG_ID == Item.OrgId && data.GROUP_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<UserGroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserGroupItem> GetItemActiveDataById()
        {
            List<UserGroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUPDTL
                                  where data.ORG_ID == Item.OrgId && data.GROUP_ID == Item.Id && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<UserGroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public UserGroup GetByName()
        {
            UserGroup obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_USERGROUP
                                  where data.ORG_ID == Item.OrgId
                                        && data.GROUP_NAME == Item.Name
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new UserGroup();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public List<UserGroupItem> GetItemByName()
        {
            List<UserGroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_USERGROUP
                                  join dtl in dbContext.GBL_USERGROUPDTL on mas.GROUP_ID equals dtl.GROUP_ID
                                  where mas.GROUP_NAME == Item.Name && mas.ORG_ID == Item.OrgId
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<UserGroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }

            return itemList;
        }
        public List<UserGroupItem> GetItemActiveDataByName()
        {
            List<UserGroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_USERGROUP
                                  join dtl in dbContext.GBL_USERGROUPDTL on mas.GROUP_ID equals dtl.GROUP_ID
                                  where mas.GROUP_NAME == Item.Name && mas.ORG_ID == Item.OrgId && dtl.IS_ACTIVE == "Y"
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<UserGroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }

            return itemList;
        }


        #region Convert Type.
        private GBL_USERGROUP ConvertType(UserGroup item)
        {
            GBL_USERGROUP obj = null;
            if (item != null)
            {
                obj = new GBL_USERGROUP();

                obj.GROUP_ID = item.Id;
                obj.GROUP_NAME = item.Name;
                obj.GROUP_USER_NAME = item.UserName;
                obj.GROUP_PASS = item.Password;
                obj.GROUP_TYPE = item.Type;
                obj.GROUP_HEAD = item.Head;
                obj.GROUP_CONTACT_NO = item.ContactNo;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private UserGroup ConvertType(GBL_USERGROUP item)
        {
            UserGroup obj = null;
            if (item != null)
            {
                obj = new UserGroup();

                obj.Id = item.GROUP_ID;
                obj.Name = item.GROUP_NAME;
                obj.UserName = item.GROUP_USER_NAME;
                obj.Password = item.GROUP_PASS;
                obj.Type = item.GROUP_TYPE;
                obj.Head = item.GROUP_HEAD;
                obj.ContactNo = item.GROUP_CONTACT_NO;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }

        private GBL_USERGROUPDTL ConvertType(UserGroupItem item)
        {
            GBL_USERGROUPDTL obj = null;
            if (item != null)
            {
                obj = new GBL_USERGROUPDTL();

                obj.GROUP_ID = item.ParentId;
                obj.MEMBER_ID = item.EmpId;
                obj.SL = item.SL;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private UserGroupItem ConvertType(GBL_USERGROUPDTL item)
        {
            UserGroupItem obj = null;
            if (item != null)
            {
                obj = new UserGroupItem();

                obj.ParentId = item.GROUP_ID;
                obj.EmpId = item.MEMBER_ID;
                obj.SL = item.SL;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
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