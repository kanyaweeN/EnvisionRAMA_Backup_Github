using System;

namespace Envision.Entity.Common
{
    public class Sequences : BaseObject
    {
        public Sequences(){

        }

        public string Name { get; set;}
        public int Seed { get; set;}
        public int Increment { get; set;}
        public int? CurrentValue { get; set;}
        public DateTime? StartDate { get; set;}
    }
}