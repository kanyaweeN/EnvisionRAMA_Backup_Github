using System.Data;
using System;

/// <summary>
/// Get is receive data.
/// Set is send data.
/// </summary>
namespace EnvisionIEGet3rdPartyData.InterfaceEngine
{
	public enum ConnectionName
	{
		Rama,
		None
	}

	public interface IBilling
	{
		DataSet Get_Billing(DataSet data);
		DataSet Set_Billing(DataSet data);
		DataSet Set_PreBilling(DataSet data);
	}

	public interface IDemographic
	{
		DataSet Get_Demographic(DataSet data);
		DataSet Get_Demographic_Short(DataSet data);
		DataSet Get_PatientAllergy(DataSet data);
		DataSet Get_PatientLabData(DataSet data);

		DataSet Set_Demographic(DataSet data);
        bool Get_TeleMedByEncIdAndType(DataSet data);
	}

	public interface IResult
	{
		DataSet Get_Result_Legacy(DataSet data);

		DataSet Set_Result(DataSet data);
		DataSet Set_ResultHasImage(DataSet data);
	}

	public interface ISchedule
	{
		DataSet Get_Schedule(DataSet data);
		DataSet Get_Schedule_Legacy(DataSet data);

		DataSet Set_Schedule(DataSet data);
	}

    public interface ICheckSync 
    {
        string Check_Sync();
    }
}