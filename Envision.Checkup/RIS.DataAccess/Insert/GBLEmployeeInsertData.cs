using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class GBLEmployeeInsertData : DataAccessBase
    {
        private GBLEmployee _gblemp;
        private GBLEmployeeInsertDataParameters _gblempparameters;

        public GBLEmployeeInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.GBLEmployee_InsertAccount.ToString();
        }

        public void Add()
        {
            _gblempparameters = new GBLEmployeeInsertDataParameters(GBLEmployee);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _gblempparameters.Parameters);
        }

        public GBLEmployee GBLEmployee
        {
            get { return _gblemp; }
            set { _gblemp = value; }
        }
    }

    public class GBLEmployeeInsertDataParameters
    {
        private GBLEmployee _gblemp;
        private SqlParameter[] _parameters;

        public GBLEmployeeInsertDataParameters(GBLEmployee gblemp)
        {
            GBLEmployee = gblemp;
            Build();
        }

        private void Build()
        {
            SqlParameter[] parameters =
		    {                    
                    new SqlParameter( "@Username" ,  GBLEmployee.User_Name),
                    new SqlParameter( "@Password" ,  GBLEmployee.Pwd),
                    new SqlParameter( "@Empuid" ,     GBLEmployee.Emp_UID),
                    new SqlParameter( "@Unitid" ,     GBLEmployee.Unit_ID),
                    new SqlParameter( "@Gender" ,     GBLEmployee.Gender),

                    new SqlParameter( "@Salutation" , GBLEmployee.Salutation),
                    new SqlParameter( "@Fname" ,      GBLEmployee.Fname),
                    new SqlParameter( "@Mname" ,      GBLEmployee.Mname),
                    new SqlParameter( "@Lname" ,      GBLEmployee.Lname),

                    new SqlParameter( "@Titleeng" ,   GBLEmployee.Title_Eng),
                    new SqlParameter( "@Fnameeng" ,   GBLEmployee.Fname_Eng),
                    new SqlParameter( "@Mnameeng" ,   GBLEmployee.Mname_Eng),
                    new SqlParameter( "@Lnameeng" ,   GBLEmployee.Lname_Eng),

                    new SqlParameter( "@Securityquestion" , GBLEmployee.Security_Question),
                    new SqlParameter( "@Securityanswer" , GBLEmployee.Security_Answer),

                    new SqlParameter( "@Defaultlang" ,    GBLEmployee.Default_Lang),
                    new SqlParameter( "@Authlvid" ,   GBLEmployee.Auth_Level_ID),
                    new SqlParameter( "@Jobtype" ,    GBLEmployee.Job_Type),

                    new SqlParameter( "@Active" , GBLEmployee.Is_Active),
                    new SqlParameter( "@Radiologist" ,    GBLEmployee.Is_Radiologist),
                    new SqlParameter( "@Allowfinalize" ,  GBLEmployee.Allow_Other_To_Finalize),
                    new SqlParameter( "@Support" ,    GBLEmployee.Support_User),
                    new SqlParameter( "@Cankill"  ,GBLEmployee.Can_Kill_Session),

                    new SqlParameter( "@Orgid"  ,GBLEmployee.Org_ID),

                    new SqlParameter( "@Emp_report_footer1"  ,GBLEmployee.EMP_REPORT_FOOTER1),
                    new SqlParameter( "@Emp_report_footer2"  ,GBLEmployee.EMP_REPORT_FOOTER2),

			};

            Parameters = parameters;
        }

        public GBLEmployee GBLEmployee
        {
            get { return _gblemp; }
            set { _gblemp = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
