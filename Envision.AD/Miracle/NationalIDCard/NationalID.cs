using System;
using System.Collections.Generic;
using System.Text;
using Itworks.NationalIdCardSdk;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace Miracle.NationalIDCard
{
    public class NationalIDCard
    {
        private uint _context = 0;
        private string errorCode = "";
        private DataTable resultTable;
        private NidNationalIdMagneticCardDataType idCardData;
        public string[] Activatation_Keys = new string[]
        { 
            "0169FEE74A2C8DB5BFE16ED456C1",
            "0169-FEE7-4A2C-8DB5-BFE1-6ED4-56C1"
        };
        public event ValueUpdatedEventHandler ValueUpdated;


        public NationalIDCard()
        {
            //NationalIdCardSdkWrapper.InitializeModule();

            //ResultCodeTypes result = NationalIdCardSdkWrapper.CreateContext(out _context);
            //if (ResultCodeTypes.OK == result)
            //{
            //    uint major = 0;
            //    uint minor = 0;
            //    uint release = 0;
            //    uint build = 0;

            //    NationalIdCardSdkWrapper.GetVersion(_context, ref major, ref minor, ref release, ref build);
            //    NationalIdCardSdkWrapper.SetDeviceModel(_context, DeviceModelTypes.MSR120D);
            //}
            //else
            //{
            //    // If function fail then show error message.
            //};

            //result = NationalIdCardSdkWrapper.SetCommPortNumber(_context, 0);
            //if (ResultCodeTypes.OK == result)
            //{
            //    Int32 port_number = 0;
            //    NationalIdCardSdkWrapper.GetCommPortNumber(_context, ref port_number);

            //    if (0 == port_number)
            //    {
            //        //"ไม่สามารถกำหนดหมายเลขพอร์ทได้";
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{

            //}

            //result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, "0169-FEE7-4A2C-8DB5-BFE1-6ED4-56C1");
            //if (result == ResultCodeTypes.OK)
            //{
            //    // Add delegate for handling data comming from card reader.
            //    NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);

            //    // Start card reader.
            //    result = NationalIdCardSdkWrapper.StartReadCard(_context);
            //    if (result == ResultCodeTypes.OK)
            //    {
            //        //"เริ่มการทำงาน"
            //    }
            //    else
            //    {
            //    };
            //}
            //else
            //{
            //};
        }

        public void Invoke()
        {
            NationalIdCardSdkWrapper.InitializeModule();

            ResultCodeTypes result = NationalIdCardSdkWrapper.CreateContext(out _context);
            if (ResultCodeTypes.OK == result)
            {
                uint major = 0;
                uint minor = 0;
                uint release = 0;
                uint build = 0;

                NationalIdCardSdkWrapper.GetVersion(_context, ref major, ref minor, ref release, ref build);
                NationalIdCardSdkWrapper.SetDeviceModel(_context, DeviceModelTypes.MSR120D);
            }
            else
            {
                // If function fail then show error message.
                throw new Exception(this.ResultCodeToString(result));
            };

            result = NationalIdCardSdkWrapper.SetCommPortNumber(_context, 0);
            if (ResultCodeTypes.OK == result)
            {
                Int32 port_number = 0;
                NationalIdCardSdkWrapper.GetCommPortNumber(_context, ref port_number);

                if (0 == port_number)
                {
                    //"ไม่สามารถกำหนดหมายเลขพอร์ทได้";
                    throw new Exception("ไม่สามารถกำหนดหมายเลขพอร์ทได้");
                }
                else
                {

                }
            }
            else
            {
                throw new Exception(this.ResultCodeToString(result));
            }

            string path = @"C:\Envision\activeCode.env";
            string readText = File.ReadAllText(path, Encoding.UTF8);

            //result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, "0169-FEE7-4A2C-8DB5-BFE1-6ED4-56C1");
            result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, readText);
            if (result == ResultCodeTypes.OK)
            {
                // Add delegate for handling data comming from card reader.
                //NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);
                NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(NationalIDCardSDKWrapper_OnReceiveData);

                // Start card reader.
                result = NationalIdCardSdkWrapper.StartReadCard(_context);
                if (result == ResultCodeTypes.OK)
                {
                    //"เริ่มการทำงาน"
                }
                else
                {
                    throw new Exception(this.ResultCodeToString(result));
                };
            }
            else
            {
                throw new Exception(this.ResultCodeToString(result));
            };
        }

        public void Invoke(string activateCode)
        {
            NationalIdCardSdkWrapper.InitializeModule();

            ResultCodeTypes result = NationalIdCardSdkWrapper.CreateContext(out _context);
            if (ResultCodeTypes.OK == result)
            {
                uint major = 0;
                uint minor = 0;
                uint release = 0;
                uint build = 0;

                NationalIdCardSdkWrapper.GetVersion(_context, ref major, ref minor, ref release, ref build);
                NationalIdCardSdkWrapper.SetDeviceModel(_context, DeviceModelTypes.MSR120D);
            }
            else
            {
                // If function fail then show error message.
                throw new Exception(this.ResultCodeToString(result));
            };

            result = NationalIdCardSdkWrapper.SetCommPortNumber(_context, 0);
            if (ResultCodeTypes.OK == result)
            {
                Int32 port_number = 0;
                NationalIdCardSdkWrapper.GetCommPortNumber(_context, ref port_number);

                if (0 == port_number)
                {
                    //"ไม่สามารถกำหนดหมายเลขพอร์ทได้";
                    throw new Exception("ไม่สามารถกำหนดหมายเลขพอร์ทได้");
                }
                else
                {

                }
            }
            else
            {
                throw new Exception(this.ResultCodeToString(result));
            }

            //result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, "0169-FEE7-4A2C-8DB5-BFE1-6ED4-56C1");
            result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, activateCode);
            if (result == ResultCodeTypes.OK)
            {
                // Add delegate for handling data comming from card reader.
                //NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);
                NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(NationalIDCardSDKWrapper_OnReceiveData);

                // Start card reader.
                result = NationalIdCardSdkWrapper.StartReadCard(_context);
                if (result == ResultCodeTypes.OK)
                {
                    //"เริ่มการทำงาน"
                }
                else
                {
                    throw new Exception(this.ResultCodeToString(result));
                };
            }
            else
            {
                throw new Exception(this.ResultCodeToString(result));
            };
        }

        private void CreateTable()
        { 
            resultTable = new DataTable("IDCardData");
            resultTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ชื่อเต็ม"),
                new DataColumn("คำนำหน้าชื่อ"),
                new DataColumn("ชื่อ"),
                new DataColumn("นามสกุล"),
                new DataColumn("วันเกิด"),
                new DataColumn("เดือนเกิด"),
                new DataColumn("ปีเกิด"),
                new DataColumn("เพศ"),
                new DataColumn("อายุ"),
                new DataColumn("หมายเลขบัตรประจำตัวประชาชน"),
                new DataColumn("วันหมดอายุบัตร"),
                new DataColumn("เดือนหมดอายุบัตร"),
                new DataColumn("ปีหมดอายุบัตร"),
                new DataColumn("หน่วยงานที่ออกบัตร"),
                new DataColumn("เลขที่บ้าน"),
                new DataColumn("ตรอก"),
                new DataColumn("ซอย"),
                new DataColumn("ถนน"),
                new DataColumn("หมู่"),
                new DataColumn("ตำบล/แขวง"),
                new DataColumn("อำเภอ/เขต"),
                new DataColumn("จังหวัด"),
                new DataColumn("ที่อยู่เต็ม"),
            }
            );
        }

        public bool DeviceChecking()
        {
            // Initialize NationalIDCardSDK module.
            NationalIdCardSdkWrapper.InitializeModule();

            // Create context for this session. This context use to grant access to later NationalIDCardSDK's function.			
            ResultCodeTypes result = NationalIdCardSdkWrapper.CreateContext(out _context);
            if (ResultCodeTypes.OK == result)
            {
                //this.ShowStatus("สร้าง context สำหรับใช้งานชุดพัฒนาสำเร็จ");

                uint major = 0;
                uint minor = 0;
                uint release = 0;
                uint build = 0;

                // Get NationalIDCardSDK version.
                NationalIdCardSdkWrapper.GetVersion(_context, ref major, ref minor, ref release, ref build);
                //this.ShowStatus("National ID card SDK version = " + major.ToString() + "." + minor.ToString() + "." + release.ToString() + "." + build.ToString());

                // Specify card reader's device model for proper internal hardware operation.
                NationalIdCardSdkWrapper.SetDeviceModel(_context, DeviceModelTypes.MSR120D);
                //this.ShowStatus("กำหนดชนิดของเครื่องอ่านเป็น MSR120D");
            }
            else
            {
                // If function fail then show error message.
                //this.ShowStatus(this.ResultCodeToString(result));
                errorCode = this.ResultCodeToString(result);
                return false;
            };

            ResultCodeTypes result1 = NationalIdCardSdkWrapper.SetCommPortNumber(_context, 0);
            if (ResultCodeTypes.OK == result1)
            {
                // Get comm port to make sure auto-assign port work correctly.
                Int32 port_number = 0;
                NationalIdCardSdkWrapper.GetCommPortNumber(_context, ref port_number);

                if (0 == port_number)
                {
                    //PortNumberLabel.Text = "ไม่สามารถกำหนดหมายเลขพอร์ทได้";
                    //this.ShowStatus("ไม่สามารถกำหนดหมายเลขพอร์ทได้");
                    errorCode = "ไม่สามารถกำหนดหมายเลขพอร์ทได้";
                    return false;
                }
                else
                {
                    //PortNumberLabel.Text = "หมายเลขพอร์ท = " + port_number.ToString();
                    //this.ShowStatus("หมายเลขพอร์ท = " + port_number.ToString());

                    //ReadDeviceIDButton.Enabled = true;
                    //DeviceActivationGroupBox.Enabled = true;
                    //ActivateDeviceAndStartButton.Enabled = true;
                }
            }
            else
            {
                //this.ShowStatus(this.ResultCodeToString(result));
                errorCode = this.ResultCodeToString(result);
                return false;
            }

            return true;
        }

        public bool ModuleActivated(string Activatation_Key)
        {
            ResultCodeTypes result = (ResultCodeTypes)NationalIdCardSdkWrapper.ActivateModule(_context, Activatation_Key);
            if (result == ResultCodeTypes.OK)
            {
                //this.ShowStatus("ลงทะเบียนเครื่องอ่านสำเร็จ");
                // Add delegate for handling data comming from card reader.
                NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);

                // Start card reader.
                result = NationalIdCardSdkWrapper.StartReadCard(_context);
                if (result == ResultCodeTypes.OK)
                {
                    //this.ShowStatus("เริ่มการทำงาน");
                    //ActivateDeviceAndStartButton.Enabled = false;
                    //StopButton.Enabled = true;
                }
                else
                {
                    //this.ShowStatus(this.ResultCodeToString(result));
                    errorCode = this.ResultCodeToString(result);
                    return false;
                };
            }
            else
            {
                //this.ShowStatus(this.ResultCodeToString(result));
                errorCode = this.ResultCodeToString(result);
                return false;
            };

            return true;
        }

        private void NationalIDCardSDKWrapper_OnReceiveData(NidNationalIdMagneticCardDataType nationalIdCardData)
        {
            idCardData = nationalIdCardData;

            ValueUpdatedEventArgs valueArgs = new ValueUpdatedEventArgs(idCardData);
            ValueUpdated(new object(), valueArgs);
        }

        private string ResultCodeToString(ResultCodeTypes resultCode)
        {
            string result = "";

            switch (resultCode)
            {
                case ResultCodeTypes.GeneralFail:
                    result = "พบข้อผิดพลาดที่ไม่สามารถระบุได้.";
                    break;

                case ResultCodeTypes.InvalidContext:
                    result = "context ไม่ถูกต้อง";
                    break;

                case ResultCodeTypes.ActivationFail:
                    result = "พบข้อผิดพลาดในการลงทะเบียน";
                    break;

                case ResultCodeTypes.ModuleNotActivate:
                    result = "ยังไม่มีการลงทะเบียน";
                    break;
            };

            return result;
        }

        public string ErrorReport
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        public void Closing()
        {
            // If context created then delete it.
            if (0 < _context)
            {
                NationalIdCardSdkWrapper.DeleteContext(_context);
            };

            // Finalize NationalIDCardSDK module.
            NationalIdCardSdkWrapper.FinalizeModule();
        }
    }

    /// Defines the signature for the method that the ValueUpdated handler need to support.
    public delegate void ValueUpdatedEventHandler(object sender, ValueUpdatedEventArgs e);


    /// Holds the event arguments for the ValueUpdated event.
    public class ValueUpdatedEventArgs : System.EventArgs
    {
        /// Used to store the new value
        private NidNationalIdMagneticCardDataType newValue;

        /// Create a new instance of the ValueUpdatedEventArgs class.
        public ValueUpdatedEventArgs(NidNationalIdMagneticCardDataType newValue)
        {
            this.newValue = newValue;
        }

        /// Gets the updated value
        public NidNationalIdMagneticCardDataType NewValue
        {
            get
            {
                return this.newValue;
            }
        }
    }
}
