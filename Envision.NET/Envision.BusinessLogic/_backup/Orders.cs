using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using System.Linq;
using System.Data.Linq;


using Envision.Common;
using Envision.Common.Linq;

using Envision.DataAccess.Select;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;

using Envision.Operational.PACS;
using Miracle.HL7.ORM;
using Miracle.Scanner;
namespace Envision.BusinessLogic
{
    public class OrderManager
    {
        private List<Order> myArray;

        public OrderManager()
        {
            myArray = new List<Order>();
        }
        public OrderManager(Order order)
        {
            myArray = new List<Order>();
            myArray.Add(order);
        }

        public Order this[int index]
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
        public void Add(Order item)
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

    public class Order 
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

        private GBLEnvVariable env = new GBLEnvVariable();
        private RIS_ORDER item;
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
        private List<string> _accNo = new List<string>();
        private List<string> _accNo_Edit = new List<string>();
        public List<string> AccessionFail_List
        {
            get
            {
                return _accNo;
            }
        }
        private HIS_REGISTRATION his;
        private string xray_no;

        private bool isXrayReq;
        private int xrayReq;

        //public int Enc_ID = 0;
        //public string Enc_Type = "OTH";

        FinancialBilling fnBill = new FinancialBilling();

        public Order()
        {
            item = new RIS_ORDER();
            item.SCHEDULE_ID = 0;
            patient = new Patient();
            his = new HIS_REGISTRATION();
            RefreshData();
            initBaseData();
            initOrderData();
        }
        public Order(string HN)
        {
            patient = new Patient(HN);
            item = new RIS_ORDER();
            item.REF_UNIT = patient.REF_UNIT;
            item.REF_DOC = patient.REF_DOC;
            his = new HIS_REGISTRATION();
            RefreshData();
            initBaseData();
            initOrderData();
        }
        public Order(string HN, bool GetDataFromLocal)
        {
            item = new RIS_ORDER();
            his = new HIS_REGISTRATION();
            patient = new Patient(HN, GetDataFromLocal);
            item.REF_UNIT = patient.REF_UNIT;
            item.REF_DOC = patient.REF_DOC;
            RefreshData();
            initBaseData();
            initOrderData();
        }
        public Order(int Order_ID)
        {
            item = new RIS_ORDER();
            his = new HIS_REGISTRATION();
            patient = new Patient();
            item.ORDER_ID = Order_ID;
            RefreshData();
            initBaseData();
            initOrderData();
        }

