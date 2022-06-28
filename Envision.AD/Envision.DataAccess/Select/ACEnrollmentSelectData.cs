using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class ACEnrollmentSelectData : DataAccessBase
    {
        DataSet ds;
        public ACEnrollmentSelectData()
        {

        }
        public DataSet SelectAll()
        {
            ParameterList = buildParameteSelectAll();
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectByID(int _id)
        {
            ParameterList = buildParameteSelectByID(_id);
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_Select;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectEnrollmentResident()
        {
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_SelectResident;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectEnrollmentRadiologist()
        {
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_SelectRadiologist;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet SelectEnrollmentForAssignment(int _empID)
        {
            ParameterList = buildParameteSelectForAssignment(_empID);
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_SelectForAssignment;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
         public DataSet SelectEnrollmentByYear(int _YearID)
        {
            ParameterList = buildParameteSelectByYear(_YearID);
            StoredProcedureName = StoredProcedure.Prc_AC_ENROLLMENT_SelectByYear;
            ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
         private DbParameter[] buildParameteSelectByYear(int _YearID)
         {
             DbParameter[] parameters = { 
                                          Parameter("@YEAR_ID",_YearID)

                                       };
             return parameters;
         }
        private DbParameter[] buildParameteSelectForAssignment(int _empID)
        {
            DbParameter[] parameters = { 
                                          Parameter("@EMP_ID",_empID)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectAll()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ENROLL_ID",0)

                                       };
            return parameters;
        }
        private DbParameter[] buildParameteSelectByID(int _id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@ENROLL_ID",_id)

                                       };
            return parameters;
        }
    }
}
