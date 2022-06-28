using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Envision.BusinessLogic.ProcessRead;
using Miracle.Util;
using Envision.Common;

namespace Envision.BusinessLogic
{
    public class Technologist
    {
        private string user;
        private string pass;
        private DataTable dttech;

        private string hn;
        private DateTime fromdate;
        private DateTime todate;

        private DataTable dtworkload;
        private DataTable dtmodality;
        private DataTable dtdemographic;
        private DataTable dthisregis;
        private GBLEnvVariable env = new GBLEnvVariable();

        public Technologist()
        { 
        }

        public bool LoadTechnician()
        {
            bool flag = true;
            ProcessGetHREmp bg = new ProcessGetHREmp();
            bg.HR_EMP.MODE = "UserName";
            bg.HR_EMP.EMP_ID = 0;
            bg.HR_EMP.USER_NAME = USERNAME;
            bg.HR_EMP.UNIT_ID = 0;
            bg.HR_EMP.AUTH_LEVEL_ID = 0;
            bg.Invoke();

            string pass = "";
            if (bg.Result.Tables[0].Rows.Count == 0)
                return false;
            else
                //pass = Secure.Decrypt(bg.Result.Tables[0].Rows[0]["PWD"].ToString());
                pass = Utilities.Decrypt(bg.Result.Tables[0].Rows[0]["PWD"].ToString());
            if (pass != PASSOWRD)
                return false;

            if (flag) dtTech = bg.Result.Tables[0];

            return flag;
        }
        public bool LoadModality()
        {
            try
            {
                #region Show modality with User
                ProcessGetRISScheduleDefaultDestination procDestiantion = new ProcessGetRISScheduleDefaultDestination();
                procDestiantion.RIS_SCHEDULEDEFAULTDESTINATION.EMP_ID = env.UserID;
                procDestiantion.Invoke();
                if (Miracle.Util.Utilities.IsHaveData(procDestiantion.Result))
                {
                    DataTable dtt = new DataTable();
                    ProcessGetRISModality procModality = new ProcessGetRISModality();
                    procModality.Invoke();
                    dtt = procModality.Result.Tables[0];
                    dtmodality = dtt.Clone();
                    dtmodality.AcceptChanges();

                    foreach (DataRow rowHandle in procDestiantion.Result.Tables[1].Rows)
                    {
                        DataView dv = new DataView(dtt);
                        dv.RowFilter = "MODALITY_ID=" + rowHandle["MODALITY_ID"].ToString();
                        DataTable dttTemp = dv.ToTable();
                        if (dttTemp.Rows.Count > 0)
                        {
                            DataRow row = dtmodality.NewRow();
                            for (int i = 0; i < dttTemp.Columns.Count; i++)
                                row[i] = dttTemp.Rows[0][i];
                            dtmodality.Rows.Add(row);
                        }
                        dtmodality.AcceptChanges();
                    }
                    if (dtmodality.Rows.Count == 0)
                    {
                        ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                        dtmodality = process.GetModality();
                    }
                }
                else
                {
                    ProcessGetRISSchedule process = new ProcessGetRISSchedule();
                    dtmodality = process.GetModality();
                }
                #endregion

                //ProcessGetRISModality bg = new ProcessGetRISModality(true);
                //bg.Invoke();
                //dtmodality = bg.Result.Tables[0];
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LoadDemographic(string HN)
        {
            try
            {
                ProcessGetHISRegistration bg = new ProcessGetHISRegistration(HN);
                bg.Invoke();
                dtDemographic = bg.Result.Tables[0];
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LoadModality_forAIMC()
        {
            try
            {
                ProcessGetRISModality bg = new ProcessGetRISModality(true);
                bg.Invoke_forAIMC();
                dtmodality = bg.Result.Tables[0];
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Reset()
        {
            user = "";
            pass = "";

            dttech = null;
            dtworkload = null;
        }

        public string USERNAME
        {
            get { return user; }
            set { user = value; }
        }
        public string PASSOWRD
        {
            get { return pass; }
            set { pass = value; }
        }
        public DataTable dtTech
        {
            get { return dttech; }
            set { dttech = value; }
        }

        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
        public DateTime FromDate
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        public DateTime ToDate
        {
            get { return todate; }
            set { todate = value; }
        }
        public DataTable dtWorkload
        {
            get { return dtworkload; }
            set { dtworkload = value; }
        }
        public DataTable dtModality
        {
            get { return dtmodality; }
            set { dtmodality = value; }
        }
        public DataTable dtDemographic
        {
            get { return dtdemographic; }
            set { dtdemographic = value; }
        }
        public DataTable dtHisRegistration
        {
            get { return dthisregis; }
            set { dthisregis = value; }
        }
    }
}
