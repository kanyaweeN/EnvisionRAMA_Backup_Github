using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Miracle.ScannerNew;

namespace RIS.Common.Common
{
    public class GBLEnvVariable
    {
        public static string imgcount;
        public static IntPtr bmpptr1;
        public static IntPtr pixptr1;
        public static IntPtr bmpptr2;
        public static IntPtr pixptr2;
        public static IntPtr bmpptr3;
        public static IntPtr pixptr3;
        public static string count;
        public static PointerStruct[] pix;

        public static int _unitid;
        public static int _langid;
        public static int _formid;
        public static int _userid;
        public static int _orgid;
        public static string _firstname;
        public static string _lastname;
        public static string _langname;
        public static string _guid;
        public static string _logtype;
        public static string _dtformat;
        public static string _tmformat;
        public static string _curname;
        public static string _cursymbol;
        public static string _curformat;
        public static string _pacsdomain;
        public static string _pacsip;
        public static string _pacsport;
        public static string _pacsurl;
        public static string _pacsurl2;
        public static string _pacsurl3;
        public static string _frmtitle;
        public static string _currtag;
        public static string _currtext;
        public static string _fontname;
        public static string _fontsize;
        public static string _openstatus;
        public static int _templateid;
        private static DateTime _activedate;
        private static string _username;
        private static string _useruid;
        private static string _scanedimagepath;
        //private static string _scanedimageweb;
        private static string _webserviceIP;
        public static string _titleeng;
        public static string _firsteng;
        public static string _lasteng;
        public static string _authlevelid;
        public static string _ws_ip_picture;
        private static string _pacsip_1;
        private static string _pacsport_1;
        private static string _pacsurl1_1;
        private static string _pacsurl2_1;
        private static string _pacsdomain_1;
        public static string _passwordAD;

        static GBLEnvVariable()
        {
        }

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
        //public string ScannedImageWeb
        //{
        //    get { return _scanedimageweb; }
        //    set { _scanedimageweb = value; }
        //}

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


        public string CountImg
        {
            get { return count; }
            set { count = value; }
        }

        public IntPtr BmpPic
        {
            get { return bmpptr1; }
            set { bmpptr1 = value; }
        }
        public IntPtr PixPic
        {
            get { return pixptr1; }
            set { pixptr1 = value; }
        }

        public IntPtr BmpPic2
        {
            get { return bmpptr2; }
            set { bmpptr2 = value; }
        }
        public IntPtr PixPic2
        {
            get { return pixptr2; }
            set { pixptr2 = value; }
        }

        public IntPtr BmpPic3
        {
            get { return bmpptr3; }
            set { bmpptr3 = value; }
        }
        public IntPtr PixPic3
        {
            get { return pixptr3; }
            set { pixptr3 = value; }
        }

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
        public string PacsDomain
        {
            get { return _pacsdomain; }
            set { _pacsdomain = value; }
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

        public string PacsIp_1
        {
            get { return _pacsip_1; }
            set { _pacsip_1 = value; }
        }
        public string PacsPort_1
        {
            get { return _pacsport_1; }
            set { _pacsport_1 = value; }
        }
        public string PacsUrl1_1
        {
            get { return _pacsurl1_1; }
            set { _pacsurl1_1 = value; }
        }
        public string PacsUrl2_1
        {
            get { return _pacsurl2_1; }
            set { _pacsurl2_1 = value; }
        }
        public string PasswordAD
        {
            get { return _passwordAD; }
            set { _passwordAD = value; }
        }

        public PointerStruct[] PixPicture
        {
            get { return pix; }
            set { pix = value; }
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
