using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace RIS.Common
{

    public class GBLAlert
    {
        private int _altid;
        private string _altuid;
        private int _orgid;
        private int _createdby;
        private string _createdon;
        private int _lastmodifiedby;
        private string _lastmodifiedon;
        private int _langid;
        private string _alerttext;
        private string _alerttype;
        private string _isactive;
        private string _alerttitle;
        private int _alertbutton;
        private string _captionbtn1;
        private string _captionbtn2;
        private string _captionbtn3;
        private int _defaultbtn;
        private int _timesec;

        public GBLAlert()
        {
        }

        public int AlertID
        {
            get { return _altid; }
            set { _altid = value; }
        }

        public string AlertUID
        {
            get { return _altuid; }
            set { _altuid = value; }
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

        public int LangID
        {
            get { return _langid; }
            set { _langid = value; }
        }
        
        public string AlertText
        {
            get { return _alerttext; }
            set { _alerttext = value; }
        }
        
        public string AlertType
        {
            get { return _alerttype; }
            set { _alerttype = value; }
        }
                
        public string IsActive
        {
            get { return _isactive; }
            set { _isactive = value; }
        }
       
        public string AlertTitle
        {
            get { return _alerttitle; }
            set { _alerttitle = value; }
        }
       
        public int AlertButton
        {
            get { return _alertbutton; }
            set { _alertbutton = value; }
        }
        
        public string CaptionButton1
        {
            get { return _captionbtn1; }
            set { _captionbtn1 = value; }
        }

        public string CaptionButton2
        {
            get { return _captionbtn2; }
            set { _captionbtn2 = value; }
        }

        public string CaptionButton3
        {
            get { return _captionbtn3; }
            set { _captionbtn3 = value; }
        }

        public int DefaultBtn
        {
            get { return _defaultbtn; }
            set { _defaultbtn = value; }
        }
        public int TimeSec
        {
            get { return _timesec; }
            set { _timesec = value; }
        }
    }

    public class alertObjectCollection : CollectionBase
    {
        public void Add(GBLAlert _alertObject)
        {
            this.List.Add(_alertObject);
        }
        public void Delete(int index)
        {
            this.List.RemoveAt(index);
        }
        public GBLAlert this[int index]
        {
            get
            {
                return (GBLAlert)List[index];
            }
            set
            {
                List[index] = value;
            }
        }
    }

}
