using System;

namespace Envision.Entity.Common
{
    public class Product : BaseObject
    {
        public Product(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public string Version { get; set;}
        public DateTime? ReleaseDate { get; set;}
        public string Type { get; set;}
        public string LicensedTo { get; set;}
        public string LicenseType { get; set;}
        public DateTime? ValidUntil { get; set;}
        public string ForceLicense { get; set;}
        public string CopyRight { get; set;}
    }
}