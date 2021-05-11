using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common.User;

namespace Envision.DataAccess.Common
{
    public class DbUser
    {
        public DbUser()
        {
            dbItem = new HR_EMP();
            Item = new UserInfo();
        }

        private HR_EMP dbItem { get; set; }
        public UserInfo Item { get; set; }

        public int? Insert()
        {
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HR_EMP.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.EMP_ID;
            }
            return Id;
        }
        public bool? Update()
        {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HR_EMP.Find(Item.Id);
                if (obj != null)
                {
                    obj.EMP_UID = Item.Code;
                    obj.USER_NAME = Item.UserName;
                    obj.SECURITY_QUESTION = Item.SecurityQuestion;
                    obj.SECURITY_ANSWER = Item.SecurityAnswer;
                    obj.PWD = Item.Password;
                    obj.UNIT_ID = Item.UnitId;
                    obj.JOBTITLE_ID = Item.JobtitleId;
                    obj.JOB_TYPE = Item.JobType;
                    obj.IS_RADIOLOGIST = Item.IsRadiologist.TryToString();
                    obj.SALUTATION = Item.Title;
                    obj.FNAME = Item.FirstName;
                    obj.MNAME = Item.MiddleName;
                    obj.LNAME = Item.LastName;
                    obj.TITLE_ENG = Item.TitleEng;
                    obj.FNAME_ENG = Item.FirstNameEng;
                    obj.MNAME_ENG = Item.MiddleNameEng;
                    obj.LNAME_ENG = Item.LastNameEng;
                    obj.GENDER = Item.Gender;
                    //obj.DISPLAY_NAME = Item.DisplayName;
                    obj.EMAIL_PERSONAL = Item.EmailPersonal;
                    obj.EMAIL_OFFICIAL = Item.EmailOfficial;
                    obj.PHONE_HOME = Item.PhoneHome;
                    obj.PHONE_MOBILE = Item.PhoneMobile;
                    obj.PHONE_OFFICE = Item.PhoneOffice;
                    obj.PREFERRED_PHONE = Item.PreferredPhone;
                    obj.PABX_EXT = Item.PABXExt;
                    obj.FAX_NO = Item.FaxNumber;
                    obj.DOB = Item.DateOfBirth;
                    obj.BLOOD_GROUP = Item.BloodGroup;
                    obj.DEFAULT_LANG = Item.DefaultLanguage;
                    obj.RELIGION = Item.Religion;
                    obj.PE_ADDR1 = Item.Addr1;
                    obj.PE_ADDR2 = Item.Addr2;
                    obj.PE_ADDR3 = Item.Addr3;
                    obj.PE_ADDR4 = Item.Addr4;
                    obj.AUTH_LEVEL_ID = Item.AuthLevelId;
                    obj.REPORTING_TO = Item.ReportingTo;
                    obj.ALLOW_OTHERS_TO_FINALIZE = Item.AllowOthersToFinalize.TryToString();
                    obj.LAST_PWD_MODIFIED = Item.LastPwdModified;
                    obj.LAST_LOGIN = Item.LastLogin;
                    obj.CARD_NO = Item.CardNo;
                    obj.PLACE_OF_BIRTH = Item.PlaceOfBirth;
                    obj.NATIONALITY = Item.Nationality;
                    obj.M_STATUS = Item.MilitaryStatus;
                    obj.IS_ACTIVE = Item.IsActive.TryToString();
                    obj.SUPPORT_USER = Item.SupportUser.TryToString();
                    obj.CAN_KILL_SESSION = Item.CanKillSession.TryToString();
                    obj.DEFAULT_SHIFT_NO = Item.DefaultShiftNumber;
                    obj.IMG_FILE_NAME = Item.ImageFileName;
                    obj.EMP_REPORT_FOOTER1 = Item.ReportFooter1;
                    obj.EMP_REPORT_FOOTER2 = Item.ReportFooter2;
                    obj.ALLPROPERTIES = Item.Allproperties;
                    obj.VISIBLE = Item.Visible;
                    obj.IS_RESIDENT = Item.IsResident.TryToString();
                    obj.CAN_EXCEED_SCHEDULE = Item.CanExceedSchedule.TryToString();
                    obj.IS_FELLOW = Item.IsFellow.TryToString();
                    obj.IS_NURSE = Item.IsNurse.TryToString();
                    obj.IS_TECHNOLOGIST = Item.IsTechnologist.TryToString();
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
                var obj = dbContext.HR_EMP.Find(Item.Id);
                if (obj != null)
                {
                    obj.IS_ACTIVE = "N";
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }
        public void GrantRole(List<GrantRole> objList)
        {
            if (objList == null) return;
            if (objList.Count == 0) return;
            foreach (var obj in objList)
            {
                using (var dbContext = new EnvisionDataModel())
                {
                    var itemSearch = (from data in dbContext.GBL_GRANTROLE
                                      where data.ROLE_ID == obj.RoleId
                                            && data.EMP_ID == obj.EmpId
                                      select data).ToList();
                    if (itemSearch == null || itemSearch.Count == 0)
                    {
                        GBL_GRANTROLE objAdd = ConvertType(obj);
                        objAdd.CREATED_ON = DateTime.Now;

                        dbContext.GBL_GRANTROLE.Add(objAdd);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        itemSearch[0].CAN_GRANT = obj.CanGrant;
                        itemSearch[0].GRANTOR = obj.Grantor;
                        itemSearch[0].GRANT_DT = DateTime.Now;
                        itemSearch[0].IS_UPDATED = "Y";
                        itemSearch[0].IS_DELETED = "N";
                        itemSearch[0].ORG_ID = obj.OrgId;
                        itemSearch[0].LAST_MODIFIED_BY = obj.ModifiedBy;
                        itemSearch[0].LAST_MODIFIED_ON = DateTime.Now;
                        dbContext.SaveChanges();
                    }
                }
            }
        }


        public List<UserInfo> GetAllData()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserInfo> GetAllActiveData()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        public UserInfo GetById()
        {
            UserInfo obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HR_EMP.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public UserInfo GetByCode()
        {
            UserInfo obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId
                                        && data.EMP_UID == Item.Code
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new UserInfo();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public UserInfo GetByUserName()
        {
            UserInfo obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId
                                        && data.USER_NAME == Item.UserName
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new UserInfo();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }
        public UserInfo GetByUserNameAndPassword()
        {
            UserInfo obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.USER_NAME == Item.UserName
                                        && data.PWD == "ptssFFqOjIAYcnyzoYT++A=="
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0)
                {
                    obj = new UserInfo();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        public List<UserInfo> GetDoctor()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" && data.JOB_TYPE == "D"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserInfo> GetRadiologist()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" && data.IS_RADIOLOGIST == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserInfo> GetResident()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" && data.IS_RADIOLOGIST == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserInfo> GetFellow()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" && data.IS_RADIOLOGIST == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserInfo> GetTechnologist()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" && data.IS_TECHNOLOGIST == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }
        public List<UserInfo> GetNurse()
        {
            List<UserInfo> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HR_EMP
                                  where data.ORG_ID == Item.OrgId && data.IS_ACTIVE == "Y" && data.IS_NURSE == "Y"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<UserInfo>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
            return itemList;
        }

        #region Convert Type.
        private HR_EMP ConvertType(UserInfo item)
        {
            HR_EMP obj = null;
            if (item != null)
            {
                obj = new HR_EMP();

                obj.EMP_ID = item.Id;
                obj.EMP_UID = item.Code;
                obj.USER_NAME = item.UserName;
                obj.SECURITY_QUESTION = item.SecurityQuestion;
                obj.SECURITY_ANSWER = item.SecurityAnswer;
                obj.PWD = item.Password;
                obj.UNIT_ID = item.UnitId;
                obj.JOBTITLE_ID = item.JobtitleId;
                obj.JOB_TYPE = item.JobType;
                obj.IS_RADIOLOGIST = item.IsRadiologist.TryToString();
                obj.SALUTATION = item.Title;
                obj.FNAME = item.FirstName;
                obj.MNAME = item.MiddleName;
                obj.LNAME = item.LastName;
                obj.TITLE_ENG = item.TitleEng;
                obj.FNAME_ENG = item.FirstNameEng;
                obj.MNAME_ENG = item.MiddleNameEng;
                obj.LNAME_ENG = item.LastNameEng;
                obj.GENDER = item.Gender;
                //obj.DISPLAY_NAME = item.DisplayName;
                obj.EMAIL_PERSONAL = item.EmailPersonal;
                obj.EMAIL_OFFICIAL = item.EmailOfficial;
                obj.PHONE_HOME = item.PhoneHome;
                obj.PHONE_MOBILE = item.PhoneMobile;
                obj.PHONE_OFFICE = item.PhoneOffice;
                obj.PREFERRED_PHONE = item.PreferredPhone;
                obj.PABX_EXT = item.PABXExt;
                obj.FAX_NO = item.FaxNumber;
                obj.DOB = item.DateOfBirth;
                obj.BLOOD_GROUP = item.BloodGroup;
                obj.DEFAULT_LANG = item.DefaultLanguage;
                obj.RELIGION = item.Religion;
                obj.PE_ADDR1 = item.Addr1;
                obj.PE_ADDR2 = item.Addr2;
                obj.PE_ADDR3 = item.Addr3;
                obj.PE_ADDR4 = item.Addr4;
                obj.AUTH_LEVEL_ID = item.AuthLevelId;
                obj.REPORTING_TO = item.ReportingTo;
                obj.ALLOW_OTHERS_TO_FINALIZE = item.AllowOthersToFinalize.TryToString();
                obj.LAST_PWD_MODIFIED = item.LastPwdModified;
                obj.LAST_LOGIN = item.LastLogin;
                obj.CARD_NO = item.CardNo;
                obj.PLACE_OF_BIRTH = item.PlaceOfBirth;
                obj.NATIONALITY = item.Nationality;
                obj.M_STATUS = item.MilitaryStatus;
                obj.IS_ACTIVE = item.IsActive.TryToString();
                obj.SUPPORT_USER = item.SupportUser.TryToString();
                obj.CAN_KILL_SESSION = item.CanKillSession.TryToString();
                obj.DEFAULT_SHIFT_NO = item.DefaultShiftNumber;
                obj.IMG_FILE_NAME = item.ImageFileName;
                obj.EMP_REPORT_FOOTER1 = item.ReportFooter1;
                obj.EMP_REPORT_FOOTER2 = item.ReportFooter2;
                obj.ALLPROPERTIES = item.Allproperties;
                obj.VISIBLE = item.Visible;
                obj.IS_RESIDENT = item.IsResident.TryToString();
                obj.CAN_EXCEED_SCHEDULE = item.CanExceedSchedule.TryToString();
                obj.IS_FELLOW = item.IsFellow.TryToString();
                obj.IS_NURSE = item.IsNurse.TryToString();
                obj.IS_TECHNOLOGIST = item.IsTechnologist.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private UserInfo ConvertType(HR_EMP item)
        {
            UserInfo obj = null;
            if (item != null)
            {
                obj = new UserInfo();

                obj.Id = item.EMP_ID;
                obj.Code = item.EMP_UID;
                obj.UserName = item.USER_NAME;
                obj.SecurityQuestion = item.SECURITY_QUESTION;
                obj.SecurityAnswer = item.SECURITY_ANSWER;
                obj.Password = item.PWD;
                obj.UnitId = item.UNIT_ID;
                obj.JobtitleId = item.JOBTITLE_ID;
                obj.JobType = item.JOB_TYPE;
                obj.IsRadiologist = item.IS_RADIOLOGIST.TryToBoolean();
                obj.Title = item.SALUTATION;
                obj.FirstName = item.FNAME;
                obj.MiddleName = item.MNAME;
                obj.LastName = item.LNAME;
                obj.TitleEng = item.TITLE_ENG;
                obj.FirstNameEng = item.FNAME_ENG;
                obj.MiddleNameEng = item.MNAME_ENG;
                obj.LastNameEng = item.LNAME_ENG;
                obj.Gender = item.GENDER;
                //obj.DisplayName = item.DISPLAY_NAME;
                obj.EmailPersonal = item.EMAIL_PERSONAL;
                obj.EmailOfficial = item.EMAIL_OFFICIAL;
                obj.PhoneHome = item.PHONE_HOME;
                obj.PhoneMobile = item.PHONE_MOBILE;
                obj.PhoneOffice = item.PHONE_OFFICE;
                obj.PreferredPhone = item.PREFERRED_PHONE;
                obj.PABXExt = item.PABX_EXT;
                obj.FaxNumber = item.FAX_NO;
                obj.DateOfBirth = item.DOB;
                obj.BloodGroup = item.BLOOD_GROUP;
                obj.DefaultLanguage = item.DEFAULT_LANG;
                obj.Religion = item.RELIGION;
                obj.Addr1 = item.PE_ADDR1;
                obj.Addr2 = item.PE_ADDR2;
                obj.Addr3 = item.PE_ADDR3;
                obj.Addr4 = item.PE_ADDR4;
                obj.AuthLevelId = item.AUTH_LEVEL_ID;
                obj.ReportingTo = item.REPORTING_TO;
                obj.AllowOthersToFinalize = item.ALLOW_OTHERS_TO_FINALIZE.TryToBoolean();
                obj.LastPwdModified = item.LAST_PWD_MODIFIED;
                obj.LastLogin = item.LAST_LOGIN;
                obj.CardNo = item.CARD_NO;
                obj.PlaceOfBirth = item.PLACE_OF_BIRTH;
                obj.Nationality = item.NATIONALITY;
                obj.MilitaryStatus = item.M_STATUS;
                obj.IsActive = item.IS_ACTIVE.TryToBoolean();
                obj.SupportUser = item.SUPPORT_USER.TryToBoolean();
                obj.CanKillSession = item.CAN_KILL_SESSION.TryToBoolean();
                obj.DefaultShiftNumber = item.DEFAULT_SHIFT_NO;
                obj.ImageFileName = item.IMG_FILE_NAME;
                obj.ReportFooter1 = item.EMP_REPORT_FOOTER1;
                obj.ReportFooter2 = item.EMP_REPORT_FOOTER2;
                obj.Allproperties = item.ALLPROPERTIES;
                obj.Visible = item.VISIBLE;
                obj.IsResident = item.IS_RESIDENT.TryToBoolean();
                obj.CanExceedSchedule = item.CAN_EXCEED_SCHEDULE.TryToBoolean();
                obj.IsFellow = item.IS_FELLOW.TryToBoolean();
                obj.IsNurse = item.IS_NURSE.TryToBoolean();
                obj.IsTechnologist = item.IS_TECHNOLOGIST.TryToBoolean();
                obj.OrgId = item.ORG_ID;
                obj.CreatedBy = item.CREATED_BY;
                obj.CreatedOn = item.CREATED_ON;
                obj.ModifiedBy = item.LAST_MODIFIED_BY;
                obj.ModifiedOn = item.LAST_MODIFIED_ON;
            }
            return obj;
        }

        private GBL_GRANTROLE ConvertType(GrantRole item)
        {
            GBL_GRANTROLE obj = null;
            if (item != null)
            {
                obj = new GBL_GRANTROLE();

                obj.GRANTROLE_ID = item.Id;
                obj.ROLE_ID = item.RoleId;
                obj.EMP_ID = item.EmpId;
                obj.CAN_GRANT = item.CanGrant;
                obj.GRANTOR = item.Grantor;
                obj.GRANT_DT = item.GrantDate;
                obj.IS_UPDATED = item.IsUpdate.TryToString();
                obj.IS_DELETED = item.IsDelete.TryToString();
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private GrantRole ConvertType(GBL_GRANTROLE item)
        {
            GrantRole obj = null;
            if (item != null)
            {
                obj = new GrantRole();

                obj.Id = item.GRANTROLE_ID;
                obj.RoleId = item.ROLE_ID;
                obj.EmpId = item.EMP_ID;
                obj.CanGrant = item.CAN_GRANT;
                obj.Grantor = item.GRANTOR;
                obj.GrantDate = item.GRANT_DT;
                obj.IsUpdate = item.IS_UPDATED.TryToBoolean();
                obj.IsDelete = item.IS_DELETED.TryToBoolean();
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