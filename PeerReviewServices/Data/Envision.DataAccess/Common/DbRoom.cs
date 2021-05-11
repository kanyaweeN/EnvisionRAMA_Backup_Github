using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbRoom
    {
        public DbRoom(){
            dbItem = new HR_ROOM();
            Item = new Room();
        }
        
        private HR_ROOM dbItem { get; set; }
        public Room Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HR_ROOM.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.ROOM_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HR_ROOM.Find(Item.Id);
                if (obj != null)
                {
                    obj.ROOM_UID = Item.Code;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
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
                var obj = dbContext.HR_ROOM.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.HR_ROOM.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Room> GetAllData() {
            List<Room> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_ROOM
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Room>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public List<Room> GetAllActiveData() {
            List<Room> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_ROOM
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Room>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public Room GetById() {
            Room obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HR_ROOM.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Room GetByCode() {
            Room obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.HR_ROOM
                                  where data.ORG_ID == Item.OrgId
                                        && data.ROOM_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new Room();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private HR_ROOM ConvertType(Room item) {
            HR_ROOM obj = null;
            if (item != null)
            {
                obj = new HR_ROOM();

                obj.ROOM_ID = item.Id;
                obj.ROOM_UID = item.Code;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Room ConvertType(HR_ROOM item) {
            Room obj = null;
            if (item != null)
            {
                obj = new Room();

                obj.Id = item.ROOM_ID;
                obj.Code = item.ROOM_UID;
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