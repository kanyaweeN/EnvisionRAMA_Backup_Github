using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

using Miracle.ScannerNew;
using RIS.Common.Common;
using RIS.Operational;
using RIS.Common;

namespace RIS.BusinessLogic
{
    public class ScanImage
    {
        private GBLEnvVariable env = new GBLEnvVariable();

        public ScanImage(string hn, int orderno)
        {
            byte index = 0;

            for (int i = 0; i < PointerStruct.MaxScanner; i++)
            {
                if (env.PixPicture[i].Pix != IntPtr.Zero || env.PixPicture[i].Bmp != IntPtr.Zero)
                {
                    index++;

                    string image_name = new ExternalFiles().SendPicture(orderno.ToString(), env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                    ordimg.HN = hn;
                    ordimg.ORDER_ID = orderno;
                    ordimg.SL_NO = index;
                    ordimg.IMAGE_NAME = image_name;
                    ordimg.ORG_ID = env.OrgID;
                    ordimg.CREATED_BY = env.UserID;

                    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                    addimg.RIS_ORDERIMAGE = ordimg;
                    addimg.Invoke();
                }
            }
        }
        public ScanImage(string hn, int orderno, DataTable dtt)
        {
            ProcessGetRISOrderimages processImage = new ProcessGetRISOrderimages();
            processImage.RIS_ORDERIMAGE.ORDER_ID = orderno;
            processImage.Invoke();
            DataTable dttImg = processImage.Result.Tables[0].Copy();

            ProcessUpdateRISOrderimages process = new ProcessUpdateRISOrderimages();
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["ORDER_IMAGE_ID"].ToString().Trim() != string.Empty)
                {
                    if (dr["IS_DELETED"].ToString() == "Y")
                    {
                        process.RIS_ORDERIMAGE.ORDER_IMAGE_ID = Convert.ToInt32(dr["ORDER_IMAGE_ID"]);
                        process.RIS_ORDERIMAGE.IS_DELETED = 'Y';
                        process.RIS_ORDERIMAGE.LAST_MODIFIED_BY = env.UserID;
                        process.Invoke();
                    }
                }
            }

            byte index = 0;

            foreach (DataRow dr in dtt.Rows)
            {
                byte tmp = 0;
                tmp = string.IsNullOrEmpty(dr["SL_NO"].ToString()) ? tmp : Convert.ToByte(dr["SL_NO"].ToString());
                if (index < tmp) index = tmp;
            }

            for (int i = 0; i < PointerStruct.MaxScanner; i++)
            {
                if (env.PixPicture[i].Pix != IntPtr.Zero || env.PixPicture[i].Bmp != IntPtr.Zero)
                {
                    index++;

                    string image_name = new ExternalFiles().SendPicture(orderno.ToString(), env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                    ordimg.HN = hn;
                    ordimg.ORDER_ID = orderno;
                    ordimg.SL_NO = index;
                    ordimg.IMAGE_NAME = image_name;
                    ordimg.ORG_ID = env.OrgID;
                    ordimg.CREATED_BY = env.UserID;
                    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                    addimg.RIS_ORDERIMAGE = ordimg;
                    addimg.Invoke();
                }
            }
        }

        public ScanImage(string hn, int scheduleid, string caseSchedule)
        {
            byte index = 0;
            for (int i = 0; i < PointerStruct.MaxScanner; i++)
            {
                if (env.PixPicture[i].Pix != IntPtr.Zero || env.PixPicture[i].Bmp != IntPtr.Zero)
                {
                    index++;

                    string image_name = new ExternalFiles().SendPicture("S" + scheduleid.ToString(), env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                    ordimg.HN = hn;
                    ordimg.SCHEDULE_ID = scheduleid;
                    ordimg.ORDER_ID = 0;
                    ordimg.SL_NO = index;
                    ordimg.IMAGE_NAME = image_name;
                    ordimg.ORG_ID = env.OrgID;
                    ordimg.CREATED_BY = env.UserID;
                    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                    addimg.RIS_ORDERIMAGE = ordimg;
                    addimg.Invoke();
                }
            }
        }
        public ScanImage(string hn, int scheduleid, DataTable dtt, string caseSchedule)
        {
            List<string> fname = new List<string>();
            foreach (DataRow dr in dtt.Rows)
                fname.Add(dr["IMAGE_NAME"].ToString());
            ProcessUpdateRISOrderimages process = new ProcessUpdateRISOrderimages();
            foreach (DataRow dr in dtt.Rows)
            {
                if (dr["ORDER_IMAGE_ID"].ToString().Trim() != string.Empty)
                {
                    if (dr["IS_DELETED"].ToString() == "Y")
                    {
                        process.RIS_ORDERIMAGE.ORDER_IMAGE_ID = Convert.ToInt32(dr["ORDER_IMAGE_ID"]);
                        process.RIS_ORDERIMAGE.IS_DELETED = 'Y';
                        process.RIS_ORDERIMAGE.LAST_MODIFIED_BY = env.UserID;
                        process.Invoke();
                    }
                }
            }
            byte index = 0;
            foreach (DataRow dr in dtt.Rows)
            {
                byte tmp = 0;
                tmp = string.IsNullOrEmpty(dr["SL_NO"].ToString()) ? tmp : Convert.ToByte(dr["SL_NO"].ToString());
                if (index < tmp) index = tmp;
            }
            for (int i = 0; i < PointerStruct.MaxScanner; i++)
            {
                if (env.PixPicture[i].Pix != IntPtr.Zero || env.PixPicture[i].Bmp != IntPtr.Zero)
                {
                    index++;

                    string image_name = new ExternalFiles().SendPicture("S" + scheduleid.ToString(), env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                    ordimg.HN = hn;
                    ordimg.SCHEDULE_ID = scheduleid;
                    ordimg.ORDER_ID = 0;
                    ordimg.SL_NO = index;
                    ordimg.IMAGE_NAME = image_name;
                    ordimg.ORG_ID = env.OrgID;
                    ordimg.CREATED_BY = env.UserID;
                    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                    addimg.RIS_ORDERIMAGE = ordimg;
                    addimg.Invoke();
                }
            }
        }
    }
}
