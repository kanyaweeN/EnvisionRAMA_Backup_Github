using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetAlert : IBusinessLogic
    {

        private DataSet _resultset;
       
        private string _uid="";

        public ProcessGetAlert()
        {

        }

        public void Invoke()
        {
            AlertSelectData alertdata = new AlertSelectData();
            ResultSet = alertdata.Get(_uid);
            
        }

        public void Invoke2()
        {
            AlertSelectData alertdata = new AlertSelectData();
            ResultSet = alertdata.Get2(Convert.ToInt32(_uid));
          
        }


        public alertObjectCollection SelectData()
        {
            try
            {
                AlertSelectData alertdata = new AlertSelectData();
                ResultSet = alertdata.Get("");
                DataTable dt = ResultSet.Tables[0];
                alertObjectCollection item = new alertObjectCollection();
                int k = 0;
                while (k<dt.Rows.Count)
                {
                    GBL_ALERT itemValue = new GBL_ALERT();
                    itemValue.ALT_ID = Convert.ToInt32(dt.Rows[k]["ALT_DTL_ID"].ToString());
                    itemValue.ALT_UID = (dt.Rows[k]["ALT_UID"].ToString());
                    itemValue.LangID = Convert.ToInt32(dt.Rows[k]["LANG_ID"].ToString());
                    itemValue.AlertText = (dt.Rows[k]["ALT_TEXT"].ToString());
                    itemValue.AlertType = (dt.Rows[k]["ALT_TYPE"].ToString());
                    itemValue.IsActive = (dt.Rows[k]["IS_ACTIVE"].ToString());
                    itemValue.AlertTitle = (dt.Rows[k]["ALT_TITLE"].ToString());
                    itemValue.AlertButton = Convert.ToInt32(dt.Rows[k]["ALT_BUTTON"].ToString());
                    itemValue.CaptionButton1 = (dt.Rows[k]["CAPTION_BTN1"].ToString());
                    itemValue.CaptionButton2 = (dt.Rows[k]["CAPTION_BTN2"].ToString());
                    itemValue.CaptionButton3 = (dt.Rows[k]["CAPTION_BTN3"].ToString());


                    item.Add(itemValue);
                    k++;

                }

                
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        
        public  string UsID
        {
            get { return _uid; }
            set { _uid = value; }
        }



    }

}
