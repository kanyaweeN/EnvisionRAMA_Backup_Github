using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.User;

namespace Envision.DataAccess.Common
{
    public class DbOccupation
    {
        public DbOccupation()
        {
            dbItem = new HR_OCCUPATION();
            Item = new Occupation();
        }

        private HR_OCCUPATION dbItem { get; set; }
        public Occupation Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HR_OCCUPATION.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.OCCUPATION_ID;
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HR_OCCUPATION.Find(Item.Id);
                if (obj != null)
                {
                    obj.OCCUPATION_UID = Item.Code;
                    obj.OCCUPATION_DESC = Item.Description;
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy == null ? null : Item.ModifiedBy.ToString();
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }
        public bool? Delete()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HR_OCCUPATION.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.Database.ExecuteSqlCommand("update HIS_REGISTRATION set OCCUPATION_ID = NULL where OCCUPATION_ID = " + Item.Id);
                    dbContext.HR_OCCUPATION.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Occupation> GetAllData()
        {
            List<Occupation> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_OCCUPATION
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Occupation>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<Occupation> GetAllActiveData()
        {
            List<Occupation> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_OCCUPATION
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Occupation>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public Occupation GetById()
        {
            Occupation obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HR_OCCUPATION.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Occupation GetByCode()
        {
            Occupation obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_OCCUPATION
                                  where data.ORG_ID == Item.OrgId
                                        && data.OCCUPATION_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Occupation();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private HR_OCCUPATION ConvertType(Occupation item)
        {
            HR_OCCUPATION obj = null;
            if (item != null)
            {
                obj = new HR_OCCUPATION();

                obj.OCCUPATION_ID = item.Id;
                obj.OCCUPATION_UID = item.Code;
                obj.OCCUPATION_DESC = item.Description;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy == null ? null : item.CreatedBy.ToString();
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy == null ? null : item.CreatedBy.ToString();
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Occupation ConvertType(HR_OCCUPATION item)
        {
            Occupation obj = null;
            if (item != null)
            {
                obj = new Occupation();

                obj.Id = item.OCCUPATION_ID;
                obj.Code = item.OCCUPATION_UID;
                obj.Description = item.OCCUPATION_DESC;
                obj.OrgId = item.ORG_ID;

                obj.CreatedBy = null;
                obj.CreatedBy = item.CREATED_BY == null ? obj.CreatedBy : Convert.ToInt32(item.CREATED_BY);
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = null;
                obj.ModifiedBy = item.LAST_MODIFIED_BY == null ? obj.ModifiedBy : Convert.ToInt32(item.LAST_MODIFIED_BY);
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }
        #endregion
    }
}