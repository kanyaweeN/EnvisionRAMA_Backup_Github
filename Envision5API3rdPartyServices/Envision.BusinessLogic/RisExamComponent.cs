using Envision.Database;
using Envision.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class RisExamComponent
    {
        public RisExam Item { get; set; }
        public int? UserId { get; set; }
        public int? OrgId { get; set; }

        public RisExamComponent()
        {
            Item = new RisExam();
        }

        public RisExam Add()
        {
            using (var context = new EnvisionContext())
            {
                Item.OrgId = OrgId;
                Item.CreatedOn = DateTime.Now;
                Item.CreatedBy = UserId;
                context.RisExam.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public void Edit()
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.RisExam.Where(x => x.Id == Item.Id).FirstOrDefault();
                if (obj != null)
                {
                    obj.ExamCode = Item.ExamCode == null ? obj.ExamCode : Item.ExamCode;
                    obj.GovtId = Item.GovtId == null ? obj.GovtId : Item.GovtId;
                    obj.ExamName = Item.ExamName == null ? obj.ExamName : Item.ExamName;
                    obj.ReportHeader = Item.ReportHeader == null ? obj.ReportHeader : Item.ReportHeader;
                    obj.ReqSample = Item.ReqSample == null ? obj.ReqSample : Item.ReqSample;
                    obj.Rate = Item.Rate == null ? obj.Rate : Item.Rate;
                    obj.GovtRate = Item.GovtRate == null ? obj.GovtRate : Item.GovtRate;
                    obj.TypeId = Item.TypeId == null ? obj.TypeId : Item.TypeId;
                    obj.ServiceTypeId = Item.ServiceTypeId == null ? obj.ServiceTypeId : Item.ServiceTypeId;
                    obj.ClaimableAmt = Item.ClaimableAmt == null ? obj.ClaimableAmt : Item.ClaimableAmt;
                    obj.NonclaimableAmt = Item.NonclaimableAmt == null ? obj.NonclaimableAmt : Item.NonclaimableAmt;
                    obj.FreeAmt = Item.FreeAmt == null ? obj.FreeAmt : Item.FreeAmt;
                    obj.SpecialClinic = Item.SpecialClinic == null ? obj.SpecialClinic : Item.SpecialClinic;
                    obj.SpecialRate = Item.SpecialRate == null ? obj.SpecialRate : Item.SpecialRate;
                    obj.VatApplicable = Item.VatApplicable == null ? obj.VatApplicable : Item.VatApplicable;
                    obj.VatRate = Item.VatRate == null ? obj.VatRate : Item.VatRate;
                    obj.UnitId = Item.UnitId == null ? obj.UnitId : Item.UnitId;
                    obj.RevHeadId = Item.RevHeadId == null ? obj.RevHeadId : Item.RevHeadId;
                    obj.IsActive = Item.IsActive == null ? obj.IsActive : Item.IsActive;
                    obj.AvgReqHrs = Item.AvgReqHrs == null ? obj.AvgReqHrs : Item.AvgReqHrs;
                    obj.MinReqHrs = Item.MinReqHrs == null ? obj.MinReqHrs : Item.MinReqHrs;
                    obj.CostPrice = Item.CostPrice == null ? obj.CostPrice : Item.CostPrice;
                    obj.ReleaseAuthLevel = Item.ReleaseAuthLevel == null ? obj.ReleaseAuthLevel : Item.ReleaseAuthLevel;
                    obj.FinalizeAuthLevel = Item.FinalizeAuthLevel == null ? obj.FinalizeAuthLevel : Item.FinalizeAuthLevel;
                    obj.PreparationFlag = Item.PreparationFlag == null ? obj.PreparationFlag : Item.PreparationFlag;
                    obj.PreparationTat = Item.PreparationTat == null ? obj.PreparationTat : Item.PreparationTat;
                    obj.RepeatFlag = Item.RepeatFlag == null ? obj.RepeatFlag : Item.RepeatFlag;
                    obj.IcdId = Item.IcdId == null ? obj.IcdId : Item.IcdId;
                    obj.AcrId = Item.AcrId == null ? obj.AcrId : Item.AcrId;
                    obj.CptId = Item.CptId == null ? obj.CptId : Item.CptId;
                    obj.DefCapture = Item.DefCapture == null ? obj.DefCapture : Item.DefCapture;
                    obj.DefImages = Item.DefImages == null ? obj.DefImages : Item.DefImages;
                    obj.IsStructuredReport = Item.IsStructuredReport == null ? obj.IsStructuredReport : Item.IsStructuredReport;
                    obj.QaRequired = Item.QaRequired == null ? obj.QaRequired : Item.QaRequired;
                    obj.IsUpdated = Item.IsUpdated == null ? obj.IsUpdated : Item.IsUpdated;
                    obj.IsDeleted = Item.IsDeleted == null ? obj.IsDeleted : Item.IsDeleted;
                    obj.LastModifiedBy = UserId;
                    obj.LastModifiedOn = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }

        public List<RisExam> GetAll()
        {
            List<RisExam> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.RisExam.Where(x => x.OrgId == OrgId && x.IsActive == true).ToList();
            }
            return dataList;
        }
        public List<RisExam> GetAllWithUnActive()
        {
            List<RisExam> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.RisExam.Where(x => x.OrgId == OrgId).ToList();
            }
            return dataList;
        }
        public RisExam GetById()
        {
            RisExam obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisExam.Include(d => d.ExamType)
                                  .Include(s => s.ServiceType)
                                  .Include(u => u.Unit)
                                  .Where(x => x.Id == Item.Id).FirstOrDefault();
            }
            return obj;
        }
        public RisExam GetByCode()
        {
            RisExam obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.RisExam.Where(x => x.ExamCode == Item.ExamCode && x.OrgId == OrgId).FirstOrDefault();
            }
            return obj;
        }
    }
}
