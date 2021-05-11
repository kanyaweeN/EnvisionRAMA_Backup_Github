using System;
using System.Collections.Generic;
using System.Linq;
using Envision.Database;
using Envision.Entity.Common;

namespace Envision.DataAccess.Common
{
    public class DbPatient
    {
        public DbPatient(){
            dbItem = new HIS_REGISTRATION();
            Item = new Patient();
        }

        private HIS_REGISTRATION dbItem { get; set; }
        public Patient Item { get; set; }

        public int? Insert(){
            int? Id = null;
            using (var dbContext = new EnvisionDataModel())
            {
                dbItem = ConvertType(Item);
                dbItem.CREATED_ON = DateTime.Now;

                dbContext.HIS_REGISTRATION.Add(dbItem);
                dbContext.SaveChanges();

                Id = dbItem.REG_ID;
            }
            return Id;
        }
        public bool? Update(){
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HIS_REGISTRATION.Find(Item.Id);
                if (obj != null)
                {
                    obj.HN = Item.HN;
                    obj.TITLE = Item.Title;
                    obj.REG_DT = Item.RegistDate;
                    obj.FNAME = Item.FirstName;
                    obj.MNAME = Item.MiddleName;
                    obj.LNAME = Item.LastName;
                    obj.TITLE_ENG = Item.TitleEng;
                    obj.FNAME_ENG = Item.FirstNameEng;
                    obj.MNAME_ENG = Item.MiddleNameEng;
                    obj.LNAME_ENG = Item.LastNameEng;
                    obj.SSN = Item.SocialNumber;
                    obj.DOB = Item.DateOfBirth;
                    obj.AGE = Item.Age;
                    obj.ADDR1 = Item.Addr1;
                    obj.ADDR2 = Item.Addr2;
                    obj.ADDR3 = Item.Addr3;
                    obj.ADDR4 = Item.Addr4;
                    obj.ADDR5 = Item.Addr5;
                    obj.PHONE1 = Item.Phone1;
                    obj.PHONE2 = Item.Phone2;
                    obj.PHONE3 = Item.Phone3;
                    obj.EMAIL = Item.Email;
                    obj.GENDER = Item.Gender;
                    obj.MARITAL_STATUS = Item.MaritalStatus;
                    obj.OCCUPATION_ID = Item.OccupationId;
                    obj.NATIONALITY = Item.Nationality;
                    obj.PASSPORT_NO = Item.PassportNumber;
                    obj.BLOOD_GROUP = Item.BloodGroup;
                    obj.RELIGION = Item.Religion;
                    obj.PATIENT_TYPE = Item.PatientType;
                    obj.BLOCK_PATIENT = Item.BlockPatient;
                    obj.EM_CONTACT_PERSON = Item.EmergencyContactPerson;
                    obj.EM_RELATION = Item.EmergencyContactRelation;
                    obj.EM_ADDR = Item.EmergencyContactAddress;
                    obj.EM_PHONE = Item.EmergencyContactPhone;
                    obj.INSURANCE_TYPE = Item.InsuranceType;
                    obj.HL7_FORMAT = Item.HL7;
                    obj.HL7_SEND = Item.IsHL7Send;
                    obj.LINK_DOWN = Item.IsLinkDown;
                    obj.ALLERGIES = Item.Allergy;
                    obj.IS_DELETED = Item.IsDelete;
                    obj.IS_UPDATED = Item.IsUpdate;
                    obj.Picture = Item.Picture;
                    obj.IS_JOHNDOE = Item.IsJohnDoe;
                    obj.IS_PREGNANT = Item.IsPregnant;
                    obj.ORG_ID = Item.OrgId;
                    obj.LAST_MODIFIED_BY = Item.ModifiedBy;
                    obj.LAST_MODIFIED_ON = DateTime.Now;

                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }
        public bool? Delete() {
            bool? flag = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var obj = dbContext.HIS_REGISTRATION.Find(Item.Id);
                if (obj != null)
                {
                    dbContext.HIS_REGISTRATION.Remove(obj);
                    flag = dbContext.SaveChanges() > 0;
                }
            }
            return flag;
        }

        public List<Patient> GetAllData() {
            List<Patient> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_REGISTRATION
                                  where data.ORG_ID == Item.OrgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Patient>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public List<Patient> GetAllActiveData() {
            List<Patient> itemList = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var itemSearch = (from data in dbContext.HIS_REGISTRATION
                                  where data.ORG_ID == Item.OrgId && data.IS_DELETED == "N"
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<Patient>();
                    foreach (var obj in itemSearch)
                        itemList.Add(ConvertType(obj));
                }
            }
             return itemList;
        }
        public Patient GetById() {
            Patient obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                var objFind = dbContext.HIS_REGISTRATION.Find(Item.Id);
                obj = ConvertType(objFind);
            }

            return obj;
        }
        public Patient GetByHN() {
            Patient obj = null;
            using (var dbContext = new EnvisionDataModel())
            {
                 var itemSearch = (from data in dbContext.HIS_REGISTRATION
                                  where data.ORG_ID == Item.OrgId
                                        && data.HN == Item.HN
                                  select data).ToList();
                if (itemSearch != null && itemSearch.Count > 0) {
                    obj = new Patient();
                    obj = ConvertType(itemSearch[0]);
                }
            }

            return obj;
        }

