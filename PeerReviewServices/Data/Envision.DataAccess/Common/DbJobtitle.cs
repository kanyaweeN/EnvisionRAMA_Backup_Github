using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.User;

namespace Envision.DataAccess.Common
{
    public class DbJobTitle
    {
        public DbJobTitle(){
            dbItem = new HR_JOBTITLE();
            Item = new JobTitle();
        }

        private HR_JOBTITLE dbItem { get; set; }
        public JobTitle Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HR_JOBTITLE.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.JOB_TITLE_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HR_JOBTITLE.Find(Item.Id);
                if (obj != null)
                {
                    obj.JOB_TITLE_UID = Item.Code;
                    obj.JOB_TITLE_DESC = Item.Description;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.SL_NO = Item.SL;
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
                var obj = dbContext.HR_JOBTITLE.Find(Item.Id);
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

        public List<JobTitle> GetAllData() {
            List<JobTitle> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_JOBTITLE
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<JobTitle>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public List<JobTitle> GetAllActiveData() {
            List<JobTitle> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_JOBTITLE
                                  where data.ORG_ID == Item.OrgId  && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<JobTitle>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public JobTitle GetById() {
            JobTitle obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HR_JOBTITLE.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public JobTitle GetByCode() {
            JobTitle obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.HR_JOBTITLE
                                  where data.ORG_ID == Item.OrgId
                                        && data.JOB_TITLE_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new JobTitle();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private HR_JOBTITLE ConvertType(JobTitle item) {
            HR_JOBTITLE obj = null;
            if (item != null)
            {
                obj = new HR_JOBTITLE();

                obj.JOB_TITLE_ID = item.Id;
                obj.JOB_TITLE_UID = item.Code;
                obj.JOB_TITLE_DESC = item.Description;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.SL_NO = item.SL;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private JobTitle ConvertType(HR_JOBTITLE item) {
            JobTitle obj = null;
            if (item != null)
            {
                obj = new JobTitle();

                obj.Id = item.JOB_TITLE_ID;
                obj.Code = item.JOB_TITLE_UID;
                obj.Description = item.JOB_TITLE_DESC;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.SL = item.SL_NO;
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