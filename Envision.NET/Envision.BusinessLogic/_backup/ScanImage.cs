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

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.WebService.ImageStoreService;
using Miracle.Scanner;
namespace Envision.BusinessLogic
{
    public class ScanImage
    {
        GBLEnvVariable env = new GBLEnvVariable();


        public ScanImage(string hn, int orderno)
        {
            try
            {
                byte index = 0;
                for (int i = 0; i < PointerStruct.MaxScanner; i++)
                {
                    if (env.PixPicture[i].Pix != IntPtr.Zero || env.PixPicture[i].Bmp != IntPtr.Zero)
                    {
                        index++;
                        string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                        string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
                        string sfile = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + month + day + "_" + index.ToString() + ".jpg";
                        string filename = env.ScannedImagePath + sfile;
                        CallWebService(filename, env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                        RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                        ordimg.PATIENT_ID = hn;
                        ordimg.ORDER_ID = orderno;
                        ordimg.SL_NO = index;
                        ordimg.IMAGE_NAME = sfile;
                        ordimg.ORG_ID = env.OrgID;
                        ordimg.CREATED_BY = env.UserID;
                        ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                        addimg.RIS_ORDERIMAGE = ordimg;
                        addimg.Invoke();
                    }
                }


                #region OLD_CODE.
                //GBLEnvVariable env = new GBLEnvVariable();
                //string a = env.CountImg;
                //string _path = env.ScannedImagePath;
                //int count = Convert.ToInt32(a);
                //string m, d;
                //if (count == 1)
                //{
                //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

                //    string sfile = orderno.ToString() + "_" + DateTime.Today.Year.ToString() +  m + d + "_1.jpg";
                //    string filename = env.ScannedImagePath + sfile;

                //    CallWebService(filename, env.BmpPic, env.PixPic);
                //    env.CountImg = "";

                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;

                //    ordimg.ORDER_ID = orderno;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = sfile;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;

                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();



                //}
                //if (count == 2)
                //{
                //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

                //    string sfile = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m +  d + "_1.jpg";
                //    string filename = env.ScannedImagePath + sfile;

                //    string sfile2 = orderno.ToString() + "_" + DateTime.Today.Year.ToString()+ m +  d + "_2.jpg";
                //    string filename2 = env.ScannedImagePath + sfile2;

                //    CallWebService(filename, env.BmpPic, env.PixPic);
                //    CallWebService(filename2, env.BmpPic2, env.PixPic2);
                //    env.CountImg = "";

                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;
                //    ordimg.ORDER_ID = orderno;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = sfile;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();

                //    RIS_ORDERIMAGE ordimg2 = new RIS_ORDERIMAGE();
                //    ordimg2.PATIENT_ID = hn;
                //    ordimg2.ORDER_ID = orderno;
                //    ordimg2.SL_NO = 2;
                //    ordimg2.IMAGE_NAME = sfile2;
                //    ordimg2.ORG_ID = env.OrgID;
                //    ordimg2.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg2 = new ProcessAddOrderImages();
                //    addimg2.RIS_ORDERIMAGE = ordimg2;
                //    addimg2.Invoke();


                //}
                //if (count == 3)
                //{
                //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

                //    string sfile = orderno.ToString() + "_" + DateTime.Today.Year.ToString()  + m +  d + "_1.jpg";
                //    string filename = env.ScannedImagePath + sfile;

                //    string sfile2 = orderno.ToString() + "_" + DateTime.Today.Year.ToString() +  m + d + "_2.jpg";
                //    string filename2 = env.ScannedImagePath + sfile2;

                //    string sfile3 = orderno.ToString() + "_" + DateTime.Today.Year.ToString() +  m + d + "_3.jpg";
                //    string filename3 = env.ScannedImagePath + sfile3;

                //    CallWebService(filename, env.BmpPic, env.PixPic);
                //    CallWebService(filename2, env.BmpPic2, env.PixPic2);
                //    CallWebService(filename3, env.BmpPic3, env.PixPic3);
                //    env.CountImg = "";

                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;
                //    ordimg.ORDER_ID = orderno;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = sfile;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();

                //    RIS_ORDERIMAGE ordimg2 = new RIS_ORDERIMAGE();
                //    ordimg2.PATIENT_ID = hn;
                //    ordimg2.ORDER_ID = orderno;
                //    ordimg2.SL_NO = 2;
                //    ordimg2.IMAGE_NAME = sfile2;
                //    ordimg2.ORG_ID = env.OrgID;
                //    ordimg2.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg2 = new ProcessAddOrderImages();
                //    addimg2.RIS_ORDERIMAGE = ordimg2;
                //    addimg2.Invoke();

                //    RIS_ORDERIMAGE ordimg3 = new RIS_ORDERIMAGE();
                //    ordimg3.PATIENT_ID = hn;
                //    ordimg3.ORDER_ID = orderno;
                //    ordimg3.SL_NO = 3;
                //    ordimg3.IMAGE_NAME = sfile3;
                //    ordimg3.ORG_ID = env.OrgID;
                //    ordimg3.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg3 = new ProcessAddOrderImages();
                //    addimg3.RIS_ORDERIMAGE = ordimg3;
                //    addimg3.Invoke();
                //} 
                #endregion
            }
            catch (Exception err) 
            {
                MessageBox.Show("ไม่สามารถทำการบันทึกใบแสกนได้ กรุณาติดต่อเจ้าหน้าที่ : " + err.Message, "ไม่สามารถทำการบันทึกใบแสกนได้", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
            
        }
        public ScanImage(string hn, int orderno, DataTable dtt){
            try
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
                        string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                        string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
                        string sfile = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + month + day + "_" + index.ToString() + ".jpg";
                        string filename = env.ScannedImagePath + sfile;
                        CallWebService(filename, env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                        RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                        ordimg.PATIENT_ID = hn;
                        ordimg.ORDER_ID = orderno;
                        ordimg.SL_NO = index;
                        ordimg.IMAGE_NAME = sfile;
                        ordimg.ORG_ID = env.OrgID;
                        ordimg.CREATED_BY = env.UserID;
                        ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                        addimg.RIS_ORDERIMAGE = ordimg;
                        addimg.Invoke();
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("ไม่สามารถทำการบันทึกใบแสกนได้ กรุณาติดต่อเจ้าหน้าที่ : " + ex.Message, "ไม่สามารถทำการบันทึกใบแสกนได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region OLD CODE.
            //Envision.BusinessLogic.ProcessRead.ProcessGetRISOrderimages processImage = new Envision.BusinessLogic.ProcessRead.ProcessGetRISOrderimages();
            //processImage.RIS_ORDERIMAGE.ORDER_ID = orderno;
            //processImage.Invoke();
            //DataTable dttImg = processImage.Result.Tables[0].Copy();

            //ProcessUpdateRISOrderimages process = new ProcessUpdateRISOrderimages();
            //foreach (DataRow dr in dtt.Rows)
            //{
            //    if (dr["ORDER_IMAGE_ID"].ToString().Trim() != string.Empty)
            //    {
            //        if (dr["IS_DELETED"].ToString() == "Y")
            //        {
            //            process.RIS_ORDERIMAGE.ORDER_IMAGE_ID = Convert.ToInt32(dr["ORDER_IMAGE_ID"]);
            //            process.RIS_ORDERIMAGE.IS_DELETED = 'Y';
            //            process.RIS_ORDERIMAGE.LAST_MODIFIED_BY = env.UserID;
            //            process.Invoke();
            //        }
            //    }
            //}
            //string m, d;
            //m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
            //d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
            //string fileName = string.Empty;
            //if (env.PixPic != IntPtr.Zero || env.BmpPic != IntPtr.Zero)
            //{
            //    //fileName =  orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_1_1.jpg";
            //    fileName = createName(dttImg, orderno);
            //    CallWebService(env.ScannedImagePath + fileName, env.BmpPic, env.PixPic);
            //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
            //    ordimg.PATIENT_ID = hn;
            //    ordimg.ORDER_ID = orderno;
            //    ordimg.SL_NO = 1;
            //    ordimg.IMAGE_NAME = fileName;
            //    ordimg.ORG_ID = env.OrgID;
            //    ordimg.CREATED_BY = env.UserID;
            //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
            //    addimg.RIS_ORDERIMAGE = ordimg;
            //    addimg.Invoke();
            //}
            //if (env.PixPic2 != IntPtr.Zero || env.BmpPic2!=IntPtr.Zero) {
            //    //fileName = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_1_2.jpg";
            //    fileName = createName(dttImg, orderno);
            //    CallWebService(env.ScannedImagePath + fileName, env.BmpPic2, env.PixPic2);
            //    RIS_ORDERIMAGE ordimg2 = new RIS_ORDERIMAGE();
            //    ordimg2.PATIENT_ID = hn;
            //    ordimg2.ORDER_ID = orderno;
            //    ordimg2.SL_NO = 2;
            //    ordimg2.IMAGE_NAME = fileName;
            //    ordimg2.ORG_ID = env.OrgID;
            //    ordimg2.CREATED_BY = env.UserID;
            //    ProcessAddOrderImages addimg2 = new ProcessAddOrderImages();
            //    addimg2.RIS_ORDERIMAGE = ordimg2;
            //    addimg2.Invoke();
            //}
            //if (env.PixPic3 != IntPtr.Zero || env.BmpPic3 != IntPtr.Zero)
            //{
            //    //fileName =  orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_1_3.jpg";
            //    fileName = createName(dttImg, orderno);
            //    CallWebService(env.ScannedImagePath + fileName, env.BmpPic3, env.PixPic3);
            //    RIS_ORDERIMAGE ordimg3 = new RIS_ORDERIMAGE();
            //    ordimg3.PATIENT_ID = hn;
            //    ordimg3.ORDER_ID = orderno;
            //    ordimg3.SL_NO = 3;
            //    ordimg3.IMAGE_NAME = fileName;
            //    ordimg3.ORG_ID = env.OrgID;
            //    ordimg3.CREATED_BY = env.UserID;
            //    ProcessAddOrderImages addimg3 = new ProcessAddOrderImages();
            //    addimg3.RIS_ORDERIMAGE = ordimg3;
            //    addimg3.Invoke();
            //} 
            #endregion
        }

        public ScanImage(string hn, int scheduleid, string caseSchedule)
        {
            try
            {
                byte index = 0;
                for (int i = 0; i < PointerStruct.MaxScanner; i++)
                {
                    if (env.PixPicture[i].Pix != IntPtr.Zero || env.PixPicture[i].Bmp != IntPtr.Zero)
                    {
                        index++;
                        string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                        string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
                        string sfile = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + month + day + "_S" + index.ToString() + ".jpg";
                        string filename = env.ScannedImagePath + sfile;
                        CallWebService(filename, env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                        RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                        ordimg.PATIENT_ID = hn;
                        ordimg.SCHEDULE_ID = scheduleid;
                        ordimg.ORDER_ID = 0;
                        ordimg.SL_NO = index;
                        ordimg.IMAGE_NAME = sfile;
                        ordimg.ORG_ID = env.OrgID;
                        ordimg.CREATED_BY = env.UserID;
                        ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                        addimg.RIS_ORDERIMAGE = ordimg;
                        addimg.Invoke();
                    }
                }

                #region OLD_CODE.
                //GBLEnvVariable env = new GBLEnvVariable();
                //string a = env.CountImg;
                //string _path = env.ScannedImagePath;
                //int count = Convert.ToInt32(a);
                //string m, d;
                //if (count == 1)
                //{
                //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

                //    string sfile = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S1.jpg";
                //    string filename = env.ScannedImagePath + sfile;

                //    CallWebService(filename, env.BmpPic, env.PixPic);
                //    env.CountImg = "";

                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;
                //    ordimg.ORDER_ID = 0;
                //    ordimg.SCHEDULE_ID = scheduleid;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = sfile;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;

                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();

                //}
                //if (count == 2)
                //{
                //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

                //    string sfile = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S1.jpg";
                //    string filename = env.ScannedImagePath + sfile;

                //    string sfile2 = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S2.jpg";
                //    string filename2 = env.ScannedImagePath + sfile2;

                //    CallWebService(filename, env.BmpPic, env.PixPic);
                //    CallWebService(filename2, env.BmpPic2, env.PixPic2);
                //    env.CountImg = "";

                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;
                //    ordimg.ORDER_ID = 0;
                //    ordimg.SCHEDULE_ID = scheduleid;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = sfile;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();

                //    RIS_ORDERIMAGE ordimg2 = new RIS_ORDERIMAGE();
                //    ordimg2.PATIENT_ID = hn;
                //    ordimg2.ORDER_ID = 0;
                //    ordimg2.SL_NO = 2;
                //    ordimg2.IMAGE_NAME = sfile2;
                //    ordimg2.SCHEDULE_ID = scheduleid;
                //    ordimg2.ORG_ID = env.OrgID;
                //    ordimg2.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg2 = new ProcessAddOrderImages();
                //    addimg2.RIS_ORDERIMAGE = ordimg2;
                //    addimg2.Invoke();

                //}
                //if (count == 3)
                //{
                //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

                //    string sfile = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S1.jpg";
                //    string filename = env.ScannedImagePath + sfile;

                //    string sfile2 = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S2.jpg";
                //    string filename2 = env.ScannedImagePath + sfile2;

                //    string sfile3 = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S3.jpg";
                //    string filename3 = env.ScannedImagePath + sfile3;

                //    CallWebService(filename, env.BmpPic, env.PixPic);
                //    CallWebService(filename2, env.BmpPic2, env.PixPic2);
                //    CallWebService(filename3, env.BmpPic3, env.PixPic3);
                //    env.CountImg = "";

                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;
                //    ordimg.ORDER_ID = 0;
                //    ordimg.SCHEDULE_ID = scheduleid;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = sfile;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();

                //    RIS_ORDERIMAGE ordimg2 = new RIS_ORDERIMAGE();
                //    ordimg2.PATIENT_ID = hn;
                //    ordimg2.ORDER_ID = 0;
                //    ordimg2.SCHEDULE_ID = scheduleid;
                //    ordimg2.SL_NO = 2;
                //    ordimg2.IMAGE_NAME = sfile2;
                //    ordimg2.ORG_ID = env.OrgID;
                //    ordimg2.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg2 = new ProcessAddOrderImages();
                //    addimg2.RIS_ORDERIMAGE = ordimg2;
                //    addimg2.Invoke();

                //    RIS_ORDERIMAGE ordimg3 = new RIS_ORDERIMAGE();
                //    ordimg3.PATIENT_ID = hn;
                //    ordimg3.ORDER_ID = 0;
                //    ordimg3.SCHEDULE_ID = scheduleid;
                //    ordimg3.SL_NO = 3;
                //    ordimg3.IMAGE_NAME = sfile3;
                //    ordimg3.ORG_ID = env.OrgID;
                //    ordimg3.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg3 = new ProcessAddOrderImages();
                //    addimg3.RIS_ORDERIMAGE = ordimg3;
                //    addimg3.Invoke();
                //} 
                #endregion
            }
            catch (Exception err) 
            {
                MessageBox.Show("ไม่สามารถทำการบันทึกใบแสกนได้ กรุณาติดต่อเจ้าหน้าที่ : " + err.Message, "ไม่สามารถทำการบันทึกใบแสกนได้", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public ScanImage(string hn, int scheduleid, DataTable dtt, string caseSchedule)
        {
            try
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
                        string month = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                        string day = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
                        string sfile = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + month + day + "_S" + index.ToString() + ".jpg";
                        string filename = env.ScannedImagePath + sfile;
                        CallWebService(filename, env.PixPicture[i].Bmp, env.PixPicture[i].Pix);

                        RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                        ordimg.PATIENT_ID = hn;
                        ordimg.SCHEDULE_ID = scheduleid;
                        ordimg.ORDER_ID = 0;
                        ordimg.SL_NO = index;
                        ordimg.IMAGE_NAME = sfile;
                        ordimg.ORG_ID = env.OrgID;
                        ordimg.CREATED_BY = env.UserID;
                        ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                        addimg.RIS_ORDERIMAGE = ordimg;
                        addimg.Invoke();
                    }
                }



                #region OLD CODE.
                //List<string> fname = new List<string>();
                //foreach (DataRow dr in dtt.Rows)
                //{
                //    fname.Add(dr["IMAGE_NAME"].ToString());
                //}
                //GBLEnvVariable env = new GBLEnvVariable();
                //string a = env.CountImg;
                //string _path = env.ScannedImagePath;
                //string m, d;
                //int i = 0;
                //ProcessUpdateRISOrderimages process = new ProcessUpdateRISOrderimages();
                //foreach (DataRow dr in dtt.Rows)
                //{
                //    if (dr["ORDER_IMAGE_ID"].ToString().Trim() != string.Empty)
                //    {
                //        if (dr["IS_DELETED"].ToString() == "Y")
                //        {
                //            process.RIS_ORDERIMAGE.ORDER_IMAGE_ID = Convert.ToInt32(dr["ORDER_IMAGE_ID"]);
                //            process.RIS_ORDERIMAGE.IS_DELETED = 'Y';
                //            process.RIS_ORDERIMAGE.LAST_MODIFIED_BY = env.UserID;
                //            process.Invoke();
                //        }
                //    }
                //}
                ////string m, d;
                //m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
                //d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();
                //string fileName = string.Empty;
                //if (env.PixPic != IntPtr.Zero || env.BmpPic != IntPtr.Zero)
                //{
                //    //fileName =  orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_1_1.jpg";
                //    fileName = createNameForSchedule(dtt, scheduleid,1);
                //    CallWebService(env.ScannedImagePath + fileName, env.BmpPic, env.PixPic);
                //    RIS_ORDERIMAGE ordimg = new RIS_ORDERIMAGE();
                //    ordimg.PATIENT_ID = hn;
                //    ordimg.SCHEDULE_ID = scheduleid;
                //    ordimg.SL_NO = 1;
                //    ordimg.IMAGE_NAME = fileName;
                //    ordimg.ORG_ID = env.OrgID;
                //    ordimg.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg = new ProcessAddOrderImages();
                //    addimg.RIS_ORDERIMAGE = ordimg;
                //    addimg.Invoke();
                //}
                //if (env.PixPic2 != IntPtr.Zero || env.BmpPic2 != IntPtr.Zero)
                //{
                //    //fileName = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_1_2.jpg";
                //    fileName = createNameForSchedule(dtt, scheduleid,2);
                //    CallWebService(env.ScannedImagePath + fileName, env.BmpPic2, env.PixPic2);
                //    RIS_ORDERIMAGE ordimg2 = new RIS_ORDERIMAGE();
                //    ordimg2.PATIENT_ID = hn;
                //    ordimg2.SCHEDULE_ID = scheduleid;
                //    ordimg2.SL_NO = 2;
                //    ordimg2.IMAGE_NAME = fileName;
                //    ordimg2.ORG_ID = env.OrgID;
                //    ordimg2.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg2 = new ProcessAddOrderImages();
                //    addimg2.RIS_ORDERIMAGE = ordimg2;
                //    addimg2.Invoke();
                //}
                //if (env.PixPic3 != IntPtr.Zero || env.BmpPic3 != IntPtr.Zero)
                //{
                //    //fileName =  orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_1_3.jpg";
                //    fileName = createNameForSchedule(dtt, scheduleid,3);
                //    CallWebService(env.ScannedImagePath + fileName, env.BmpPic3, env.PixPic3);
                //    RIS_ORDERIMAGE ordimg3 = new RIS_ORDERIMAGE();
                //    ordimg3.PATIENT_ID = hn;
                //    ordimg3.SCHEDULE_ID = scheduleid;
                //    ordimg3.SL_NO = 3;
                //    ordimg3.IMAGE_NAME = fileName;
                //    ordimg3.ORG_ID = env.OrgID;
                //    ordimg3.CREATED_BY = env.UserID;
                //    ProcessAddOrderImages addimg3 = new ProcessAddOrderImages();
                //    addimg3.RIS_ORDERIMAGE = ordimg3;
                //    addimg3.Invoke();
                //} 
                #endregion
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ไม่สามารถทำการบันทึกใบแสกนได้ กรุณาติดต่อเจ้าหน้าที่ : " + ex.Message, "ไม่สามารถทำการบันทึกใบแสกนได้", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
        }

        public bool CallWebService(string _imgpath, IntPtr bmpptr, IntPtr pixptr)
        {
            bool flag = false;
            try
            {
                System.Drawing.Bitmap bmapss = BitmapFromDIB(bmpptr, pixptr);

                System.IO.MemoryStream stream = new System.IO.MemoryStream();
                bmapss.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Position = 0;
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, Convert.ToInt32(stream.Length));



                Service proxy = new Service();
                GBLEnvVariable env = new GBLEnvVariable();
                proxy.Url = env.WebServiceIP_PICTURE;
                proxy.SavePictures(_imgpath, data);
                stream.Dispose();
                bmapss.Dispose();
                flag = true;
            }
            catch (Exception ex) {

                throw ex;
            }

            return flag;
        }


        public static Bitmap BitmapFromDIB(IntPtr pDIB, IntPtr pPix)
        {
            MethodInfo mi = typeof(Bitmap).GetMethod("FromGDIplus",BindingFlags.Static | BindingFlags.NonPublic);
            if (mi == null)
                return null; // (permission problem) 
            IntPtr pBmp = IntPtr.Zero;
            int status = GdipCreateBitmapFromGdiDib(pDIB, pPix, out pBmp);
            if ((status == 0) && (pBmp != IntPtr.Zero)) // success 
                return (Bitmap)mi.Invoke(null, new object[] { pBmp });
            else
                return null; // failure 
        }
        [DllImport("GdiPlus.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int GdipCreateBitmapFromGdiDib(IntPtr pBIH, IntPtr pPix, out IntPtr pBitmap);



        //private string createName(DataTable dtt,int orderno) {
        //    string fileName = string.Empty;
        //    string m, d;
        //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
        //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();

            
        //    int i = 1;
        //    for (; i < dtt.Rows.Count; i++)
        //    {
        //        fileName = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_" + i.ToString()+".jpg";
        //        bool flag=true;
        //        foreach (DataRow row in dtt.Rows) {
        //            if (row["IMAGE_NAME"].ToString().Trim() == fileName.Trim())
        //            {
        //                flag = false;
        //                break;
        //            }
        //        }
        //        if (flag) break;
        //    }
        //    fileName = orderno.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + i.ToString() + ".jpg";
        //    DataRow r = dtt.NewRow();
        //    r["IMAGE_NAME"] = fileName;
        //    dtt.Rows.Add(r);
        //    dtt.AcceptChanges();
        //    return fileName;
        //}
        //private string createNameForSchedule(DataTable dtt, int scheduleid,int run)//for cu เด๋วกลับมาแก้ค๊าาบบบบ
        //{
        //    string fileName = string.Empty;
        //    string m, d;
        //    m = DateTime.Today.Month.ToString().Length == 1 ? "0" + DateTime.Today.Month.ToString() : DateTime.Today.Month.ToString();
        //    d = DateTime.Today.Day.ToString().Length == 1 ? "0" + DateTime.Today.Day.ToString() : DateTime.Today.Day.ToString();


        //    int i = 1;
        //    for (; i < dtt.Rows.Count; i++)
        //    {
        //        fileName = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S" +run.ToString()+ ".jpg";//i.ToString()  + ".jpg";
        //        bool flag = true;
        //        foreach (DataRow row in dtt.Rows)
        //        {
        //            if (row["IMAGE_NAME"].ToString().Trim() == fileName.Trim())
        //            {
        //                flag = false;
        //                break;
        //            }
        //        }
        //        if (flag) break;
        //    }
        //    fileName = scheduleid.ToString() + "_" + DateTime.Today.Year.ToString() + m + d + "_S" + run.ToString() + ".jpg";//i.ToString()  + ".jpg";
        //    DataRow r = dtt.NewRow();
        //    r["IMAGE_NAME"] = fileName;
        //    dtt.Rows.Add(r);
        //    dtt.AcceptChanges();
        //    return fileName;
        //}
    }
}