        public Order(int ReqNo, bool PreOrder)
        {
            if (PreOrder)
            {
                item = new RIS_ORDER();
                his = new HIS_REGISTRATION();
                patient = new Patient();
                RefreshData();
                initBaseData();
                //initDataFromXrayREQ(ReqNo);
            }
            else
            {
                item = new RIS_ORDER();
                his = new HIS_REGISTRATION();
                patient = new Patient();
                item.ORDER_ID = ReqNo;
                RefreshData();
                initBaseData();
                initOrderData();
            }
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
            string MOD = "HN";
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
                processGBL.GBL_SEQUENCE.Seq_Name = MOD;
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
            dtPatStatus = dtClinicType = null;
            RISBaseData.RIS_ClinicType();
            _isRowDefalutClinic = RISBaseData.DefaultClinicType;
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
        public HIS_REGISTRATION His_Registratiion
        {
            set
            {
                his = new HIS_REGISTRATION();
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
        public RIS_ORDER Item
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
        public DataTable Ris_InsuranceType()
        {
            ProcessGetRISInsurancetype getData = new ProcessGetRISInsurancetype();
            getData.Invoke();
            return getData.Result.Tables[0];
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

            try
            {
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
            catch { }
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
                    {
                        item.INSURANCE_TYPE_ID = 0;
                        patient.InsuranceID = 0;
                    }
                    else
                    {
                        item.INSURANCE_TYPE_ID = patient.InsuranceID= Convert.ToInt32(dr["INSURANCE_TYPE_ID"]);
                        
                    }

                    if (dr["PAT_STATUS"].ToString().Trim() == string.Empty)
                        item.PAT_STATUS = string.Empty;
                    else
                        item.PAT_STATUS = dr["PAT_STATUS"].ToString();
                    patient.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    patient.REF_DOC  = patient.REF_DOC==null ? 0 : (int) item.REF_DOC;
                    patient.REF_UNIT = item.REF_UNIT == null ? 0 : (int)item.REF_UNIT;
                    if (dr["LMP_DT"].ToString() != null)
                        if (dr["LMP_DT"].ToString().Trim() != string.Empty)
                            item.LMP_DT = Convert.ToDateTime(dr["LMP_DT"]);

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
            if (dtExam == null)
                dtExam = RISBaseData.Ris_Exam();
            ProcessGetRISSchedule schedule = new ProcessGetRISSchedule(scheduleID);
            schedule.Invoke();
            DataTable dtt = schedule.Result.Tables[0];
            item.ORDER_DT = Convert.ToDateTime(schedule.Result.Tables[0].Rows[0]["SCHEDULE_DT"]);
            item.REF_DOC_INSTRUCTION = schedule.Result.Tables[0].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            item.CLINICAL_INSTRUCTION = schedule.Result.Tables[0].Rows[0]["CLINICAL_INSTRUCTION"].ToString();
            item.REASON = schedule.Result.Tables[0].Rows[0]["REASON"].ToString();
            item.DIAGNOSIS = schedule.Result.Tables[0].Rows[0]["DIAGNOSIS"].ToString();
            item.ICD_ID = schedule.Result.Tables[0].Rows[0]["DIAGNOSIS"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["DIAGNOSIS"]);
            item.ORG_ID = schedule.Result.Tables[0].Rows[0]["ORG_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["ORG_ID"]);
            item.REF_UNIT = schedule.Result.Tables[0].Rows[0]["REF_UNIT"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["REF_UNIT"]);
            item.REF_DOC = schedule.Result.Tables[0].Rows[0]["REF_DOC"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(schedule.Result.Tables[0].Rows[0]["REF_DOC"]);
            dtt = schedule.Result.Tables[1];
            DataTable dt = dtOrder.Clone();
            DataRow drOrder;
            foreach (DataRow dr in dtt.Rows)
            {
                drOrder = dt.NewRow();
                drOrder["EXAM_ID"] = dr["EXAM_ID"];
                DataRow[] drExams = dtExam.Select("EXAM_ID=" + drOrder["EXAM_ID"].ToString());
                drOrder["EXAM_UID"] = drExams[0]["EXAM_UID"];
                drOrder["EXAM_NAME"] = drExams[0]["EXAM_NAME"];
                drOrder["RATE"] = dr["RATE"];
                drOrder["SPECIAL_RATE"] = drExams[0]["SPECIAL_RATE"];
                drOrder["ACCESSION_NO"] = "wait process";
                drOrder["MODALITY_ID"] = schedule.Result.Tables[0].Rows[0]["MODALITY_ID"];
                drOrder["EXAM_DT"] = schedule.Result.Tables[0].Rows[0]["SCHEDULE_DT"];
                drOrder["QTY"] = dr["QTY"];
                drOrder["ASSIGNED_TO"] = dr["EMP_ID"];
                drOrder["PRIORITY"] = "R";
                drOrder["BPVIEW_ID"] = 5;
                drOrder["IS_DELETED"] = "N";
                drOrder["CLINIC_TYPE"] = schedule.Result.Tables[0].Rows[0]["CLINIC_TYPE_ID"];
                drOrder["PREPARATION_ID"] = dr["PREPATION_ID"];
                drOrder["colDelete"] = "Delete";
                dt.Rows.Add(drOrder);
            } 
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

        }
        private void getOrderImage()
        {
            if (item.SCHEDULE_ID == null)
                item.SCHEDULE_ID = 0;
            ProcessGetRISOrderimages process = new ProcessGetRISOrderimages();
            process.RIS_ORDERIMAGE.ORDER_ID = item.ORDER_ID;
            process.RIS_ORDERIMAGE.SCHEDULE_ID = item.SCHEDULE_ID;
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
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule(patient.Reg_UID);
                schedule.RIS_SCHEDULE.REG_ID = 0;
                schedule.RIS_SCHEDULE.HN = patient.Reg_UID;
                schedule.RIS_SCHEDULE.START_DATETIME = DateTime.Today;
                schedule.Invoke();

                dtSchedule = new DataTable();
                dtSchedule = schedule.Result.Tables[0].Copy();
                scheduleID = 0;

            }
            catch (Exception ex) { }
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

        private void setTreeBySchedule()
        {
            try
            {
                ProcessGetRISSchedule schedule = new ProcessGetRISSchedule();
                schedule.RIS_SCHEDULE.REG_ID = 0;
                schedule.RIS_SCHEDULE.HN = patient == null ? string.Empty : patient.Reg_UID;
                schedule.RIS_SCHEDULE.START_DATETIME = DateTime.Today;
                schedule.Invoke();
                if (schedule.Result != null)
                {
                    foreach (DataRow dr in schedule.Result.Tables[0].Rows)
                    {
                        DataRow drData = dsPrevOrder.Tables["Masters"].NewRow();
                        drData["ID"] = dr["SCHEDULE_ID"];
                        drData["Caption"] = "Schedule No: " + dr["SCHEDULE_ID"];
                        drData["DateTime"] = dr["SCHEDULE_DT"];
                        drData["Level"] = 1;
                        //drData["SPECIAL_CLINIC"] = dr["SPECIAL_CLINIC"];
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
                    drData["Caption"] = "Xray No: " + dr["XRAYNO"];
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

        private void updateScheduleStatus(DbTransaction tran)
        {
            if (scheduleID > 0)
            {
                ProcessUpdateRISSchedule process = new ProcessUpdateRISSchedule(scheduleID);
                process.Transaction = tran;
                process.RIS_SCHEDULE.SCHEDULE_STATUS = 'O';
                process.Invoke();
            }
        }
        
        public bool Invoke()
        {
            bool retFlag = true;
            bool flag = true;
            bool anonymous = false;
            DbTransaction tran = null;
            DbConnection con = null;
            DataTable dtt = dtOrder.Clone();
            dtt.Columns.Add("ordflag", typeof(string));

            DataTable dttPatOri;
            string mode = "New";
            xray_no = string.Empty;
            try
            {
                DataAccess.DataAccessBase db = new Envision.DataAccess.DataAccessBase();
                con = db.Connection();
                con.Open();
                tran = con.BeginTransaction();

                #region เพิ่ม ปรังปรุง ข้อมูล Patient
                int regID = 0;
                if (patient.LinkDown == false && patient.DataFromHIS)
                {
                    ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
                    pAddHIS.HIS_REGISTRATION.ADDR1 = patient.Address1;
                    pAddHIS.HIS_REGISTRATION.ADDR2 = patient.Address2;
                    pAddHIS.HIS_REGISTRATION.ADDR3 = patient.Address3;
                    pAddHIS.HIS_REGISTRATION.ADDR4 = patient.Address4;
                    pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = patient.Em_Contact_Person;
                    pAddHIS.HIS_REGISTRATION.EMAIL = patient.Email;
                    pAddHIS.HIS_REGISTRATION.NATIONALITY = patient.Nationality;
                    pAddHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                    pAddHIS.HIS_REGISTRATION.DOB = patient.DateOfBirth;
                    pAddHIS.HIS_REGISTRATION.FNAME = patient.FirstName;
                    pAddHIS.HIS_REGISTRATION.FNAME_ENG = patient.FirstName_ENG;
                    pAddHIS.HIS_REGISTRATION.MNAME_ENG = patient.MiddleName_ENG;
                    if(patient.Gender!=null)
                        pAddHIS.HIS_REGISTRATION.GENDER = Convert.ToChar(patient.Gender);
                    pAddHIS.HIS_REGISTRATION.HN = patient.Reg_UID;
                    pAddHIS.HIS_REGISTRATION.LNAME = patient.LastName;
                    pAddHIS.HIS_REGISTRATION.LNAME_ENG = patient.LastName_ENG;
                    pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                    pAddHIS.HIS_REGISTRATION.PHONE1 = patient.Phone1;
                    pAddHIS.HIS_REGISTRATION.PHONE2 = patient.Phone2;
                    pAddHIS.HIS_REGISTRATION.PHONE3 = patient.Phone3;
                    pAddHIS.HIS_REGISTRATION.SSN = patient.SocialNumber;
                    pAddHIS.HIS_REGISTRATION.TITLE = patient.Title;
                    pAddHIS.HIS_REGISTRATION.TITLE_ENG = patient.Title_ENG;
                    pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    if (patient.DateOfBirth == DateTime.MinValue)
                        anonymous = true;
                    if (patient.FirstName == "Anonymous")
                        anonymous = true;
                    if (patient.LastName == "Anonymous")
                        anonymous = true;
                    if (patient.Reg_UID.Length > 7)
                        anonymous = true;
                    if (anonymous)
                        pAddHIS.HIS_REGISTRATION.IS_JOHNDOE = 'Y';
                    else
                        pAddHIS.HIS_REGISTRATION.IS_JOHNDOE = 'N';

                    pAddHIS.Invoke();

                    regID = pAddHIS.HIS_REGISTRATION.REG_ID;
                }
                else if (patient.DataFromLocal)
                {
                    ProcessUpdateHISRegistration pUpdateHIS = new ProcessUpdateHISRegistration();
                    pUpdateHIS.HIS_REGISTRATION.ADDR1 = patient.Address1;
                    pUpdateHIS.HIS_REGISTRATION.LAST_MODIFIED_BY = env.UserID;
                    pUpdateHIS.HIS_REGISTRATION.DOB = patient.DateOfBirth;
                    pUpdateHIS.HIS_REGISTRATION.FNAME = patient.FirstName;
                    pUpdateHIS.HIS_REGISTRATION.FNAME_ENG = patient.FirstName_ENG;
                    if (patient.Gender != null)
                        pUpdateHIS.HIS_REGISTRATION.GENDER = Convert.ToChar(patient.Gender);
                    pUpdateHIS.HIS_REGISTRATION.HN = patient.Reg_UID;
                    pUpdateHIS.HIS_REGISTRATION.LNAME = patient.LastName;
                    pUpdateHIS.HIS_REGISTRATION.LNAME_ENG = patient.LastName_ENG;
                    pUpdateHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                    pUpdateHIS.HIS_REGISTRATION.PHONE1 = patient.Phone1;
                    pUpdateHIS.HIS_REGISTRATION.SSN = patient.SocialNumber;
                    pUpdateHIS.HIS_REGISTRATION.TITLE = patient.Title;
                    pUpdateHIS.HIS_REGISTRATION.TITLE_ENG = patient.Title_ENG;
                    pUpdateHIS.HIS_REGISTRATION.REG_ID = patient.Reg_ID;
                    pUpdateHIS.HIS_REGISTRATION.INSURANCE_TYPE = patient.InsuranceID.ToString();

                    if (patient.DateOfBirth == DateTime.MinValue)
                        anonymous = true;
                    if (patient.FirstName == "Anonymous")
                        anonymous = true;
                    if (patient.LastName == "Anonymous")
                        anonymous = true;
                    if (patient.Reg_UID.Length > 7)
                        anonymous = true;
                    if (anonymous)
                        pUpdateHIS.HIS_REGISTRATION.IS_JOHNDOE = 'Y';
                    else
                        pUpdateHIS.HIS_REGISTRATION.IS_JOHNDOE = 'N';

                    pUpdateHIS.Invoke();
                    regID = patient.Reg_ID;
                }
                else
                {
                    ProcessAddHISRegistration pHIS = new ProcessAddHISRegistration(true);
                    pHIS.HIS_REGISTRATION.ADDR1 = his.ADDR1;
                    pHIS.HIS_REGISTRATION.CREATED_BY = env.UserID;
                    pHIS.HIS_REGISTRATION.DOB = his.DOB;
                    pHIS.HIS_REGISTRATION.FNAME = his.FNAME;
                    pHIS.HIS_REGISTRATION.FNAME_ENG = his.FNAME_ENG;
                    pHIS.HIS_REGISTRATION.GENDER = his.GENDER;
                    pHIS.HIS_REGISTRATION.HN = his.HN;
                    pHIS.HIS_REGISTRATION.LNAME = his.LNAME;
                    pHIS.HIS_REGISTRATION.LNAME_ENG = his.LNAME_ENG;
                    pHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
                    pHIS.HIS_REGISTRATION.PHONE1 = his.PHONE1;
                    pHIS.HIS_REGISTRATION.SSN = his.SSN;
                    pHIS.HIS_REGISTRATION.TITLE = his.TITLE;
                    pHIS.HIS_REGISTRATION.TITLE_ENG = his.TITLE_ENG;
                    pHIS.HIS_REGISTRATION.LINK_DOWN = 'Y';
                    pHIS.HIS_REGISTRATION.INSURANCE_TYPE = patient.InsuranceID.ToString();
                    if (patient.DateOfBirth == DateTime.MinValue)
                        anonymous = true;
                    if (patient.FirstName == "Anonymous"||patient.FirstName == "John Doe")
                        anonymous = true;
                    if (patient.LastName == "Anonymous"|| patient.LastName == "John Doe")
                        anonymous = true;
                    if (his.HN.Length>7)
                        anonymous = true;
                    if (anonymous)
                        pHIS.HIS_REGISTRATION.IS_JOHNDOE = 'Y';
                    else
                        pHIS.HIS_REGISTRATION.IS_JOHNDOE = 'N';
                    string sa = mode;
                    pHIS.Invoke();
                    regID = pHIS.HIS_REGISTRATION.REG_ID;
                    patient.Reg_UID = his.HN;
                    item.HN = his.HN;
                }
                #endregion

                item.REG_ID = regID;
                patient.Reg_ID = regID;

                ProcessDeleteRISOrderdtl processDelete = new ProcessDeleteRISOrderdtl();
                processDelete.Transaction = tran;

                ProcessAddRISOrder processAdd = new ProcessAddRISOrder();
                processAdd.Transaction = tran;

                ProcessAddRISOrderdtl processAddDetails = new ProcessAddRISOrderdtl();
                processAddDetails.UseTransaction = tran;

                ProcessUpdateRISOrder processUpd = new ProcessUpdateRISOrder(true);
                processUpd.Transaction = tran;

                ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
                processUpdate.Transaction = tran;

                ProcessAddHISRegistration processHis = new ProcessAddHISRegistration();
                processHis.Transaction = tran;

                ProcessUpdateHISRegistration processUpdateHis = new ProcessUpdateHISRegistration();
                processUpdateHis.Transaction = tran;

                updateScheduleStatus(tran);

                if (item.ORDER_ID == 0)
                {
                    IsSchedule = "Order";
                    #region Insert Master-Details Data
                    processAdd.RIS_ORDER.REG_ID = patient.Reg_ID;
                    processAdd.RIS_ORDER.HN = patient.Reg_UID;
                    processAdd.RIS_ORDER.VISIT_NO = visitNumber;
                    processAdd.RIS_ORDER.ADMISSION_NO = item.ADMISSION_NO;
                    processAdd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RIS_ORDER.SCHEDULE_ID = item.SCHEDULE_ID;
                    processAdd.RIS_ORDER.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    processAdd.RIS_ORDER.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
                    processAdd.RIS_ORDER.REASON = item.REASON;
                    processAdd.RIS_ORDER.DIAGNOSIS = item.DIAGNOSIS;
                    processAdd.RIS_ORDER.ICD_ID = item.ICD_ID;
                    processAdd.RIS_ORDER.ORG_ID = item.ORG_ID;
                    processAdd.RIS_ORDER.CREATED_BY = item.CREATED_BY;
                    processAdd.RIS_ORDER.ORDER_DT = item.ORDER_DT;
                    processAdd.RIS_ORDER.SCHEDULE_ID = scheduleID;
                    processAdd.RIS_ORDER.REF_DOC = item.REF_DOC;
                    processAdd.RIS_ORDER.REF_UNIT = item.REF_UNIT;
                    processAdd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RIS_ORDER.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
                    processAdd.RIS_ORDER.PAT_STATUS = item.PAT_STATUS;
                    processAdd.RIS_ORDER.LMP_DT = item.LMP_DT;
                    processAdd.Invoke();
                    Item.ORDER_ID = processAdd.RIS_ORDER.ORDER_ID;
                    Item.XRAY_NO = processAdd.RIS_ORDER.XRAY_NO;
                    xray_no = processAdd.RIS_ORDER.XRAY_NO;
                    foreach (DataRow dr in dtOrder.Rows)
                    {

                        processAddDetails.RIS_ORDERDTL.ORDER_ID = processAdd.RIS_ORDER.ORDER_ID;
                        processAddDetails.RIS_ORDERDTL.EXAM_DT = item.ORDER_DT;
                        processAddDetails.RIS_ORDERDTL.ORG_ID = item.ORG_ID;
                        processAddDetails.RIS_ORDERDTL.CREATED_BY = item.CREATED_BY;
                        processAddDetails.RIS_ORDERDTL.EST_START_TIME = dr["EST_START_TIME"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["EST_START_TIME"]);
                        processAddDetails.RIS_ORDERDTL.QTY = Convert.ToByte(dr["QTY"].ToString());
                        processAddDetails.RIS_ORDERDTL.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
                        processAddDetails.RIS_ORDERDTL.MODALITY_ID = (int)dr["MODALITY_ID"];
                        processAddDetails.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"].ToString());
                        processAddDetails.RIS_ORDERDTL.EXAM_ID = (int)dr["EXAM_ID"];
                        processAddDetails.RIS_ORDERDTL.RATE = (decimal)dr["RATE"];
                        processAddDetails.RIS_ORDERDTL.CLINIC_TYPE = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];
                        if (processAddDetails.RIS_ORDERDTL.MODALITY_ID > 0)
                        {
                            processAddDetails.RIS_ORDERDTL.ACCESSION_NO = getAccessionNo(processAddDetails.RIS_ORDERDTL.MODALITY_ID);
                        }
                        else
                        {
                            processAddDetails.RIS_ORDERDTL.MODALITY_ID = 1;// 86;
                            processAddDetails.RIS_ORDERDTL.ACCESSION_NO = GenHN();
                        }
                        int bv_view = string.IsNullOrEmpty(dr["BPVIEW_ID"].ToString()) ? 0 : (int)dr["BPVIEW_ID"];
                        processAddDetails.RIS_ORDERDTL.BV_VIEW = bv_view;
                        processAddDetails.RIS_ORDERDTL.COMMENTS = dr["COMMENTS"].ToString();
                        processAddDetails.RIS_ORDERDTL.HIS_SYNC = 'N';// SendBilling(processAddDetails.RIS_ORDERDTL.ACCESSION_NO);
                        if (string.IsNullOrEmpty(dr["PREPARATION_ID"].ToString()))
                        {
                            processAddDetails.RIS_ORDERDTL.PREPARATION_ID = 0;
                        }
                        else
                        {
                            processAddDetails.RIS_ORDERDTL.PREPARATION_ID = Convert.ToInt32(dr["PREPARATION_ID"]);
                        }
                        
                        processAddDetails.Invoke();
                        _accNo.Add(processUpdate.RIS_ORDERDTL.ACCESSION_NO);

                        //DataRow drDtt = dtt.NewRow();
                        //for (int i = 0; i < dtOrder.Columns.Count; i++)
                        //    drDtt[i] = dr[i];
                        //drDtt["ordflag"] = "NW";
                        //drDtt["ACCESSION_NO"] = processAddDetails.RIS_ORDERDTL.ACCESSION_NO;
                        //drDtt["ORDER_ID"] = item.ORDER_ID;
                        //dtt.Rows.Add(drDtt);
                    }

                    #endregion

                    #region Insert PAT_ICD

                    if (dtPatICD != null)
                    {
                        foreach (DataRow dr in dtPatICD.Rows)
                        {
                            ProcessAddRISPaticd processPatICD = new ProcessAddRISPaticd();
                            processPatICD.Transaction = tran;
                            processPatICD.RIS_PATICD.ACCESSION_NO = processAddDetails.RIS_ORDERDTL.ACCESSION_NO;
                            processPatICD.RIS_PATICD.CREATED_BY = env.UserID;
                            processPatICD.RIS_PATICD.HN = patient.Reg_UID;
                            processPatICD.RIS_PATICD.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                            processPatICD.RIS_PATICD.ORDER_NO = processAdd.RIS_ORDER.ORDER_ID;
                            processPatICD.RIS_PATICD.ORDER_RESULT_FLAG = 'O';
                            processPatICD.RIS_PATICD.ORG_ID = env.OrgID;
                            processPatICD.Invoke();
                        }
                    }
                    #endregion

                    #region Update XREGIST.
                    if (!string.IsNullOrEmpty(item.REQUESTNO)) { 
                        //Update XREGIST STATUS='Y'
                        ProcessUpdateXRAYREQ proX = new ProcessUpdateXRAYREQ();
                        proX.XRAYREQ.ORDER_ID = Convert.ToInt32(item.REQUESTNO);
                        proX.Transaction = tran;
                        proX.Invoke();
                    }


                    #endregion

                }
                else if (item.ORDER_ID == -1)
                {
                    mode = "Schedule";
                    IsSchedule = "Schedule";
                    #region Insert Master-Details Data(Schedule)
                    processAdd.RIS_ORDER.REG_ID = patient.Reg_ID;
                    processAdd.RIS_ORDER.HN = patient.Reg_UID;
                    processAdd.RIS_ORDER.VISIT_NO = visitNumber;
                    processAdd.RIS_ORDER.ADMISSION_NO = item.ADMISSION_NO;
                    processAdd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RIS_ORDER.SCHEDULE_ID = item.SCHEDULE_ID;
                    processAdd.RIS_ORDER.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    processAdd.RIS_ORDER.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
                    processAdd.RIS_ORDER.REASON = item.REASON;
                    processAdd.RIS_ORDER.DIAGNOSIS = item.DIAGNOSIS;
                    processAdd.RIS_ORDER.ICD_ID = item.ICD_ID;
                    processAdd.RIS_ORDER.ORG_ID = item.ORG_ID;
                    processAdd.RIS_ORDER.CREATED_BY = item.CREATED_BY;
                    processAdd.RIS_ORDER.ORDER_DT = item.ORDER_DT;

                    processAdd.RIS_ORDER.REF_DOC = item.REF_DOC;
                    processAdd.RIS_ORDER.REF_UNIT = item.REF_UNIT;
                    processAdd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
                    processAdd.RIS_ORDER.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
                    processAdd.RIS_ORDER.PAT_STATUS = item.PAT_STATUS;
                    processAdd.RIS_ORDER.LMP_DT = item.LMP_DT;
                    processAdd.Invoke();
                    Item.ORDER_ID = processAdd.RIS_ORDER.ORDER_ID;

                    dtt.Clear();
                    dtt.Columns.Add("ACCESSION_NO", typeof(string));
                    dtt.Columns.Add("ORDER_ID", typeof(string));
                    dtt.Columns.Add("EXAM_UID", typeof(string));
                    dtt.Columns.Add("EXAM_NAME", typeof(string));
                    dtt.Columns.Add("PRIORITY", typeof(string));

                    foreach (DataRow dr in dtOrder.Rows)
                    {

                        processAddDetails.RIS_ORDERDTL.ORDER_ID = processAdd.RIS_ORDER.ORDER_ID;
                        processAddDetails.RIS_ORDERDTL.EXAM_DT = item.ORDER_DT;
                        processAddDetails.RIS_ORDERDTL.ORG_ID = item.ORG_ID;
                        processAddDetails.RIS_ORDERDTL.CREATED_BY = item.CREATED_BY;
                        processAddDetails.RIS_ORDERDTL.EST_START_TIME = dr["SCHEDULE_DT"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["SCHEDULE_DT"]);
                        if (string.IsNullOrEmpty(dr["QTY"].ToString()))
                        {
                            processAddDetails.RIS_ORDERDTL.QTY = 1;
                        }
                        else
                        {
                            processAddDetails.RIS_ORDERDTL.QTY = Convert.ToByte(dr["QTY"]); //(byte)dr["QTY"];
                        }
                        processAddDetails.RIS_ORDERDTL.ASSIGNED_TO = dr["RAD_ID"].ToString() == string.Empty ? 0 : (int)dr["RAD_ID"];
                        processAddDetails.RIS_ORDERDTL.MODALITY_ID = Convert.ToInt32(dr["MODALITY_ID"]);
                        processAddDetails.RIS_ORDERDTL.PRIORITY = 'R';
                        processAddDetails.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                        processAddDetails.RIS_ORDERDTL.RATE = Convert.ToDecimal(dr["RATE"]);
                        processAddDetails.RIS_ORDERDTL.CLINIC_TYPE = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 :  Convert.ToInt32(dr["CLINIC_TYPE"]);
                        if (processAddDetails.RIS_ORDERDTL.MODALITY_ID > 0)
                        {
                            processAddDetails.RIS_ORDERDTL.ACCESSION_NO = getAccessionNo(processAddDetails.RIS_ORDERDTL.MODALITY_ID);
                        }
                        else
                        {
                            //processAddDetails.RIS_ORDERDTL.MODALITY_ID = 86;
                            //processAddDetails.RIS_ORDERDTL.ACCESSION_NO = GenHN();
                        }
                        //processAddDetails.RIS_ORDERDTL.BV_VIEW = (int)dr["BPVIEW_ID"];
                        processAddDetails.RIS_ORDERDTL.COMMENTS = dr["COMMENTS"].ToString();
                        processAddDetails.RIS_ORDERDTL.HIS_SYNC = 'N';//SendBilling(processAddDetails.RIS_ORDERDTL.ACCESSION_NO);
                        if (string.IsNullOrEmpty(dr["PREPARATION_ID"].ToString()))
                        {
                            processAddDetails.RIS_ORDERDTL.PREPARATION_ID = 0;
                        }
                        else
                        {
                            processAddDetails.RIS_ORDERDTL.PREPARATION_ID = Convert.ToInt32(dr["PREPARATION_ID"].ToString());
                        }
                        processAddDetails.Invoke();

                        //flag = true;
                        //for (int i = 0; i < dtExam.Rows.Count; i++)
                        //{
                        //    if (dtExam.Rows[i]["EXAM_ID"].ToString() == processAddDetails.RIS_ORDERDTL.EXAM_ID.ToString())
                        //    {
                        //        if (dtExam.Rows[i]["SERVICE_TYPE"].ToString() != "1")
                        //            flag = false;
                        //        break;
                        //    }
                        //}
                        //if (flag)
                        //{
                        //    DataRow drDtt = dtt.NewRow();
                        //    for (int i = 0; i < dtOrder.Columns.Count; i++)
                        //        drDtt[i] = dr[i];
                        //    drDtt["ordflag"] = "NW";
                        //    drDtt["ACCESSION_NO"] = processAddDetails.RIS_ORDERDTL.ACCESSION_NO;
                        //    drDtt["ORDER_ID"] = item.ORDER_ID;
                        //    DataRow[] drXUID = dtExam.Select("EXAM_ID=" + dtOrder.Rows[0]["EXAM_ID"].ToString());
                        //    drDtt["EXAM_UID"] = drXUID[0]["EXAM_UID"];
                        //    drDtt["EXAM_NAME"] = drXUID[0]["EXAM_NAME"];
                        //    drDtt["PRIORITY"] = "R";
                        //    dtt.Rows.Add(drDtt);
                        //}
                    }

                    #endregion

                    #region Insert PAT_ICD

                    if (dtPatICD != null)
                    {
                        foreach (DataRow dr in dtPatICD.Rows)
                        {
                            ProcessAddRISPaticd processPatICD = new ProcessAddRISPaticd();
                            processPatICD.Transaction = tran;
                            processPatICD.RIS_PATICD.ACCESSION_NO = processAddDetails.RIS_ORDERDTL.ACCESSION_NO;
                            processPatICD.RIS_PATICD.CREATED_BY = env.UserID;
                            processPatICD.RIS_PATICD.HN = patient.Reg_UID;
                            processPatICD.RIS_PATICD.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                            processPatICD.RIS_PATICD.ORDER_NO = processAdd.RIS_ORDER.ORDER_ID;
                            processPatICD.RIS_PATICD.ORDER_RESULT_FLAG = 'O';
                            processPatICD.RIS_PATICD.ORG_ID = env.OrgID;
                            processPatICD.Invoke();
                        }
                    }
                    #endregion

                }
                else
                {
                    IsSchedule = "Other";
                    #region Update Master
                    ProcessGetRISPaticd processRISPatICD = new ProcessGetRISPaticd(item.ORDER_ID);
                    processRISPatICD.Invoke();
                    dttPatOri = processRISPatICD.Result.Tables[0];

                    processUpd.RIS_ORDER.ORDER_ID = item.ORDER_ID;
                    processUpd.RIS_ORDER.REG_ID = patient.Reg_ID;
                    processUpd.RIS_ORDER.HN = patient.Reg_UID;
                    processUpd.RIS_ORDER.VISIT_NO = visitNumber;
                    processUpd.RIS_ORDER.ADMISSION_NO = item.ADMISSION_NO;
                    processUpd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
                    processUpd.RIS_ORDER.SCHEDULE_ID = item.SCHEDULE_ID;
                    processUpd.RIS_ORDER.REF_DOC_INSTRUCTION = item.REF_DOC_INSTRUCTION;
                    processUpd.RIS_ORDER.CLINICAL_INSTRUCTION = item.CLINICAL_INSTRUCTION;
                    processUpd.RIS_ORDER.REF_DOC = item.REF_DOC;
                    processUpd.RIS_ORDER.REF_UNIT = item.REF_UNIT;
                    processUpd.RIS_ORDER.REASON = item.REASON;
                    processUpd.RIS_ORDER.DIAGNOSIS = item.DIAGNOSIS;
                    processUpd.RIS_ORDER.ICD_ID = item.ICD_ID;
                    processUpd.RIS_ORDER.ORG_ID = item.ORG_ID;
                    processUpd.RIS_ORDER.CREATED_BY = item.CREATED_BY;
                    processUpd.RIS_ORDER.ORDER_DT = item.ORDER_DT;
                    processUpd.RIS_ORDER.LAST_MODIFIED_BY = item.LAST_MODIFIED_BY;
                    processUpd.RIS_ORDER.ORDER_START_TIME = item.ORDER_START_TIME;
                    processUpd.RIS_ORDER.INSURANCE_TYPE_ID = item.INSURANCE_TYPE_ID;
                    processUpd.RIS_ORDER.LMP_DT = item.LMP_DT;
                    processUpd.RIS_ORDER.PAT_STATUS = item.PAT_STATUS;
                    processUpd.Invoke();
                    xray_no = item.XRAY_NO;
                    #endregion

                    #region Update Details
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        if (dr["ORDER_ID"].ToString() != string.Empty)
                        {
                            #region ปรังปรุง Record
                            processUpdate.RIS_ORDERDTL.ORDER_ID = item.ORDER_ID;
                            processUpdate.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(dr["EXAM_ID"]);
                            processUpdate.RIS_ORDERDTL.EXAM_DT = item.ORDER_DT;

                            if (dr["QTY"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.QTY = 0;
                            else
                                processUpdate.RIS_ORDERDTL.QTY = Convert.ToByte(dr["QTY"].ToString());

                            if (dr["BPVIEW_ID"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.BV_VIEW = 0;
                            else
                                processUpdate.RIS_ORDERDTL.BV_VIEW = (int)dr["BPVIEW_ID"];

                            if (dr["Q_NO"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.Q_NO = 0;
                            else
                                processUpdate.RIS_ORDERDTL.Q_NO = Convert.ToByte(dr["Q_NO"]);

                            if (dr["HL7_SENT"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.HL7_SENT = null;
                            else
                                processUpdate.RIS_ORDERDTL.HL7_SENT = Convert.ToChar(dr["HL7_SENT"].ToString());

                            if (dr["HL7_TEXT"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.HL7_TEXT = string.Empty;
                            else
                                processUpdate.RIS_ORDERDTL.HL7_TEXT = dr["HL7_TEXT"].ToString();

                            if (dr["COMMENTS"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.COMMENTS = string.Empty;
                            else
                                processUpdate.RIS_ORDERDTL.COMMENTS = dr["COMMENTS"].ToString();

                            if (dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null)
                                processUpdate.RIS_ORDERDTL.CLINIC_TYPE = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];
                            else
                                processUpdate.RIS_ORDERDTL.CLINIC_TYPE = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];

                            if (dr["IMAGE_CAPTURED_BY"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.IMAGE_CAPTURED_BY = 0;
                            else
                                processUpdate.RIS_ORDERDTL.IMAGE_CAPTURED_BY = Convert.ToInt32(dr["IMAGE_CAPTURED_BY"]);

                            if (dr["IMAGE_CAPTURED_ON"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.IMAGE_CAPTURED_ON = DateTime.MinValue;
                            else
                                processUpdate.RIS_ORDERDTL.IMAGE_CAPTURED_ON = Convert.ToDateTime(dr["IMAGE_CAPTURED_ON"]);

                            if (dr["QA_BY"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.QA_BY = 0;
                            else
                                processUpdate.RIS_ORDERDTL.QA_BY = Convert.ToInt32(dr["QA_BY"]);

                            if (dr["QA_ON"].ToString() == string.Empty)
                                processUpdate.RIS_ORDERDTL.QA_ON = DateTime.MinValue;
                            else
                                processUpdate.RIS_ORDERDTL.QA_ON = Convert.ToDateTime(dr["QA_ON"]);


                            if (dr["ACCESSION_NO"].ToString() == string.Empty)
                            {

                                //processAddDetails.RIS_ORDERDTL.ACCESSION_NO = GenAccessionNo(processAddDetails.RIS_ORDERDTL.EXAM_DT, processAddDetails.RIS_ORDERDTL.MODALITY_ID.ToString());
                                processUpdate.RIS_ORDERDTL.MODALITY_ID = (int)dr["MODALITY_ID"];
                                if (processUpdate.RIS_ORDERDTL.MODALITY_ID > 0)
                                {
                                    processUpdate.RIS_ORDERDTL.ACCESSION_NO = getAccessionNo(processUpdate.RIS_ORDERDTL.MODALITY_ID);
                                }
                                else
                                {
                                    processUpdate.RIS_ORDERDTL.MODALITY_ID = 86;
                                    processUpdate.RIS_ORDERDTL.ACCESSION_NO = GenHN();

                                }
                            }
                            else
                                processUpdate.RIS_ORDERDTL.ACCESSION_NO = dr["ACCESSION_NO"].ToString();

                            processUpdate.RIS_ORDERDTL.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
                            processUpdate.RIS_ORDERDTL.MODALITY_ID = (int)dr["MODALITY_ID"];
                            processUpdate.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"].ToString());
                            processUpdate.RIS_ORDERDTL.EXAM_ID = (int)dr["EXAM_ID"];
                            processUpdate.RIS_ORDERDTL.RATE = (decimal)dr["RATE"];
                            processUpdate.RIS_ORDERDTL.OLD_EXAM_ID = dr["ORIGIN_ID"].ToString().Trim().Length == 0 ? 0 : Convert.ToInt32(dr["ORIGIN_ID"]);
                            processUpdate.RIS_ORDERDTL.IS_DELETED = Convert.ToChar(dr["IS_DELETED"].ToString());
                            processUpdate.RIS_ORDERDTL.ORG_ID = item.ORG_ID;
                            processUpdate.RIS_ORDERDTL.LAST_MODIFIED_BY = env.UserID;
                            if (string.IsNullOrEmpty(dr["PREPARATION_ID"].ToString()))
                            {
                                processUpdate.RIS_ORDERDTL.PREPARATION_ID = 0;
                            }
                            else
                            {
                                processUpdate.RIS_ORDERDTL.PREPARATION_ID = Convert.ToInt32(dr["PREPARATION_ID"].ToString());
                            }

                            processUpdate.Invoke();

                            _accNo_Edit.Add(processUpdate.RIS_ORDERDTL.ACCESSION_NO);
                            #endregion
                        }
                        else
                        {
                            #region กรณีแก้ไขแล้วเพิ่ม Record
                            processAddDetails.RIS_ORDERDTL.ORDER_ID = item.ORDER_ID;
                            processAddDetails.RIS_ORDERDTL.EXAM_DT = item.ORDER_DT;
                            processAddDetails.RIS_ORDERDTL.ORG_ID = item.ORG_ID;
                            processAddDetails.RIS_ORDERDTL.CREATED_BY = item.CREATED_BY;
                            processAddDetails.RIS_ORDERDTL.EST_START_TIME = dr["EST_START_TIME"].ToString() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(dr["EST_START_TIME"]);
                            processAddDetails.RIS_ORDERDTL.QTY = Convert.ToByte(dr["QTY"].ToString());

                            processAddDetails.RIS_ORDERDTL.ASSIGNED_TO = dr["ASSIGNED_TO"].ToString() == string.Empty ? 0 : (int)dr["ASSIGNED_TO"];
                            processAddDetails.RIS_ORDERDTL.MODALITY_ID = (int)dr["MODALITY_ID"];
                            processAddDetails.RIS_ORDERDTL.PRIORITY = Convert.ToChar(dr["PRIORITY"].ToString());

                            processAddDetails.RIS_ORDERDTL.EXAM_ID = (int)dr["EXAM_ID"];
                            processAddDetails.RIS_ORDERDTL.RATE = (decimal)dr["RATE"];
                            processAddDetails.RIS_ORDERDTL.CLINIC_TYPE = dr["CLINIC_TYPE"].ToString().Trim() == string.Empty || dr["CLINIC_TYPE"].ToString().Trim() == null ? 0 : (int)dr["CLINIC_TYPE"];

                            if (processAddDetails.RIS_ORDERDTL.MODALITY_ID > 0)
                            {
                                processAddDetails.RIS_ORDERDTL.ACCESSION_NO = getAccessionNo(processAddDetails.RIS_ORDERDTL.MODALITY_ID);
                            }
                            else
                            {
                                processAddDetails.RIS_ORDERDTL.MODALITY_ID = 86;
                                processAddDetails.RIS_ORDERDTL.ACCESSION_NO = GenHN();
                            }
                            processAddDetails.RIS_ORDERDTL.CREATED_BY = env.UserID;

                            processAddDetails.RIS_ORDERDTL.BV_VIEW = (int)dr["BPVIEW_ID"];

                            
                            try
                            {
                                processAddDetails.RIS_ORDERDTL.PREPARATION_ID = Convert.ToInt32(dr["PREPARATION_ID"]);
                            }
                            catch
                            {
                                processAddDetails.RIS_ORDERDTL.PREPARATION_ID = 0;
                            }
                            processAddDetails.Invoke();

                            _accNo.Add(processAddDetails.RIS_ORDERDTL.ACCESSION_NO);
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
                                processPatICD.Transaction = tran;
                                processPatICD.RIS_PATICD.ACCESSION_NO = processAddDetails.RIS_ORDERDTL.ACCESSION_NO;
                                processPatICD.RIS_PATICD.CREATED_BY = env.UserID;
                                processPatICD.RIS_PATICD.HN = patient.Reg_UID;
                                processPatICD.RIS_PATICD.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                                processPatICD.RIS_PATICD.ORDER_NO = item.ORDER_ID;
                                processPatICD.RIS_PATICD.ORDER_RESULT_FLAG = 'O';
                                processPatICD.RIS_PATICD.ORG_ID = env.OrgID;
                                processPatICD.Invoke();
                            }
                            else
                            {
                                //update
                                listID.Add(dr["PAT_ICD_ID"].ToString());
                                ProcessUpdateRISPaticd processUpdatePAT = new ProcessUpdateRISPaticd();
                                processUpdatePAT.Transaction = tran;
                                processUpdatePAT.RIS_PATICD.ACCESSION_NO = processUpdate.RIS_ORDERDTL.ACCESSION_NO;
                                processUpdatePAT.RIS_PATICD.CREATED_BY = env.UserID;
                                processUpdatePAT.RIS_PATICD.HN = patient.Reg_UID;
                                processUpdatePAT.RIS_PATICD.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                                processUpdatePAT.RIS_PATICD.ORDER_NO = item.ORDER_ID;
                                processUpdatePAT.RIS_PATICD.ORDER_RESULT_FLAG = 'O';
                                processUpdatePAT.RIS_PATICD.ORG_ID = env.OrgID;
                                processUpdatePAT.Invoke();
                            }
                        }
                        foreach (DataRow dr in dttPatOri.Rows)
                        {
                            if (listID.IndexOf(dr["PAT_ICD_ID"].ToString()) == -1)
                            {
                                ProcessDeleteRISPaticd processDelPAT = new ProcessDeleteRISPaticd();
                                processDelPAT.Transaction = tran;
                                processDelPAT.RIS_PATICD.PAT_ICD_ID = (int)dr["PAT_ICD_ID"];
                                processDelPAT.Invoke();
                            }
                        }
                    }
                    #endregion

                    Item.ORDER_ID = item.ORDER_ID;
                    mode = "Edit";
                }

                tran.Commit();

                #region UPDATE ENCOUNTER AND ADDMINSSION NO.

                string strEnc_id = "";
                string strEnc_type = "";
                string perfDate = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

                string strUNIT_UID = "";
                string strUNIT_NAME = "";
                int ref_unit = Convert.ToInt32(processAdd.RIS_ORDER.REF_UNIT);
                fnBill.LoadHRUnit(ref_unit, ref strUNIT_UID, ref strUNIT_NAME);

                //fnBill.LoadEncounter(processAdd.RIS_ORDER.HN, strUNIT_UID, ref strEnc_id, ref strEnc_type);
                fnBill.LoadEncounter(patient.Reg_UID, strUNIT_UID, ref strEnc_id, ref strEnc_type);

                string encid = strEnc_id;
                string enctype = strEnc_type;
                fnBill.UpdateEncount(processAdd.RIS_ORDER.ORDER_ID, encid, enctype);

                //string admission_no = fnBill.LoadAdmissinNo(processAdd.RIS_ORDER.HN);
                string admission_no = fnBill.LoadAdmissinNo(patient.Reg_UID);
                fnBill.UpdateAddmissionNo(processAdd.RIS_ORDER.ORDER_ID, admission_no);

                #endregion

                #region HL7 and Order Images

                try
                {

                    SendToPacs send = new SendToPacs();
                    send.SendHL7Queue(Item.ORDER_ID);
                }
                catch (Exception exMSG)
                {

                }
                try
                {
                    ScanImage save = null;
                    if (mode == "New")
                        save = new ScanImage(patient.Reg_UID, item.ORDER_ID);
                    else
                        save = new ScanImage(patient.Reg_UID, item.ORDER_ID, dtOrderImage);
                    //new GBLEnvVariable().CountImg = "";
                    //new GBLEnvVariable().PixPic = IntPtr.Zero;
                    //new GBLEnvVariable().PixPic2 = IntPtr.Zero;
                    //new GBLEnvVariable().PixPic3 = IntPtr.Zero;
                    //new GBLEnvVariable().BmpPic = IntPtr.Zero;
                    //new GBLEnvVariable().BmpPic2 = IntPtr.Zero;
                    //new GBLEnvVariable().BmpPic3 = IntPtr.Zero;

                    env.PixPicture = PointerStruct.ClearPointerStruct(env.PixPicture);
                   
                }
                catch { }
                #endregion

                #region Set Billing
                try
                {
                    //#region During Run in TestDB don't send Billing.
                    //FinancialBilling billing = new FinancialBilling();
                    //string bill_msg = billing.GetBillingMessage(processAddDetails.RIS_ORDERDTL.ACCESSION_NO);
                    //string ack_msg = billing.Set_Billing(bill_msg); 

                    SendBilling(mode);

                }
                catch { }
                #endregion

            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch { }
                retFlag = false;//MessageBox.Show(ex.Message);
                //System.IO.File.AppendAllText(@"c:\envision-GlobalBaseData.txt", ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                tran.Dispose();
            }

            return retFlag;
        }

        private string findLocationCode(string ModalityID)
        {
            string locationCode = "RD-0101"; //DIAGNOSIT
            if (!string.IsNullOrEmpty(ModalityID))
            {
                try
                {
                    DataRow[] rows = dtModality.Select("MODALITY_ID=" + ModalityID);
                    if (rows.Length > 0)
                    {
                        switch (rows[0]["UNIT_ID"].ToString())
                        {
                            case "2": //AIMC
                                locationCode = "RD-0212";
                                break;
                            case "3"://MEMO
                                locationCode = "RD-0101";
                                break;
                            //case "4"://ER
                            //    locationCode = "";
                            //    break;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return locationCode;
        }
        private string genNewMessageBill(DataRow dr)
        {
            DataTable dtExam = RISBaseData.Ris_Exam();
            DataTable dtDoctor = RISBaseData.His_Doctor();
            DataTable dtDepart = RISBaseData.His_Department();
            DataTable dtClinic = RISBaseData.RIS_ClinicType();
            DataTable dtInsurance = RISBaseData.Ris_InsuranceType();


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
                dsIPD = BillHis.Get_ipd_detail(patient.Reg_UID);
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
            DataRow[] drBExam =dtExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
            DataRow[] drBEmp = dtDoctor.Select("EMP_ID=" + item.REF_DOC.ToString());
            DataRow[] drBUnit = dtDepart.Select("UNIT_ID=" + item.REF_UNIT.ToString());
            DataRow[] drBClinic = dtClinic.Select("CLINIC_TYPE_ID=" + dr["CLINIC_TYPE"].ToString());
            if (item.INSURANCE_TYPE_ID != 0)
            {
                DataRow[] drBIn = dtInsurance.Select("INSURANCE_TYPE_ID=" + item.INSURANCE_TYPE_ID.ToString());
                strInSu = drBIn[0]["INSURANCE_TYPE_UID"].ToString();
            }
            else
            {
                strInSu = " ";
            }

            intQTY = Convert.ToInt32(dr["QTY"]);

            if (!string.IsNullOrEmpty(drBClinic[0]["CLINIC_TYPE_UID"].ToString()))
            {
                strClinic = drBClinic[0]["CLINIC_TYPE_UID"].ToString() == "Normal" ? "R" : "S";
            }
            decimal rate = Convert.ToDecimal(dr["RATE"].ToString());
            Amt = rate * intQTY;
            string reg_uid = patient.Reg_UID;
            string unit_uid = drBUnit[0]["UNIT_UID"].ToString();
            string exam_uid = drBExam[0]["EXAM_UID"].ToString();
            string emp_uid = drBEmp[0]["EMP_UID"].ToString();
            str = "#" + " "
                + "#" + reg_uid
                + "#" + strAcc
                + "#" + strAN
                + "#" + strISEQ
                + "#" + unit_uid
                + "#" + item.ORDER_DT.ToString("dd/MM") + "/" + item.ORDER_DT.Year
                + "#" + "C"
                + "#" + "3"
                + "#" + exam_uid
                + "#" + intQTY.ToString()
                + "#" + rate.ToString("#0.0")
                + "#" + Amt.ToString("#.0")
                + "#" + emp_uid
                + "# # # # #" + item.ORDER_DT.ToString("dd/MM") + "/" + item.ORDER_DT.Year
                + "#" + item.ORDER_DT.ToString("HH:mm")
                + "#" + strMstype
                + "#" + strClinic
                + "#" + "3"
                + "#" + strInSu
                //+ "#" + "RD-0101"
                + "#" + findLocationCode(dr["MODALITY_ID"].ToString())
                + "#" + "0"
                + "#" + env.UserUID
                + "#";

            return str;
        }
        private void SendBilling(string mode)
        {
            //SendToPacs send = new SendToPacs();
            //if (mode == "Edit")
            //    send.SendBillMessage("E;" + item.ORDER_ID.ToString());
            //else
            //    send.SendBillMessage("N;" + item.ORDER_ID.ToString());

            List<String> Accession_List = new List<string>();
            List<String> Accession_Cancel = new List<string>();
            bool flag = true;

            ProcessGetRISExam geExam = new ProcessGetRISExam();
            geExam.Invoke();
            ProcessGetRISOrderdtl process = new ProcessGetRISOrderdtl('3', item.ORDER_ID, 0);
            process.Invoke();
            DataTable dtt = process.Result.Tables[0].Copy();

            string str = "";

            if (mode == "Edit")
            {
                #region Update Billing.

                #region old code
                //foreach (string s in _accNo)
                //{
                //    flag = true;
                //    foreach (DataRow dr in dtt.Rows)
                //    {
                //        DataRow[] drChkExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                //        if (drChkExam.Length == 0)
                //        {
                //            flag = false;
                //            break;
                //        }
                //        if (drChkExam[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                //        {
                //            if (dr["ACCESSION_NO"].ToString().Trim() == s)
                //            {
                //                flag = false;
                //                break;
                //            }
                //            if (flag)
                //            {
                //                flag = false;
                //                //string str = BillHis.Cancel_Billing(patient.Reg_UID, s, " ", " ");

                //                if (billAck != "Success in Cancel_Billing")
                //                {
                //                    if (MessageBox.Show("ไม่สามารถส่งข้อมูลไปการเงินได้ กรุณาลองใหม่อีกครั้ง", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                //                    {
                //                        str = BillHis.Cancel_Billing(patient.Reg_UID, s, " ", " ");
                //                        if (str.Trim() != "Success in Cancel_Billing")
                //                        {
                //                            MessageBox.Show("ไม่สามารถส่งข้อมูลไปการเงินได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //foreach (DataRow dr in dtt.Rows)
                //{

                //    DataRow[] drChkExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                //    if (drChkExam.Length == 0)
                //    {
                //        flag = false;
                //        break;
                //    }
                //    if (drChkExam[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                //    {
                //        flag = false;
                //        string str = string.Empty;
                //        if (_accNo.IndexOf(dr["ACCESSION_NO"].ToString()) > -1)
                //        {
                //            str = BillHis.Cancel_Billing(patient.Reg_UID.Trim(), dr["ACCESSION_NO"].ToString().Trim(), " ", " ");
                //            if (str.Trim() == "Success in Cancel_Billing")
                //            {
                //                //str = genNewMessageBill(dr);
                //                //str = genNewMessageBill_Encounter(dr);
                //                //str = BillHis.Set_Billing(str);
                //                string billMsg = fnBill.GetBillingMessage(s);
                //                string billAck = fnBill.Set_Billing(billMsg);
                //                if (str.Trim() == "Success in Set_Billing")
                //                    flag = true;
                //                else
                //                {
                //                    flag = false;
                //                }
                //            }
                //            else
                //            {
                //                Accession_Cancel.Add(dr["ACCESSION_NO"].ToString());
                //                flag = false;
                //            }
                //        }
                //        else
                //        {
                //            //str = genNewMessageBill(dr);
                //            str = genNewMessageBill_Encounter(dr);
                //            str = BillHis.Set_Billing(str);
                //            if (str.Trim() == "Success in Set_Billing")
                //                flag = true;
                //            else
                //            {
                //                flag = false;
                //            }
                //        }
                //        dtl.RISOrderdtl.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                //        dtl.RISOrderdtl.HIS_SYNC = flag ? "Y" : "N";
                //        dtl.RISOrderdtl.HIS_ACK = str;

                //        if (dtl.RISOrderdtl.HIS_SYNC == "N")
                //            Accession_List.Add(dtl.RISOrderdtl.ACCESSION_NO);

                //        dtl.UpdateSend();


                //    }
                //}
                #endregion

                //cancel billing
                foreach (string acc in _accNo_Edit)
                {
                    // send billing

                    DataRow[] rows = dtt.Select("ACCESSION_NO='" + acc + "'");
                    if (rows.Length > 0)
                    {
                        DataRow dr = rows[0];
                        DataRow[] drChkExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                        if (drChkExam.Length == 0)
                        {
                            continue;
                        }
                        if (drChkExam[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                        {
                            str = fnBill.Cancel_Billing(patient.Reg_UID, acc, " ", " ");
                            fnBill.UpdateHisSync(acc, str);
                            if (str.Trim() != "Success in Cancel_Billing")
                            {
                                MessageBox.Show("ไม่สามารถทำการยกเลิกบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                                continue;
                            }


                            string billMsg = fnBill.GetBillingMessage(dr["ACCESSION_NO"].ToString());
                            if (string.IsNullOrEmpty(billMsg)) continue;

                            str = fnBill.Set_Billing(billMsg);
                            fnBill.UpdateHisSync(dr["ACCESSION_NO"].ToString(), str);
                            if (str.Trim() != "Success in Set_Billing")
                            {
                                MessageBox.Show("ไม่สามารถทำการส่งบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                                continue;
                            }
                        }
                    }
                }
                foreach (string acc in _accNo)
                {
                    //str = fnBill.Cancel_Billing(patient.Reg_UID, acc, " ", " ");
                    //fnBill.UpdateHisSync(acc, str);
                    //if (str.Trim() != "Success in Cancel_Billing")
                    //{
                    //    MessageBox.Show("ไม่สามารถทำการยกเลิกบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                    //    continue;
                    //}

                    // send billing
                    //foreach (DataRow dr in dtt.Rows)

                    DataRow[] rows = dtt.Select("ACCESSION_NO='" + acc + "'");
                    if (rows.Length > 0)
                    {
                        DataRow dr = rows[0];
                        DataRow[] drChkExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                        if (drChkExam.Length == 0)
                        {
                            continue;
                        }
                        if (drChkExam[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                        {
                            string billMsg = fnBill.GetBillingMessage(dr["ACCESSION_NO"].ToString());
                            if (string.IsNullOrEmpty(billMsg)) continue;

                            str = fnBill.Set_Billing(billMsg);
                            fnBill.UpdateHisSync(dr["ACCESSION_NO"].ToString(), str);
                            if (str.Trim() != "Success in Set_Billing")
                            {
                                MessageBox.Show("ไม่สามารถทำการส่งบิลลิ่งได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                                continue;
                            }
                        }

                    }
                }

                #endregion
            }
            else
            {
                #region Insert Billing.
                foreach (DataRow dr in dtt.Rows)
                {
                    DataRow[] drChkExam = geExam.Result.Tables[0].Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                    if (drChkExam.Length == 0)
                    {
                        flag = false;
                        break;
                    }
                    if (drChkExam[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                    {
                        flag = false;

                        string billMsg = fnBill.GetBillingMessage(dr["ACCESSION_NO"].ToString());

                        if (string.IsNullOrEmpty(billMsg)) continue;
                        try
                        {
                            str = fnBill.Set_Billing(billMsg);

                            if (str.Trim() == "Success in Set_Billing")
                            {
                                flag = true;
                            }
                            else
                            {
                                if (MessageBox.Show("ไม่สามารถส่งข้อมูลไปการเงินได้ กรุณาลองใหม่อีกครั้ง", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                                {
                                    billMsg = fnBill.GetBillingMessage(dr["ACCESSION_NO"].ToString());
                                    str = fnBill.Set_Billing(billMsg);

                                    if (str.Trim() != "Success in Set_Billing")
                                    {
                                        MessageBox.Show("ไม่สามารถส่งข้อมูลไปการเงินได้ กรุณาติดต่อเจ้าหน้าที่", "Error", MessageBoxButtons.OK);
                                        flag = false;
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {

                        }

                        fnBill.UpdateHisSync(dr["ACCESSION_NO"].ToString(), str);
                    }
                }
                #endregion
            }
        }
        public void SendBilling(int OrderID)
        {
            SendToPacs send = new SendToPacs();
            send.SendBillMessage("N;" + OrderID.ToString());
        }
        public void SendBilling_Intervent(int OrderID)
        {
            SendToPacs send = new SendToPacs();
            send.SendBillMessage("I;" + OrderID.ToString());
        }

        public void CancelBilling(int OrderID, string HN, string accession)
        {
            //SendToPacs send = new SendToPacs();
            //send.SendBillMessage("C;" + OrderID);
            fnBill.Cancel_Billing(HN, accession, " ", " ");
        }
        private string getDeptName(int ref_unit)
        {

            DataRow[] dr = dtDepartment.Select("UNIT_ID=" + ref_unit);
            if (dr.Length > 0)
                return dr[0]["UNIT_UID"].ToString() + ":" + dr[0]["UNIT_NAME"].ToString() + "(" + dr[0]["PHONE_NO"].ToString() + ")";
            return "";
        }
        private string getDocName(int ref_doc)
        {
            DataRow[] dr =  dtDoctor.Select("EMP_ID=" + ref_doc);
            if (dr.Length > 0)
                return dr[0]["EMP_UID"].ToString() + ":" + dr[0]["FNAME"].ToString() + " " + dr[0]["LNAME"].ToString();
            return "";
        }
       
    }
}
