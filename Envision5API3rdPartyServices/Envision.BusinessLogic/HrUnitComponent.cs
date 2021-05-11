using Envision.Database;
using Envision.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class HrUnitComponent
    {
        public HrUnit Item { get; set; }
        public int? UserId { get; set; }
        public int? OrgId { get; set; }

        public HrUnitComponent()
        {
            Item = new HrUnit();
        }

        public HrUnit Add()
        {
            using (var context = new EnvisionContext())
            {
                Item.OrgId = OrgId;
                Item.CreatedOn = DateTime.Now;
                Item.CreatedBy = UserId;
                context.HrUnit.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public void Edit()
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.HrUnit.Where(x => x.Id == Item.Id).FirstOrDefault();
                if (obj != null)
                {
                    obj.Code = Item.Code;
                    obj.ParentId = Item.ParentId;
                    obj.Name = Item.Name;
                    obj.AliasName = Item.AliasName;
                    obj.PhoneNo = Item.PhoneNo;
                    obj.Desc = Item.Desc;
                    obj.UnitAlias = Item.UnitAlias;
                    obj.UnitType = Item.UnitType;
                    obj.UnitIns = Item.UnitIns;
                    obj.IsExternal = Item.IsExternal;
                    obj.Loc = Item.Loc;
                    obj.IsDeleted = Item.IsDeleted;
                    obj.LocAlias = Item.LocAlias;
                    obj.UnitParentName = Item.UnitParentName;
                    obj.LastModifiedBy = UserId;
                    obj.LastModifiedOn = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var context = new EnvisionContext())
            {
                var obj = new HrUnit { Id = Item.Id };
                context.Remove(obj);
                context.SaveChanges();
            }
        }

        public List<HrUnit> GetAll()
        {
            List<HrUnit> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.HrUnit.Where(x => x.OrgId == OrgId).ToList();
            }
            return dataList;
        }
        public HrUnit GetById()
        {
            HrUnit obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.HrUnit.Where(x => x.Id == Item.Id).FirstOrDefault();
            }
            return obj;
        }
        public HrUnit GetByCode()
        {
            HrUnit obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.HrUnit.Where(x => x.Code == Item.Code && x.OrgId == OrgId).FirstOrDefault();
            }
            return obj;
        }
    }
}