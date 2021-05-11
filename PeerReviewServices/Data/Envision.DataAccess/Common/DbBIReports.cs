using Envision.Database;
using Envision.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.DataAccess.Common
{
    public class DbBIReports
    {
        public class DbBireports
        {
            public DbBireports()
            {
                dbItem = new GBL_BIREPORTS();
                Item = new BIReports();
            }

            private GBL_BIREPORTS dbItem { get; set; }
            public BIReports Item { get; set; }

            public int? Insert()
            {
                int? Id = null;
                using (var dbContext = new EnvisionDataModel())
                {
                    dbItem = ConvertType(Item);
                    dbItem.CREATED_ON = DateTime.Now;

                    dbContext.GBL_BIREPORTS.Add(dbItem);
                    dbContext.SaveChanges();

                    Id = dbItem.BIREPORTS_ID;
                }
                return Id;
            }
            public bool? Update()
            {
                bool? flag = null;
                using (var dbContext = new EnvisionDataModel())
                {
                    var obj = dbContext.GBL_BIREPORTS.Find(Item.Id);
                    if (obj != null)
                    {
                        obj.BIREPORTS_UID = Item.Code;
                        obj.BIREPORTS_NAME = Item.Name;
                        obj.BIREPORTS_TAG = Item.Tag;
                        obj.ORG_ID = Item.OrgId;
                        obj.LAST_MODIFIED_BY = Item.ModifiedBy;
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
                    var obj = dbContext.GBL_BIREPORTS.Find(Item.Id);
                    if (obj != null)
                    {
                        dbContext.GBL_BIREPORTS.Remove(obj);
                        flag = dbContext.SaveChanges() > 0;
                    }
                }
                return flag;
            }

            public List<BIReports> GetAllData()
            {
                List<BIReports> itemList = null;
                using (var dbContext = new EnvisionDataModel())
                {
                    var itemSearch = (from data in dbContext.GBL_BIREPORTS
                                      where data.ORG_ID == Item.OrgId
                                      select data).ToList();
                    if (itemSearch != null)
                    {
                        itemList = new List<BIReports>();
                        foreach (var obj in itemSearch)
                            itemList.Add(ConvertType(obj));
                    }
                }
                return itemList;
            }
            public List<BIReports> GetAllActiveData()
            {
                List<BIReports> itemList = null;
                using (var dbContext = new EnvisionDataModel())
                {
                    var itemSearch = (from data in dbContext.GBL_BIREPORTS
                                      where data.ORG_ID == Item.OrgId
                                      select data).ToList();
                    if (itemSearch != null)
                    {
                        itemList = new List<BIReports>();
                        foreach (var obj in itemSearch)
                            itemList.Add(ConvertType(obj));
                    }
                }
                return itemList;
            }
            public BIReports GetById()
            {
                BIReports obj = null;
                using (var dbContext = new EnvisionDataModel())
                {
                    var objFind = dbContext.GBL_BIREPORTS.Find(Item.Id);
                    obj = ConvertType(objFind);
                }

                return obj;
            }
            public BIReports GetByCode()
            {
                BIReports obj = null;
                using (var dbContext = new EnvisionDataModel())
                {
                    var itemSearch = (from data in dbContext.GBL_BIREPORTS
                                      where data.ORG_ID == Item.OrgId
                                            && data.BIREPORTS_UID == Item.Code
                                      select data).ToList();
                    if (itemSearch != null && itemSearch.Count > 0)
                    {
                        obj = new BIReports();
                        obj = ConvertType(itemSearch[0]);
                    }
                }

                return obj;
            }

            #region Convert Type.
            private GBL_BIREPORTS ConvertType(BIReports item)
            {
                GBL_BIREPORTS obj = null;
                if (item != null)
                {
                    obj = new GBL_BIREPORTS();

                    obj.BIREPORTS_ID = item.Id;
                    obj.BIREPORTS_UID = item.Code;
                    obj.BIREPORTS_NAME = item.Name;
                    obj.BIREPORTS_TAG = item.Tag;
                    obj.ORG_ID = item.OrgId;
                    obj.CREATED_BY = item.CreatedBy;
                    obj.CREATED_ON = item.CreatedOn;
                    obj.LAST_MODIFIED_BY = item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = item.ModifiedOn;
                }
                return obj;
            }
            private BIReports ConvertType(GBL_BIREPORTS item)
            {
                BIReports obj = null;
                if (item != null)
                {
                    obj = new BIReports();

                    obj.Id = item.BIREPORTS_ID;
                    obj.Code = item.BIREPORTS_UID;
                    obj.Name = item.BIREPORTS_NAME;
                    obj.Tag = item.BIREPORTS_TAG;
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
}
