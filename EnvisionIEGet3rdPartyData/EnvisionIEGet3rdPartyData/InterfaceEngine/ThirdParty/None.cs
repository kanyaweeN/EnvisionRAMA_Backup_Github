using System.Data;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Operational;

namespace EnvisionIEGet3rdPartyData.InterfaceEngine.ThirdParty
{
	public class None : IBilling, IDemographic, IResult, ISchedule
	{
		// IBilling
		public DataSet Get_Billing(DataSet data) { return defaultValue(); }
		public DataSet Set_Billing(DataSet data) { return defaultValue(); }
		public DataSet Set_PreBilling(DataSet data) { return defaultValue(); }

		// IDemographic
		public DataSet Get_Demographic(DataSet data) { return defaultValue(); }
		public DataSet Get_Demographic_Short(DataSet data) { return defaultValue(); }
        public DataSet Get_PatientAllergy(DataSet data) { return defaultValue(); }
        public DataSet Get_PatientLabData(DataSet data) { return defaultValue(); }

		public DataSet Set_Demographic(DataSet data) { return defaultValue(); }
        public bool Get_TeleMedByEncIdAndType(DataSet data) { return false; }

		// IResult
		public DataSet Get_Result_Legacy(DataSet data) { return defaultValue(); }

		public DataSet Set_Result(DataSet data) { return defaultValue(); }
		public DataSet Set_ResultHasImage(DataSet data) { return defaultValue(); }

		// ISchedule
		public DataSet Get_Schedule(DataSet data) { return defaultValue(); }
		public DataSet Get_Schedule_Legacy(DataSet data) { return defaultValue(); }

		public DataSet Set_Schedule(DataSet data) { return defaultValue(); }

		public DataSet defaultValue()
		{
			HL7ACK hl7_ack = new HL7ACK();
			hl7_ack.MSA.ACKNOWLEDGMENT_CODE = string.Empty;
			hl7_ack.MSA.TEXT_MESSAGE = "Coming soon!";

			DataSet ds = new DataSet("EnvisionIE");
			ds.Tables.Add(Utilities.ConvertObjectToTable(hl7_ack.MSA));
			ds.Tables[0].TableName = "ACK";
			ds.AcceptChanges();

			return ds.Copy();
		}
	}
}