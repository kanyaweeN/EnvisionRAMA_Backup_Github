using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbSequences
    {
        public DbSequences()
        {
            dbItem = new GBL_SEQUENCES();
            Item = new Sequences();
        }

        private GBL_SEQUENCES dbItem { get; set; }
        public Sequences Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);

                dbContext.GBL_SEQUENCES.Add(dbItem);
                dbContext.SaveChanges();
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.GBL_SEQUENCES.Find(Item.Name);
                if (obj != null)
                {
                    obj.Seed = Item.Seed;
                    obj.Incr = Item.Increment;
                    obj.Curr_val = Item.CurrentValue;
                    obj.DateStart = Item.StartDate;
                    obj.ORG_ID = Item.OrgId;

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
                var obj = dbContext.GBL_SEQUENCES.Find(Item.Name);
                if (obj != null)
                {
                    dbContext.GBL_SEQUENCES.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }
        
        public List<Sequences> GetAllData()
        {
            List<Sequences> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SEQUENCES
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Sequences>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public Sequences GetByName()
        {
            Sequences obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.GBL_SEQUENCES
                                  where data.ORG_ID == Item.OrgId
                                        && data.Seq_Name == Item.Name
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new Sequences();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private GBL_SEQUENCES ConvertType(Sequences item)
        {
            GBL_SEQUENCES obj = null;
            if (item != null)
            {
                obj = new GBL_SEQUENCES();

                obj.Seq_Name = item.Name;
                obj.Seed = item.Seed;
                obj.Incr = item.Increment;
                obj.Curr_val = item.CurrentValue;
                obj.DateStart = item.StartDate;
                obj.ORG_ID = item.OrgId;
            }
            return obj;
        }
        private Sequences ConvertType(GBL_SEQUENCES item)
        {
            Sequences obj = null;
            if (item != null)
            {
                obj = new Sequences();

                obj.Name = item.Seq_Name;
                obj.Seed = item.Seed;
                obj.Increment = item.Incr;
                obj.CurrentValue = item.Curr_val;
                obj.StartDate = item.DateStart;
                obj.OrgId = item.ORG_ID;

            }
            return obj;
        }
        #endregion
    }
}