using System;
using System.Data;
using System.Globalization;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.Common;
using Envision.WebService;
using Miracle.Util;

namespace Envision.BusinessLogic
{
    public class ScanImages
    {
        private GBLEnvVariable env = new GBLEnvVariable();

        public ScanImages() { }

        public DataView GetData(int scheduleId, int orderId)
        {
            ProcessGetRISOrderimages prc = new ProcessGetRISOrderimages();
            prc.RIS_ORDERIMAGE.SCHEDULE_ID = scheduleId;
            prc.RIS_ORDERIMAGE.ORDER_ID = orderId;
            prc.Invoke();

            return prc.Result.Tables[0].Copy().DefaultView;
        }

        public void Invoke(string hn, int scheduleId, int orderId, DataView data)
        {
            if (!Utilities.IsHaveData(data))
                return;

            RIS_ORDERIMAGE order_image = new RIS_ORDERIMAGE()
            {
                HN = hn,
                SCHEDULE_ID = scheduleId,
                ORDER_ID = orderId,
                ORG_ID = env.OrgID,
                LAST_MODIFIED_BY = env.UserID,
            };

            foreach (DataRowView row in data)
            {
                if (ToInt(row["ORDER_IMAGE_ID"]) == 0)
                {
                    if (ToChar(row["IS_DELETED"], 'N') == 'N')
                    {
                        string temp_image_name = row["IMAGE_NAME"].ToString();
                        string temp_image_extension = temp_image_name.Substring(temp_image_name.LastIndexOf('.'), temp_image_name.Length - temp_image_name.LastIndexOf('.'));
                        string image_name = string.Format(
                            CultureInfo.GetCultureInfo("th-TH"),
                            "{0:yyyy}\\{0:MMdd}\\{1}_{0:yyyyMMddHHmmssfff}{2}",
                            DateTime.Now,
                            order_image.ORDER_ID == 0
                                ? "S" + order_image.SCHEDULE_ID.ToString()
                                : order_image.ORDER_ID.ToString(),
                            temp_image_extension);

                        ProcessAddRISOrderimages prc_add = new ProcessAddRISOrderimages();
                        prc_add.RIS_ORDERIMAGE = order_image;
                        if (prc_add.RIS_ORDERIMAGE.SCHEDULE_ID == 0)
                            prc_add.RIS_ORDERIMAGE.SCHEDULE_ID = ToInt(row["SCHEDULE_ID"]);
                        if (prc_add.RIS_ORDERIMAGE.ORDER_ID == 0)
                            prc_add.RIS_ORDERIMAGE.ORDER_ID = ToInt(row["ORDER_ID"]);
                        prc_add.RIS_ORDERIMAGE.IMAGE_NAME = image_name;
                        prc_add.RIS_ORDERIMAGE.IS_DELETED = 'N';
                        prc_add.Invoke();

                        new EnvisionWebService(env.WebServiceIP).MoveFile(
                            string.Format("{0}{1}", env.ScannedImagePath, temp_image_name),
                            string.Format("{0}{1}", env.ScannedImagePath, image_name));
                    }
                }
                else
                {
                    ProcessUpdateRISOrderimages prc_update = new ProcessUpdateRISOrderimages();
                    prc_update.RIS_ORDERIMAGE = order_image;

                    if (ToChar(row["IS_DELETED"], 'N') == 'N')
                    {
                        prc_update.RIS_ORDERIMAGE.ORDER_IMAGE_ID = ToInt(row["ORDER_IMAGE_ID"]);
                        if (prc_update.RIS_ORDERIMAGE.SCHEDULE_ID == 0)
                            prc_update.RIS_ORDERIMAGE.SCHEDULE_ID = ToInt(row["SCHEDULE_ID"]);
                        if (prc_update.RIS_ORDERIMAGE.ORDER_ID == 0)
                            prc_update.RIS_ORDERIMAGE.ORDER_ID = ToInt(row["ORDER_ID"]);
                        prc_update.RIS_ORDERIMAGE.IMAGE_NAME = row["IMAGE_NAME"].ToString();
                        prc_update.RIS_ORDERIMAGE.IS_DELETED = 'N';
                        prc_update.Invoke();
                    }
                    else
                    {
                        prc_update.RIS_ORDERIMAGE.ORDER_IMAGE_ID = ToInt(row["ORDER_IMAGE_ID"]);
                        prc_update.RIS_ORDERIMAGE.IS_DELETED = 'Y';
                        prc_update.InvokeIsDeleted();
                    }
                }
            }
        }

        public static int ToInt(object value) { return ToInt((value ?? string.Empty).ToString()); }
        public static int ToInt(string value)
        {
            int result = 0;

            int.TryParse(value, out result);

            return result;
        }
        public static char ToChar(object value) { return ToChar((value ?? string.Empty).ToString(), char.MinValue); }
        public static char ToChar(string value) { return ToChar(value, char.MinValue); }
        public static char ToChar(object value, char defaultValue) { return ToChar((value ?? string.Empty).ToString(), defaultValue); }
        public static char ToChar(string value, char defaultValue)
        {
            char result;

            if (!char.TryParse(value, out result) || result == char.MinValue)
                result = defaultValue;

            return result;
        }
    }
}