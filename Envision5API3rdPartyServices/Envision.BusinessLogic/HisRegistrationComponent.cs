using Envision.Database;
using Envision.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.BusinessLogic
{
    public class HisRegistrationComponent
    {
        public HisRegistration Item { get; set; }
        public HisRegistrationComponent()
        {
            Item = new HisRegistration();
        }

        public HisRegistration Invoke()
        {
            using (var context = new EnvisionContext())
            {
                var obj = context.HisRegistration.Where(x => x.Hn == Item.Hn).FirstOrDefault();
                if (obj != null)
                {
                    obj.Hn = Item.Hn;
                    obj.Title = Item.Title == null ? obj.Title : Item.Title;
                    obj.RegDt = Item.RegDt == null ? obj.RegDt : Item.RegDt;
                    obj.Fname = Item.Fname == null ? obj.Fname : Item.Fname;
                    obj.Mname = Item.Mname == null ? obj.Mname : Item.Mname;
                    obj.Lname = Item.Lname == null ? obj.Lname : Item.Lname;
                    obj.TitleEng = Item.TitleEng == null ? obj.TitleEng : Item.TitleEng;
                    obj.FnameEng = Item.FnameEng == null ? obj.FnameEng : Item.FnameEng;
                    obj.LnameEng = Item.LnameEng == null ? obj.LnameEng : Item.LnameEng;
                    obj.MnameEng = Item.MnameEng == null ? obj.MnameEng : Item.MnameEng;
                    obj.Ssn = Item.Ssn == null ? obj.Ssn : Item.Ssn;
                    obj.Dob = Item.Dob == null ? obj.Dob : Item.Dob;
                    obj.Age = Item.Age == null ? obj.Age : Item.Age;
                    obj.Address1 = Item.Address1 == null ? obj.Address1 : Item.Address1;
                    obj.Address2 = Item.Address2 == null ? obj.Address2 : Item.Address2;
                    obj.Address3 = Item.Address3 == null ? obj.Address3 : Item.Address3;
                    obj.Address4 = Item.Address4 == null ? obj.Address4 : Item.Address4;
                    obj.Address5 = Item.Address5 == null ? obj.Address5 : Item.Address5;
                    obj.Phone1 = Item.Phone1 == null ? obj.Phone1 : Item.Phone1;
                    obj.Phone2 = Item.Phone2 == null ? obj.Phone2 : Item.Phone2;
                    obj.Phone3 = Item.Phone3 == null ? obj.Phone3 : Item.Phone3;
                    obj.Email = Item.Email == null ? obj.Email : Item.Email;
                    obj.Gender = Item.Gender == null ? obj.Gender : Item.Gender;
                    obj.MaritalStatus = Item.MaritalStatus == null ? obj.MaritalStatus : Item.MaritalStatus;
                    obj.OccupationId = Item.OccupationId == null ? obj.OccupationId : Item.OccupationId;
                    obj.Natiionality = Item.Natiionality == null ? obj.Natiionality : Item.Natiionality;
                    obj.PassportNo = Item.PassportNo == null ? obj.PassportNo : Item.PassportNo;
                    obj.BloodGroup = Item.BloodGroup == null ? obj.BloodGroup : Item.BloodGroup;
                    obj.Religion = Item.Religion == null ? obj.Religion : Item.Religion;
                    obj.PatientType = Item.PatientType == null ? obj.PatientType : Item.PatientType;
                    obj.BlockPatient = Item.BlockPatient == null ? obj.BlockPatient : Item.BlockPatient;
                    obj.EmContactPerson = Item.EmContactPerson == null ? obj.EmContactPerson : Item.EmContactPerson;
                    obj.EmRelation = Item.EmRelation == null ? obj.EmRelation : Item.EmRelation;
                    obj.EmAddress = Item.EmAddress == null ? obj.EmAddress : Item.EmAddress;
                    obj.EmPhone = Item.EmPhone == null ? obj.EmPhone : Item.EmPhone;
                    obj.InsuranceType = Item.InsuranceType == null ? obj.InsuranceType : Item.InsuranceType;
                    obj.Allergies = Item.Allergies == null ? obj.Allergies : Item.Allergies;
                    obj.OrgId = Item.OrgId;
                    obj.LastModifiedBy = Item.LastModifiedBy;
                    obj.LastModifiedOn = DateTime.Now;
                    obj.IsDeleted = Item.IsDeleted == null ? obj.IsDeleted : Item.IsDeleted;
                    obj.IsUpdated = Item.IsUpdated == null ? obj.IsUpdated : Item.IsUpdated;
                    obj.Pciture = Item.Pciture == null ? obj.Pciture : Item.Pciture;
                    obj.PcitureName = Item.PcitureName == null ? obj.PcitureName : Item.PcitureName;
                    obj.IsJohndoe = Item.IsJohndoe == null ? obj.IsJohndoe : Item.IsJohndoe;
                    obj.IsForeigner = Item.IsForeigner == null ? obj.IsForeigner : Item.IsForeigner;
                    obj.HisHn = Item.HisHn == null ? obj.HisHn : Item.HisHn;
                    obj.ExtHn = Item.ExtHn == null ? obj.ExtHn : Item.ExtHn;
                    obj.PatientIdentificationLabel = Item.PatientIdentificationLabel == null ? obj.PatientIdentificationLabel : Item.PatientIdentificationLabel;
                    obj.PatientIdentificationDetail = Item.PatientIdentificationDetail == null ? obj.PatientIdentificationDetail : Item.PatientIdentificationDetail;
                    obj.IsVip = Item.IsVip == null ? obj.IsVip : Item.IsVip;
                    context.SaveChanges();
                    Item = obj;
                } else
                {
                    Item.RegDt = Item.RegDt == null ? DateTime.Now : Item.RegDt;
                    context.HisRegistration.Add(Item);
                    context.SaveChanges();
                }
            }
            return Item;
        }
        public HisRegistration GetByHn(string hn)
        {
            HisRegistration data = null;
            using (var context = new EnvisionContext())
            {
                data = context.HisRegistration.Where(x => x.Hn == hn).FirstOrDefault();
            }
            return data;
        }
    }
}