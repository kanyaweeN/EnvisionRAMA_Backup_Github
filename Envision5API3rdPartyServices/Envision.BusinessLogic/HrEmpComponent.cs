using Envision.Database;
using Envision.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class HrEmpComponent
    {
        public HrEmp Item { get; set; }
        public int? UserId { get; set; }
        public int? OrgId { get; set; }

        public HrEmpComponent()
        {
            Item = new HrEmp();
        }

        public HrEmp Add()
        {
            using (var context = new EnvisionContext())
            {
                Item.OrgId = OrgId;
                Item.CreatedOn = DateTime.Now;
                Item.CreatedBy = UserId;
                context.HrEmp.Add(Item);
                context.SaveChanges();
            }
            return Item;
        }
        public void Edit()
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.HrEmp.Where(x => x.Id == Item.Id).FirstOrDefault();
                if (obj != null)
                {
                    obj.EmpCode = Item.EmpCode == null ? obj.EmpCode : Item.EmpCode;
                    obj.UserName = Item.UserName == null ? obj.UserName : Item.UserName;
                    obj.SecurityQuestion = Item.SecurityQuestion == null ? obj.SecurityQuestion : Item.SecurityQuestion;
                    obj.SecurityAnswer = Item.SecurityAnswer == null ? obj.SecurityAnswer : Item.SecurityAnswer;
                    obj.Pwd = Item.Pwd == null ? obj.Pwd : Item.Pwd;
                    //obj.Pwd = HelperComponent.Encryp(Item.Pwd);
                    obj.UnitId = Item.UnitId == null ? obj.UnitId : Item.UnitId;
                    obj.JobtitleId = Item.JobtitleId == null ? obj.JobtitleId : Item.JobtitleId;
                    obj.JobType = Item.JobType == null ? obj.JobType : Item.JobType;
                    obj.IsRadiologist = Item.IsRadiologist == null ? obj.IsRadiologist : Item.IsRadiologist;
                    obj.Salutation = Item.Salutation == null ? obj.Salutation : Item.Salutation;
                    obj.Fname = Item.Fname == null ? obj.Fname : Item.Fname;
                    obj.Mname = Item.Mname == null ? obj.Mname : Item.Mname;
                    obj.Lname = Item.Lname == null ? obj.Lname : Item.Lname;
                    obj.TitleEng = Item.TitleEng == null ? obj.TitleEng : Item.TitleEng;
                    obj.FnameEng = Item.FnameEng == null ? obj.FnameEng : Item.FnameEng;
                    obj.MnameEng = Item.MnameEng == null ? obj.MnameEng : Item.MnameEng;
                    obj.LnameEng = Item.LnameEng == null ? obj.LnameEng : Item.LnameEng;
                    obj.Gender = Item.Gender == null ? obj.Gender : Item.Gender;
                    obj.EmailPersonal = Item.EmailPersonal == null ? obj.EmailPersonal : Item.EmailPersonal;
                    obj.EmailOfficial = Item.EmailOfficial == null ? obj.EmailOfficial : Item.EmailOfficial;
                    obj.PhoneHome = Item.PhoneHome == null ? obj.PhoneHome : Item.PhoneHome;
                    obj.PhoneMobile = Item.PhoneMobile == null ? obj.PhoneMobile : Item.PhoneMobile;
                    obj.PhoneOffice = Item.PhoneOffice == null ? obj.PhoneOffice : Item.PhoneOffice;
                    obj.PreferredPhone = Item.PreferredPhone == null ? obj.PreferredPhone : Item.PreferredPhone;
                    obj.PabxExt = Item.PabxExt == null ? obj.PabxExt : Item.PabxExt;
                    obj.FaxNo = Item.FaxNo == null ? obj.FaxNo : Item.FaxNo;
                    obj.Dob = Item.Dob == null ? obj.Dob : Item.Dob;
                    obj.BloodGroup = Item.BloodGroup == null ? obj.BloodGroup : Item.BloodGroup;
                    obj.DefaultLang = Item.DefaultLang == null ? obj.DefaultLang : Item.DefaultLang;
                    obj.Religion = Item.Religion == null ? obj.Religion : Item.Religion;
                    obj.PeAddr1 = Item.PeAddr1 == null ? obj.PeAddr1 : Item.PeAddr1;
                    obj.PeAddr2 = Item.PeAddr2 == null ? obj.PeAddr2 : Item.PeAddr2;
                    obj.PeAddr3 = Item.PeAddr3 == null ? obj.PeAddr3 : Item.PeAddr3;
                    obj.PeAddr4 = Item.PeAddr4 == null ? obj.PeAddr4 : Item.PeAddr4;
                    obj.AuthLevelId = Item.AuthLevelId == null ? obj.AuthLevelId : Item.AuthLevelId;
                    obj.ReportingTo = Item.ReportingTo == null ? obj.ReportingTo : Item.ReportingTo;
                    obj.AllowOthersToFinalize = Item.AllowOthersToFinalize == null ? obj.AllowOthersToFinalize : Item.AllowOthersToFinalize;
                    obj.LastPwdModified = Item.LastPwdModified == null ? obj.LastPwdModified : Item.LastPwdModified;
                    obj.LastLogin = Item.LastLogin == null ? obj.LastLogin : Item.LastLogin;
                    obj.CardNo = Item.CardNo == null ? obj.CardNo : Item.CardNo;
                    obj.PlaceOfBirth = Item.PlaceOfBirth == null ? obj.PlaceOfBirth : Item.PlaceOfBirth;
                    obj.Nationality = Item.Nationality == null ? obj.Nationality : Item.Nationality;
                    obj.MStatus = Item.MStatus == null ? obj.MStatus : Item.MStatus;
                    obj.IsActive = Item.IsActive == null ? obj.IsActive : Item.IsActive;
                    obj.SupportUser = Item.SupportUser == null ? obj.SupportUser : Item.SupportUser;
                    obj.CanKillSession = Item.CanKillSession == null ? obj.CanKillSession : Item.CanKillSession;
                    obj.DefaultShiftNo = Item.DefaultShiftNo == null ? obj.DefaultShiftNo : Item.DefaultShiftNo;
                    obj.ImgFileName = Item.ImgFileName == null ? obj.ImgFileName : Item.ImgFileName;
                    obj.EmpReportFooter1 = Item.EmpReportFooter1 == null ? obj.EmpReportFooter1 : Item.EmpReportFooter1;
                    obj.EmpReportFooter2 = Item.EmpReportFooter2 == null ? obj.EmpReportFooter2 : Item.EmpReportFooter2;
                    obj.Allproperties = Item.Allproperties == null ? obj.Allproperties : Item.Allproperties;
                    obj.Visible = Item.Visible == null ? obj.Visible : Item.Visible;
                    obj.IsResident = Item.IsResident == null ? obj.IsResident : Item.IsResident;
                    obj.CanExceedSchedule = Item.CanExceedSchedule == null ? obj.CanExceedSchedule : Item.CanExceedSchedule;
                    obj.IsFellow = Item.IsFellow == null ? obj.IsFellow : Item.IsFellow;
                    obj.IsNurse = Item.IsNurse == null ? obj.IsNurse : Item.IsNurse;
                    obj.IsTechnologist = Item.IsTechnologist == null ? obj.IsTechnologist : Item.IsTechnologist;
                    obj.AliasName = Item.AliasName == null ? obj.AliasName : Item.AliasName;
                    obj.IsAccessvip = Item.IsAccessvip == null ? obj.IsAccessvip : Item.IsAccessvip;
                    obj.Theme = Item.Theme == null ? obj.Theme : Item.Theme;
                    obj.LockScreen = Item.LockScreen == null ? obj.LockScreen : Item.LockScreen;
                    obj.ProfileLayout = Item.ProfileLayout == null ? obj.ProfileLayout : Item.ProfileLayout;
                    obj.MenuLayout = Item.MenuLayout == null ? obj.MenuLayout : Item.MenuLayout;
                    obj.IsDarkmenu = Item.IsDarkmenu == null ? obj.IsDarkmenu : Item.IsDarkmenu;
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
                var obj = new HrEmp { Id = Item.Id };
                context.Remove(obj);
                context.SaveChanges();
            }
        }
        public HrEmp Check() {
            HrEmp data = null;
            using (var context = new EnvisionContext())
            {
                data = context.HrEmp.Where(x => x.EmpCode == Item.EmpCode).FirstOrDefault();
                if(data == null)
                {
                    Item.OrgId = OrgId;
                    Item.CreatedOn = DateTime.Now;
                    Item.CreatedBy = UserId;
                    context.HrEmp.Add(Item);
                    context.SaveChanges();
                    data = Item;
                }
            }
            return data;
        }

        public List<HrEmp> GetAll()
        {
            List<HrEmp> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.HrEmp.Where(x => x.OrgId == OrgId && x.IsActive == true).ToList();
            }
            return dataList;
        }
        public List<HrEmp> GetAllWithUnActive()
        {
            List<HrEmp> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.HrEmp.Where(x => x.OrgId == OrgId).ToList();
            }
            return dataList;
        }
        public List<HrEmp> GetRadiologistAll()
        {
            List<HrEmp> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = (
                            from data in context.HrEmp
                            join job in context.HrJobTitle on data.JobtitleId equals job.Id
                            where job.Tag == "R" || job.Tag == "RMO"
                            select data
                            ).ToList();
            }
            return dataList;
        }
        public HrEmp GetById()
        {
            HrEmp obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.HrEmp.Where(x => x.Id == Item.Id).FirstOrDefault();
            }
            return obj;
        }
        public HrEmp GetByCode()
        {
            HrEmp obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.HrEmp.Where(x => x.EmpCode == Item.EmpCode && x.OrgId == OrgId).FirstOrDefault();
            }
            return obj;
        }
        public HrJobTitle AddJobTitle(HrJobTitle item)
        {
            using (var context = new EnvisionContext())
            {
                item.CreatedOn = DateTime.Now;
                item.CreatedBy = UserId;
                context.HrJobTitle.Add(item);
                context.SaveChanges();
            }
            return item;
        }
        public void EditJobTitle(HrJobTitle item)
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.HrJobTitle.Where(x => x.Id == item.Id).FirstOrDefault();
                if (obj != null)
                {
                    obj.Code = item.Code;
                    obj.Desc = item.Desc;
                    obj.IsActive = item.IsActive;
                    obj.SL = item.SL;
                    obj.Tag = item.Tag;
                    obj.LastModifiedBy = UserId;
                    obj.LastModifiedOn = DateTime.Now;
                    context.SaveChanges();
                }
            }
        }
        public void DeleteJobTitle(int Id)
        {
            using (var context = new EnvisionContext())
            {
                var obj = new HrJobTitle { Id = Id };
                context.Remove(obj);
                context.SaveChanges();
            }
        }
        public List<HrJobTitle> GetJobTitleAll()
        {
            List<HrJobTitle> dataList = null;
            using (var context = new EnvisionContext())
            {
                dataList = context.HrJobTitle.Where(x => x.OrgId == OrgId).ToList();
            }
            return dataList;
        }
        public HrJobTitle GetJobTitleById(int? Id)
        {
            HrJobTitle obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.HrJobTitle.Where(x => x.Id == Id).FirstOrDefault();
            }
            return obj;
        }
        public HrJobTitle GetJobTitleByCode(string Code)
        {
            HrJobTitle obj = null;
            using (var context = new EnvisionContext())
            {
                obj = context.HrJobTitle.Where(x => x.Code == Code && x.OrgId == OrgId).FirstOrDefault();
            }
            return obj;
        }
    }
}