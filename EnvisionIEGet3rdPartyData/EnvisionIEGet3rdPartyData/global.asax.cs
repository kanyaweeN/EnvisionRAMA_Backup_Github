using System;
using System.Web;
using EnvisionIEGet3rdPartyData.Common;
using EnvisionIEGet3rdPartyData.InterfaceEngine;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionIEGet3rdPartyData
{
	public class global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			Utilities.SaveLog("EnvisionIEGet3rdPartyData.Global", "Application_Start(object sender, EventArgs e)", "Start", false);
		}
		protected void Session_Start(object sender, EventArgs e) { }
		protected void Application_BeginRequest(object sender, EventArgs e) { }
		protected void Application_AuthenticateRequest(object sender, EventArgs e) { }
		protected void Application_Error(object sender, EventArgs e) { Utilities.SaveLog("EnvisionIEGet3rdPartyData.Global", "Application_Error(object sender, EventArgs e)", e.ToString(), true); }
		protected void Session_End(object sender, EventArgs e) { }
		protected void Application_End(object sender, EventArgs e) { Utilities.SaveLog("EnvisionIEGet3rdPartyData.Global", "Application_End(object sender, EventArgs e)", "End", false); }
	}
}