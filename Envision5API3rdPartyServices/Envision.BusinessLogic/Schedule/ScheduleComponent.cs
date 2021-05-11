using Envision.Database;
using Envision.Entity.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic.Schedule
{
    public class ScheduleComponent
    {
        public RisSchedule Item { get; set; }
        public RisScheduleLogs ItemLogs { get; set; }

        public ScheduleComponent()
        {
            Item = new RisSchedule();
            ItemLogs = new RisScheduleLogs();
        }

        public RisSchedule Get(int scheduleId)
        {
            RisSchedule obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisSchedule.Where(x => x.ScheduleId == scheduleId).FirstOrDefault();
            }
            return obj;
        }

        public RisSchedule Add()
        {
            using (var context = new EnvisionContext())
            {
                Item.NotifyAdminWl = string.IsNullOrEmpty(Item.NotifyAdminWl) ? "N" : Item.NotifyAdminWl;
                context.RisSchedule.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public void Delete(int scheduleId)
        {
            using (var context = new EnvisionContext())
            {
                var obj = new RisSchedule { ScheduleId = scheduleId };
                context.Remove(obj);
                context.SaveChanges();
            }
        }
        public RisScheduleLogs AddLogs()
        {
            using (var context = new EnvisionContext())
            {
                ItemLogs.NotifyAdminWl = string.IsNullOrEmpty(ItemLogs.NotifyAdminWl) ? "N" : ItemLogs.NotifyAdminWl;
                context.RisScheduleLogs.Add(ItemLogs);
                context.SaveChanges();
            }
            return ItemLogs;
        }
    }
}
