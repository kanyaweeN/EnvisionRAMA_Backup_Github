using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbProduct
    {
        public DbProduct(){
            dbItem = new GBL_PRODUCT();
            Item = new Product();
        }

        private GBL_PRODUCT dbItem { get; set; }
        public Product Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.GBL_PRODUCT.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.PROD_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_PRODUCT.Find(Item.Id);
                if (obj != null)
                {
                    obj.PROD_UID = Item.Code;
                    obj.PROD_NAME = Item.Name;
                    obj.PROD_DESCR = Item.Description;
                    obj.PROD_VERSION = Item.Version;
                    obj.RELEASE_DT = Item.ReleaseDate;
                    obj.PROD_TYPE = Item.Type;
                    obj.LICENSED_TO = Item.LicensedTo;
                    obj.LICENSE_TYPE = Item.LicenseType;
                    obj.VALID_UNTIL = Item.ValidUntil;
                    obj.FORCE_LICENSE = Item.ForceLicense;
                    obj.COPY_RIGHT = Item.CopyRight;
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy.ToString();
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
                var obj = dbContext.GBL_PRODUCT.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.GBL_PRODUCT.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Product> GetAllData() {
            List<Product> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_PRODUCT
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Product>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public Product GetById() {
            Product obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.GBL_PRODUCT.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Product GetByCode() {
            Product obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.GBL_PRODUCT
                                  where data.ORG_ID == Item.OrgId
                                        && data.PROD_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new Product();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private GBL_PRODUCT ConvertType(Product item) {
            GBL_PRODUCT obj = null;
            if (item != null)
            {
                obj = new GBL_PRODUCT();

                obj.PROD_ID = item.Id;
                obj.PROD_UID = item.Code;
                obj.PROD_NAME = item.Name;
                obj.PROD_DESCR = item.Description;
                obj.PROD_VERSION = item.Version;
                obj.RELEASE_DT = item.ReleaseDate;
                obj.PROD_TYPE = item.Type;
                obj.LICENSED_TO = item.LicensedTo;
                obj.LICENSE_TYPE = item.LicenseType;
                obj.VALID_UNTIL = item.ValidUntil;
                obj.FORCE_LICENSE = item.ForceLicense;
                obj.COPY_RIGHT = item.CopyRight;
                obj.ORG_ID = Item.OrgId;
                obj.CREATED_BY = item.CreatedBy == null ? null : item.CreatedBy.ToString();
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = Item.ModifiedBy == null ? null : item.ModifiedBy.ToString();
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Product ConvertType(GBL_PRODUCT item) {
            Product obj = null;
            if (item != null)
            {
                obj = new Product();

                obj.Id = item.PROD_ID;
                obj.Code = item.PROD_UID;
                obj.Name = item.PROD_NAME;
                obj.Description = item.PROD_DESCR;
                obj.Version = item.PROD_VERSION;
                obj.ReleaseDate = item.RELEASE_DT;
                obj.Type = item.PROD_TYPE;
                obj.LicensedTo = item.LICENSED_TO;
                obj.LicenseType = item.LICENSE_TYPE;
                obj.ValidUntil = item.VALID_UNTIL;
                obj.ForceLicense = item.FORCE_LICENSE;
                obj.CopyRight = item.COPY_RIGHT;
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