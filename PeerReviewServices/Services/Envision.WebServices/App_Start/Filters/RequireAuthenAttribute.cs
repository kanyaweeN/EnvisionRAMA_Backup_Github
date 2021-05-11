using Envision.Business.Common;
using Envision.Entity.Common;
using Envision.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace Envision.WebServices.App_Start.Filters
{
    public class RequireAuthenAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var request = actionContext.Request;
            if (IsNotAuthenPath(request.RequestUri.LocalPath))
            {
                if (IsTokenAlive(request) == false)
                {
                    var response = new HttpResponseMessage();
                    response.StatusCode = HttpStatusCode.Forbidden;
                    actionContext.Response = response;
                }
            }
            base.OnAuthorization(actionContext);
        }

        private bool IsTokenAlive(HttpRequestMessage req)
        {
            bool flag = true;
            if (req.Headers.Authorization == null)
                flag = false;
            else
            {
                string token = req.Headers.Authorization.Parameter;
                if (!string.IsNullOrEmpty(token))
                {
                    SessionComponent sessionComp = new SessionComponent();
                    Session obj = sessionComp.GetByToken(token);
                    if (obj == null)
                        flag = false;
                    else if (obj.Status != "A")
                        flag = false;
                    else
                    {
                        //store token session 
                        AppHelper.Token = token;
                        AppHelper.OrgId = obj.OrgId;
                        AppHelper.UserId = obj.EmpId;
                        if (req.Properties.ContainsKey("MS_HttpContext"))
                        {
                            HttpContextWrapper ctx = (HttpContextWrapper)req.Properties["MS_HttpContext"];
                            if (ctx != null)
                                AppHelper.ClientIP = ctx.Request.UserHostAddress;
                        }
                        else
                            AppHelper.ClientIP = null;
                    }
                }
            }
            return flag;
        }
        private bool IsNotAuthenPath(string path)
        {
            bool flag = true;
            if (path == "/api/Authen/Token")
                flag = false;
            return flag;
        }
    }
}