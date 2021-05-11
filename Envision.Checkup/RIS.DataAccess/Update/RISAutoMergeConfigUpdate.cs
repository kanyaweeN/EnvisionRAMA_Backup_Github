using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RIS.DataAccess.Update
{
    public class RISAutoMergeConfigUpdate : DataAccessBase
    {
        #region Variable
        private int merger_unit_id;
        private int merger_exam_id;
        private int mergee_unit_id;
        private int mergee_exam_id;
        private string auto_apply;
        private string config_name;
        private string is_active;
        private int last_modified_by;
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
        public int Last_Modified_By
        {
            get { return last_modified_by; }
            set { last_modified_by = value; }
        }
        #endregion

        public void Update()
        {
            SqlParameter[] parameters = {
                                            new SqlParameter("@config_name", config_name)
                                           , new SqlParameter("@merger_unit_id", merger_unit_id)
                                           , new SqlParameter("@merger_exam_id", merger_exam_id)
                                           , new SqlParameter("@mergee_unit_id", mergee_unit_id)
                                           , new SqlParameter("@mergee_exam_id", mergee_exam_id)
                                           , new SqlParameter("@auto_apply", auto_apply)
                                           , new SqlParameter("@is_active", is_active)
                                           , new SqlParameter("@Last_modified_by", last_modified_by)
                                        };
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedure.Name.RIS_AutoMergeConfig_Update.ToString());
            dbHelper.Run(base.ConnectionString, parameters);
        }
    }
}
