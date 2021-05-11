using System;

namespace Envision.Entity.Common.User
{
    public class Occupation : BaseObject
    {
        public Occupation(){

        }

        public int Id { get; set;}
        public string Code { get; set;}
        public string Description { get; set;}
    }
}