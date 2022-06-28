using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.Adr
{
    public class AdrData
    {
        public string adrId { get; set; }
        public string drugCode { get; set; }
        public string drugName { get; set; }
        public string ingredientCode { get; set; }
        public string ingredientName { get; set; }
        public AdrLevel adrLevel { get; set; }
        public string severity { get; set; }
        public string naranjo { get; set; }
        public string sideEffect { get; set; }
        public string editDate { get; set; }
        public List<AdrComment> comments { get; set; }
    }
}
