using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common.Common
{
    public class ObjectControls
    {
    }
    public class Filter_WLLOC_Mode
    {
        private int _LOC_ID;
        private string _LOC_Name, _LOC_Filter;
        public Filter_WLLOC_Mode(int Loc_id, string Loc_Name, string Loc_filter)
        {
            _LOC_ID = Loc_id;
            _LOC_Name = Loc_Name;
            _LOC_Filter = Loc_filter;
        }
        public string Loc_Filter()
        {
            return _LOC_Filter;
        }
        public override string ToString()
        {
            return _LOC_Name;
        }
        public int Loc_id()
        {
            return _LOC_ID;
        }
    }
    public class Filter_Conferene_Mode
    {
        private int _CONFERENCE_ID;
        private string _CONFERENCE_NAME;
        public Filter_Conferene_Mode(int conference_id, string conference_name)
        {
            _CONFERENCE_ID = conference_id;
            _CONFERENCE_NAME = conference_name;
        }
        public override string ToString()
        {
            return _CONFERENCE_NAME;
        }
        public int id()
        {
            return _CONFERENCE_ID;
        }
    }
    public class Exam_items
    {
        private int _exam_id;
        private string _exam_uid;
        private string _exam_name;
        public Exam_items(int exam_id,string exam_uid, string exam_name)
        {
            _exam_id = exam_id;
            _exam_uid = exam_uid;
            _exam_name = exam_name;
        }
        public override string ToString()
        {
            return _exam_name;
        }
        public int Exam_id()
        {
            return _exam_id;
        }
        public string Exam_code()
        {
            return _exam_uid;
        }
    }
    public class Doctor_items
    {
        private int _doctor_id;
        private string _doctor_name;
        public Doctor_items(int doctor_id, string doctor_name)
        {
            _doctor_id = doctor_id;
            _doctor_name = doctor_name;
        }
        public override string ToString()
        {
            return _doctor_name;
        }
        public int id()
        {
            return _doctor_id;
        }
    }
    public class TraumaItems
    {
        private int _traumaID;
        private string _traumaName;
        private int _traumaSEQ;
        public TraumaItems(int traumaID, string traumaName, int traumaSeq)
        {
            _traumaID = traumaID;
            _traumaName = traumaName;
            _traumaSEQ = traumaSeq;
        }
        public override string ToString()
        {
            return _traumaName;
        }
        public int Trauma_id()
        {
            return _traumaID;
        }
        public int Trauma_Seq()
        {
            return _traumaSEQ;
        }
    }
    public class Filter_ClinicSession
    {
        private int _SESSION_ID;
        private string _SESSION_NAME;
        public Filter_ClinicSession(int sessionID, string sessionName)
        {
            _SESSION_ID = sessionID;
            _SESSION_NAME = sessionName;
        }
        public override string ToString()
        {
            return _SESSION_NAME;
        }
        public int id()
        {
            return _SESSION_ID;
        }
    }
    public class Filter_TitleName
    {
        private int _title_id;
        private string _title_desc, _gender;
        public Filter_TitleName(int title_id, string title_desc, string gender)
        {
            _title_id = title_id;
            _title_desc = title_desc;
            _gender = gender;
        }
        public string get_Gender()
        {
            return _gender;
        }
        public override string ToString()
        {
            return _title_desc;
        }
        public int get_Title_id()
        {
            return _title_id;
        }
    }
    public class Filter_QuickText
    {
        private int _filter_mode_id;
        private string _filter_mode_desc;
        public Filter_QuickText(int filter_mode_id, string filter_mode_desc)
        {
            _filter_mode_id = filter_mode_id;
            _filter_mode_desc = filter_mode_desc;
        }
        public override string ToString()
        {
            return _filter_mode_desc;
        }
        public int get_filter_mode_id()
        {
            return _filter_mode_id;
        }
    }
}
