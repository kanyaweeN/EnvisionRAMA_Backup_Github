using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACAssignmentSelectData : DataAccessBase
    {
         DataSet ds;
         public ACAssignmentSelectData()
        {

        }
        public DataSet SelectAll()
        {
            ParameterList = buildParameteSelectAll();
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByID(int _id)
        {
            ParameterList = buildParameteSelectByID(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable SelectByAccessionNo(string _acc)
        {
            ParameterList = buildParameteSelectByAccession(_acc);
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_CheckMerge;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataSet SelectByAccessionNo(string _acc,int _empid)
        {
            ParameterList = buildParameteSelectByAccessionNo(_acc, _empid);
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_SelectByAccessionNo;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByAccessionNoRAD(string _acc, int _empid)
        {
            ParameterList = buildParameteSelectByAccessionNoRAD(_acc, _empid);
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_SelectByAccessionWithRAD;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet canAcademic(int _empid, int _org_id)
        {
            ParameterList = new DbParameter[]
                                        { 
                                          Parameter("@EMP_ID",_empid)
                                          ,Parameter("@ORG_ID",_org_id)
                                       };
            StoredProcedureName = StoredProcedure.Prc_AC_ASSIGNMENT_canAcademic;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }

        private DbParameter[] buildParameteSelectByAccession(string _acc)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",_acc)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByAccessionNoRAD(string _acc, int _empid)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",_acc)
                                          , Parameter("@EMP_ID",_empid)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByAccessionNo(string _acc, int _empid)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ACCESSION_NO",_acc)
                                          , Parameter("@EMP_ID",_empid)
                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectAll()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ASSIGNMENT_ID",0)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByID(int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ASSIGNMENT_ID",_id)

                                       };
            return parameters;
        }
    }
}
