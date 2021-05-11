using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using EnvisionHelpdesk.BusinessLogic;

namespace EnvisionProvideHelpdesk
{
    /// <summary>
    /// Summary description for EnvisionHelpdesk
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EnvisionHelpdesk : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet get_PatientDetail(string hn)
        {
            DataSet ds = new DataSet();
            ProcessGetHelpdeskPatientDetail prc = new ProcessGetHelpdeskPatientDetail();
            ds = prc.getDatabyHN(hn);
            return ds;
        }
    }
}
