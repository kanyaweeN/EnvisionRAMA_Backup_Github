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
            //        //"�������ö��˹������Ţ������";
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
            //        //"�������÷ӧҹ"
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
                    //"�������ö��˹������Ţ������";
                    throw new Exception("�������ö��˹������Ţ������");
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
                    //"�������÷ӧҹ"
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
                    //"�������ö��˹������Ţ������";
                    throw new Exception("�������ö��˹������Ţ������");
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
                    //"�������÷ӧҹ"
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
                new DataColumn("�������"),
                new DataColumn("�ӹ�˹�Ҫ���"),
                new DataColumn("����"),
                new DataColumn("���ʡ��"),
                new DataColumn("�ѹ�Դ"),
                new DataColumn("��͹�Դ"),
                new DataColumn("���Դ"),
                new DataColumn("��"),
                new DataColumn("����"),
                new DataColumn("�����Ţ�ѵû�Шӵ�ǻ�ЪҪ�"),
                new DataColumn("�ѹ������غѵ�"),
                new DataColumn("��͹������غѵ�"),
                new DataColumn("��������غѵ�"),
                new DataColumn("˹��§ҹ����͡�ѵ�"),
                new DataColumn("�Ţ����ҹ"),
                new DataColumn("��͡"),
                new DataColumn("���"),
                new DataColumn("���"),
                new DataColumn("����"),
                new DataColumn("�Ӻ�/�ǧ"),
                new DataColumn("�����/ࢵ"),
                new DataColumn("�ѧ��Ѵ"),
                new DataColumn("����������"),
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
                //this.ShowStatus("���ҧ context ����Ѻ��ҹ�ش�Ѳ�������");

                uint major = 0;
                uint minor = 0;
                uint release = 0;
                uint build = 0;

                // Get NationalIDCardSDK version.
                NationalIdCardSdkWrapper.GetVersion(_context, ref major, ref minor, ref release, ref build);
                //this.ShowStatus("National ID card SDK version = " + major.ToString() + "." + minor.ToString() + "." + release.ToString() + "." + build.ToString());

                // Specify card reader's device model for proper internal hardware operation.
                NationalIdCardSdkWrapper.SetDeviceModel(_context, DeviceModelTypes.MSR120D);
                //this.ShowStatus("��˹���Դ�ͧ����ͧ��ҹ�� MSR120D");
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
                    //PortNumberLabel.Text = "�������ö��˹������Ţ������";
                    //this.ShowStatus("�������ö��˹������Ţ������");
                    errorCode = "�������ö��˹������Ţ������";
                    return false;
                }
                else
                {
                    //PortNumberLabel.Text = "�����Ţ���� = " + port_number.ToString();
                    //this.ShowStatus("�����Ţ���� = " + port_number.ToString());

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
                //this.ShowStatus("ŧ����¹����ͧ��ҹ�����");
                // Add delegate for handling data comming from card reader.
                NationalIdCardSdkWrapper.OnReceiveNationalIdCardData += new NationalIdCardSdkWrapper.NidReceiveDataEventHandler(this.NationalIDCardSDKWrapper_OnReceiveData);

                // Start card reader.
                result = NationalIdCardSdkWrapper.StartReadCard(_context);
                if (result == ResultCodeTypes.OK)
                {
                    //this.ShowStatus("�������÷ӧҹ");
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
                    result = "����ͼԴ��Ҵ����������ö�к���.";
                    break;

                case ResultCodeTypes.InvalidContext:
                    result = "context ���١��ͧ";
                    break;

                case ResultCodeTypes.ActivationFail:
                    result = "����ͼԴ��Ҵ㹡��ŧ����¹";
                    break;

                case ResultCodeTypes.ModuleNotActivate:
                    result = "�ѧ����ա��ŧ����¹";
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
