using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
    public class RIS_AutoMergeExam_Insert : DataAccessBase
    {       
        #region Variable
        private int merger_unit_id;
        private int merger_exam_id;
        private int mergee_unit_id;
        private int mergee_exam_id;
        private string auto_apply;
        private string config_name;
        private string is_active;
        private int org_id;
        private int create_by;
        #endregion

        #region Propertise
        public int Merger_unit_id
        {
            get { return merger_unit_id; }
            set { merger_unit_id = value; }
        }
        public int Merger_exam_id
        {
            get { return merger_exam_id; }
            set { merger_exam_id = value; }
        }
        public int Mergee_unit_id
        {
            get { return mergee_unit_id; }
            set { mergee_unit_id = value; }
        }
        public int Mergee_exam_id
        {
            get { return mergee_exam_id; }
            set { mergee_exam_id = value; }
        }
        public string Auto_apply
        {
            get { return auto_apply; }
            set { auto_apply = value; }
        }
        public string Config_Name
        {
            get { return config_name; }
            set { config_name = value; }
        }
        public string Is_Active
        {
            get { return is_active; }
            set { is_active = value; }
        }
        public int Org_id
        {
            get { return org_id; }
            set { org_id = value; }
        }
        public int Create_by
        {
            get { return create_by; }
            set { create_by = value; }
        }
        #endregion

        public void Insert()
        {
            SqlParameter[] parameters = {
                                           new SqlParameter("@merger_unit_id", merger_unit_id)
                                           , new SqlParameter("@merger_exam_id", merger_exam_id)
                                           , new SqlParameter("@mergee_unit_id", mergee_unit_id)
                                           , new SqlParameter("@mergee_exam_id", mergee_exam_id)
                                           , new SqlParameter("@Auto_Apply", auto_apply)
                                           , new SqlParameter("@Config_Name", config_name)
                                           , new SqlParameter("@Is_Active", is_active)
                                           , new SqlParameter("@Org_id", org_id)
                                           , new SqlParameter("@Created_by", create_by)
                                        };
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedure.Name.Prc_RIS_AUTOMERGECONFIG_INSERT.ToString());
            dbHelper.Run(base.ConnectionString, parameters);
        }

    }
}
