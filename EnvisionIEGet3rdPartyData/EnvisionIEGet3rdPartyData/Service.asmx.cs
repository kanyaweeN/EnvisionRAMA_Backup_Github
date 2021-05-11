using System;
using System.Data;
using System.Web.Services;
using EnvisionIEGet3rdPartyData.Common;
using EnvisionIEGet3rdPartyData.InterfaceEngine;
using EnvisionIEGet3rdPartyData.InterfaceEngine.ThirdParty;
using EnvisionIEGet3rdPartyData.InterfaceEngine.ThirdParty.InHouse;

namespace EnvisionIEGet3rdPartyData
{
	[WebService(Namespace = "http://www.miracleadvance.com/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	public class Service : WebService
	{
		[WebMethod]
		public string Welcome(string how)
		{
			DataSet ds = new DataSet("EnvisionIE");
			DataSet data = ((IBilling)getInterface()).Get_Billing(ds);
			//DataSet ds = new DataSet("Envision");
			//ds.Tables.Add(new DataTable());
			//ds.Tables[0].Columns.Add("HN");
			//ds.Tables[0].Rows.Add("1");

			//DataSet data = ((IDemographic)getInterface()).Get_Demographic(ds);

			//if (Utilities.HasData(data))
			//{
			//    object[] objs = data.Tables[0].Rows[0].ItemArray;

			//    how = string.Empty;

			//    foreach (object obj in objs)
			//        how += "\r\n" + obj.ToString();
			//}

			return string.Format("Welcome {0}", how);
		}
        [WebMethod]
        public string Check_Sync()
        {
            return ((ICheckSync)getInterface()).Check_Sync(); ;
        }

		#region IBilling
		[WebMethod]
		public DataSet Get_Billing(DataSet data) { return ((IBilling)getInterface()).Get_Billing(data); }

		[WebMethod]
		public DataSet Set_Billing(DataSet data) { return ((IBilling)getInterface()).Set_Billing(data); }
		[WebMethod]
		public DataSet Set_PreBilling(DataSet data) { return ((IBilling)getInterface()).Set_PreBilling(data); }
		#endregion

		#region IDemographic
		[WebMethod]
		public DataSet Get_Demographic(DataSet data) { return ((IDemographic)getInterface()).Get_Demographic(data); }
		[WebMethod]
		public DataSet Get_Demographic_Short(DataSet data) { return ((IDemographic)getInterface()).Get_Demographic_Short(data); }

		[WebMethod]
		public DataSet Set_Demographic(DataSet data) { return ((IDemographic)getInterface()).Set_Demographic(data); }
        [WebMethod]
        public bool Get_TeleMedByEncIdAndType(DataSet data) { return ((IDemographic)getInterface()).Get_TeleMedByEncIdAndType(data); }
		#endregion

		#region IResult
		[WebMethod]
		public DataSet Get_Result_Legacy(DataSet data) { return ((IResult)getInterface()).Get_Result_Legacy(data); }

		[WebMethod]
		public DataSet Set_Result(DataSet data) { return ((IResult)getInterface()).Set_Result(data); }
		[WebMethod]
		public DataSet Set_ResultHasImage(DataSet data) { return ((IResult)getInterface()).Set_ResultHasImage(data); }
		#endregion

		#region ISchedule
		[WebMethod]
		public DataSet Get_Schedule(DataSet data) { return ((ISchedule)getInterface()).Get_Schedule(data); }
		[WebMethod]
		public DataSet Get_Schedule_Legacy(DataSet data) { return ((ISchedule)getInterface()).Get_Schedule_Legacy(data); }

		[WebMethod]
		public DataSet Set_Schedule(DataSet data) { return ((ISchedule)getInterface()).Set_Schedule(data); }
		#endregion

		private object getInterface()
		{
			try
			{
				switch ((ConnectionName)Enum.Parse(typeof(ConnectionName), ConfigService.ThirdPartyConnectionName, true))
				{
					case ConnectionName.Rama: return new RAMA();
					default: return new None();
				}
			}
			catch
			{
				throw new Exception("Connection name is not match");
			}
		}
	}
}