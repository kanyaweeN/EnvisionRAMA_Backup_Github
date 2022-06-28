using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Envision.BusinessLogic
{
    /// <summary>
    /// this class use to manage envision to pacs
    /// </summary>
    public class PascManagement
    {
        private static DataTable dtGenHL7 = new DataTable();
        /// <summary>
        /// Static constructor
        /// </summary>
        static PascManagement()
        {
            // Create HL7 datatable format
            dtGenHL7.Columns.Add("ACCESSION_NO");
            dtGenHL7.Columns.Add("ordflag");
            dtGenHL7.Columns.Add("ORDER_ID");
            dtGenHL7.Columns.Add("EXAM_UID");
            dtGenHL7.Columns.Add("EXAM_NAME");
            dtGenHL7.Columns.Add("PRIORITY");
            dtGenHL7.AcceptChanges();
        }
        /// <summary>
        /// This method use to get HL7 datatable schemas
        /// </summary>
        /// <returns>HL7 datatable format</returns>
        public static DataTable GetHL7DataTableSchemas()
        {
            return dtGenHL7.Clone();
        }
    }
}
