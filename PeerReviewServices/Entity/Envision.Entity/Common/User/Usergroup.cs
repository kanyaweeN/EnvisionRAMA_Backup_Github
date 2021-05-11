using System;

namespace Envision.Entity.Common.User
{
    public class UserGroup : BaseObject
    {
        public UserGroup(){

        }

        public int Id { get; set;}
        public string Name { get; set;}
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Type { get; set;}
        public int? Head { get; set;}
        public string ContactNo { get; set;}
        public bool? IsActive { get; set;}
    }
}