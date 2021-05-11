using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using RIS.Common.Common;


namespace RIS.BusinessLogic
{
    public class ViewPerformance
    {
        private DateTime dtTodayNow;
        private DataSet ds=new DataSet();
        private string minOrder = "00:00:00";
        private string maxOrder = "00:00:00";
        private string minOrderAll = "00:00:00";
        private string maxOrderAll = "00:00:00";
        private string lastTook = "00:00:00";
        GBLEnvVariable env = new GBLEnvVariable();


        public ViewPerformance(DateTime dtNow) {
            dtTodayNow = dtNow;
            InitData();
        }

        private void InitData() {
            //dtTodayNow=dtTodayNow.AddDays(-3); ต้องลบออก***************************

            #region หา Max, Min เฉพาะ Order 
            ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
            DataTable dtt = process.Get7Days(103, dtTodayNow, env.UserID);
            if (dtt.Rows.Count > 0)
            {
                dtt.Columns.Add("minus", typeof(TimeSpan));
                foreach (DataRow dr in dtt.Rows)
                {
                    DateTime dt1 = Convert.ToDateTime(dr[0]);
                    DateTime dt2 = Convert.ToDateTime(dr[1]);
                    dr[2] = dt2.Subtract(dt1);
                }
                //find min ของ user 
                TimeSpan ts = (TimeSpan)dtt.Rows[0][2];
                foreach (DataRow dr in dtt.Rows)
                {
                    TimeSpan tsTmp = (TimeSpan)dr[2];

                    int i = TimeSpan.Compare(ts, tsTmp);
                    if (i == 1)
                        ts = tsTmp;

                }
                minOrder = ts.ToString();
                //fine max ของ user 
                ts = (TimeSpan)dtt.Rows[0][2];
                foreach (DataRow dr in dtt.Rows)
                {
                    TimeSpan tsTmp = (TimeSpan)dr[2];
                    int i = TimeSpan.Compare(ts, tsTmp);
                    if (i == -1)
                        ts = tsTmp;
                }
                maxOrder = ts.ToString();

                minOrder = minOrder.Substring(0, 8);
                maxOrder = maxOrder.Substring(0, 8);
            } 
            #endregion

            #region หา Max, Min ทั้งหมด 
            dtt = process.Get7Days(102, dtTodayNow, env.UserID);
            if (dtt.Rows.Count > 0)
            {
                dtt.Columns.Add("minus", typeof(TimeSpan));
                foreach (DataRow dr in dtt.Rows)
                {
                    DateTime dt1 = Convert.ToDateTime(dr[0]);
                    DateTime dt2 = Convert.ToDateTime(dr[1]);
                    dr[2] = dt2.Subtract(dt1);
                }
                //find min ของทั้งหมด
                TimeSpan ts = (TimeSpan)dtt.Rows[0][2];
                foreach (DataRow dr in dtt.Rows)
                {
                    TimeSpan tsTmp = (TimeSpan)dr[2];

                    int i = TimeSpan.Compare(ts, tsTmp);
                    if (i == 1)
                        ts = tsTmp;

                }
                minOrderAll = ts.ToString();
                minOrderAll = minOrderAll.Replace('-', ' ');
                //fine max ของทั้งหมด
                ts = (TimeSpan)dtt.Rows[0][2];
                foreach (DataRow dr in dtt.Rows)
                {
                    TimeSpan tsTmp = (TimeSpan)dr[2];
                    int i = TimeSpan.Compare(ts, tsTmp);
                    if (i == -1)
                        ts = tsTmp;
                }
                maxOrderAll = ts.ToString();
                maxOrderAll = maxOrderAll.Replace('-', ' ');

                minOrderAll = minOrderAll.Trim().Substring(0, 8);
                maxOrderAll = maxOrderAll.Trim().Substring(0, 8);
            } 
            #endregion

            #region หา Last Took Order 
            dtt = process.Get7Days(104, dtTodayNow, env.UserID);
            if (dtt.Rows.Count > 0)
            {
                 dtt.Columns.Add("minus", typeof(TimeSpan));
                 DateTime dt1 = Convert.ToDateTime(dtt.Rows[0][0]);
                 DateTime dt2 = Convert.ToDateTime(dtt.Rows[0][1]);
                 dtt.Rows[0][2] = dt2.Subtract(dt1);
                 lastTook = dtt.Rows[0][2].ToString();
                 lastTook = lastTook.Substring(0, 8);
            } 
            #endregion
        }

        public string FullName {
            get { return new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName; }
        }

        public string LastOrderTook{
            get { return lastTook; }
        }

        public string MinOrderToday
        {
            get { return minOrder; }
        }
        public string MaxOrderToday
        {
            get { return maxOrder; }
        }

        public string MinOrderAll
        {
            get { return minOrderAll; }
          
        }
        public string MaxOrderAll
        {
            get { return maxOrderAll; }
        }

