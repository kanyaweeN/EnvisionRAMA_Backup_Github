using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateRISAutoMergeConfig : IBusinessLogic
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

        #region IBusinessLogic Members

        public void Invoke()
        {
            RISAutoMergeConfigUpdate proc = new RISAutoMergeConfigUpdate();
            proc.Merger_unit_id = merger_unit_id;
            proc.Merger_exam_id = merger_exam_id;
            proc.Mergee_unit_id = mergee_unit_id;
            proc.Mergee_exam_id = mergee_exam_id;
            proc.Config_Name = config_name;
            proc.Auto_apply = auto_apply;
            proc.Is_Active = is_active;
            proc.Last_Modified_By = last_modified_by;
            proc.Update();
        }

        #endregion
    }
}
