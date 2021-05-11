using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbGroup
    {
        public DbGroup()
        {
            dbItem = new GBL_GROUP();
            Item = new Group();
            ItemList = new List<GroupItem>();
        }

        private GBL_GROUP dbItem { get; set; }
        public Group Item { get; set; }
        public List<GroupItem> ItemList { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                if (ItemList != null && ItemList.Count > 0)
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_GROUP.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.GROUP_ID;
                    foreach (var item in ItemList)
                    {
                        item.ParentId = dbItem.GROUP_ID;
                        GBL_GROUPDTL obj = ConvertType(item);
                        dbContext.GBL_GROUPDTL.Add(obj);
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
                var obj = dbContext.GBL_GROUP.Find(Item.Id);
                if (obj != null)
                {
                    obj.GROUP_UID = Item.Code;
                    obj.GROUP_NAME = Item.Name;
                    obj.GROUP_USER_NAME = Item.UserName;
                    obj.GROUP_PASS = Item.Pass;
                    obj.GROUP_TYPE = Item.Type;
                    obj.GROUP_HEAD = Item.HeadId;
                    obj.GROUP_HEAD_NAME = Item.HeadName;
                    obj.GROUP_CONTACT_NO = Item.ContactNumber;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
                var itemSearch = (from data in dbContext.GBL_GROUPDTL
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
                            dbContext.GBL_GROUPDTL.Add(objAdd);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            var objUpdateList = (from data in dbContext.GBL_GROUPDTL
                                     where data.MEMBER_ID == item.MemberId && data.GROUP_ID == item.ParentId
                                     select data).ToList();
                            if (objUpdateList != null)
                            {
                                foreach (var objUpdate in objUpdateList)
                                {
                                    objUpdate.GROUP_ID = item.ParentId;
                                    objUpdate.MEMBER_ID = item.MemberId;
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
                        var element = ItemList.Find(e => e.ParentId == item.GROUP_ID && e.MemberId == item.MEMBER_ID);
                        if (element != null) continue;

                        var objUpdateList = (from data in dbContext.GBL_GROUPDTL
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
                var obj = dbContext.GBL_GROUP.Find(Item.Id);
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

        public List<Group> GetAllData()
        {
            List<Group> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUP
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Group>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<Group> GetAllActiveData()
        {
            List<Group> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Group>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public List<GroupItem> GetItemAll()
        {
            List<GroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUPDTL
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<GroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<GroupItem> GetItemActiveData()
        {
            List<GroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUPDTL
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<GroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        

        public Group GetById()
        {
            Group obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_GROUP.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public List<GroupItem> GetItemById()
        {
            List<GroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUPDTL
                                  where data.ORG_ID == Item.OrgId && data.GROUP_ID == Item.Id
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<GroupItem> GetItemActiveDataById()
        {
            List<GroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUPDTL
                                  where data.ORG_ID == Item.OrgId && data.GROUP_ID == Item.Id && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
       

        public Group GetByCode()
        {
            Group obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_GROUP
                                  where data.ORG_ID == Item.OrgId
                                        && data.GROUP_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Group();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public List<GroupItem> GetItemByCode()
        {
            List<GroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_GROUP
                                  join dtl in dbContext.GBL_GROUPDTL on mas.GROUP_ID equals dtl.GROUP_ID
                                  where mas.GROUP_UID == Item.Code && mas.ORG_ID == Item.OrgId
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }

            return itemList;
        }
        public List<GroupItem> GetItemActiveDataByCode()
        {
            List<GroupItem> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from mas in dbContext.GBL_GROUP
                                  join dtl in dbContext.GBL_GROUPDTL on mas.GROUP_ID equals dtl.GROUP_ID
                                  where mas.GROUP_UID == Item.Code && mas.ORG_ID == Item.OrgId && dtl.IS_ACTIVE == "Y"
                                  select dtl).ToList();

                if (itemSearch != null && itemSearch.Count > 0)
                {
                    itemList = new List<GroupItem>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }

            return itemList;
        }
       

        #region Convert Type.
        private GBL_GROUP ConvertType(Group item)
        {
            GBL_GROUP obj = null;
            if (item != null)
            {
                obj = new GBL_GROUP();

                obj.GROUP_ID = item.Id;
                obj.GROUP_UID = item.Code;
                obj.GROUP_NAME = item.Name;
                obj.GROUP_USER_NAME = item.UserName;
                obj.GROUP_PASS = item.Pass;
                obj.GROUP_TYPE = item.Type;
                obj.GROUP_HEAD = item.HeadId;
                obj.GROUP_HEAD_NAME = item.HeadName;
                obj.GROUP_CONTACT_NO = item.ContactNumber;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.ORG_ID = Item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Group ConvertType(GBL_GROUP item)
        {
            Group obj = null;
            if (item != null)
            {
                obj = new Group();

                obj.Id = item.GROUP_ID;
                obj.Code = item.GROUP_UID;
                obj.Name = item.GROUP_NAME;
                obj.UserName = item.GROUP_USER_NAME;
                obj.Pass = item.GROUP_PASS;
                obj.Type = item.GROUP_TYPE;
                obj.HeadId = item.GROUP_HEAD;
                obj.HeadName = item.GROUP_HEAD_NAME;
                obj.ContactNumber = item.GROUP_CONTACT_NO;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }


        private GBL_GROUPDTL ConvertType(GroupItem item)
        {
            GBL_GROUPDTL obj = null;
            if (item != null)
            {
                obj = new GBL_GROUPDTL();

                obj.GROUP_ID = item.ParentId;
                obj.MEMBER_ID = item.MemberId;
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
        private GroupItem ConvertType(GBL_GROUPDTL item)
        {
            GroupItem obj = null;
            if (item != null)
            {
                obj = new GroupItem();

                obj.ParentId = item.GROUP_ID;
                obj.MemberId = item.MEMBER_ID;
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