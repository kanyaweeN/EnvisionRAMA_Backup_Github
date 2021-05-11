using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class ExamResultTemplate
    {
        private int _examid;
        private static string _templatetext;
        private string _templatetype;
        private string _autoapply;
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;
        private int _share;
        private string _name;
   
        
        public ExamResultTemplate()
        {
        }

        public int ExamID
        {
            get { return _examid; }
            set { _examid = value; }
        }

        public string TemplateNmae
        {
            get { return _name; }
            set { _name = value; }
        }
       

        public string TemplateText
        {
            get { return _templatetext; }
            set { _templatetext = value; }
        }

        public string TemplateType
        {
            get { return _templatetype; }
            set { _templatetype = value; }
        }

        public string AutoApply
        {
            get { return _autoapply; }
            set { _autoapply = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public int CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
        }

        public string CreatedOn
        {
            get { return _createdon; }
            set { _createdon = value; }
        }

        public int ModifiedBy
        {
            get { return _lastmodifiedby; }
            set { _lastmodifiedby = value; }
        }

        public string ModifiedOn
        {
            get { return _lastmodifiedon; }
            set { _lastmodifiedon = value; }
        }
        public int ShareWith
        {
            get { return _share; }
            set { _share = value; }
        }
        
    }

}
