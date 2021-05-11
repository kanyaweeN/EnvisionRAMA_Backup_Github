using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace Envision.Common
{
    public class RISSearchEngine
    {
        private string key1;
        private string key2;
        private string key3;
        private string key4;
        private string key5;
        private string key6;
        private string key7;
        private string key8;
        private string key9;
        private string[] keys;
        private string mode;
        private string accession_no;
        private string hn;
        private int? age;
        private string gender;
        private int? examname;
        private int? examtype;
        private string reportFrom;
        private string reportTo;
        private string studyFrom;
        private string studyTo;
        private int? empid;

        public RISSearchEngine()
        {
            keys = new string[10] {"","","","",""
                                ,"","","","",""};
        }

        public string KEY1
        {
            get { return key1; }
            set { key1 = value; }
        }
        public string KEY2
        {
            get { return key2; }
            set { key2 = value; }
        }
        public string KEY3
        {
            get { return key3; }
            set { key3 = value; }
        }
        public string KEY4
        {
            get { return key4; }
            set { key4 = value; }
        }
        public string KEY5
        {
            get { return key5; }
            set { key5 = value; }
        }
        public string KEY6
        {
            get { return key6; }
            set { key6 = value; }
        }
        public string KEY7
        {
            get { return key7; }
            set { key7 = value; }
        }
        public string KEY8
        {
            get { return key8; }
            set { key8 = value; }
        }
        public string KEY9
        {
            get { return key9; }
            set { key9 = value; }
        }
        public string[] KEYS
        {
            get { return keys; }
            set { keys = value; }
        }
        public string MODE
        {
            get { return mode; }
            set { mode = value; }
        }
        public string ACCESSION_NO
        {
            get { return accession_no; }
            set { accession_no = value; }
        }
        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
        public int? AGE
        {
            get { return age; }
            set { age = value; }
        }
        public string GENDER
        {
            get { return gender; }
            set { gender = value; }
        }
        public int? EXAM_NAME
        {
            get { return examname; }
            set { examname = value; }
        }
        public int? EXAM_TYPE
        {
            get { return examtype; }
            set { examtype = value; }
        }
        public string REPORTDATE_FROM
        {
            get { return reportFrom; }
            set { reportFrom = value; }
        }
        public string REPORTDATE_TO
        {
            get { return reportTo; }
            set { reportTo = value; }
        }
        public string STUDYDATE_FROM
        {
            get { return studyFrom; }
            set { studyFrom = value; }
        }
        public string STUDYDATE_TO
        {
            get { return studyTo; }
            set { studyTo = value; }
        }
        public int? EMP_ID
        {
            get { return empid; }
            set { empid = value; }
        }

    }
}
