using Envision.Database;
using Envision.Entity.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic.Schedule
{
    public class ScheduleDetailComponent
    {
        public RisScheduleDtl Item { get; set; }
        public RisScheduleLogsDtl ItemLogs { get; set; }

        public ScheduleDetailComponent()
        {
            Item = new RisScheduleDtl();
            ItemLogs = new RisScheduleLogsDtl();
        }

        public List<RisScheduleDtl> Get(int scheduleId)
        {
            List<RisScheduleDtl> obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisScheduleDtl.Where(x => x.ScheduleId == scheduleId).ToList();
            }
            return obj;
        }

        public RisScheduleDtl Add()
        {
            using (var context = new EnvisionContext())
            {
                context.RisScheduleDtl.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public RisScheduleLogsDtl AddLogs()
        {
            using (var context = new EnvisionContext())
            {
                context.RisScheduleLogsDtl.Add(ItemLogs);
                context.SaveChanges();
            }
            return ItemLogs;
        }
        public void Delete(int scheduleId,int examId)
        {
            using (var context = new EnvisionContext())
            {
                RisScheduleDtl obj = context.RisScheduleDtl.Where(x => x.ScheduleId == scheduleId && x.ExamId == examId).FirstOrDefault();
                context.Remove(obj);
                context.SaveChanges();
            }
        }
    }
}