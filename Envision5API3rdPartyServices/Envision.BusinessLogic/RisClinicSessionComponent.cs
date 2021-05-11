using Envision.Database;
using Envision.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class RisClinicSessionComponent
    {
        public RisClinicSession Item { get; set; }
        public int? UserId { get; set; }
        public int? OrgId { get; set; }

        public RisClinicSessionComponent()
        {
            Item = new RisClinicSession();
        }

        public RisClinicSession Add()
        {
            using (var context = new EnvisionContext())
            {
                Item.OrgId = OrgId;
                Item.CreatedOn = DateTime.Now;
                Item.CreatedBy = UserId;
                context.RisClinicSession.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public void Edit()
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.RisClinicSession.Where(x => x.Id == Item.Id).FirstOrDefault();
                if (obj != null)
                {
                    obj.Code = Item.Code;
                    obj.Name = Item.Name;
                    obj.TypeId = Item.TypeId;
                    obj.StartTime = Item.StartTime;
                    obj.EndTime = Item.EndTime;
                    obj.SL = Item.SL;
                    obj.IsActive = Item.IsActive;
                    obj.AliasName = Item.AliasName;
                    obj.IsOnline = Item.IsOnline;
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
                var obj = new RisClinicSession { Id = Item.Id };
                context.Remove(obj);
                context.SaveChanges();
            }
        }

        public List<RisClinicSession> GetAll()
        {
            List<RisClinicSession> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.RisClinicSession.Where(x => x.OrgId == OrgId && x.IsActive == true).ToList();
            }
            return dataList;
        }
        public List<RisClinicSession> GetAllWithUnActive()
        {
            List<RisClinicSession> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.RisClinicSession.Where(x => x.OrgId == OrgId).ToList();
            }
            return dataList;
        }
        public RisClinicSession GetById()
        {
            RisClinicSession obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisClinicSession.Where(x => x.Id == Item.Id).FirstOrDefault();
            }
            return obj;
        }
        public RisClinicSession GetByCode()
        {
            RisClinicSession obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisClinicSession.Where(x => x.Code == Item.Code && x.OrgId == OrgId).FirstOrDefault();
            }
            return obj;
        }
        public RisClinicSession GetByDate(DateTime date)
        {
            RisClinicSession obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisClinicSession.Where(x => 
                date.TimeOfDay >= x.StartTime.Value.TimeOfDay && 
                date.TimeOfDay <= x.EndTime.Value.TimeOfDay && 
                x.OrgId == OrgId).FirstOrDefault();
            }
            return obj;
        }
    }
}
