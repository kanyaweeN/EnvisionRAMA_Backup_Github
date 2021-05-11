using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Envision.BusinessLogic;
using Envision.BusinessLogic.Schedule;
using Envision.Entity;
using Envision.Entity.Schedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EnvisionAPI3rdParty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckupCNMIController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CheckupCNMIController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetVersion")]
        public string GetVersion()
        {
            return "1.0.0.1";
        }
        [HttpPost]
        [Route("TranslateName")]
        public string TranslateName(string nameTH)
        {
            EnvisionWebService.ServiceSoapClient.EndpointConfiguration endpointConfiguration = new EnvisionWebService.ServiceSoapClient.EndpointConfiguration();
            EnvisionWebService.ServiceSoapClient serviceSoapClient = new EnvisionWebService.ServiceSoapClient(endpointConfiguration);
            var userData = serviceSoapClient.ThaiToEngAsync(nameTH).Result;
            return userData.Trim().ToString();
        }
        [HttpPost]
        [Route("TestCheckup")]
        public ScheduleResponse TestCheckup()
        {
            return new ScheduleResponse()
            {
                code = 200,
                message = "Success"
            };
        }
        [HttpPost]
        [Route("Set_CheckupAppointment_Xray")]
        public ScheduleResponse Set_CheckupAppointment_Xray([FromBody] dynamic para)
        {
            bool keepLog = Convert.ToBoolean(_configuration.GetValue<string>("Modules:Logging:keepLog")); // read logDb connection string example
            if (keepLog)
            {
                string strCon = @"server=10.58.252.231; database=RIS_CNMITEST;User ID=sa;Password=mira@@1; Persist Security Info=false;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into AAA_LOG_REQUEST
                                    (STR_PARAM,CREATED_ON)
                                    values
                                    (@STR_PARAM,GETDATE())";
                SqlParameter[] param = {
                                                new SqlParameter("@STR_PARAM",para.ToString()),
                                        };
                cmd.Parameters.AddRange(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                da.Fill(dss);
            }
            var scheduleData = JsonConvert.DeserializeObject<ScheduleCheckupData>(para.ToString());
            return this.CheckCheckupAppointmentXray(scheduleData, para.ToString());
        }
        [HttpPost]
        [Route("CheckCheckupAppointmentXray")]
        public ScheduleResponse CheckCheckupAppointmentXray(ScheduleCheckupData scheduleData, string paraString)
        {
            try
            {
                HisRegistrationComponent hisRegistration = new HisRegistrationComponent();
                HisRegistration registration = new HisRegistration();
                registration.Hn = scheduleData.hn;
                registration.HisHn = scheduleData.hn;
                registration.RegDt = DateTime.Now;
                registration.Title = scheduleData.initial_name;
                registration.Fname = scheduleData.first_name;
                registration.Lname = scheduleData.last_name;
                registration.Mname = scheduleData.middle_name;
                registration.FnameEng = scheduleData.first_name_eng;
                registration.LnameEng = scheduleData.last_name_eng;
                registration.MnameEng = scheduleData.middle_name_eng;
                registration.Ssn = scheduleData.id_card_no;
                registration.Natiionality = scheduleData.nationality;
                //registration.Natiionality = scheduleData.nation_code;
                registration.Dob = Convert.ToDateTime(scheduleData.dob);
                registration.Gender = scheduleData.gender;
                registration.Address1 = scheduleData.address;
                registration.Address2 = scheduleData.amphur;
                registration.Address3 = scheduleData.province;
                registration.Address4 = scheduleData.zipcode;
                registration.Phone1 = scheduleData.tel_no;
                registration.Phone2 = scheduleData.mobile_no;
                registration.Email = scheduleData.email;
                registration.EmContactPerson = scheduleData.emergency_contact;
                hisRegistration.Item = registration;
                registration = hisRegistration.Invoke();

                HrUnitComponent hrUnit = new HrUnitComponent();
                HrUnit unit = new HrUnit();
                if (!string.IsNullOrEmpty(scheduleData.ref_unit_code))
                {
                    hrUnit.Item.Code = scheduleData.ref_unit_code.Trim();
                    hrUnit.Item.Name = scheduleData.ref_unit_name.Trim();
                    hrUnit.OrgId = 1;
                    unit = hrUnit.GetByCode();
                    if (unit == null)
                    {
                        unit = hrUnit.Add();
                    }
                }
                //HrEmpComponent hrEmp2 = new HrEmpComponent();
                //hrEmp2.Item.EmpCode = scheduleData.created_by_code;
                //hrEmp2.Item.Fname = scheduleData.created_by_fname;
                //hrEmp2.Item.Lname = scheduleData.created_by_lname;
                //HrEmp refDocEmp2 = hrEmp2.Check();

                HrEmpComponent hrEmp = new HrEmpComponent();
                hrEmp.Item.EmpCode = scheduleData.ref_doc_code;
                hrEmp.OrgId = 1;
                HrEmp refDocEmp = hrEmp.GetByCode();
                if(refDocEmp == null)
                {
                    hrEmp.Item.Fname = scheduleData.ref_doc_fname;
                    hrEmp.Item.Lname = scheduleData.ref_doc_lname;
                    refDocEmp =hrEmp.Add();
                }

                //hrEmp.Item.EmpCode = scheduleData.created_by_code;
                //hrEmp.OrgId = 1;
                //HrEmp createEmp = hrEmp.GetByCode();
                //if(createEmp == null)
                //{
                //    hrEmp.Item.Fname = scheduleData.created_by_fname;
                //    hrEmp.Item.Lname = scheduleData.created_by_lname;
                //    createEmp = hrEmp.Add();
                //}

                RisClinicSessionComponent sessionComponent = new RisClinicSessionComponent();
                sessionComponent.OrgId = 1;
                RisClinicSession session = sessionComponent.GetByDate(Convert.ToDateTime(scheduleData.order_dt));
                if(session == null)
                {
                    sessionComponent.Item.Id = 2;
                    session = sessionComponent.GetById();
                }
                string _strExam = "";
                int _dateLenght = 10;
                foreach (ScheduleDtlCheckupData scheduleDtl in scheduleData.exam_list)
                {
                    RisExamComponent examComponent = new RisExamComponent();
                    examComponent.Item.ExamCode = scheduleDtl.exam_code;
                    examComponent.OrgId = 1;
                    RisExam exam = examComponent.GetByCode();
                    if (exam == null)
                    {
                        examComponent.Item.ExamCode = scheduleDtl.exam_code;
                        examComponent.Item.ExamName = scheduleDtl.exam_name;
                        examComponent.Item.Rate = 0;
                        examComponent.Item.TypeId = 1;
                        examComponent.Item.ServiceTypeId = 1;
                        examComponent.Item.SpecialRate = 0;
                        examComponent.Item.UnitId = 1;
                        examComponent.Item.IsActive = true;
                        examComponent.Item.AvgReqHrs = 5;
                        examComponent.Item.MinReqHrs = 5;
                        examComponent.Item.IsUpdated = false;
                        examComponent.Item.IsDeleted = false;
                        examComponent.UserId = 1;// createEmp.Id;
                        exam = examComponent.Add();
                    }

                    _strExam += exam.ExamName + ";";

                    if (exam.MinReqHrs > 10)
                        _dateLenght += Convert.ToInt32(exam.MinReqHrs);
                }
                string _schData = string.Format("HN: {0} {1} {2} ({3})",
                    registration.Hn,
                    registration.Fname + " " + registration.Lname,
                    _strExam,
                    "Checkup");
                ScheduleComponent schedule = new ScheduleComponent();
                schedule.Item.RegId = schedule.ItemLogs.RegId = registration.RegId;
                schedule.Item.ScheduleDt = schedule.ItemLogs.ScheduleDt = Convert.ToDateTime(scheduleData.order_dt);
                schedule.Item.ModalityId = schedule.ItemLogs.ModalityId = 24;//registration.ModalityId;
                schedule.Item.ScheduleData = schedule.ItemLogs.ScheduleData = _schData;
                schedule.Item.SessionId = schedule.ItemLogs.SessionId = session.Id;
                schedule.Item.StartDatetime = schedule.ItemLogs.StartDatetime = Convert.ToDateTime(scheduleData.order_dt);
                schedule.Item.EndDatetime = schedule.ItemLogs.EndDatetime = schedule.Item.StartDatetime.AddMinutes(_dateLenght);
                schedule.Item.RefUnit = schedule.ItemLogs.RefUnit = unit.Id;
                schedule.Item.RefDoc = schedule.ItemLogs.RefDoc = refDocEmp.Id;
                schedule.Item.ClinicalInstruction = schedule.ItemLogs.ClinicalInstruction = scheduleData.clinical_instruction;
                schedule.Item.CreatedBy = schedule.ItemLogs.LogsModifiedBy = 1;// createEmp.Id;
                schedule.Item.EncClinic = schedule.ItemLogs.EncClinic = scheduleData.enc_clinic;
                schedule.Item.EncType = schedule.ItemLogs.EncType = scheduleData.enc_type;
                schedule.Item.OrgId = schedule.ItemLogs.OrgId = 1;
                schedule.Item.CreatedOn = schedule.ItemLogs.LogsModifiedOn = DateTime.Now;
                schedule.Add();

                schedule.ItemLogs.ScheduleId = schedule.Item.ScheduleId;
                schedule.ItemLogs.LogsStatus = "C";
                schedule.ItemLogs.LogsDesc = "Create Checkup";
                schedule.AddLogs();

                foreach (ScheduleDtlCheckupData scheduleDtl in scheduleData.exam_list)
                {
                    RisExamComponent examComponent = new RisExamComponent();
                    examComponent.Item.ExamCode = scheduleDtl.exam_code;
                    examComponent.OrgId = 1;
                    RisExam exam = examComponent.GetByCode();

                    ScheduleDetailComponent scheduleDetail = new ScheduleDetailComponent();
                    scheduleDetail.Item.ScheduleId = scheduleDetail.ItemLogs.ScheduleId = schedule.Item.ScheduleId;
                    scheduleDetail.Item.AvgReqMin = scheduleDetail.ItemLogs.AvgReqMin = Convert.ToInt32(exam.AvgReqHrs);
                    scheduleDetail.Item.BpviewId = scheduleDetail.ItemLogs.BpviewId = 5;
                    scheduleDetail.Item.ExamId = scheduleDetail.ItemLogs.ExamId = exam.Id;
                    scheduleDetail.Item.PatDestId = scheduleDetail.ItemLogs.PatDestId = 1;
                    scheduleDetail.Item.Qty = scheduleDetail.ItemLogs.Qty = 1;
                    scheduleDetail.Item.Rate = scheduleDetail.ItemLogs.Rate = exam.Rate.Value;
                    scheduleDetail.Item.SchedulePriority = scheduleDetail.ItemLogs.SchedulePriority = "R";
                    scheduleDetail.Item.OrgId = 1;
                    scheduleDetail.Item.CreatedBy = 1;// createEmp.Id;
                    scheduleDetail.Item.CreatedOn = schedule.Item.CreatedOn;
                    scheduleDetail.Add();

                    scheduleDetail.ItemLogs.SchedulelogId = schedule.ItemLogs.SchedulelogId;
                    scheduleDetail.AddLogs();
                }
                return new ScheduleResponse()
                {
                    code = 200,
                    message = "Success",
                    pool_id = schedule.Item.ScheduleId
                };
            }
            catch (Exception ex)
            {

                return new ScheduleResponse()
                {
                    code = 500,
                    message = "Error : " + ex.Message,
                    pool_id = 0
                };
            }
        }
        [HttpPost]
        [Route("Set_CancelCheckupAppointment_Xray")]
        public ScheduleResponse Set_CancelCheckupAppointment_Xray([FromBody] dynamic para)
        {
            bool keepLog = Convert.ToBoolean(_configuration.GetValue<string>("Modules:Logging:keepLog")); // read logDb connection string example
            if (keepLog)
            {
                string strCon = @"server=10.58.252.231; database=RIS_CNMITEST;User ID=sa;Password=mira@@1; Persist Security Info=false;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"insert into AAA_LOG_REQUEST
                                    (STR_PARAM,CREATED_ON)
                                    values
                                    (@STR_PARAM,GETDATE())";
                SqlParameter[] param = {
                                                new SqlParameter("@STR_PARAM",para.ToString()),
                                        };
                cmd.Parameters.AddRange(param);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dss = new DataSet();
                da.Fill(dss);
            }

            var cancelData = JsonConvert.DeserializeObject<ScheduleCheckupCancelData>(para.ToString());
            return this.CheckCancelAppointmentXray(cancelData, para.ToString());
        }
        [HttpPost]
        [Route("CheckCancelAppointmentXray")]
        public ScheduleResponse CheckCancelAppointmentXray(ScheduleCheckupCancelData cancelData, string paraString)
        {
            if (string.IsNullOrEmpty(cancelData.pool_id.ToString()))
            {
                return new ScheduleResponse()
                {
                    code = 500,
                    message = "Error Pool Id"
                };
            }

            ScheduleComponent schedule = new ScheduleComponent();
            RisSchedule risSchedule = schedule.Get(cancelData.pool_id);
            schedule.ItemLogs.RegId = risSchedule.RegId;
            schedule.ItemLogs.ScheduleDt = risSchedule.ScheduleDt;
            schedule.ItemLogs.ModalityId = risSchedule.ModalityId;
            schedule.ItemLogs.ScheduleData = risSchedule.ScheduleData;
            schedule.ItemLogs.SessionId = risSchedule.SessionId;
            schedule.ItemLogs.StartDatetime = risSchedule.StartDatetime;
            schedule.ItemLogs.EndDatetime = risSchedule.EndDatetime;
            schedule.ItemLogs.RefUnit = risSchedule.RefUnit;
            schedule.ItemLogs.RefDoc = risSchedule.RefDoc;
            schedule.ItemLogs.ClinicalInstruction = risSchedule.ClinicalInstruction;
            schedule.ItemLogs.EncClinic = risSchedule.EncClinic;
            schedule.ItemLogs.EncType = risSchedule.EncType;
            schedule.ItemLogs.OrgId = risSchedule.OrgId;
            schedule.ItemLogs.LogsModifiedOn = DateTime.Now;
            schedule.ItemLogs.Reason = cancelData.cancel_reason;
            schedule.ItemLogs.ScheduleId = risSchedule.ScheduleId;
            schedule.ItemLogs.LogsStatus = "D";
            schedule.ItemLogs.LogsDesc = "Delete Checkup By " + cancelData.cancel_by_code + ":" + cancelData.cancel_by_name;
            schedule.AddLogs();

            ScheduleDetailComponent scheduleDetail = new ScheduleDetailComponent();
            List<RisScheduleDtl> risScheduleDtl = scheduleDetail.Get(cancelData.pool_id);
            foreach (RisScheduleDtl item in risScheduleDtl)
            {
                scheduleDetail.ItemLogs.ScheduleId = item.ScheduleId;
                scheduleDetail.ItemLogs.AvgReqMin = item.AvgReqMin;
                scheduleDetail.ItemLogs.BpviewId = item.BpviewId;
                scheduleDetail.ItemLogs.ExamId = item.ExamId;
                scheduleDetail.ItemLogs.PatDestId = item.PatDestId;
                scheduleDetail.ItemLogs.Qty = item.Qty;
                scheduleDetail.ItemLogs.Rate = item.Rate;
                scheduleDetail.ItemLogs.SchedulePriority = item.SchedulePriority;
                scheduleDetail.ItemLogs.SchedulelogId = schedule.ItemLogs.SchedulelogId;
                scheduleDetail.AddLogs();

                scheduleDetail.Delete(item.ScheduleId, item.ExamId);
            }

            schedule.Delete(cancelData.pool_id);
            return new ScheduleResponse()
            {
                code = 200,
                message = "Success",
            };
        }

    }
}