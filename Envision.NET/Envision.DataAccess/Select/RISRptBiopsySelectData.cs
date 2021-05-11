using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISRptBiopsySelectData : DataAccessBase
    {
        private string Accession_no;
        private int UserID;
        private string rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13;
        
        public RISRptBiopsySelectData(string Accession, int userID
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

            StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_BiopsyResult;
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(Accession_no, UserID, rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(string Accession, int userID
                                        , string RC, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10, string R11, string R12, string RO
                                        , string LC, string L1, string L2, string L3, string L4, string L5, string L6, string L7, string L8, string L9, string L10, string L11, string L12, string LO)
        {
            DbParameter[] parameters = { 
                                            Parameter("@Accession_no", Accession_no)
                                            ,Parameter("@UserID",UserID)
                                            ,Parameter("@RC",rc)
                                            ,Parameter("@R1",r1)
                                            ,Parameter("@R2",r2)
                                            ,Parameter("@R3",r3)
                                            ,Parameter("@R4",r4)
                                            ,Parameter("@R5",r5)
                                            ,Parameter("@R6",r6)
                                            ,Parameter("@R7",r7)
                                            ,Parameter("@R8",r8)
                                            ,Parameter("@R9",r9)
                                            ,Parameter("@R10",r10)
                                            ,Parameter("@R11",r11)
                                            ,Parameter("@R12",r12)
                                            ,Parameter("@RO",r13)
                                            ,Parameter("@LC",lc)
                                            ,Parameter("@L1",l1)
                                            ,Parameter("@L2",l2)
                                            ,Parameter("@L3",l3)
                                            ,Parameter("@L4",l4)
                                            ,Parameter("@L5",l5)
                                            ,Parameter("@L6",l6)
                                            ,Parameter("@L7",l7)
                                            ,Parameter("@L8",l8)
                                            ,Parameter("@L9",l9)
                                            ,Parameter("@L10",l10)
                                            ,Parameter("@L11",l11)
                                            ,Parameter("@L12",l12)
                                            ,Parameter("@LO",l13)

                                            
                                        };
            return parameters;
        }
    }

}
