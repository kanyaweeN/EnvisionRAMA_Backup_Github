using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbUnit
    {
        public DbUnit(){
            dbItem = new HR_UNIT();
            Item = new Unit();
        }

        private HR_UNIT dbItem { get; set; }
        public Unit Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HR_UNIT.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.UNIT_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HR_UNIT.Find(Item.Id);
                if (obj != null)
                {
                    obj.UNIT_UID = Item.Code;
                    obj.UNIT_ID_PARENT = Item.ParentId;
                    obj.UNIT_NAME = Item.Name;
                    obj.UNIT_NAME_ALIAS = Item.NameAlias;
                    obj.PHONE_NO = Item.PhoneNo;
                    obj.DESCR = Item.Description;
                    obj.UNIT_ALIAS = Item.UnitAlias;
                    obj.UNIT_TYPE = Item.Type;
                    obj.UNIT_INS = Item.Instruction;
                    obj.IS_EXTERNAL = Item.IsExternal.TryToString();
                    obj.LOC = Item.Loc;
                    obj.IS_DELETED = Item.IsDelete.TryToString();
                    obj.LOC_ALIAS = Item.LocAlias;
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
                var obj = dbContext.HR_UNIT.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.HR_UNIT.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Unit> GetAllData() {
            List<Unit> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_UNIT
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Unit>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public List<Unit> GetAllActiveData() {
            List<Unit> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_UNIT
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Unit>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public Unit GetById() {
            Unit obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HR_UNIT.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Unit GetByCode() {
            Unit obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.HR_UNIT
                                  where data.ORG_ID == Item.OrgId
                                        && data.UNIT_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new Unit();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private HR_UNIT ConvertType(Unit item) {
            HR_UNIT obj = null;
            if (item != null)
            {
                obj = new HR_UNIT();

                obj.UNIT_ID = item.Id;
                obj.UNIT_UID = item.Code;
                obj.UNIT_ID_PARENT = item.ParentId;
                obj.UNIT_NAME = item.Name;
                obj.UNIT_NAME_ALIAS = item.NameAlias;
                obj.PHONE_NO = item.PhoneNo;
                obj.DESCR = item.Description;
                obj.UNIT_ALIAS = item.UnitAlias;
                obj.UNIT_TYPE = item.Type;
                obj.UNIT_INS = item.Instruction;
                obj.IS_EXTERNAL = item.IsExternal.TryToString();
                obj.LOC = item.Loc;
                obj.IS_DELETED = item.IsDelete.TryToString();
                obj.LOC_ALIAS = item.LocAlias;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Unit ConvertType(HR_UNIT item) {
            Unit obj = null;
            if (item != null)
            {
                obj = new Unit();

                obj.Id = item.UNIT_ID;
                obj.Code = item.UNIT_UID;
                obj.ParentId = item.UNIT_ID_PARENT;
                obj.Name = item.UNIT_NAME;
                obj.NameAlias = item.UNIT_NAME_ALIAS;
                obj.PhoneNo = item.PHONE_NO;
                obj.Description = item.DESCR;
                obj.UnitAlias = item.UNIT_ALIAS;
                obj.Type = item.UNIT_TYPE;
                obj.Instruction = item.UNIT_INS;
                obj.IsExternal = item.IS_EXTERNAL.TryToBoolean();
                obj.Loc = item.LOC;
                obj.IsDelete = item.IS_DELETED.TryToBoolean();
                obj.LocAlias = item.LOC_ALIAS;
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