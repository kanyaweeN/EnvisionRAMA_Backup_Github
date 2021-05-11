using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity
{
    public enum FilterBy
    {
        Id,
        Code,
        Accession,
        HN,
        OrgId,
        OneDay,
        RangeDay,
        UserId,
    }
    public class SearchFilter
    {
        public SearchFilter()
        {
           // Condition = FilterBy.OrgId;
        }

        public FilterBy Condition;
        public int Id { get; set; }
        public string Code { get; set; }
        public string HN { get; set; }
        public string Accession { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int OrgId { get; set; }
        public int UserId { get; set; }
    }
}
