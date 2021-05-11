using System;

namespace Envision.Entity.Common
{
    public class Session : BaseObject
    {
        public Session(){

        }

        public int Id { get; set;}
        public string Status { get; set;}
        public int? EmpId { get; set;}
        public string SessionGuid { get; set;}
        public string SID { get; set;}
        public string Serial { get; set;}
        public string LogOnType { get; set;}
        public DateTime? LogOnTimeStamp { get; set;}
        public DateTime? LogOutTimeStamp { get; set;}
        public string LogOutType { get; set;}
        public int? KilledBy { get; set;}
        public string KillReason { get; set;}
        public string OSUserName { get; set;}
        public string OSName { get; set;}
        public string OSTimezone { get; set;}
        public string OSRegion { get; set;}
        public string IpAddressOwner { get; set;}
        public string IpAddressCurrent { get; set;}
        public string ProductVersion { get; set; }
    }
}