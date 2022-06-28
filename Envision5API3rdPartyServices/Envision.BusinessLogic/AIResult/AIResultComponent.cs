using Envision.Database;
using Envision.Entity.AIResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic.AIResult
{
    public class AIResultComponent
    {
        public RisAIDetail Item { get; set; }
        public AIResultComponent()
        {
            Item = new RisAIDetail();
        }

        public RisAIDetail GetByAccession()
        {
            RisAIDetail data = null;
            using (var context = new EnvisionContext())
            {
                data = context.RisAIDetail.Where(x => x.AccessionNo == Item.AccessionNo && x.AiVendor == Item.AiVendor).FirstOrDefault();
            }
            return data;
        }
        public RisAIDetail Add()
        {
            using (var context = new EnvisionContext())
            {
                Item.CreatedOn = DateTime.Now;
                context.RisAIDetail.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public void Update()
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.RisAIDetail.Where(x => x.AccessionNo == Item.AccessionNo && x.AiVendor == Item.AiVendor).FirstOrDefault();
                if (obj != null)
                {
                    obj.DetectValues = Item.DetectValues == null ? obj.DetectValues : Item.DetectValues;
                    obj.Hn = Item.Hn == null ? obj.Hn : Item.Hn;
                    obj.Remark = Item.Remark == null ? obj.Remark : Item.Remark;
                    obj.AiVendor = Item.AiVendor == null ? obj.AiVendor : Item.AiVendor;
                    obj.LastModifiedOn = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
    }
}
