using System;

namespace Envision.Entity.Common
{
    public class Room : BaseObject
    {
        public Room(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public bool? IsActive { get; set;}
    }
}