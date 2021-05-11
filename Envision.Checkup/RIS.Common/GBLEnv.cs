using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class GBLEnv
    {
        #region Field

        private string _orguid;
        private string _orgname;
        private string _orgalias;
        private string _orgslogan1;
        private string _orgslogan2;

        private string _orgaddr1;
        private string _orgaddr2;
        private string _orgaddr3;
        private string _orgaddr4;

        private string _orgtel1;
        private string _orgtel2;
        private string _orgtel3;
        private string _orgfax;

        private string _orgemail1;
        private string _orgemail2;
        private string _orgemail3;
        private string _orgwebsite;

        private string _welcomedialog1;
        private string _welcomedialog2;

        private string _defaultfontface;
        private string _defaultfontsize;

        private string _repserver;
        private string _repformat;
        private string _repfooter1;
        private string _repfooter2;

        private string _empimagetype;
        private string _empimagemaxsize;
        private int _othermaxfilesize;

        private string _dateformat;
        private string _timeformat;

        private string _localcurrencyname;
        private string _localcurrencysymbol;
        private string _currencyformat;

        private string _resourceimagepath;
        private string _scannedimagepath;
        private string _documentpath;
        private string _backuppath;
        private string _otherfilepath;
        private string _empimagepath;
        private string _labdatapath;

        private string _userdisplayformat;

        private string _vendorh1;
        private string _vendorh2;
        private string _vendorlogopath;

        private string _partner1h1;
        private string _partner1h2;
        private string _partner1logopath;

        private string _partner2h1;
        private string _partner2h2;
        private string _partner2logopath;

        private string _risip;
        private string _risport;
        private string _risuser;
        private string _rispass;
        private string _risurl;

        private string _pacsip;
        private string _pacsport;
        private string _pacsurl1;
        private string _pacsurl2;
        private string _pacsdomain;

        private string _hisip;
        private string _hisport;
        private string _hisdbname;
        private string _hisusername;
        private string _hisuserpass;
        private string _hisfinflag;

        private string _wsip;
        private string _wsversion;

        private byte[] _image;

        private int _created_by;

        private string _pacsip_1;
        private string _pacsport_1;
        private string _pacsurl1_1;
        private string _pacsurl2_1;
        private string _pacsdomain_1;

        //private string _createdby;
        //private string _createdon;

        //private string _lastmodifiedby;
        //private string _lastmodifiedon;

        #endregion Field

        #region Properties

        public string OrgUID
        {
            get { return _orguid; }
            set { _orguid = value; }
        }
        public string OrgName
        {
            get { return _orgname; }
            set { _orgname = value; }
        }
        public string OrgAlias
        {
            get { return _orgalias; }
            set { _orgalias = value; }
        }
        public string OrgSlogan1
        {
            get { return _orgslogan1; }
            set { _orgslogan1 = value; }
        }
        public string OrgSlogan2
        {
            get { return _orgslogan2; }
            set { _orgslogan2 = value; }
        }
        public string OrgAddr1
        {
            get { return _orgaddr1; }
            set { _orgaddr1 = value; }
        }
        public string OrgAddr2
        {
            get { return _orgaddr2; }
            set { _orgaddr2 = value; }
        }
        public string OrgAddr3
        {
            get { return _orgaddr3; }
            set { _orgaddr3 = value; }
        }
        public string OrgAddr4
        {
            get { return _orgaddr4; }
            set { _orgaddr4 = value; }
        }

        public string OrgTel1
        {
            get { return _orgtel1; }
            set { _orgtel1 = value; }
        }
        public string OrgTel2
        {
            get { return _orgtel2; }
            set { _orgtel2 = value; }
        }
        public string OrgTel3
        {
            get { return _orgtel3; }
            set { _orgtel3 = value; }
        }
        public string OrgFax
        {
            get { return _orgfax; }
            set { _orgfax = value; }
        }

        public string OrgEmail1
        {
            get { return _orgemail1; }
            set { _orgemail1 = value; }
        }
        public string OrgEmail2
        {
            get { return _orgemail2; }
            set { _orgemail2 = value; }
        }
        public string OrgEmail3
        {
            get { return _orgemail3; }
            set { _orgemail3 = value; }
        }
        public string OrgWebsite
        {
            get { return _orgwebsite; }
            set { _orgwebsite = value; }
        }

        public string WelcomeDialog1
        {
            get { return _welcomedialog1; }
            set { _welcomedialog1 = value; }
        }
        public string WelcomeDialog2
        {
            get { return _welcomedialog2; }
            set { _welcomedialog2 = value; }
        }

        public string DefaultFontFace
        {
            get { return _defaultfontface; }
            set { _defaultfontface = value; }
        }
        public string DefaultFontSize
        {
            get { return _defaultfontsize; }
            set { _defaultfontsize = value; }
        }

        public string RepServer
        {
            get { return _repserver; }
            set { _repserver = value; }
        }
        public string RepFormat
        {
            get { return _repformat; }
            set { _repformat = value; }
        }
        public string RepFooter1
        {
            get { return _repfooter1; }
            set { _repfooter1 = value; }
        }
        public string RepFooter2
        {
            get { return _repfooter2; }
            set { _repfooter2 = value; }
        }

        public string EmpImageType
        {
            get { return _empimagetype; }
            set { _empimagetype = value; }
        }
        public string EmpImageMaxSize
        {
            get { return _empimagemaxsize; }
            set { _empimagemaxsize = value; }
        }
        public int OtherMaxFileSize
        {
            get { return _othermaxfilesize; }
            set { _othermaxfilesize = value; }
        }

        public string DateFormat
        {
            get { return _dateformat; }
            set { _dateformat = value; }
        }
        public string TimeFormat
        {
            get { return _timeformat; }
            set { _timeformat = value; }
        }

        public string LocalCurrencyName
        {
            get { return _localcurrencyname; }
            set { _localcurrencyname = value; }
        }
        public string LocalCurrencySymbol
        {
            get { return _localcurrencysymbol; }
            set { _localcurrencysymbol = value; }
        }
        public string CurrencyFormat
        {
            get { return _currencyformat; }
            set { _currencyformat = value; }
        }

        public string ResourceImagePath
        {
            get { return _resourceimagepath; }
            set { _resourceimagepath = value; }
        }
        public string ScannedImagePath
        {
            get { return _scannedimagepath; }
            set { _scannedimagepath = value; }
        }
        public string DocumentPath
        {
            get { return _documentpath; }
            set { _documentpath = value; }
        }
        public string BackupPath
        {
            get { return _backuppath; }
            set { _backuppath = value; }
        }
        public string OtherFilePath
        {
            get { return _otherfilepath; }
            set { _otherfilepath = value; }
        }
        public string EmpImagePath
        {
            get { return _empimagepath; }
            set { _empimagepath = value; }
        }
        public string LabDataPath
        {
            get { return _labdatapath; }
            set { _labdatapath = value; }
        }

        public string UserDisplayFormat
        {
            get { return _userdisplayformat; }
            set { _userdisplayformat = value; }
        }

        public string VendorH1
        {
            get { return _vendorh1; }
            set { _vendorh1 = value; }
        }
        public string VendorH2
        {
            get { return _vendorh2; }
            set { _vendorh2 = value; }
        }
        public string VendorLogoPath
        {
            get { return _vendorlogopath; }
            set { _vendorlogopath = value; }
        }

        public string Partner1H1
        {
            get { return _partner1h1; }
            set { _partner1h1 = value; }
        }
        public string Partner1H2
        {
            get { return _partner1h2; }
            set { _partner1h2 = value; }
        }
        public string Partner1LogoPath
        {
            get { return _partner1logopath; }
            set { _partner1logopath = value; }
        }

        public string Partner2H1
        {
            get { return _partner2h1; }
            set { _partner2h1 = value; }
        }
        public string Partner2H2
        {
            get { return _partner2h2; }
            set { _partner2h2 = value; }
        }
        public string Partner2LogoPath
        {
            get { return _partner2logopath; }
            set { _partner2logopath = value; }
        }

        public string RisIP
        {
            get { return _risip; }
            set { _risip = value; }
        }
        public string RisPort
        {
            get { return _risport; }
            set { _risport = value; }
        }
        public string RisUser
        {
            get { return _risuser; }
            set { _risuser = value; }
        }
        public string RisPass
        {
            get { return _rispass; }
            set { _rispass = value; }
        }
        public string RisURL
        {
            get { return _risurl; }
            set { _risurl = value; }
        }

        public string PacsIP
        {
            get { return _pacsip; }
            set { _pacsip = value; }
        }
        public string PacsPort
        {
            get { return _pacsport; }
            set { _pacsport = value; }
        }
        public string PacsURL1
        {
            get { return _pacsurl1; }
            set { _pacsurl1 = value; }
        }
        public string PacsURL2
        {
            get { return _pacsurl2; }
            set { _pacsurl2 = value; }
        }
        public string PacsDomain
        {
            get { return _pacsdomain; }
            set { _pacsdomain = value; }
        }

        public string HisIP
        {
            get { return _hisip; }
            set { _hisip = value; }
        }
        public string HisPort
        {
            get { return _hisport; }
            set { _hisport = value; }
        }
        public string HisDBName
        {
            get { return _hisdbname; }
            set { _hisdbname = value; }
        }
        public string HisUserName
        {
            get { return _hisusername; }
            set { _hisusername = value; }
        }
        public string HisUserPass
        {
            get { return _hisuserpass; }
            set { _hisuserpass = value; }
        }
        public string HisFinFlag
        {
            get { return _hisfinflag; }
            set { _hisfinflag = value; }
        }

        public string WsIP
        {
            get { return _wsip; }
            set { _wsip = value; }
        }
        public string WsVersion
        {
            get { return _wsversion; }
            set { _wsversion = value; }
        }

        public byte[] Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public int CREATED_BY
        {
            get { return _created_by; }
            set { _created_by = value; }
        }

        public string PacsIP_1
        {
            get { return _pacsip_1; }
            set { _pacsip_1 = value; }
        }
        public string PacsPort_1
        {
            get { return _pacsport_1; }
            set { _pacsport_1 = value; }
        }
        public string PacsURL1_1
        {
            get { return _pacsurl1_1; }
            set { _pacsurl1_1 = value; }
        }
        public string PacsURL2_1
        {
            get { return _pacsurl2_1; }
            set { _pacsurl2_1 = value; }
        }
        public string PacsDomain_1
        {
            get { return _pacsdomain_1; }
            set { _pacsdomain_1 = value; }
        }

        #endregion Properties

    }
}