        #region Convert Type.
        private HIS_REGISTRATION ConvertType(Patient item) {
            HIS_REGISTRATION obj = null;
            if (item != null)
            {
                obj = new HIS_REGISTRATION();

                obj.REG_ID = item.Id;
                obj.HN = item.HN;
                obj.TITLE = item.Title;
                obj.REG_DT = item.RegistDate;
                obj.FNAME = item.FirstName;
                obj.MNAME = item.MiddleName;
                obj.LNAME = item.LastName;
                obj.TITLE_ENG = item.TitleEng;
                obj.FNAME_ENG = item.FirstNameEng;
                obj.MNAME_ENG = item.MiddleNameEng;
                obj.LNAME_ENG = item.LastNameEng;
                obj.SSN = item.SocialNumber;
                obj.DOB = item.DateOfBirth;
                obj.AGE = item.Age;
                obj.ADDR1 = item.Addr1;
                obj.ADDR2 = item.Addr2;
                obj.ADDR3 = item.Addr3;
                obj.ADDR4 = item.Addr4;
                obj.ADDR5 = item.Addr5;
                obj.PHONE1 = item.Phone1;
                obj.PHONE2 = item.Phone2;
                obj.PHONE3 = item.Phone3;
                obj.EMAIL = item.Email;
                obj.GENDER = item.Gender;
                obj.MARITAL_STATUS = item.MaritalStatus;
                obj.OCCUPATION_ID = item.OccupationId;
                obj.NATIONALITY = item.Nationality;
                obj.PASSPORT_NO = item.PassportNumber;
                obj.BLOOD_GROUP = item.BloodGroup;
                obj.RELIGION = item.Religion;
                obj.PATIENT_TYPE = item.PatientType;
                obj.BLOCK_PATIENT = item.BlockPatient;
                obj.EM_CONTACT_PERSON = item.EmergencyContactPerson;
                obj.EM_RELATION = item.EmergencyContactRelation;
                obj.EM_ADDR = item.EmergencyContactAddress;
                obj.EM_PHONE = item.EmergencyContactPhone;
                obj.INSURANCE_TYPE = item.InsuranceType;
                obj.HL7_FORMAT = item.HL7;
                obj.HL7_SEND = item.IsHL7Send;
                obj.LINK_DOWN = item.IsLinkDown;
                obj.ALLERGIES = item.Allergy;
                obj.IS_DELETED = item.IsDelete;
                obj.IS_UPDATED = item.IsUpdate;
                obj.Picture = item.Picture;
                obj.IS_JOHNDOE = item.IsJohnDoe;
                obj.IS_PREGNANT = item.IsPregnant;
                obj.ORG_ID = item.OrgId;
                obj.CREATED_BY = item.CreatedBy;
                obj.CREATED_ON = item.CreatedOn;
                obj.LAST_MODIFIED_BY = item.ModifiedBy;
                obj.LAST_MODIFIED_ON = item.ModifiedOn;
            }
            return obj;
        }
        private Patient ConvertType(HIS_REGISTRATION item) {
            Patient obj = null;
            if (item != null)
            {
                obj = new Patient();

                obj.Id = item.REG_ID;
                obj.HN = item.HN;
                obj.Title = item.TITLE;
                obj.RegistDate = item.REG_DT;
                obj.FirstName = item.FNAME;
                obj.MiddleName = item.MNAME;
                obj.LastName = item.LNAME;
                obj.TitleEng = item.TITLE_ENG;
                obj.FirstNameEng = item.FNAME_ENG;
                obj.MiddleNameEng = item.MNAME_ENG;
                obj.LastNameEng = item.LNAME_ENG;
                obj.SocialNumber = item.SSN;
                obj.DateOfBirth = item.DOB;
                obj.Age = item.AGE;
                obj.Addr1 = item.ADDR1;
                obj.Addr2 = item.ADDR2;
                obj.Addr3 = item.ADDR3;
                obj.Addr4 = item.ADDR4;
                obj.Addr5 = item.ADDR5;
                obj.Phone1 = item.PHONE1;
                obj.Phone2 = item.PHONE2;
                obj.Phone3 = item.PHONE3;
                obj.Email = item.EMAIL;
                obj.Gender = item.GENDER;
                obj.MaritalStatus = item.MARITAL_STATUS;
                obj.OccupationId = item.OCCUPATION_ID;
                obj.Nationality = item.NATIONALITY;
                obj.PassportNumber = item.PASSPORT_NO;
                obj.BloodGroup = item.BLOOD_GROUP;
                obj.Religion = item.RELIGION;
                obj.PatientType = item.PATIENT_TYPE;
                obj.BlockPatient = item.BLOCK_PATIENT;
                obj.EmergencyContactPerson = item.EM_CONTACT_PERSON;
                obj.EmergencyContactRelation = item.EM_RELATION;
                obj.EmergencyContactAddress = item.EM_ADDR;
                obj.EmergencyContactPhone = item.EM_PHONE;
                obj.InsuranceType = item.INSURANCE_TYPE;
                obj.HL7 = item.HL7_FORMAT;
                obj.IsHL7Send = item.HL7_SEND;
                obj.IsLinkDown = item.LINK_DOWN;
                obj.Allergy = item.ALLERGIES;
                obj.IsDelete = item.IS_DELETED;
                obj.IsUpdate = item.IS_UPDATED;
                obj.Picture = item.Picture;
                obj.IsJohnDoe = item.IS_JOHNDOE;
                obj.IsPregnant = item.IS_PREGNANT;
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