        public DataTable In7Days(int RegID) {
            DataTable dtt = new DataTable("7Days");
            DateTime dt = dtTodayNow;
            dtt.Columns.Add("Day", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            for (int i = 0; i < 7; i++)
            {

                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtPer = new DataTable();
                if (RegID == 0)
                    dtPer = process.Get7Days(100, dt, RegID);
                else
                    dtPer = process.Get7Days(101, dt, RegID);
                DataRow dr = dtt.NewRow();
                dr["Day"] = dt.ToString("dd/MM/yyyy");
                if (dtPer.Rows.Count == 0)
                    dr["Amt"] = 0;
                else
                    dr["Amt"] = dtPer.Rows[0]["amount"];
                dt = dt.AddDays(-1);
                dtt.Rows.Add(dr);
            }
            return dtt; 
        }
        public DataSet In7DaysCompare(int RegID)
        {
            #region Old Code 
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable("7DaysCompare");
            DateTime dt = dtTodayNow;
            dtt.Columns.Add("Day", typeof(string));
            dtt.Columns.Add("Min", typeof(decimal));
            dtt.Columns.Add("Max", typeof(decimal));
            for (int i = 0; i < 7; i++)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtPer = process.Get7Days(2, dt, RegID);
                DataRow dr = dtt.NewRow();
                dr["Day"] = dt.ToString("dd/MM/yyyy");
                if (dtPer.Rows.Count == 0)
                {
                    dr["Min"] = 0;
                    dr["Max"] = 0;
                }
                else
                {
                    try
                    {
                        dr["Min"] = dtPer.Rows[0]["minPer"].ToString().Trim() == string.Empty ? 0M : Convert.ToDecimal(dtPer.Rows[0]["minPer"]);
                        dr["Max"] = dtPer.Rows[0]["maxPer"].ToString().Trim() == string.Empty ? 0M : Convert.ToDecimal(dtPer.Rows[0]["maxPer"]);
                    }
                    catch (Exception ex)
                    {
                        dr["Min"] = 0;
                        dr["Max"] = 0;
                    }
                }
                dtt.Rows.Add(dr);
                dt = dt.AddDays(-1);
            }
            ds.Tables.Add(dtt);
            ds.Tables[0].TableName = "7DaysCompare";
            DataTable dtComp = dtt.Clone();
            dt = dtTodayNow;
            for (int i = 0; i < 7; i++)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtPer = process.Get7Days(3, dt, RegID);
                DataRow dr = dtComp.NewRow();
                dr["Day"] = dt.ToString("dd/MM/yyyy");
                if (dtPer.Rows.Count == 0)
                {
                    dr["Min"] = 0;
                    dr["Max"] = 0;
                }
                else
                {
                    dr["Min"] = dtPer.Rows[0]["minPer"].ToString().Trim() == string.Empty ? 0M : Convert.ToDecimal(dtPer.Rows[0]["minPer"]);
                    dr["Max"] = dtPer.Rows[0]["maxPer"].ToString().Trim() == string.Empty ? 0M : Convert.ToDecimal(dtPer.Rows[0]["maxPer"]);
                }
                dtComp.Rows.Add(dr);
                dt = dt.AddDays(-1);
            }

            dtComp.TableName = "7DaysCompareAll";
            ds.Tables.Add(dtComp);
            return ds; 
            #endregion
        }

        #region WorkLoad 

