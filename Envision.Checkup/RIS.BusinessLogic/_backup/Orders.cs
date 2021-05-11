using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using RIS.Operational;
using RIS.Operational.HL7.OrderManagement;
using RIS.Operational.PACS;
using RIS.Operational.Translator;
using RIS.Common;
using RIS.Common.Common;
using RIS.DataAccess.Select;
using System.Windows.Forms;
//using RIS.BusinessLogic.Common.HISService;
using RIS.BusinessLogic.Common.RamaService;
using System.Text.RegularExpressions;
namespace RIS.BusinessLogic
{
    public class OrderManager
    {
        private List<order> myArray;

        public OrderManager()
        {
            myArray = new List<order>();
        }
        public OrderManager(order order)
        {
            myArray = new List<order>();
            myArray.Add(order);
        }

        public order this[int index]
        {
            get
            {
                if (myArray.Count > index)
                    return myArray[index];
                else
                    throw new Exception("Out of Range");
            }
            set
            {
                if (myArray.Count > index)
                    myArray[index] = value;
                else
                    throw new Exception("Out of Range");
            }
        }
        public int Count
        {
            get { return myArray.Count; }
        }
        public void Add(order item)
        {
            myArray.Add(item);

        }
        public void RemoveAt(int i)
        {
            if (myArray.Count > i)
                myArray.RemoveAt(i);
            else
                throw new Exception("Out of index");

        }
    }

    public class order : IPatient, IScanDocument
    {
        private static DataTable dtExam;
        private static DataTable dtPrioriy;
        private static DataTable dtModality;
        private static DataTable dtModalityExam;
        private static DataTable dtRadiologist;
        private static DataTable dtDepartment;
        private static DataTable dtDoctor;
        private static DataTable dtBPView;
        private static DataTable dtInsuranceType;
        private static DataTable dtPatStatus;
        private static DataTable dtClinicType;
        private static int _isRowDefalutClinic;
        private static DataTable dtExamCheckup;
        private static DataTable dtFreqUsedExam;

        private GBLEnvVariable env = new GBLEnvVariable();
        private RISOrder item;
        private Patient patient;
        private DataTable dtPatICD;
        private DataTable dtOrderImage;
        private DataTable dtOrder;
        private DataTable dtSchedule;
        private DataSet dsPrevOrder;//ใช้ในกรณีเก็บข้อมูลที่จะแสดงใน TreeGrid 
        private bool hasSchedule;
        private int scheduleID; //schedule ที่ถูก User เลือก
        private string IsSchedule; //check ว่า มากจาก schedule or order
        private string visitNumber;
        private List<string> accNo = new List<string>();
       
        public HISRegistration his;

        public order()
        {
            item = new RISOrder();
            patient = new Patient();
            his = new HISRegistration();
            RefreshData();
            initBaseData();
            initOrderData();
        }
        public order(string HN)
        {
            patient = new Patient(HN);
            item = new RISOrder();
            item.REF_UNIT = patient.REF_UNIT;
            item.REF_DOC = patient.REF_DOC;
            his = new HISRegistration();
            RefreshData();
            initBaseData();
            initOrderData();
        }
        public order(string HN, bool GetDataFromLocal)
        {
            item = new RISOrder();
            his = new HISRegistration();
            patient = new Patient(HN, GetDataFromLocal);
            item.REF_UNIT = patient.REF_UNIT;
            item.REF_DOC = patient.REF_DOC;
            RefreshData();
            initBaseData();
            initOrderData();
        }
        public order(int Order_ID)
        {
            item = new RISOrder();
            his = new HISRegistration();
            item.ORDER_ID = Order_ID;
            RefreshData();
            initBaseData();
            initOrderData();
            if (item.HN != null & item.HN != "")
                patient = new Patient(item.HN);
        }

        public static bool HasHN(string HN)
        {
            bool flag = false;
            ProcessGetHISRegistration process = new ProcessGetHISRegistration(HN);
            process.Invoke();
            if (process.Result != null)
                if (process.Result.Tables[0].Rows.Count > 0)
                    flag = true;
            return flag;
        }
        public static bool HasOrder(int OrderID)
        {
            bool flag = false;
            ProcessGetRISOrder processOrder = new ProcessGetRISOrder(OrderID, 0);
            processOrder.Invoke();
            if (processOrder.Result != null)
                if (processOrder.Result.Tables[0].Rows.Count > 0)
                    flag = true;
            return flag;
        }
        public static DataTable His_Department()
        {
            if (dtDepartment == null)
            {

                ProcessGetHRUnit processDep = new ProcessGetHRUnit();
                processDep.Invoke();
                dtDepartment = processDep.Result.Tables[0].Copy();
                dtDepartment.TableName = "HIS_DEPARTMENT";
            }
            return dtDepartment;
        }
        public static DataTable BP_View()
        {
            if (dtBPView == null)
            {
                ProcessGetRISBpview prcBP = new ProcessGetRISBpview();
                prcBP.Invoke();
                dtBPView = prcBP.Result.Tables[0].Copy();
                dtBPView.TableName = "BP_VIEW";
            }
            return dtBPView;
        }
        public static DataTable His_Doctor()
        {
            if (dtDoctor == null)
            {
                ProcessGetHISDoctor processDoctor = new ProcessGetHISDoctor();
                processDoctor.Invoke();
                dtDoctor = processDoctor.Result.Tables[0].Copy();
                dtDoctor.TableName = "HIS_DOCTOR";
            }
            return dtDoctor;
        }
        public static DataTable Ris_Exam()
        {
            if (dtExam == null)
            {
                ProcessGetRISExam processExam = new ProcessGetRISExam();
                processExam.Invoke();
                dtExam = processExam.Result.Tables[0].Copy();
                dtExam.TableName = "RIS_EXAM";
            }
            return dtExam;
        }
        public static DataTable Ris_Priority()
        {
            if (dtPrioriy == null)
            {
                dtPrioriy = new DataTable();
                dtPrioriy.Columns.Add("PRI_ID", typeof(string));
                dtPrioriy.Columns.Add("PRIORITY", typeof(string));
                DataRow dr = dtPrioriy.NewRow();
                dr["PRI_ID"] = "S";
                dr["PRIORITY"] = "Stat";
                dtPrioriy.Rows.Add(dr);
                dr = dtPrioriy.NewRow();
                dr["PRI_ID"] = "R";
                dr["PRIORITY"] = "Routine";
                dtPrioriy.Rows.Add(dr);
                dr = dtPrioriy.NewRow();
                dr["PRI_ID"] = "U";
                dr["PRIORITY"] = "Urgent";
                dtPrioriy.Rows.Add(dr);
                dtPrioriy.TableName = "RIS_PRIORITY";
            }
            return dtPrioriy;
        }
        public static DataTable Ris_Modality()
        {
            if (dtModality == null)
            {

                ProcessGetRISModality processModality = new ProcessGetRISModality();
                processModality.Invoke();
                dtModality = processModality.Result.Tables[0].Copy();
                dtModality.TableName = "RIS_MODALITY";
            }
            return dtModality;
        }
        public static DataTable Ris_ModalityExam()
        {
            if (dtModalityExam == null)
            {
                ProcessGetRISModalityexam processMath = new ProcessGetRISModalityexam(true);
                processMath.Invoke();
                dtModalityExam = processMath.Result.Tables[0].Copy();
                dtModalityExam.TableName = "RIS_MODALITYEXAM";
            }
            return dtModalityExam;
        }
        public static DataTable Ris_Radiologist()
        {
            if (dtRadiologist == null)
            {

                ProcessGetRISOrderdtl processRadiologist = new ProcessGetRISOrderdtl();
                dtRadiologist = processRadiologist.GetRadioLogist().Copy();
                dtRadiologist.TableName = "HR_EMP";
            }
            return dtRadiologist;

        }
        public static void Refresh_InsuranceType()
        {
            ProcessGetRISInsurancetype processInsure = new ProcessGetRISInsurancetype();
            processInsure.Invoke();
            dtInsuranceType = processInsure.Result.Tables[0].Copy();
            dtInsuranceType.TableName = "RIS_INSURANCETYPE";
        }
        public static DataTable Ris_InsuranceType()
        {
            if (dtInsuranceType == null)
            {

                ProcessGetRISInsurancetype processInsure = new ProcessGetRISInsurancetype();
                processInsure.Invoke();
                dtInsuranceType = processInsure.Result.Tables[0].Copy();
                dtInsuranceType.TableName = "RIS_INSURANCETYPE";
            }
            return dtInsuranceType;
        }
        public static DataTable RIS_PatStatus()
        {

            if (dtPatStatus == null)
            {
                ProcessGetRISPatstatus processPat = new ProcessGetRISPatstatus(true);
                processPat.Invoke();
                dtPatStatus = processPat.ResultSet.Tables[0].Copy();
                dtPatStatus.TableName = "RIS_PATSTATUS";
            }

            return dtPatStatus;
        }
        public static DataTable RIS_ClinicType()
        {
            if (dtClinicType == null)
            {


                ProcessGetRISClinictype processClinic = new ProcessGetRISClinictype();
                processClinic.Invoke();
                dtClinicType = processClinic.Result.Tables[0].Copy();
                dtClinicType.TableName = "RIS_CLINICTYPE";
                _isRowDefalutClinic = 0;
                if (processClinic.Result != null)
                    if (processClinic.Result.Tables.Count > 0)
                        if (processClinic.Result.Tables[0].Rows.Count > 0)
                            foreach (DataRow drClinic in processClinic.Result.Tables[0].Rows)
                            {
                                if (drClinic["IS_DEFAULT"].ToString().Trim() == "Y")
                                {
                                    _isRowDefalutClinic = Convert.ToInt32(drClinic["CLINIC_TYPE_ID"]);
                                    break;
                                }
                            }
            }

            return dtClinicType;
        }
        public static decimal CalTotal(DataTable dtHasFiled_Rate)
        {
            decimal tax = 0.0M;
            if (dtHasFiled_Rate != null)
                if (dtHasFiled_Rate.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtHasFiled_Rate.Rows)
                    {
                        decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
                        tax += taxTemp;
                    }

                }
            return tax;
        }
        public static decimal CalSpecialTotal(DataTable dtHasField_Special_Rate)
        {
            decimal tax = 0.0M;
            if (dtHasField_Special_Rate != null)
                if (dtHasField_Special_Rate.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtHasField_Special_Rate.Rows)
                    {
                        decimal taxTemp = dr["SPECIAL_RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["SPECIAL_RATE"]);
                        tax += taxTemp;
                    }

                }
            return tax;
        }
        public static decimal CalTax(DataTable dtHasField_Vat_Rate)
        {
            decimal tax = 0.0M;
            if (dtHasField_Vat_Rate != null)
                if (dtHasField_Vat_Rate.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtHasField_Vat_Rate.Rows)
                    {
                        decimal taxTemp = dr["VAT_RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["VAT_RATE"]);
                        tax += taxTemp;
                    }

                }
            return tax;
        }
        public static string GenHN()
        {
            string MOD = "ZZX";
            string strRet = DateTime.Today.Year.ToString();
            if (DateTime.Today.Month.ToString().Length == 1)
                strRet += "0";
            strRet += DateTime.Today.Month.ToString();
            if (DateTime.Today.Day.ToString().Length == 1)
                strRet += "0";
            strRet += DateTime.Today.Day.ToString();
            try
            {
                ProcessGetGBLSequences processGBL = new ProcessGetGBLSequences();
                processGBL.GBLSequences.Seq_Name = MOD;
                //string no = processGBL.GetAccessionNo().ToString();
                string no = processGBL.GetRunnigNo().ToString();
                if (MOD.Length == 2)
                {
                    switch (no.Length)
                    {
                        case 1:
                            no = "0000" + no;
                            break;
                        case 2:
                            no = "000" + no;
                            break;
                        case 3:
                            no = "00" + no;
                            break;
                        case 4:
                            no = "0" + no;
                            break;
                    }
                }
                else
                {
                    switch (no.Length)
                    {
                        case 1:
                            no = "000" + no;
                            break;
                        case 2:
                            no = "00" + no;
                            break;
                        case 3:
                            no = "0" + no;
                            break;
                    }
                }
                strRet += no;
            }

            catch (Exception ex)
            {
                return string.Empty;
            }
            return strRet;
        }
        public static void RefreshData()
        {
            _isRowDefalutClinic = 0;
            dtDepartment = dtDoctor = dtExam = dtPrioriy = null;
            dtModality = dtModalityExam = dtRadiologist = dtInsuranceType = null;
            dtExamCheckup = dtFreqUsedExam = null;
            dtPatStatus = dtClinicType = null;

            His_Department();
            His_Doctor();
            Ris_Exam();
            Ris_Priority();
            Ris_Modality();
            Ris_ModalityExam();
            Ris_Radiologist();
            Ris_InsuranceType();
            RIS_PatStatus();
            RIS_ClinicType();
        }
        public static DataTable Ris_ExamCheckup()
        {
            if (dtExamCheckup == null)
            {
                ProcessGetRISExam processExam = new ProcessGetRISExam();
                processExam.Invoke();
                DataRow[] drs = processExam.Result.Tables[0].Select("IS_CHECKUP like 'Y'");
                if (drs.Length > 0)
                {
                    DataTable dt = drs[0].Table.Clone();
                    foreach (DataRow row in drs)
                        dt.Rows.Add(row);
                    dtExamCheckup = dt.Copy();
                }
                else
                {
                    dtExamCheckup = processExam.Result.Tables[0].Copy();
                }
                dtExamCheckup.TableName = "RIS_ExamCheckup";
            }
            return dtExamCheckup;
        }
        public static DataTable Ris_FrequenlyUsedExam()
        {
            if (dtFreqUsedExam == null)
            {
                ProcessGetRisvFreqUsedExam processFreqUsedExam = new ProcessGetRisvFreqUsedExam();
                processFreqUsedExam.Invoke();
                dtFreqUsedExam = processFreqUsedExam.ResultSet.Tables[0].Copy();
                dtFreqUsedExam.TableName = "Risv_FrequenlyUsedExam";
            }
            return dtFreqUsedExam;
        }

