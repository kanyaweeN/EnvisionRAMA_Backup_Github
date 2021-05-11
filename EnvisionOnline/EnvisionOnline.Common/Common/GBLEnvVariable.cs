using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common.Common
{
    public class GBLEnvVariable
    {
        private string imgcount;
        private IntPtr bmpptr1;
        private IntPtr pixptr1;
        private IntPtr bmpptr2;
        private IntPtr pixptr2;
        private  IntPtr bmpptr3;
        private  IntPtr pixptr3;
        private  string count;
        private  int _unitid;
        private  int _langid;
        private  int _formid;
        private  int _userid;
        private  int _orgid;
        private  string _firstname;
        private  string _lastname;
        private  string _langname;
        private  string _guid;
        private  string _logtype;
        private  string _dtformat;
        private  string _tmformat;
        private  string _curname;
        private  string _cursymbol;
        private  string _curformat;
        private  string _pacsip;
        private  string _pacsport;
        private  string _pacsurl;
        private  string _pacsurl2;
        private  string _pacsurl3;
        private  string _pacsdomain;
        private  string _frmtitle;
        private  string _currtag;
        private  string _currtext;
        private  string _fontname;
        private  string _fontsize;
        private  string _openstatus;
        private  int _templateid;
        private  DateTime _activedate;
        private  string _username;
        private  string _useruid;
        private  string _scanedimagepath;
        private  string _webserviceIP;
        private  string _titleeng;
        private  string _firsteng;
        private  string _lasteng;
        private  string _authlevelid;
        private  string _ws_ip_picture;
        private  string _organizationName;
        private  string _support_user;
        private  string _used_menubar;// USED_MENUBAR;
        private  string _used_120dpi;//USED_120DPI;
        private  string _passwordAD;
        private  string _reconfirmPassword;

        public GBLEnvVariable()
        {
        }



        public string AuthLevelID
        {
            get { return _authlevelid; }
            set { _authlevelid = value; }
        }
        public string TitleEng
        {
            get { return _titleeng; }
            set { _titleeng = value; }
        }

        public string FirstNameEng
        {
            get { return _firsteng; }
            set { _firsteng = value; }
        }

        public string LastNameEng
        {
            get { return _lasteng; }
            set { _lasteng = value; }
        }
        public string ScannedImagePath
        {
            get { return _scanedimagepath; }
            set { _scanedimagepath = value; }
        }

        public string UserUID
        {
            get { return _useruid; }
            set { _useruid = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }


        //public string CountImg
        //{
        //    get { return count; }
        //    set { count = value; }
        //}

        //public IntPtr BmpPic
        //{
        //    get { return bmpptr1; }
        //    set { bmpptr1 = value; }
        //}
        //public IntPtr PixPic
        //{
        //    get { return pixptr1; }
        //    set { pixptr1 = value; }
        //}

        //public IntPtr BmpPic2
        //{
        //    get { return bmpptr2; }
        //    set { bmpptr2 = value; }
        //}
        //public IntPtr PixPic2
        //{
        //    get { return pixptr2; }
        //    set { pixptr2 = value; }
        //}

        //public IntPtr BmpPic3
        //{
        //    get { return bmpptr3; }
        //    set { bmpptr3 = value; }
        //}
        //public IntPtr PixPic3
        //{
        //    get { return pixptr3; }
        //    set { pixptr3 = value; }
        //}

        public DateTime ActiveDate
        {
            get { return _activedate; }
            set { _activedate = value; }
        }

        public int TemplateID
        {
            get { return _templateid; }
            set { _templateid = value; }
        }
        public string OpenStatus
        {
            get { return _openstatus; }
            set { _openstatus = value; }
        }

        public string FontName
        {
            get { return _fontname; }
            set { _fontname = value; }
        }

        public string FontSize
        {
            get { return _fontsize; }
            set { _fontsize = value; }
        }

        public string LoginType
        {
            get { return _logtype; }
            set { _logtype = value; }
        }

        public string CurrentFormGUID
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public int CurrentFormID
        {
            get { return _formid; }
            set { _formid = value; }
        }

        public int CurrentLanguageID
        {
            get { return _langid; }
            set { _langid = value; }
        }

        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }

        public int UnitID
        {
            get { return _unitid; }
            set { _unitid = value; }
        }

        public int OrgID
        {
            get { return _orgid; }
            set { _orgid = value; }
        }

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        public string LangName
        {
            get { return _langname; }
            set { _langname = value; }
        }
        public string DateFormat
        {
            get { return _dtformat; }
            set { _dtformat = value; }
        }
        public string TimeFormat
        {
            get { return _tmformat; }
            set { _tmformat = value; }
        }
        public string CurrencyName
        {
            get { return _curname; }
            set { _curname = value; }
        }
        public string CurrencySymbol
        {
            get { return _cursymbol; }
            set { _cursymbol = value; }
        }
        public string CurrencyFormat
        {
            get { return _curformat; }
            set { _curformat = value; }
        }
        public string PacsIp
        {
            get { return _pacsip; }
            set { _pacsip = value; }
        }
        public string PacsPort
        {
            get { return _pacsport; }
            set { _pacsport = value; }
        }
        public string PacsUrl
        {
            get { return _pacsurl; }
            set { _pacsurl = value; }
        }
        public string PacsUrl2
        {
            get { return _pacsurl2; }
            set { _pacsurl2 = value; }
        }
        public string PacsUrl3
        {
            get { return _pacsurl3; }
            set { _pacsurl3 = value; }
        }
        public string PacsDomain
        {
            get { return _pacsdomain; }
            set { _pacsdomain = value; }
        }
        public string FormTitle
        {
            get { return _frmtitle; }
            set { _frmtitle = value; }
        }

        public string CurrentTag
        {
            get { return _currtag; }
            set { _currtag = value; }
        }
        public string CurrentText
        {
            get { return _currtext; }
            set { _currtext = value; }
        }

        public string WebServiceIP
        {
            get { return _webserviceIP; }
            set { _webserviceIP = value; }
        }
        public string WebServiceIP_PICTURE
        {
            get { return _ws_ip_picture; }
            set { _ws_ip_picture = value; }
        }
        public string OrgaizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }
        public string SUPPORT_USER
        {
            get { return _support_user; }
            set { _support_user = value; }
        }
        public string USED_MENUBAR
        {
            get { return _used_menubar; }
            set { _used_menubar = value; }
        }
        public string USED_120DPI
        {
            get { return _used_120dpi; }
            set { _used_120dpi = value; }
        }
        public string PasswordAD
        {
            get { return _passwordAD; }
            set { _passwordAD = value; }
        }
        public string ReconfirmPassword
        {
            get { return string.IsNullOrEmpty(_reconfirmPassword) ? "N" : _reconfirmPassword; }
            set { _reconfirmPassword = value; }
        }
    }
    public struct GlobalContents
    {
        public string To;
        public string FromName;
        public string FromEmailAddress;
        public string Subject;
        public string Body;
    }
}