        public DataTable DataOrderWeek()
        {
            DataTable dtt = new DataTable("OrderWeek");
            dtt.Columns.Add("Day", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Sunday.ToString();
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Monday.ToString();
            dr["Amt"] = 150;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Tuesday.ToString();
            dr["Amt"] = 300;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Wednesday.ToString();
            dr["Amt"] = 470;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Thursday.ToString();
            dr["Amt"] = 100;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Friday.ToString();
            dr["Amt"] = 130;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Saturday.ToString();
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataOrderWeekCompare()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 1200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 220;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataOrderWeekCompareSummary()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 2500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 3500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 1500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 2000;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataOrderMonth()
        {
            DataTable dtt = new DataTable("OrderMonth");
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));

            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 300;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 544;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 322;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 342;
            dtt.Rows.Add(dr);

            return dtt;
        }
        public DataTable DataOrderMonthCompare()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 1200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 220;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataOrderMonthCompareSummary()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 2500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 3500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 1500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 2000;
            dtt.Rows.Add(dr);
            return dtt;
        }


        public DataTable DataExamWeek()
        {
            DataTable dtt = new DataTable("OrderWeek");
            dtt.Columns.Add("Day", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Sunday.ToString();
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Monday.ToString();
            dr["Amt"] = 150;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Tuesday.ToString();
            dr["Amt"] = 300;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Wednesday.ToString();
            dr["Amt"] = 470;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Thursday.ToString();
            dr["Amt"] = 100;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Friday.ToString();
            dr["Amt"] = 130;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Day"] = DayOfWeek.Saturday.ToString();
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataExamWeekCompare()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 1200;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 220;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataExamWeekCompareSummary()
        {
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));
            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 2500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 3500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 1500;
            dtt.Rows.Add(dr);
            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 2000;
            dtt.Rows.Add(dr);
            return dtt;
        }
        public DataTable DataExamMonth()
        {
            DataTable dtt = new DataTable("OrderMonth");
            dtt.Columns.Add("Week", typeof(string));
            dtt.Columns.Add("Amt", typeof(decimal));

            DataRow dr = dtt.NewRow();
            dr["Week"] = "Week 1";
            dr["Amt"] = 700;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr["Week"] = "Week 2";
            dr["Amt"] = 1234;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr["Week"] = "Week 3";
            dr["Amt"] = 244;
            dtt.Rows.Add(dr);

            dr = dtt.NewRow();
            dr["Week"] = "Week 4";
            dr["Amt"] = 4224;
            dtt.Rows.Add(dr);

            return dtt;
        }
        public DataTable DataExamMonthCompare()
        {
            return new DataTable();
        } 
        #endregion

        public DataSet In7DaysComparable(){
            DataSet ds = new DataSet();
            DataTable dttYouMin = new DataTable("YouMin");
            DataTable dttYouMax = new DataTable("YouMax");
            DataTable dttAllMin = new DataTable("AllMin");
            DataTable dttAllMax = new DataTable("AllMax");
            dttYouMin.Columns.Add("Day", typeof(string));
            dttYouMin.Columns.Add("Min", typeof(decimal));
            dttYouMax.Columns.Add("Day", typeof(string));
            dttYouMax.Columns.Add("Max", typeof(decimal));
            dttAllMin.Columns.Add("Day", typeof(string));
            dttAllMin.Columns.Add("Min", typeof(decimal));
            dttAllMax.Columns.Add("Day", typeof(string));
            dttAllMax.Columns.Add("Max", typeof(decimal));
            DateTime dt = dtTodayNow;
            for (int i = 0; i < 7; i++)
            {
                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtt = null;
                DataRow drAdd = null;
                long min = 0;
                long max = 0;
                long tmp = 0;

                dtt = process.Get7Days(106, dt, env.UserID);
                #region หา YouMin 
                drAdd = dttYouMin.NewRow();
                drAdd["Day"] = dt.ToString("dd/MM/yyyy");
                if (dtt.Rows.Count > 0)
                {
                    min = Convert.ToInt64(dtt.Rows[0][1]);
                    foreach (DataRow dr in dtt.Rows)
                    {
                        tmp = Convert.ToInt64(dr[1]);
                        if (tmp < min)
                            min = tmp;
                    }
                    drAdd["Min"] = min;
                }
                else
                    drAdd["Min"] = 0;
                dttYouMin.Rows.Add(drAdd);
                #endregion            

                #region หา YouMax 
                drAdd = dttYouMax.NewRow();
                drAdd["Day"] = dt.ToString("dd/MM/yyyy");

                if (dtt.Rows.Count > 0)
                {
                    max = Convert.ToInt64(dtt.Rows[0][1]);
                    foreach (DataRow dr in dtt.Rows)
                    {
                        tmp = Convert.ToInt64(dr[1]);
                        if (tmp > max)
                            max = tmp;
                    }
                    drAdd["Max"] = max;
                }
                else
                    drAdd["Max"] = 0;
                dttYouMax.Rows.Add(drAdd);
                #endregion

                dtt = process.Get7Days(105, dt, env.UserID);
                #region หา AllMin 
                drAdd = dttAllMin.NewRow();
                drAdd["Day"] = dt.ToString("dd/MM/yyyy");
                if (dtt.Rows.Count > 0)
                {
                    if (dtt.Rows[0][0].ToString() == string.Empty)
                        min = 0;
                    else
                        min = Convert.ToInt64(dtt.Rows[0][0]);
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr[0].ToString() == string.Empty)
                            min = 0;
                        else
                            tmp = Convert.ToInt64(dr[0]);
                        if (tmp < min)
                            min = tmp;
                    }
                    drAdd["Min"] = min;
                }
                else
                    drAdd["Min"] = 0;
                dttAllMin.Rows.Add(drAdd);
                #endregion

                #region หา AllMax 
                drAdd = dttAllMax.NewRow();
                drAdd["Day"] = dt.ToString("dd/MM/yyyy");
                if (dtt.Rows.Count > 0)
                {
                    if (dtt.Rows[0][0].ToString() == string.Empty)
                        max = 0;
                    else
                        max = Convert.ToInt64(dtt.Rows[0][0]);
                    foreach (DataRow dr in dtt.Rows)
                    {
                        if (dr[0].ToString() == string.Empty)
                            min = 0;
                        else
                            tmp = Convert.ToInt64(dr[0]);
                        if (tmp > max)
                            max = tmp;
                    }
                    drAdd["Max"] = max;
                }
                else
                    drAdd["Max"] = 0;
                dttAllMax.Rows.Add(drAdd);
                #endregion

                dt = dt.AddDays(-1);
            }
            ds.Tables.Add(dttYouMin);
            ds.Tables.Add(dttYouMax);
            ds.Tables.Add(dttAllMin);
            ds.Tables.Add(dttAllMax);
            return ds;
        }
    }
}
