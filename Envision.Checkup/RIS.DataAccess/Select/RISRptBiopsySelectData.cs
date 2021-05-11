using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
    public class RISRptBiopsySelectData : DataAccessBase
    {
        private string Accession_no;
        private int UserID;
        private string rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13;

        RISRptBiopsySelectDataParameters _risrptbiopsyselectdataparameters;

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

            StoredProcedureName = StoredProcedure.Name.Prc_RIS_Rpt_BiopsyResult.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _risrptbiopsyselectdataparameters = new RISRptBiopsySelectDataParameters(Accession_no,UserID,rc,r1,r2,r3,r4,r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _risrptbiopsyselectdataparameters.Parameters);
            return ds;
        }
    }

    public class RISRptBiopsySelectDataParameters
    {
        private SqlParameter[] _parameters;
        private string Accession_no;
        private int UserID;
        private string rc, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, lc, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13;

        public RISRptBiopsySelectDataParameters(string Accession,int userID
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

            Build();
        }
        
        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public void Build()
        {
            SqlParameter[] parameters = { 
                                            new SqlParameter("@Accession_no", Accession_no)
                                            ,new SqlParameter("@UserID",UserID)
                                            ,new SqlParameter("@RC",rc)
                                            ,new SqlParameter("@R1",r1)
                                            ,new SqlParameter("@R2",r2)
                                            ,new SqlParameter("@R3",r3)
                                            ,new SqlParameter("@R4",r4)
                                            ,new SqlParameter("@R5",r5)
                                            ,new SqlParameter("@R6",r6)
                                            ,new SqlParameter("@R7",r7)
                                            ,new SqlParameter("@R8",r8)
                                            ,new SqlParameter("@R9",r9)
                                            ,new SqlParameter("@R10",r10)
                                            ,new SqlParameter("@R11",r11)
                                            ,new SqlParameter("@R12",r12)
                                            ,new SqlParameter("@RO",r13)
                                            ,new SqlParameter("@LC",lc)
                                            ,new SqlParameter("@L1",l1)
                                            ,new SqlParameter("@L2",l2)
                                            ,new SqlParameter("@L3",l3)
                                            ,new SqlParameter("@L4",l4)
                                            ,new SqlParameter("@L5",l5)
                                            ,new SqlParameter("@L6",l6)
                                            ,new SqlParameter("@L7",l7)
                                            ,new SqlParameter("@L8",l8)
                                            ,new SqlParameter("@L9",l9)
                                            ,new SqlParameter("@L10",l10)
                                            ,new SqlParameter("@L11",l11)
                                            ,new SqlParameter("@L12",l12)
                                            ,new SqlParameter("@LO",l13)

                                            
                                        };
            Parameters = parameters;
        }
    }
}
