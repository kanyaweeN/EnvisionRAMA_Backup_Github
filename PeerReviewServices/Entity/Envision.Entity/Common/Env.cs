using System;

namespace Envision.Entity.Common
{
    public class Env : BaseObject
    {
        public Env(){

        }
        public int Id { get; set; }
        public string Code { get; set;}
        public string Name { get; set;}
        public string Alias { get; set;}
        public string Slogan1 { get; set;}
        public string Slogan2 { get; set;}
        public string Addr1 { get; set;}
        public string Addr2 { get; set;}
        public string Addr3 { get; set;}
        public string Addr4 { get; set;}
        public string Tel1 { get; set;}
        public string Tel2 { get; set;}
        public string Tel3 { get; set;}
        public string Fax { get; set;}
        public string Email1 { get; set;}
        public string Email2 { get; set;}
        public string Email3 { get; set;}
        public string WebSite { get; set;}
        public byte[] Image { get; set;}
        public string WelcomeDialog1 { get; set;}
        public string WelcomeDialog2 { get; set;}
        public string FontFace { get; set;}
        public byte? FontSize { get; set;}
        public string RepServer { get; set;}
        public string RepFormat { get; set;}
        public string RepFooter1 { get; set;}
        public string RepFooter2 { get; set;}
        public string EmpImageType { get; set;}
        public string EmpImageMaxSize { get; set;}
        public int? OtherMaxFileSize { get; set;}
        public string DateFormat { get; set;}
        public string TimeFormat { get; set;}
        public string LocalCurrencyName { get; set;}
        public string LocalCurrencySymbol { get; set;}
        public string CurrencyFormat { get; set;}
        public string ResourceImagePath { get; set;}
        public string ScannedImagePath { get; set;}
        public string DocumentPath { get; set;}
        public string BackupPath { get; set;}
        public string OtherFilePath { get; set;}
        public string EmpImagePath { get; set;}
        public string LabDataPath { get; set;}
        public string UserDisplayFormat { get; set;}
        public string VendorHeader1 { get; set;}
        public string VendorHeader2 { get; set;}
        public string VendorLogoPath { get; set;}
        public string Partner1Header1 { get; set;}
        public string Partner1Header2 { get; set;}
        public string Partner1LogoPath { get; set;}
        public string Partner2Header1 { get; set;}
        public string Partner2Header2 { get; set;}
        public string Partner2LogoPath { get; set;}
        public string RISIP { get; set;}
        public string RISPort { get; set;}
        public string RISUser { get; set;}
        public string RISPass { get; set;}
        public string RISUrl { get; set;}
        public string PACSIP { get; set;}
        public string PACSPort { get; set;}
        public string PACSUrl1 { get; set;}
        public string PACSUrl2 { get; set;}
        public string PACSUrl3 { get; set;}
        public string PACSDomain { get; set;}
        public string HISIP { get; set;}
        public string HISPort { get; set;}
        public string HISDBName { get; set;}
        public string HISUserName { get; set;}
        public string HISUserPass { get; set;}
        public string HISFinFlag { get; set;}
        public string WSIP { get; set;}
        public string WSIPPicture { get; set;}
        public string WSVersion { get; set;}
        public string ORMSyncIP { get; set;}
        public string ORMSyncPort { get; set;}
        public string ORUSyncIP { get; set;}
        public string ORUSyncPort { get; set;}
        public string HISSyncIP { get; set;}
        public string HISSyncPort { get; set;}
        public string EditOrderUntil { get; set;}
        public byte? ScheduleConfirmTime { get; set;}
        public byte? ScheduleApproveTime { get; set;}
    }
}