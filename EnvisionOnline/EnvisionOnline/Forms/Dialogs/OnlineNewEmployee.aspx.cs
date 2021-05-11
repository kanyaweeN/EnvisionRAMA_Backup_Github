using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.Common;

public partial class OnlineNewEmployee : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
            if (Request.Params["USERNAME"] != null)
                param.USER_NAME = Request.Params["USERNAME"];
            Session["ONL_PARAMETER"] = param;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ONL_PARAMETER param = Session["ONL_PARAMETER"] as ONL_PARAMETER;
        ProcessAddHREmp add = new ProcessAddHREmp(queryString());
        add.HR_EMP.EMP_UID = param.USER_NAME;
        add.HR_EMP.USER_NAME = param.USER_NAME;
        add.HR_EMP.FNAME = txtFname.Text.Trim();
        add.HR_EMP.LNAME = txtLname.Text.Trim();
        add.HR_EMP.FNAME_ENG = txtFnameEng.Text.Trim();
        add.HR_EMP.LNAME_ENG = txtLnameEng.Text.Trim();
        add.Invoke();
        Response.Redirect("../../Forms/Orders/frmEnvisionOrderWL.aspx", true);
    }
    private string queryString()
    {
        string query = @"		insert into HR_EMP
			(
				EMP_UID,			USER_NAME,			JOB_TYPE,			IS_RADIOLOGIST,
				FNAME,				LNAME,				FNAME_ENG ,			LNAME_ENG,	
				IS_ACTIVE,			SUPPORT_USER,		CAN_KILL_SESSION,	ORG_ID,				
				CREATED_BY,			CREATED_ON,			LAST_MODIFIED_BY,	LAST_MODIFIED_ON
			)
		values
		(
				@EMP_UID,			@USER_NAME,			'D',				'N',
				@FNAME,				@LNAME,				@FNAME_ENG ,		@LNAME_ENG,
				'Y',				'N',				'N',				1,			
				1,					GETDATE(),			1,					GETDATE()
		)";
        return query;
    }
}