        public decimal CalTotal()
        {
            decimal tax = 0.0M;
            if (dtOrder != null)
                if (dtOrder.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        decimal taxTemp = dr["RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["RATE"]);
                        tax += taxTemp;
                    }

                }
            return tax;
        }
        public decimal CalSpecialTotal()
        {
            decimal tax = 0.0M;
            if (dtOrder != null)
                if (dtOrder.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        decimal taxTemp = dr["SPECIAL_RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["SPECIAL_RATE"]);
                        tax += taxTemp;
                    }

                }
            return tax;
        }
        public decimal CalTax()
        {
            decimal tax = 0.0M;
            if (dtOrder != null)
                if (dtOrder.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        decimal taxTemp = dr["VAT_RATE"].ToString() == string.Empty ? 0.0M : Convert.ToDecimal(dr["VAT_RATE"]);
                        tax += taxTemp;
                    }

                }
            return tax;
        }
        public bool CheckConfliction(int iCheckExamID)
        {
            try
            {
                RISOrderConfliction orderconflict = new RISOrderConfliction();
                DataSet ResultSet = orderconflict.Get(env.OrgID, item.ORDER_ID, iCheckExamID);
                DataTable dt = ResultSet.Tables[0];
                int k = 0;
                while (k < dt.Rows.Count)
                {
                    if (Convert.ToInt32(dt.Rows[k]["RESULT"]) == 1)
                        return true;
                    else
                        return false;
                    k++;
                }


                return false;
            }
            catch (Exception ex)
            {
                throw ex;
                //elog.LogException(ex.ToString(), 1, "F");
            }

        }
        public bool CheckConfliction(DateTime ExamDateTime, int iExamID, DataTable ExamDT)
        {
            try
            {
                RISOrderConfliction orderconflict = new RISOrderConfliction();

                if (ExamDT.Rows.Count == 0)
                    return false;

                foreach (DataRow dr in ExamDT.Rows)
                    if (dr["EXAM_ID"].ToString() == iExamID.ToString())
                        return true;



                int k = 0;
                while (k < ExamDT.Rows.Count)
                {
                    DataSet ResultSet = orderconflict.Get(env.OrgID, item.ORDER_ID, Convert.ToDateTime(ExamDT.Rows[k]["EXAM_DT"]), ExamDateTime);
                    DataTable dt = ResultSet.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dt.Rows[k]["RESULT"]) != 1)
                            return false;
                    }
                    k++;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                //elog.LogException(ex.ToString(), 1, "F");
            }

        }
        public bool HasSchedule
        {
            get { return hasSchedule; }
            set { hasSchedule = value; }
        }
        public int IsRowDefalutClinic
        {
            get { return _isRowDefalutClinic; }
            set { _isRowDefalutClinic = value; }
        }
        public int ScheduleID
        {
            get { return scheduleID; }
            set
            {
                initTreeGrid();
                scheduleID = value;
                fillSchedule();
            }
        }
        public string VisitNumber
        {
            get { return visitNumber; }
            set { visitNumber = value; }
        }
        public HISRegistration His_Registratiion
        {
            set
            {
                his = new HISRegistration();
                his = value;
            }
            get
            {
                return his;
            }
        }
        public DataTable Ris_Schedule()
        {

            DataTable dt = new DataTable();
            //try
            //{
            //    dt = ds.Tables[0].Copy();
            //    dt.TableName = "RIS_ORDER";
            //}
            //catch (Exception ex)
            //{
            //    string s = ex.Message;
            //}
            return dt;
        }
        public DataTable Ris_PatICD
        {
            get { return dtPatICD; }
            set { dtPatICD = value; }
        }
        public DataTable LastOrder(int UserID)
        {
            DataTable dtt = null;
            ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
            dtt = process.GetLastOrder(env.UserID);
            dtt.Columns.Add("ORIGIN_ID", typeof(int));
            dtt.Columns.Add("colDelete");
            foreach (DataRow dr in dtt.Rows)
            {
                dr["ORIGIN_ID"] = dr["EXAM_ID"];
                dr["colDelete"] = "Delete";
            }
            dtOrder = new DataTable();
            dtOrder = dtt.Copy();
            DataRow drAdd = dtOrder.NewRow();
            drAdd["SPECIAL_CLINIC"] = "N";
            drAdd["IS_DELETED"] = "N";
            drAdd["PRIORITY"] = "R";
            drAdd["EXAM_DT"] = DateTime.Today;
            drAdd["CLINIC_TYPE"] = _isRowDefalutClinic;
            drAdd["colDelete"] = "Delete";
            dtOrder.Rows.Add(drAdd);
            return dtt;
        }
        public DataTable Ris_OrderImage
        {
            get { return dtOrderImage; }
            set { dtOrderImage = value; }

        }
        public DataTable ItemDetail
        {
            get { return dtOrder; }
            set { dtOrder = value; }
        }
        public RISOrder Item
        {
            get { return item; }
            set { item = value; }
        }
        public DataSet TreeData
        {
            get { return dsPrevOrder; }
            set { dsPrevOrder = value; }
        }
        public void UpdateSpecialClinicStatus(string status)
        {
            foreach (DataRow dr in dtOrder.Rows)
                dr["SPECIAL_CLINIC"] = status;

        }
        public void SetScheduleID(int Schedule_ID)
        {
            scheduleID = Schedule_ID;
        }


        #region IPatient Members

        public IPatientDemographic Demographic
        {
            get
            {
                return (IPatientDemographic)patient;
            }
            set
            {
                patient = (Patient)value;
            }
        }

        #endregion

        #region IScanDocument Members

        public bool Scan()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        private void initBaseData()
        {

            ProcessGetRISPaticd processRISPatICD = new ProcessGetRISPaticd(item.ORDER_ID);
            processRISPatICD.Invoke();
            dtPatICD = processRISPatICD.Result.Tables[0];

        }
        private void initOrderData()
        {
            if (item.ORDER_ID == 0)
            {

                ProcessGetRISOrderdtl processDTL = new ProcessGetRISOrderdtl('3', item.ORDER_ID, item.REG_ID);
                processDTL.Invoke();
                dtOrder = processDTL.Result.Tables[0].Copy();
                dtOrder.Columns.Add("ORIGIN_ID", typeof(int));
                dtOrder.Columns.Add("colDelete");
                dtOrder.TableName = "RIS_ORDER";
                DataRow dr = dtOrder.NewRow();
                dr["SPECIAL_CLINIC"] = "N";
                dr["IS_DELETED"] = "N";
                dr["PRIORITY"] = "R";
                dr["EXAM_DT"] = DateTime.Today;
                dr["CLINIC_TYPE"] = _isRowDefalutClinic;
                dr["colDelete"] = "Delete";
                dtOrder.Rows.Add(dr);
                hasSchedule = false;
                getOrderImage();
                getSchedule();
            }
            else
            {
                fillPatient();
                fillOrderData();
                getOrderImage();
                getSchedule();

            }
            initTreeGrid();
        }
        private void initTreeGrid()
        {
            dsPrevOrder = new DataSet();

            DataTable dtt = new DataTable("Root");
            DataTable dtMaster = new DataTable("Masters");
            DataTable dtDetail = new DataTable("Details");

            #region Root
            dtt.Columns.Add("Caption", typeof(string));
            dtt.Columns.Add("Level", typeof(int));
            DataRow dr = dtt.NewRow();
            dr[0] = "New Order";
            dr[1] = 0;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr[0] = "Order Today";
            dr[1] = 1;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr[0] = "Last 3 Order";
            dr[1] = 2;
            dtt.Rows.Add(dr);
            #endregion
            #region Masters
            dtMaster.Columns.Add("ID", typeof(int));
            dtMaster.Columns.Add("Caption", typeof(string));
            dtMaster.Columns.Add("DateTime", typeof(DateTime));
            dtMaster.Columns.Add("Level", typeof(int));
            dtMaster.Columns.Add("SPECIAL_CLINIC", typeof(string));
            #endregion
            #region Details
            dtDetail.Columns.Add("ID", typeof(int));
            dtDetail.Columns.Add("EXAM_ID", typeof(int));
            dtDetail.Columns.Add("MODALITY_ID", typeof(int));
            dtDetail.Columns.Add("Level", typeof(int));

            #endregion

            dsPrevOrder.Tables.Add(dtt);
            dsPrevOrder.Tables.Add(dtMaster);
            dsPrevOrder.Tables.Add(dtDetail);

            setTreeByOrder();
            setTreeBySchedule();

            DataColumn dcMaster1, dcMaster2, dcChild1, dcChild2;
            dcMaster1 = dsPrevOrder.Tables["Masters"].Columns["ID"];
            dcMaster2 = dsPrevOrder.Tables["Masters"].Columns["Level"];
            dcChild1 = dsPrevOrder.Tables["Details"].Columns["ID"];
            dcChild2 = dsPrevOrder.Tables["Details"].Columns["Level"];
            DataRelation dl1 = new DataRelation("Master_Details", new DataColumn[] { dcMaster1, dcMaster2 }, new DataColumn[] { dcChild1, dcChild2 });
            dsPrevOrder.Relations.Add(dl1);
            dl1 = new DataRelation("Root_Master", dsPrevOrder.Tables["Root"].Columns["Level"], dsPrevOrder.Tables["Masters"].Columns["Level"]);
            dsPrevOrder.Relations.Add(dl1);
            #region Check Row
            List<int> del = new List<int>();
            for (int i = 0; i < dsPrevOrder.Tables["Root"].Rows.Count; i++)
            {
                DataRow[] drRoot = dsPrevOrder.Tables["Root"].Rows[i].GetChildRows("Root_Master");
                if (drRoot.Length == 0)
                    del.Add((int)dsPrevOrder.Tables["Root"].Rows[i]["Level"]);
            }
            foreach (int i in del)
            {
                foreach (DataRow drDelete in dsPrevOrder.Tables["Root"].Rows)
                {
                    if ((int)drDelete["Level"] == i)
                    {
                        drDelete.Delete();
                        dsPrevOrder.AcceptChanges();
                        break;
                    }
                }
            }
            #endregion
        }

        private void fillPatient()
        {
            ProcessGetRISOrder process = new ProcessGetRISOrder(item.ORDER_ID, 0);
            process.Invoke();
            patient = new Patient(process.Result.Tables[0].Rows[0]["HN"].ToString(), true);
            item.HN = patient.Reg_UID;
        }
        private void fillOrderData()
        {
            ProcessGetRISOrder processOrder = new ProcessGetRISOrder(item.ORDER_ID, item.REG_ID);
            processOrder.Invoke();
            if (processOrder.Result != null)
            {
                #region ใส่ข้อมูลรายเอียดจากตาราง Ris_Order
                if (processOrder.Result.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = processOrder.Result.Tables[0].Rows[0];
                    item.REG_ID = Convert.ToInt32(dr["REG_ID"]);
                    item.HN = dr["HN"].ToString();
                    item.VISIT_NO = dr["VISIT_NO"].ToString();
                    item.ADMISSION_NO = dr["ADMISSION_NO"].ToString();
                    if (dr["ORDER_DT"].ToString().Trim() == string.Empty)
                        item.ORDER_DT = DateTime.Today;
                    else
                        item.ORDER_DT = Convert.ToDateTime(dr["ORDER_DT"]);
                    if (dr["ORDER_START_TIME"].ToString().Trim() == string.Empty)
                        item.ORDER_START_TIME = DateTime.Today;
                    else
                        item.ORDER_START_TIME = Convert.ToDateTime(dr["ORDER_START_TIME"]);
                    int tmp = 0;
                    tmp = dr["SCHEDULE_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["SCHEDULE_ID"]);
                    item.SCHEDULE_ID = tmp;
                    item.REF_DOC_INSTRUCTION = dr["REF_DOC_INSTRUCTION"].ToString();
                    item.CLINICAL_INSTRUCTION = dr["CLINICAL_INSTRUCTION"].ToString();
                    item.REASON = dr["REASON"].ToString();
                    item.DIAGNOSIS = dr["DIAGNOSIS"].ToString();
                    tmp = dr["ICD_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["ICD_ID"]);
                    item.ICD_ID = tmp;
                    tmp = dr["ORG_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["ORG_ID"]);
                    item.ORG_ID = tmp;
                    tmp = dr["CREATED_BY"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["CREATED_BY"]);
                    item.CREATED_BY = tmp;
                    if (dr["CREATED_ON"].ToString().Trim().Length > 0)
                        item.CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"]);
                    else
                        item.CREATED_ON = DateTime.Today;
                    tmp = dr["LAST_MODIFIED_BY"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["LAST_MODIFIED_BY"]);
                    item.LAST_MODIFIED_BY = tmp;
                    if (dr["LAST_MODIFIED_ON"].ToString().Trim().Length > 0)
                        item.LAST_MODIFIED_ON = Convert.ToDateTime(dr["LAST_MODIFIED_ON"]);
                    else
                        item.LAST_MODIFIED_ON = DateTime.Today;
                    if (dr["REF_DOC"].ToString() == string.Empty)
                        item.REF_DOC = 0;
                    else
                        item.REF_DOC = Convert.ToInt32(dr["REF_DOC"]);
                    if (dr["REF_UNIT"].ToString() == string.Empty)
                        item.REF_UNIT = 0;
                    else
                        item.REF_UNIT = Convert.ToInt32(dr["REF_UNIT"]);


                    if (dr["REF_DOC_INSTRUCTION"].ToString().Trim().Length > 0)
                        item.REF_DOC_INSTRUCTION = dr["REF_DOC_INSTRUCTION"].ToString();
                    else
                        item.REF_DOC_INSTRUCTION = string.Empty;
                    if (dr["INSURANCE_TYPE_ID"].ToString() == string.Empty)
                        item.INSURANCE_TYPE_ID = 0;
                    else
                        item.INSURANCE_TYPE_ID = Convert.ToInt32(dr["INSURANCE_TYPE_ID"]);
                    patient.InsuranceID = item.INSURANCE_TYPE_ID;

                    if (dr["PAT_STATUS"].ToString().Trim() == string.Empty)
                        item.PAT_STATUS = string.Empty;
                    else
                        item.PAT_STATUS = dr["PAT_STATUS"].ToString();
                    patient.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    patient.REF_DOC = item.REF_DOC;
                    patient.REF_UNIT = item.REF_UNIT;
                    if (dr["LMP_DT"].ToString() != null)
                        if (dr["LMP_DT"].ToString().Trim() != string.Empty)
                            item.Lmp_DT = Convert.ToDateTime(dr["LMP_DT"]);

                }
                #endregion
            }
            // ใส่รายละเอียดจากตาราง Ris_OrderDtl
            dtOrder = new DataTable();
            ProcessGetRISOrderdtl processDTL = new ProcessGetRISOrderdtl('3', item.ORDER_ID, item.REG_ID);
            processDTL.Invoke();
            dtOrder = processDTL.Result.Tables[0].Copy();
            dtOrder.TableName = "RIS_ORDER";
            dtOrder.Columns.Add("ORIGIN_ID", typeof(int));
            dtOrder.Columns.Add("colDelete");
            DataRow drAdd = dtOrder.NewRow();
            drAdd["SPECIAL_CLINIC"] = "N";
            drAdd["IS_DELETED"] = "N";
            drAdd["PRIORITY"] = "R";
            drAdd["EXAM_DT"] = DateTime.Today;
            drAdd["CLINIC_TYPE"] = _isRowDefalutClinic;
            drAdd["colDelete"] = "Delete";
            dtOrder.Rows.Add(drAdd);
            foreach (DataRow dr in dtOrder.Rows)
            {
                dr["ORIGIN_ID"] = dr["EXAM_ID"];
                dr["colDelete"] = "Delete";
            }


        }
        private void fillSchedule()
        {
            ProcessGetRISSchedule schedule = new ProcessGetRISSchedule(scheduleID);
            schedule.Invoke();
            visitNumber = schedule.Result.Tables[0].Rows[0]["VISIT_NO"].ToString();
            item.ORDER_DT = Convert.ToDateTime(schedule.Result.Tables[0].Rows[0]["APPOINT_DT"]);
            item.ADMISSION_NO = schedule.Result.Tables[0].Rows[0]["ADMISSION_NO"].ToString();
            item.REF_DOC_INSTRUCTION = schedule.Result.Tables[0].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            item.CLINICAL_INSTRUCTION = schedule.Result.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString();
            item.REASON = schedule.Result.Tables[0].Rows[0]["REASON"].ToString();
            item.DIAGNOSIS = schedule.Result.Tables[0].Rows[0]["DIAGNOSIS"].ToString();
            item.ICD_ID = schedule.Result.Tables[0].Rows[0]["DIAGNOSIS"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["DIAGNOSIS"]);
            item.ORG_ID = schedule.Result.Tables[0].Rows[0]["ORG_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["ORG_ID"]);
            item.REF_UNIT = schedule.Result.Tables[0].Rows[0]["REF_UNIT"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["REF_UNIT"]);
            item.REF_DOC = schedule.Result.Tables[0].Rows[0]["REF_DOC"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["REF_DOC"]);

            DataTable dt = dtOrder.Clone();
            DataRow drOrder = dt.NewRow();
            drOrder["EXAM_ID"] = schedule.Result.Tables[0].Rows[0]["EXAM_ID"];
            foreach (DataRow drExam in dtExam.Rows)
            {
                if (drExam["EXAM_ID"].ToString().Trim() == drOrder["EXAM_ID"].ToString().Trim())
                {
                    drOrder["EXAM_UID"] = drExam["EXAM_UID"];
                    drOrder["EXAM_NAME"] = drExam["EXAM_NAME"];
                    drOrder["RATE"] = schedule.Result.Tables[0].Rows[0]["RATE"];
                    drOrder["SPECIAL_RATE"] = drExam["SPECIAL_RATE"];
                    break;
                }
            }
            //drOrder["CLINIC_TYPE"] = schedule.Result.Tables[0].Rows[0]["CLINIC_TYPE"]; 
            drOrder["ACCESSION_NO"] = "wait process";
            drOrder["MODALITY_ID"] = schedule.Result.Tables[0].Rows[0]["MODALITY_ID"];
            drOrder["EXAM_DT"] = schedule.Result.Tables[0].Rows[0]["APPOINT_DT"];
            drOrder["QTY"] = schedule.Result.Tables[0].Rows[0]["QTY"];
            drOrder["ASSIGNED_TO"] = schedule.Result.Tables[0].Rows[0]["RAD_ID"];
            drOrder["BPVIEW_ID"] = 5;
            drOrder["PRIORITY"] = "R";
            drOrder["IS_DELETED"] = "N";
            drOrder["CLINIC_TYPE"] = schedule.Result.Tables[0].Rows[0]["CLINIC_TYPE"];
            drOrder["colDelete"] = "Delete";
            dt.Rows.Add(drOrder);

            drOrder = dt.NewRow();
            drOrder["SPECIAL_CLINIC"] = "N";
            drOrder["IS_DELETED"] = "N";
            drOrder["PRIORITY"] = "R";
            drOrder["EXAM_DT"] = DateTime.Today;
            drOrder["CLINIC_TYPE"] = _isRowDefalutClinic;
            drOrder["colDelete"] = "Delete";
            dt.Rows.Add(drOrder);

            dtOrder = dt;
            dtOrder.TableName = "RIS_ORDER";

            #region MyRegion
            //ลบข้อมูลใน Tree ที่ schedule เลือก
            //dsPrevOrder.Relations.Clear();
            //int i = 0;
            //while (i < dsPrevOrder.Tables["Details"].Rows.Count)
            //{
            //    if (dsPrevOrder.Tables["Details"].Rows[i]["ID"].ToString() == scheduleID.ToString())
            //    {
            //        dsPrevOrder.Tables["Details"].Rows[i].Delete();
            //        dsPrevOrder.Tables["Details"].AcceptChanges();
            //        i = 0;
            //    }
            //    else
            //        i++;
            //}
            //i = 0;
            //while (i < dsPrevOrder.Tables["Masters"].Rows.Count)
            //{
            //    if (dsPrevOrder.Tables["Masters"].Rows[i]["ID"].ToString() == scheduleID.ToString())
            //    {
            //        dsPrevOrder.Tables["Masters"].Rows[i].Delete();
            //        dsPrevOrder.Tables["Masters"].AcceptChanges();
            //        i = 0;
            //    }
            //    else
            //        i++;
            //}
            //DataColumn dcMaster1, dcMaster2, dcChild1, dcChild2;
            //dcMaster1 = dsPrevOrder.Tables["Masters"].Columns["ID"];
            //dcMaster2 = dsPrevOrder.Tables["Masters"].Columns["Level"];
            //dcChild1 = dsPrevOrder.Tables["Details"].Columns["ID"];
            //dcChild2 = dsPrevOrder.Tables["Details"].Columns["Level"];
            //DataRelation dl1 = new DataRelation("Master_Details", new DataColumn[] { dcMaster1, dcMaster2 }, new DataColumn[] { dcChild1, dcChild2 });
            //dsPrevOrder.Relations.Add(dl1);
            //dl1 = new DataRelation("Root_Master", dsPrevOrder.Tables["Root"].Columns["Level"], dsPrevOrder.Tables["Masters"].Columns["Level"]);
            //dsPrevOrder.Relations.Add(dl1);
            //#region Check Row
            //List<int> del = new List<int>();
            //for (i = 0; i < dsPrevOrder.Tables["Root"].Rows.Count; i++)
            //{
            //    DataRow[] drRoot = dsPrevOrder.Tables["Root"].Rows[i].GetChildRows("Root_Master");
            //    if (drRoot.Length == 0)
            //        del.Add((int)dsPrevOrder.Tables["Root"].Rows[i]["Level"]);
            //}
            //foreach (int j in del)
            //{
            //    foreach (DataRow drDelete in dsPrevOrder.Tables["Root"].Rows)
            //    {
            //        if ((int)drDelete["Level"] == j)
            //        {
            //            drDelete.Delete();
            //            dsPrevOrder.AcceptChanges();
            //            break;
            //        }
            //    }
            //}
            //#endregion
            #endregion
        }
        private void getOrderImage()
        {
            ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
            process.RISOrderimages.ORDER_ID = item.ORDER_ID;
            process.Invoke();

            dtOrderImage = new DataTable();
            if (process.Result != null)
                if (process.Result.Tables.Count > 0)
                {
                    dtOrderImage = process.Result.Tables[0].Copy();
                    for (int i = 0; i < dtOrderImage.Rows.Count; i++)
                        dtOrderImage.Rows[i]["IS_DELETED"] = "N";
                }
        }
        private void getSchedule()
        {
            try
            {
                //เอาโครงสร้างเฉยๆ
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RISSchedule.REG_ID = 0;
                schedule.RISSchedule.HN = patient.Reg_UID;
                schedule.RISSchedule.APPOINT_DT = DateTime.Today;
                schedule.Invoke();

                dtSchedule = new DataTable();
                dtSchedule = schedule.Result.Tables[0].Copy();
                scheduleID = 0;

            }
            catch (Exception ex) { }
        }

        private void setTreeBySchedule()
        {
            try
            {
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RISSchedule.REG_ID = 0;
                schedule.RISSchedule.HN = patient == null ? string.Empty : patient.Reg_UID;

                schedule.RISSchedule.APPOINT_DT = DateTime.Today;
                schedule.Invoke();
                if (schedule.Result != null)
                {
                    foreach (DataRow dr in schedule.Result.Tables[0].Rows)
                    {
                        DataRow drData = dsPrevOrder.Tables["Masters"].NewRow();
                        drData["ID"] = dr["SCHEDULE_ID"];
                        drData["Caption"] = "Schedule No: " + dr["SCHEDULE_ID"];
                        drData["DateTime"] = dr["APPOINT_DT"];
                        drData["Level"] = 1;
                        drData["SPECIAL_CLINIC"] = dr["SPECIAL_CLINIC"];
                        dsPrevOrder.Tables["Masters"].Rows.Add(drData);
                        int scheduleID = Convert.ToInt32(drData["ID"]);
                        DataRow drDataDetails = dsPrevOrder.Tables["Details"].NewRow();
                        drDataDetails["ID"] = dr["SCHEDULE_ID"];
                        drDataDetails["EXAM_ID"] = dr["EXAM_ID"];
                        drDataDetails["MODALITY_ID"] = dr["MODALITY_ID"];
                        drDataDetails["Level"] = 1;
                        dsPrevOrder.Tables["Details"].Rows.Add(drDataDetails);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void setTreeByOrder()
        {

            ProcessGetRISOrder order = new ProcessGetRISOrder(item.ORDER_ID, item.REG_ID);
            DataSet dsPre = order.PreviosOrder(patient.Reg_UID);
            if (dsPre != null)
            {
                foreach (DataRow dr in dsPre.Tables[0].Rows)
                {
                    DataRow drData = dsPrevOrder.Tables["Masters"].NewRow();
                    drData["ID"] = dr["ORDER_ID"];
                    drData["Caption"] = "Order No: " + dr["ORDER_ID"];
                    drData["DateTime"] = dr["ORDER_DT"];
                    drData["Level"] = 2;
                    dsPrevOrder.Tables["Masters"].Rows.Add(drData);
                }


                ProcessGetRISOrderdtl orderDtl = new ProcessGetRISOrderdtl('1', item.ORDER_ID, item.REG_ID);
                orderDtl.Invoke();
                foreach (DataRow dr in dsPre.Tables[1].Rows)
                {
                    bool flag = true;


                    if (flag)
                    {
                        DataRow drData = dsPrevOrder.Tables["Details"].NewRow();
                        drData["ID"] = dr["ORDER_ID"];
                        drData["EXAM_ID"] = dr["EXAM_ID"];
                        drData["MODALITY_ID"] = dr["MODALITY_ID"];
                        drData["Level"] = 2;
                        dsPrevOrder.Tables["Details"].Rows.Add(drData);
                    }
                }
            }
        }

        private void updateScheduleStatus(SqlTransaction tran)
        {
            if (scheduleID > 0)
            {
                ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule(scheduleID);
                process.UseTransaction = tran;
                process.RISSchedule.SCHEDULE_STATUS = "O";
                process.Invoke();
            }
        }
        private string getAccessionNo(int MOD_ID)
        {
            string accNo = string.Empty;
            try
            {
                ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl();
                accNo = process.GetAccessionNo(MOD_ID);
                if (accNo.Trim() == string.Empty)
                    throw new Exception("Modality : " + MOD_ID + " cannot generate accession number, Please try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return accNo;
        }

        public bool Invoke()
        {
            bool retFlag = true;
            bool flag = true;
            SqlTransaction tran = null;
            SqlConnection con = null;
            DataTable dtt = dtOrder.Clone();
            dtt.Columns.Add("ordflag", typeof(string));
            string pacnum = "";

            DataTable dttPatOri;
            string mode = "New";
            try
            {

                DataAccess.DataAccessBase baseData = new RIS.DataAccess.DataAccessBase();
                con = baseData.GetSQLConnection();

                con.Open();
                tran = con.BeginTransaction();

                #region เพิ่ม ปรังปรุง ข้อมูล Patient
                int regID = 0;
                if (patient.LinkDown == false && patient.DataFromHIS)
                {
                    ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                    pAddHIS.HISRegistration.ADDR1 = patient.Address1;
                    pAddHIS.HISRegistration.ADDR2 = patient.Address2;
                    pAddHIS.HISRegistration.ADDR3 = patient.Address3;
                    pAddHIS.HISRegistration.ADDR4 = patient.Address4;
                    pAddHIS.HISRegistration.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                    pAddHIS.HISRegistration.EMAIL = patient.Email;
                    pAddHIS.HISRegistration.NATIONALITY = patient.Nationality;
                    pAddHIS.HISRegistration.CREATED_BY = env.UserID;
                    pAddHIS.HISRegistration.DOB = patient.DateOfBirth;
                    pAddHIS.HISRegistration.FNAME = patient.FirstName;
                    pAddHIS.HISRegistration.FNAME_ENG = patient.FirstName_ENG;
                    pAddHIS.HISRegistration.MNAME_ENG = patient.MiddleName_ENG;
                    pAddHIS.HISRegistration.GENDER = patient.Gender;
                    pAddHIS.HISRegistration.HN = patient.Reg_UID;
                    pAddHIS.HISRegistration.LNAME = patient.LastName;
                    pAddHIS.HISRegistration.LNAME_ENG = patient.LastName_ENG;
                    pAddHIS.HISRegistration.ORG_ID = env.OrgID;
                    pAddHIS.HISRegistration.PHONE1 = patient.Phone1;
                    pAddHIS.HISRegistration.PHONE2 = patient.Phone2;
                    pAddHIS.HISRegistration.PHONE3 = patient.Phone3;
                    pAddHIS.HISRegistration.SSN = patient.SocialNumber;
                    pAddHIS.HISRegistration.TITLE = patient.Title;
                    pAddHIS.HISRegistration.TITLE_ENG = patient.Title_ENG;
                    pAddHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    pAddHIS.Invoke();

                    regID = pAddHIS.HISRegistration.REG_ID;
                }
                else if (patient.DataFromLocal)
                {
                    ProcessUpdateHISRegistration pUpdateHIS = new ProcessUpdateHISRegistration();
                    pUpdateHIS.HISRegistration.ADDR1 = patient.Address1;
                    pUpdateHIS.HISRegistration.LAST_MODIFIED_BY = env.UserID;
                    pUpdateHIS.HISRegistration.DOB = patient.DateOfBirth;
                    pUpdateHIS.HISRegistration.FNAME = patient.FirstName;
                    pUpdateHIS.HISRegistration.FNAME_ENG = patient.FirstName_ENG;
                    pUpdateHIS.HISRegistration.GENDER = patient.Gender;
                    pUpdateHIS.HISRegistration.HN = patient.Reg_UID;
                    pUpdateHIS.HISRegistration.LNAME = patient.LastName;
                    pUpdateHIS.HISRegistration.LNAME_ENG = patient.LastName_ENG;
                    pUpdateHIS.HISRegistration.ORG_ID = env.OrgID;
                    pUpdateHIS.HISRegistration.PHONE1 = patient.Phone1;
                    pUpdateHIS.HISRegistration.SSN = patient.SocialNumber;
                    pUpdateHIS.HISRegistration.TITLE = patient.Title;
                    pUpdateHIS.HISRegistration.TITLE_ENG = patient.Title_ENG;
                    pUpdateHIS.HISRegistration.REG_ID = patient.Reg_ID;
                    pUpdateHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    pUpdateHIS.Invoke();
                    regID = patient.Reg_ID;
                }
                else
                {
                    ProcessAddHISRegistration pHIS = new ProcessAddHISRegistration(true);
                    pHIS.HISRegistration.ADDR1 = his.ADDR1;
                    pHIS.HISRegistration.CREATED_BY = env.UserID;
                    pHIS.HISRegistration.DOB = his.DOB;
                    pHIS.HISRegistration.FNAME = his.FNAME;
                    pHIS.HISRegistration.FNAME_ENG = his.FNAME_ENG;
                    pHIS.HISRegistration.GENDER = his.GENDER;
                    pHIS.HISRegistration.HN = his.HN;
                    pHIS.HISRegistration.LNAME = his.LNAME;
                    pHIS.HISRegistration.LNAME_ENG = his.LNAME_ENG;
                    pHIS.HISRegistration.ORG_ID = env.OrgID;
                    pHIS.HISRegistration.PHONE1 = his.PHONE1;
                    pHIS.HISRegistration.SSN = his.SSN;
                    pHIS.HISRegistration.TITLE = his.TITLE;
                    pHIS.HISRegistration.TITLE_ENG = his.TITLE_ENG;
                    pHIS.HISRegistration.LINK_DOWN = "Y";
                    pHIS.HISRegistration.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    pHIS.HISRegistration.IS_JOHNDOE = "N";
                    pHIS.Invoke();
                    regID = pHIS.HISRegistration.REG_ID;
                    patient.Reg_UID = his.HN;
                    item.HN = his.HN;
                }
                #endregion

                item.REG_ID = regID;
                patient.Reg_ID = regID;

                ProcessDeleteRISOrderdtl processDelete = new ProcessDeleteRISOrderdtl();
                processDelete.UseTransaction = tran;

                ProcessAddRISOrder processAdd = new ProcessAddRISOrder();
                processAdd.UseTransaction = tran;

                ProcessAddRISOrderdtl processAddDetails = new ProcessAddRISOrderdtl();
                processAddDetails.UseTransaction = tran;

                ProcessUpdateRISOrder processUpd = new ProcessUpdateRISOrder(true);
                processUpd.UseTransaction = tran;

                ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                processUpdate.UseTransaction = tran;

                ProcessAddHISRegistration processHis = new ProcessAddHISRegistration();
                processHis.UseTransaction = tran;

                ProcessUpdateHISRegistration processUpdateHis = new ProcessUpdateHISRegistration();
                processUpdateHis.UseTransaction = tran;

                updateScheduleStatus(tran);

                if (item.ORDER_ID == 0)
                {
                    IsSchedule = "Order";
                    #region Insert Master-Details Data
                    processAdd.RISOrder.REG_ID = patient.Reg_ID;
                    processAdd.RISOrder.HN = patient.Reg_UID;
                    processAdd.RISOrder.VISIT_NO = visitNumber;
                    processAdd.RISOrder.ADMISSION_NO = item.ADMISSION_NO;
                    processAdd.RISOrder.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RISOrder.SCHEDULE_ID = item.SCHEDULE_ID;
                    processAdd.RISOrder.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    processAdd.RISOrder.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
                    processAdd.RISOrder.REASON = item.REASON;
                    processAdd.RISOrder.DIAGNOSIS = item.DIAGNOSIS;
                    processAdd.RISOrder.ICD_ID = item.ICD_ID;
                    processAdd.RISOrder.ORG_ID = item.ORG_ID;
                    processAdd.RISOrder.CREATED_BY = item.CREATED_BY;
                    processAdd.RISOrder.ORDER_DT = item.ORDER_DT;
                    processAdd.RISOrder.SCHEDULE_ID = scheduleID;
                    processAdd.RISOrder.REF_DOC = item.REF_DOC;
                    processAdd.RISOrder.REF_UNIT = item.REF_UNIT;
                    processAdd.RISOrder.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RISOrder.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
                    processAdd.RISOrder.PAT_STATUS = item.PAT_STATUS;
                    processAdd.RISOrder.Lmp_DT = item.Lmp_DT;
                    processAdd.Invoke();
                    Item.ORDER_ID = processAdd.RISOrder.ORDER_ID;

                    foreach (DataRow dr in dtOrder.Rows)
                    {

                        processAddDetails.RISOrderdtl.ORDER_ID = processAdd.RISOrder.ORDER_ID;
                        processAddDetails.RISOrderdtl.EXAM_DT = item.ORDER_DT;
                        processAddDetails.RISOrderdtl.ORG_ID = item.ORG_ID;
                        processAddDetails.RISOrderdtl.CREATED_BY = item.CREATED_BY;
                        processAddDetails.RISOrderdtl.EST_START_TIME = dr["EST_START_TIME"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["EST_START_TIME"]);
                        processAddDetails.RISOrderdtl.QTY = Convert.ToInt32(dr["QTY"].ToString());
                        processAddDetails.RISOrderdtl.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
                        processAddDetails.RISOrderdtl.MODALITY_ID = (int)dr["MODALITY_ID"];
                        processAddDetails.RISOrderdtl.PRIORITY = dr["PRIORITY"].ToString(); ;
                        processAddDetails.RISOrderdtl.EXAM_ID = (int)dr["EXAM_ID"];
                        processAddDetails.RISOrderdtl.RATE = (decimal)dr["RATE"];
                        processAddDetails.RISOrderdtl.Clinic_type = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];
                        if (processAddDetails.RISOrderdtl.MODALITY_ID > 0)
                        {
                            processAddDetails.RISOrderdtl.ACCESSION_NO = getAccessionNo(processAddDetails.RISOrderdtl.MODALITY_ID);
                        }
                        else
                        {
                            processAddDetails.RISOrderdtl.MODALITY_ID = 86;
                            processAddDetails.RISOrderdtl.ACCESSION_NO = order.GenHN();
                        }
                        processAddDetails.RISOrderdtl.BV_VIEW = (int)dr["BPVIEW_ID"];
                        processAddDetails.RISOrderdtl.COMMENTS = dr["COMMENTS"].ToString();
                        processAddDetails.RISOrderdtl.HIS_SYNC = "N";// SendBilling(processAddDetails.RISOrderdtl.ACCESSION_NO);
                        processAddDetails.Invoke();

                        flag = true;
                        for (int i = 0; i < dtExam.Rows.Count; i++)
                        {
                            if (dtExam.Rows[i]["EXAM_ID"].ToString() == processAddDetails.RISOrderdtl.EXAM_ID.ToString())
                            {
                                if (dtExam.Rows[i]["SERVICE_TYPE"].ToString() != "1")
                                    flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            DataRow drDtt = dtt.NewRow();
                            for (int i = 0; i < dtOrder.Columns.Count; i++)
                                drDtt[i] = dr[i];
                            drDtt["ordflag"] = "NW";
                            drDtt["ACCESSION_NO"] = processAddDetails.RISOrderdtl.ACCESSION_NO;
                            drDtt["ORDER_ID"] = item.ORDER_ID;
                            dtt.Rows.Add(drDtt);
                        }
                        //SendBilling(processAddDetails.RISOrderdtl.ACCESSION_NO);

                    }

                    #endregion

                    #region Insert PAT_ICD

                    if (dtPatICD != null)
                    {
                        foreach (DataRow dr in dtPatICD.Rows)
                        {
                            ProcessAddRISPaticd processPatICD = new ProcessAddRISPaticd();
                            processPatICD.UseTransaction = tran;
                            processPatICD.RISPaticd.ACCESSION_NO = processAddDetails.RISOrderdtl.ACCESSION_NO;
                            processPatICD.RISPaticd.CREATED_BY = env.UserID;
                            processPatICD.RISPaticd.HN = patient.Reg_UID;
                            processPatICD.RISPaticd.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                            processPatICD.RISPaticd.ORDER_NO = processAdd.RISOrder.ORDER_ID;
                            processPatICD.RISPaticd.ORDER_RESULT_FLAG = "O";
                            processPatICD.RISPaticd.ORG_ID = env.OrgID;
                            processPatICD.Invoke();
                        }
                    }
                    #endregion

                    #region Billing.

                    #endregion
                }
                else if (item.ORDER_ID == -1)
                {
                    mode = "Schedule";
                    IsSchedule = "Schedule";
                    #region Insert Master-Details Data(Schedule)
                    processAdd.RISOrder.REG_ID = patient.Reg_ID;
                    processAdd.RISOrder.HN = patient.Reg_UID;
                    processAdd.RISOrder.VISIT_NO = visitNumber;
                    processAdd.RISOrder.ADMISSION_NO = item.ADMISSION_NO;
                    processAdd.RISOrder.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RISOrder.SCHEDULE_ID = item.SCHEDULE_ID;
                    processAdd.RISOrder.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    processAdd.RISOrder.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
                    processAdd.RISOrder.REASON = item.REASON;
                    processAdd.RISOrder.DIAGNOSIS = item.DIAGNOSIS;
                    processAdd.RISOrder.ICD_ID = item.ICD_ID;
                    processAdd.RISOrder.ORG_ID = item.ORG_ID;
                    processAdd.RISOrder.CREATED_BY = item.CREATED_BY;
                    processAdd.RISOrder.ORDER_DT = item.ORDER_DT;
                   
                    processAdd.RISOrder.REF_DOC = item.REF_DOC;
                    processAdd.RISOrder.REF_UNIT = item.REF_UNIT;
                    processAdd.RISOrder.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RISOrder.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
                    processAdd.RISOrder.PAT_STATUS = item.PAT_STATUS;
                    processAdd.RISOrder.Lmp_DT = item.Lmp_DT;
                    processAdd.Invoke();
                    Item.ORDER_ID = processAdd.RISOrder.ORDER_ID;

                    foreach (DataRow dr in dtOrder.Rows)
                    {

                        processAddDetails.RISOrderdtl.ORDER_ID = processAdd.RISOrder.ORDER_ID;
                        processAddDetails.RISOrderdtl.EXAM_DT = item.ORDER_DT;
                        processAddDetails.RISOrderdtl.ORG_ID = item.ORG_ID;
                        processAddDetails.RISOrderdtl.CREATED_BY = item.CREATED_BY;
                        processAddDetails.RISOrderdtl.EST_START_TIME = dr["APPOINT_DT"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["APPOINT_DT"]);
                        if (string.IsNullOrEmpty( dr["QTY"].ToString()))
                        {
                            processAddDetails.RISOrderdtl.QTY = 1;
                        }
                        else
                        {
                            processAddDetails.RISOrderdtl.QTY = (byte)dr["QTY"];
                        }
                        processAddDetails.RISOrderdtl.ASSIGNED_TO = dr["RAD_ID"].ToString() == string.Empty ? 0 : (int)dr["RAD_ID"];
                        processAddDetails.RISOrderdtl.MODALITY_ID = (int)dr["MODALITY_ID"];
                        processAddDetails.RISOrderdtl.PRIORITY = "R";
                        processAddDetails.RISOrderdtl.EXAM_ID = (int)dr["EXAM_ID"];
                        processAddDetails.RISOrderdtl.RATE = (decimal)dr["RATE"];
                        processAddDetails.RISOrderdtl.Clinic_type = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];
                        if (processAddDetails.RISOrderdtl.MODALITY_ID > 0)
                        {
                            processAddDetails.RISOrderdtl.ACCESSION_NO = getAccessionNo(processAddDetails.RISOrderdtl.MODALITY_ID);
                        }
                        else
                        {
                            processAddDetails.RISOrderdtl.MODALITY_ID = 86;
                            processAddDetails.RISOrderdtl.ACCESSION_NO = order.GenHN();
                        }
                        //processAddDetails.RISOrderdtl.BV_VIEW = (int)dr["BPVIEW_ID"];
                        processAddDetails.RISOrderdtl.COMMENTS = dr["COMMENTS"].ToString();
                        processAddDetails.RISOrderdtl.HIS_SYNC = "N";//SendBilling(processAddDetails.RISOrderdtl.ACCESSION_NO);
                        processAddDetails.Invoke();

                        flag = true;
                        for (int i = 0; i < dtExam.Rows.Count; i++)
                        {
                            if (dtExam.Rows[i]["EXAM_ID"].ToString() == processAddDetails.RISOrderdtl.EXAM_ID.ToString())
                            {
                                if (dtExam.Rows[i]["SERVICE_TYPE"].ToString() != "1")
                                    flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            //DataTable dttAcc = dtt.Clone();
                            dtt.Columns.Add("ACCESSION_NO", typeof(string));
                            dtt.Columns.Add("ORDER_ID", typeof(string));
                            dtt.Columns.Add("EXAM_UID", typeof(string));
                            dtt.Columns.Add("EXAM_NAME", typeof(string));
                            dtt.Columns.Add("PRIORITY", typeof(string));

                            DataRow drDtt = dtt.NewRow();
                            for (int i = 0; i < dtOrder.Columns.Count; i++)
                                drDtt[i] = dr[i];
                            drDtt["ordflag"] = "NW";
                            drDtt["ACCESSION_NO"] = processAddDetails.RISOrderdtl.ACCESSION_NO;
                            drDtt["ORDER_ID"] = item.ORDER_ID;
                            DataRow[] drXUID = order.dtExam.Select("EXAM_ID=" + dtOrder.Rows[0]["EXAM_ID"].ToString());
                            drDtt["EXAM_UID"] = drXUID[0]["EXAM_UID"];
                            drDtt["EXAM_NAME"] = drXUID[0]["EXAM_NAME"];
                            drDtt["PRIORITY"] = "R";
                            dtt.Rows.Add(drDtt);
                        }


                    }

                    #endregion

                    #region Insert PAT_ICD

                    if (dtPatICD != null)
                    {
                        foreach (DataRow dr in dtPatICD.Rows)
                        {
                            ProcessAddRISPaticd processPatICD = new ProcessAddRISPaticd();
                            processPatICD.UseTransaction = tran;
                            processPatICD.RISPaticd.ACCESSION_NO = processAddDetails.RISOrderdtl.ACCESSION_NO;
                            processPatICD.RISPaticd.CREATED_BY = env.UserID;
                            processPatICD.RISPaticd.HN = patient.Reg_UID;
                            processPatICD.RISPaticd.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                            processPatICD.RISPaticd.ORDER_NO = processAdd.RISOrder.ORDER_ID;
                            processPatICD.RISPaticd.ORDER_RESULT_FLAG = "O";
                            processPatICD.RISPaticd.ORG_ID = env.OrgID;
                            processPatICD.Invoke();
                        }
                    }
                    #endregion

                    #region Billing.

                    #endregion
                }
                else
                {
                    IsSchedule = "Other";
                    #region Update Master
                    ProcessGetRISPaticd processRISPatICD = new ProcessGetRISPaticd(item.ORDER_ID);
                    processRISPatICD.Invoke();
                    dttPatOri = processRISPatICD.Result.Tables[0];

                    processUpd.RISOrder.ORDER_ID = item.ORDER_ID;
                    processUpd.RISOrder.REG_ID = patient.Reg_ID;
                    processUpd.RISOrder.HN = patient.Reg_UID;
                    processUpd.RISOrder.VISIT_NO = visitNumber;
                    processUpd.RISOrder.ADMISSION_NO = item.ADMISSION_NO;
                    processUpd.RISOrder.ORDER_START_TIME = item.ORDER_START_TIME;
                    processUpd.RISOrder.SCHEDULE_ID = item.SCHEDULE_ID;
                    processUpd.RISOrder.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    processUpd.RISOrder.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
                    processUpd.RISOrder.REF_DOC = item.REF_DOC;
                    processUpd.RISOrder.REF_UNIT = item.REF_UNIT;
                    processUpd.RISOrder.REASON = item.REASON;
                    processUpd.RISOrder.DIAGNOSIS = item.DIAGNOSIS;
                    processUpd.RISOrder.ICD_ID = item.ICD_ID;
                    processUpd.RISOrder.ORG_ID = item.ORG_ID;
                    processUpd.RISOrder.CREATED_BY = item.CREATED_BY;
                    processUpd.RISOrder.ORDER_DT = item.ORDER_DT;
                    processUpd.RISOrder.LAST_MODIFIED_BY = item.LAST_MODIFIED_BY;
                    processUpd.RISOrder.ORDER_START_TIME = item.ORDER_START_TIME;
                    processUpd.RISOrder.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
                    processUpd.RISOrder.Lmp_DT = item.Lmp_DT;
                    processUpd.RISOrder.PAT_STATUS = item.PAT_STATUS;
                    processUpd.Invoke();
                    #endregion

                    #region Update Details
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        if (dr["ORDER_ID"].ToString() != string.Empty)
                        {

                            #region ปรังปรุง Record
                            processUpdate.RISOrderdtl.ORDER_ID = item.ORDER_ID;
                            processUpdate.RISOrderdtl.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                            processUpdate.RISOrderdtl.EXAM_DT = item.ORDER_DT;

                            if (dr["QTY"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.QTY = 0;
                            else
                                processUpdate.RISOrderdtl.QTY = Convert.ToInt32(dr["QTY"].ToString());


                            if (dr["BPVIEW_ID"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.BV_VIEW = 0;
                            else
                                processUpdate.RISOrderdtl.BV_VIEW = (int)dr["BPVIEW_ID"];

                            if (dr["Q_NO"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.Q_NO = 0;
                            else
                                processUpdate.RISOrderdtl.Q_NO = Convert.ToByte(dr["Q_NO"]);

                            if (dr["HL7_SENT"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.HL7_SENT = string.Empty;
                            else
                                processUpdate.RISOrderdtl.HL7_SENT = dr["HL7_SENT"].ToString();

                            if (dr["HL7_TEXT"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.HL7_TEXT = string.Empty;
                            else
                                processUpdate.RISOrderdtl.HL7_TEXT = dr["HL7_TEXT"].ToString();

                            if (dr["COMMENTS"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.COMMENTS = string.Empty;
                            else
                                processUpdate.RISOrderdtl.COMMENTS = dr["COMMENTS"].ToString();

                            if (dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null)
                                processUpdate.RISOrderdtl.Clinic_type = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];
                            else
                                processUpdate.RISOrderdtl.Clinic_type = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];

                            if (dr["IMAGE_CAPTURED_BY"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.IMAGE_CAPTURED_BY = 0;
                            else
                                processUpdate.RISOrderdtl.IMAGE_CAPTURED_BY = Convert.ToInt32(dr["IMAGE_CAPTURED_BY"]);

                            if (dr["IMAGE_CAPTURED_ON"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.IMAGE_CAPTURED_ON = DateTime.MinValue;
                            else
                                processUpdate.RISOrderdtl.IMAGE_CAPTURED_ON = Convert.ToDateTime(dr["IMAGE_CAPTURED_ON"]);

                            if (dr["QA_BY"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.QA_BY = 0;
                            else
                                processUpdate.RISOrderdtl.QA_BY = Convert.ToInt32(dr["QA_BY"]);

                            if (dr["QA_ON"].ToString() == string.Empty)
                                processUpdate.RISOrderdtl.QA_ON = DateTime.MinValue;
                            else
                                processUpdate.RISOrderdtl.QA_ON = Convert.ToDateTime(dr["QA_ON"]);


                            if (dr["ACCESSION_NO"].ToString() == string.Empty)
                            {

                                //processAddDetails.RISOrderdtl.ACCESSION_NO = GenAccessionNo(processAddDetails.RISOrderdtl.EXAM_DT, processAddDetails.RISOrderdtl.MODALITY_ID.ToString());
                                processUpdate.RISOrderdtl.MODALITY_ID = (int)dr["MODALITY_ID"];
                                if (processUpdate.RISOrderdtl.MODALITY_ID > 0)
                                {
                                    processUpdate.RISOrderdtl.ACCESSION_NO = getAccessionNo(processUpdate.RISOrderdtl.MODALITY_ID);
                                }
                                else
                                {
                                    processUpdate.RISOrderdtl.MODALITY_ID = 86;
                                    processUpdate.RISOrderdtl.ACCESSION_NO = order.GenHN();

                                }
                            }
                            else
                                processUpdate.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();

                            processUpdate.RISOrderdtl.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
                            processUpdate.RISOrderdtl.MODALITY_ID = (int)dr["MODALITY_ID"];
                            processUpdate.RISOrderdtl.PRIORITY = dr["PRIORITY"].ToString();
                            processUpdate.RISOrderdtl.EXAM_ID = (int)dr["EXAM_ID"];
                            processUpdate.RISOrderdtl.RATE = (decimal)dr["RATE"];
                            processUpdate.RISOrderdtl.OLD_EXAM_ID = dr["ORIGIN_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["ORIGIN_ID"]);
                            processUpdate.RISOrderdtl.IS_DELETED = dr["IS_DELETED"].ToString();
                            processUpdate.RISOrderdtl.ORG_ID = item.ORG_ID;
                            processUpdate.RISOrderdtl.LAST_MODIFIED_BY = env.UserID;
                            processUpdate.Invoke();
                            #endregion

                            #region สร้าง Table สำหรับสร้าง HL7 Message
                            flag = true;
                            for (int i = 0; i < dtExam.Rows.Count; i++)
                            {
                                if (dtExam.Rows[i]["EXAM_ID"].ToString() == processUpdate.RISOrderdtl.EXAM_ID.ToString())
                                {
                                    if (dtExam.Rows[i]["SERVICE_TYPE"].ToString() != "1")
                                        flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {

                                DataRow drDtt = dtt.NewRow();
                                for (int i = 0; i < dtOrder.Columns.Count; i++)
                                    drDtt[i] = dr[i];
                                if (processUpdate.RISOrderdtl.IS_DELETED == "Y")
                                    drDtt["ordflag"] = "CA";
                                else
                                    drDtt["ordflag"] = "XO";
                                drDtt["ORDER_ID"] = item.ORDER_ID;
                                dtt.Rows.Add(drDtt);
                            }
                            #endregion

                            accNo.Add(processUpdate.RISOrderdtl.ACCESSION_NO);
                        }
                        else
                        {

                            #region กรณีแก้ไขแล้วเพิ่ม Record
                            processAddDetails.RISOrderdtl.ORDER_ID = item.ORDER_ID;
                            processAddDetails.RISOrderdtl.EXAM_DT = item.ORDER_DT;
                            processAddDetails.RISOrderdtl.ORG_ID = item.ORG_ID;
                            processAddDetails.RISOrderdtl.CREATED_BY = item.CREATED_BY;
                            processAddDetails.RISOrderdtl.EST_START_TIME = dr["EST_START_TIME"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["EST_START_TIME"]);
                            processAddDetails.RISOrderdtl.QTY = Convert.ToInt32(dr["QTY"].ToString());

                            processAddDetails.RISOrderdtl.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
                            processAddDetails.RISOrderdtl.MODALITY_ID = (int)dr["MODALITY_ID"];
                            processAddDetails.RISOrderdtl.PRIORITY = dr["PRIORITY"].ToString();

                            processAddDetails.RISOrderdtl.EXAM_ID = (int)dr["EXAM_ID"];
                            processAddDetails.RISOrderdtl.RATE = (decimal)dr["RATE"];
                            processAddDetails.RISOrderdtl.Clinic_type = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];

                            if (processAddDetails.RISOrderdtl.MODALITY_ID > 0)
                            {
                                processAddDetails.RISOrderdtl.ACCESSION_NO = getAccessionNo(processAddDetails.RISOrderdtl.MODALITY_ID);
                            }
                            else
                            {
                                processAddDetails.RISOrderdtl.MODALITY_ID = 86;
                                processAddDetails.RISOrderdtl.ACCESSION_NO = order.GenHN();
                            }
                            processAddDetails.RISOrderdtl.CREATED_BY = env.UserID;

                            processAddDetails.RISOrderdtl.BV_VIEW = (int)dr["BPVIEW_ID"];

                            processAddDetails.Invoke();
                            #endregion

                            #region สร้าง Table สำหรับสร้าง HL7 Message
                            flag = true;
                            for (int i = 0; i < dtExam.Rows.Count; i++)
                            {
                                if (dtExam.Rows[i]["EXAM_ID"].ToString() == processAddDetails.RISOrderdtl.EXAM_ID.ToString())
                                {
                                    if (dtExam.Rows[i]["SERVICE_TYPE"].ToString() != "1")
                                        flag = false;
                                    break;
                                }
                            }
                            if (flag)
                            {

                                DataRow drDtt = dtt.NewRow();
                                for (int i = 0; i < dtOrder.Columns.Count; i++)
                                    drDtt[i] = dr[i];
                                drDtt["ordflag"] = "NW";
                                drDtt["ORDER_ID"] = Item.ORDER_ID;
                                drDtt["ACCESSION_NO"] = processAddDetails.RISOrderdtl.ACCESSION_NO;
                                dtt.Rows.Add(drDtt);
                            }
                            #endregion

                        }
                    }
                    #endregion

                    #region Update PAT_ICD
                    System.Collections.ArrayList listID = new System.Collections.ArrayList();
                    if (dtPatICD != null)
                    {
                        foreach (DataRow dr in dtPatICD.Rows)
                        {
                            if (dr["PAT_ICD_ID"].ToString().Trim() == string.Empty)
                            {
                                ProcessAddRISPaticd processPatICD = new ProcessAddRISPaticd();
                                processPatICD.UseTransaction = tran;
                                processPatICD.RISPaticd.ACCESSION_NO = processAddDetails.RISOrderdtl.ACCESSION_NO;
                                processPatICD.RISPaticd.CREATED_BY = env.UserID;
                                processPatICD.RISPaticd.HN = patient.Reg_UID;
                                processPatICD.RISPaticd.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                                processPatICD.RISPaticd.ORDER_NO = item.ORDER_ID;
                                processPatICD.RISPaticd.ORDER_RESULT_FLAG = "O";
                                processPatICD.RISPaticd.ORG_ID = env.OrgID;
                                processPatICD.Invoke();
                            }
                            else
                            {
                                //update
                                listID.Add(dr["PAT_ICD_ID"].ToString());
                                ProcessUpdateRISPaticd processUpdatePAT = new ProcessUpdateRISPaticd();
                                processUpdatePAT.UseTransaction = tran;
                                processUpdatePAT.RISPaticd.ACCESSION_NO = processUpdate.RISOrderdtl.ACCESSION_NO;
                                processUpdatePAT.RISPaticd.CREATED_BY = env.UserID;
                                processUpdatePAT.RISPaticd.HN = patient.Reg_UID;
                                processUpdatePAT.RISPaticd.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                                processUpdatePAT.RISPaticd.ORDER_NO = item.ORDER_ID;
                                processUpdatePAT.RISPaticd.ORDER_RESULT_FLAG = "O";
                                processUpdatePAT.RISPaticd.ORG_ID = env.OrgID;
                                processUpdatePAT.Invoke();
                            }
                        }
                        foreach (DataRow dr in dttPatOri.Rows)
                        {
                            if (listID.IndexOf(dr["PAT_ICD_ID"].ToString()) == -1)
                            {
                                ProcessDeleteRISPaticd processDelPAT = new ProcessDeleteRISPaticd();
                                processDelPAT.UseTransaction = tran;
                                processDelPAT.RISPaticd.PAT_ICD_ID = (int)dr["PAT_ICD_ID"];
                                processDelPAT.Invoke();
                            }
                        }
                    }
                    #endregion

                    Item.ORDER_ID = item.ORDER_ID;
                    mode = "Edit";

                    #region Billing.

                    #endregion
                }

                #region HL7 and Order Images
                DataTable dttSendToPacs = null;
                if (dtt.Rows.Count > 0)
                {
                    GenerateOrderMessage genHl7 = new GenerateOrderMessage();
                    if (patient.DateOfBirth == DateTime.MinValue || patient.FirstName == "" || patient.FirstName == null || patient.DateOfBirth.Year==DateTime.Now.Year)
                    {
                        patient.DateOfBirth = his.DOB;

                        patient.FirstName = his.FNAME;
                        patient.MiddleName = his.MNAME;
                        patient.LastName = his.LNAME;

                        patient.FirstName_ENG = his.FNAME_ENG;
                        patient.MiddleName_ENG = his.MNAME_ENG;
                        patient.LastName_ENG = his.LNAME_ENG;

                        patient.Gender = his.GENDER;
                        patient.Age = his.AGE;

                        #region Replace whitespace

                        //patient.FirstName = Regex.Replace(patient.FirstName.Replace("  ", " ");
                        //patient.MiddleName = patient.MiddleName.Replace("  ", " ");
                        //patient.LastName = patient.LastName.Replace("  ", " ");

                        #endregion
                    }
                    else
                    {
                        patient.Gender = his.GENDER;
                        patient.Age = his.AGE;

                        #region Replace whitespace

                        //patient.FirstName = patient.FirstName.Replace("  ", " ");
                        //patient.MiddleName = patient.MiddleName.Replace("  ", " ");
                        //patient.LastName = patient.LastName.Replace("  ", " ");

                        #endregion
                    }

                    dttSendToPacs = genHl7.HL7Message(patient, dtt);

                    processUpdate = new ProcessUpdateRISOrderdtl();
                    processUpdate.UseTransaction = tran;
                    processUpdate.UpdateHL7(dttSendToPacs);                                                   
                }
                tran.Commit();
                if (dttSendToPacs != null)
                {
                    if (dttSendToPacs.Rows.Count > 0)
                    {
                        //SendToPacs send = new SendToPacs();
                        //flag = send.SendMSGToPacs(dttSendToPacs, "ORM");

                        string hn1 = "";
                        string hn2 = "";

                        if (patient.Reg_UID != null)
                            hn1 = patient.Reg_UID;
                        else if (his.HN != null)
                            hn2 = his.HN;
                        else
                        {
                            MessageBox.Show("Can not send to pacs : something wrong with PATIENT or HIS variables.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                        if (hn1.StartsWith("M",StringComparison.CurrentCultureIgnoreCase) || hn2.StartsWith("M",StringComparison.CurrentCultureIgnoreCase))
                        {
                            SendToPacs send = new SendToPacs();
                            flag = send.SendMSGToPacs_StartWithM(dttSendToPacs, "ORM");
                            pacnum = "1";
                        }
                        else if (hn1.StartsWith("L", StringComparison.CurrentCultureIgnoreCase) || hn2.StartsWith("L", StringComparison.CurrentCultureIgnoreCase))
                        {
                            SendToPacs send = new SendToPacs();
                            flag = send.SendMSGToPacs_StartWithL(dttSendToPacs, "ORM");
                            pacnum = "2";
                        }
                        else
                        {
                            SendToPacs send = new SendToPacs();
                            flag = send.SendMSGToPacs(dttSendToPacs, "ORM");
                            //MessageBox.Show("HN not starting with 'M' or 'L' letter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }

                if (!flag)
                {
                    MessageBox.Show("Order No : " + item.ORDER_ID + " not send to pacs" + pacnum, "Not Send", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                try
                {
                    RIS.Operational.Scanner.SaveScannedImage save = null;
                    if (mode == "New")
                        save = new RIS.Operational.Scanner.SaveScannedImage(patient.Reg_UID, item.ORDER_ID);
                    else
                        save = new RIS.Operational.Scanner.SaveScannedImage(patient.Reg_UID, item.ORDER_ID, dtOrderImage);
                    new GBLEnvVariable().CountImg = "";
                }
                catch { }
                try
                {
                    
                    //SendBilling(mode);
                }
                catch { }
                #endregion

            }
            catch (Exception ex)
            {
                tran.Rollback();
                retFlag = false;//MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }
            return retFlag;
        }
       
        private string genNewMessageBill(DataRow dr)
        {
            string str = string.Empty;

            HIS_Patient BillHis = new HIS_Patient();
            string strAN = "";
            string strMstype = "";
            string strISEQ = "";
            string strClinic = "";
            string strInSu = "";
            string strAcc = dr["ACCESSION_NO"].ToString();
            int intQTY = 1;
            decimal Amt = 0;

            DataSet dsIPD = new DataSet();
            try
            {
                //dsIPD = BillHis.Get_ipd_detail(patient.Reg_UID);
            }
            catch
            {
                return string.Empty;
            }

            for (int ai = 0; ai < dsIPD.Tables[0].Rows.Count; ai++)
            {
                strAN = dsIPD.Tables[0].Rows[ai]["an"].ToString();
                if (strAN != "")
                {
                    strMstype = "I";
                }
                else
                {
                    strMstype = "O";
                }
                strISEQ = dsIPD.Tables[0].Rows[ai]["iseq"].ToString();
            }
            if (string.IsNullOrEmpty(strISEQ)) strISEQ = "1";
            if (string.IsNullOrEmpty(strAN)) strAN = " ";
            DataRow[] drBExam = order.Ris_Exam().Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
            DataRow[] drBEmp = order.His_Doctor().Select("EMP_ID=" + item.REF_DOC.ToString());
            DataRow[] drBUnit = order.His_Department().Select("UNIT_ID=" + item.REF_UNIT.ToString());
            DataRow[] drBClinic = order.RIS_ClinicType().Select("CLINIC_TYPE_ID=" + dr["CLINIC_TYPE"].ToString());
            if (item.INSURANCE_TYPE_ID != 0)
            {
                DataRow[] drBIn = order.Ris_InsuranceType().Select("INSURANCE_TYPE_ID=" + item.INSURANCE_TYPE_ID.ToString());
                strInSu = drBIn[0]["INSURANCE_TYPE_UID"].ToString();
            }
            else
            {
                strInSu = " ";
            }

            if (IsSchedule == "Order")
            {
                intQTY = Convert.ToInt32(dr["QTY"]);
            }
            else if (IsSchedule == "Schedule")
            {
                intQTY = 1;
            }
            strClinic = dr["CLINIC_TYPE"].ToString() == "1" ? "R" : "S";
            decimal rate = Convert.ToDecimal(dr["RATE"].ToString());
            Amt = rate * intQTY;
            str = "#" + " " + "#" + patient.Reg_UID + "#" + strAcc + "#"
                            + strAN + "#" + strISEQ + "#" + drBUnit[0]["UNIT_UID"].ToString() + "#"
                                + item.ORDER_DT.ToString("dd/MM") + "/" + item.ORDER_DT.Year + "#" + "C" + "#" + "3" + "#" + drBExam[0]["EXAM_UID"].ToString() + "#"
                                     + intQTY.ToString() + "#" + rate.ToString("#0.0") + "#" + Amt.ToString("#.0") + "#"
                                        + drBEmp[0]["EMP_UID"].ToString() + "# # # # #" + item.ORDER_DT.ToString("dd/MM") + "/" + item.ORDER_DT.Year + "#" + item.ORDER_DT.ToString("hh:mm") + "#"
                                            + strMstype + "#" + strClinic + "#" + "3" + "#" + strInSu + "#" + "RD-0101" + "#" + "0" + "#" + env.UserUID + "#";
            return str;
        }
        private void SendBilling(string mode) {
            HIS_Patient BillHis = new HIS_Patient();
            ProcessUpdateRISOrderdtl dtl = new ProcessUpdateRISOrderdtl();
            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl('3', item.ORDER_ID, 0);
            process.Invoke();
            DataTable dtt = process.Result.Tables[0].Copy();
            if (mode == "Edit")
            {
                #region Update Billing till 11/06/2009
                //foreach (string s in accNo)
                //{
                //    bool flag = true;
                //    foreach (DataRow dr in dtt.Rows)
                //        if (dr["ACCESSION_NO"].ToString().Trim() == s)
                //        {
                //            flag = false;
                //            break;
                //        }
                //    if (flag)
                //    {
                //        BillHis.Cancel_Billing(patient.Reg_UID, s, " ", " ");
                //    }
                //}
                //foreach (DataRow dr in dtt.Rows)
                //{
                //    bool flag = false;
                //    string str = string.Empty;
                //    if (accNo.IndexOf(dr["ACCESSION_NO"].ToString()) > -1)
                //    {
                //        str = BillHis.Cancel_Billing(patient.Reg_UID, dr["ACCESSION_NO"].ToString().Trim(), " ", " ");
                //        if (str.Trim() == "Success in Cancel_Billing")
                //        {
                //            str = genNewMessageBill(dr);
                //            if (str.Trim() == "Success in Cancel_Billing")
                //                flag = true;
                //        }
                //    }
                //    else
                //    {
                //        str = genNewMessageBill(dr);
                //        if (str.Trim() == "Success in Cancel_Billing")
                //            flag = true;
                //    }
                //    dtl.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                //    dtl.RISOrderdtl.HIS_SYNC = flag ? "Y" : "N";
                //    dtl.RISOrderdtl.HIS_ACK = str;
                //    dtl.UpdateSend();
                //}
                #endregion

                #region Update Billing.
                foreach (string s in accNo)
                {
                    bool flag = true;
                    foreach (DataRow dr in dtt.Rows)
                        if (dr["ACCESSION_NO"].ToString().Trim() == s)
                        {
                            flag = false;
                            break;
                        }
                    if (flag)
                    {
                        //BillHis.Cancel_Billing(patient.Reg_UID, s, " ", " ");
                    }
                }
                foreach (DataRow dr in dtt.Rows)
                {
                    bool flag = false;
                    string str = string.Empty;
                    if (accNo.IndexOf(dr["ACCESSION_NO"].ToString()) > -1)
                    {
                        //str = BillHis.Cancel_Billing(patient.Reg_UID, dr["ACCESSION_NO"].ToString().Trim(), " ", " ");
                        //if (str.Trim() == "Success in Cancel_Billing")
                        //{
                        //    str = genNewMessageBill(dr);
                        //    str = BillHis.Set_Billing(str);
                        //    if (str.Trim() == "Success in Set_Billing")
                        //        flag = true;
                        //}
                    }
                    else
                    {
                        //str = genNewMessageBill(dr);
                        //str = BillHis.Set_Billing(str);
                        //if (str.Trim() == "Success in Set_Billing")
                        //    flag = true;
                    }
                    dtl.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                    dtl.RISOrderdtl.HIS_SYNC = flag ? "Y" : "N";
                    dtl.RISOrderdtl.HIS_ACK = str;
                    dtl.UpdateSend();
                }
                #endregion
            }
            else{
                #region Insert Billing.
                foreach (DataRow dr in dtt.Rows)
                {
                    bool flag = false;
                    string str = genNewMessageBill(dr);
                    if (string.IsNullOrEmpty(str)) continue;
                    try
                    {

                        //str = BillHis.Set_Billing(str);
                        //flag = true;
                    }
                    catch (Exception ex)
                    {

                    }
                    if (flag)
                    {

                        dtl.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                        if (str == "Success in Set_Billing")
                            dtl.RISOrderdtl.HIS_SYNC = "Y";
                        else
                            dtl.RISOrderdtl.HIS_SYNC = "N";
                        dtl.RISOrderdtl.HIS_ACK = str;
                        dtl.UpdateSend();
                    }
                } 
                #endregion
            }
        }
    }
    

}
