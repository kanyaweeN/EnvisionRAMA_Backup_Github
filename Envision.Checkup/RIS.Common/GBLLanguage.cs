using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class GBLLanguage
    {
        private int _langId;
        private string _landUid;
        private string _langName;
        private string _isActive;
        private string _isDelete;

        public GBLLanguage(int langId,string langUid,string langName,string isAvtive)
        {
            this._langId = langId;
            this._landUid = langUid;
            this._langName = langName;
            this._isActive = isAvtive;
        }

        public int LangId
        {
            get { return _langId; }
            set { _langId = value; }
        }

        public string LandUid
        {
            get { return _landUid; }
            set { _landUid = value; }
        }

        public string LangName
        {
            get { return _langName; }
            set { _langName = value; }
        }

        public string IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public string IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }


    }
}
