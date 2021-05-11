using System;
using System.Collections.Generic;
using System.Text;
using RIS.DataAccess.Insert;
using RIS.Common.Common;

namespace RIS.BusinessLogic
{
    public class ProcessAddRISAutoMergeExam : IBusinessLogic
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

        #region IBusinessLogic Members

        public void Invoke()
        {
            RIS_AutoMergeExam_Insert proc = new RIS_AutoMergeExam_Insert();
            proc.Merger_unit_id = merger_unit_id;
            proc.Merger_exam_id = merger_exam_id;
            proc.Mergee_unit_id = mergee_unit_id;
            proc.Mergee_exam_id = mergee_exam_id;
            proc.Auto_apply = auto_apply;
            proc.Config_Name = config_name;
            proc.Is_Active = is_active;
            proc.Org_id = org_id;
            proc.Create_by = create_by;
            proc.Insert();
        }

        #endregion
    }
}
