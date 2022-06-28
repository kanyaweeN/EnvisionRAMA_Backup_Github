using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRptBiopsyResult : IBusinessLogic
    {
         private DataSet result;
           private string Accession_no;
        private int UserID;
        private string rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13;

        public ProcessGetRptBiopsyResult(string Accession, int userID
                                        , string RC, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10, string R11, string R12, string RO
                                        , string LC, string L1, string L2, string L3, string L4, string L5, string L6, string L7, string L8, string L9, string L10, string L11, string L12, string LO)
        {
            Accession_no = Accession;
            UserID = userID;

            rc = RC;
            r1 = R1;
            r2 = R2;
            r3 = R3;
            r4 = R4;
            r5 = R5;
            r6 = R6;
            r7 = R7;
            r8 = R8;
            r9 = R9;
            r10 = R10;
            r11 = R11;
            r12 = R12;
            r13 = RO;

            lc = LC;
            l1 = L1;
            l2 = L2;
            l3 = L3;
            l4 = L4;
            l5 = L5;
            l6 = L6;
            l7 = L7;
            l8 = L8;
            l9 = L9;
            l10 = L10;
            l11 = L11;
            l12 = L12;
            l13 = LO;

        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }

        public void Invoke()
        {
            RISRptBiopsySelectData _proc = null;
            _proc = new RISRptBiopsySelectData(Accession_no,UserID,rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
            result = _proc.Get().Copy();
        }
    }
}
