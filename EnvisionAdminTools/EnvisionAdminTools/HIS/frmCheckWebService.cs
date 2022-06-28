using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Web.Services;
using System.Web.Services.Description;
using System.Xml.Serialization;
using System.Reflection;
using System.Xml;
using System.Net.NetworkInformation;
namespace EnvisionAdminTools.HIS
{
    public partial class frmCheckWebService : Form
    {
        private MethodInfo[] methodInfo;
        private ParameterInfo[] param;
        private Type service;
        private Type[] paramTypes;
        private WsdlReader.Properties myProperty;

        private string MethodName = string.Empty;

        public frmCheckWebService()
        {
            InitializeComponent();
           
        }

        private void frmCheckWebService_Load(object sender, EventArgs e)
        {
            txtURL.Text = "http://192.168.0.247/webservice/patientservice.wsdl";

            Ping ping = new Ping();
            PingReply pgRy = ping.Send("192.168.0.247");
            if (pgRy.Status != IPStatus.Success)
            {
                txtURL.Text = txtURL.Text.Replace("192.168.0.247", "hisws");
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Trim().Length == 0)
            {
                txtURL.Focus();
                return;
            }
            initControl();
            DynamicInvocation();
        }
        private void lstMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMethod.SelectedIndex > -1)
            {
                lstParam.Items.Clear();
                propMethod.SelectedObject = null;
                txtResult.Text = string.Empty;
                txtResult.ForeColor = Color.Black;

                MethodName = lstMethod.Text;
                //param = methodInfo[lstMethod.SelectedIndex].GetParameters();
                
                int idxMed = 0;
                foreach (MethodInfo t in methodInfo)
                {
                    string medName = lstMethod.Items[lstMethod.SelectedIndex].ToString();
                    if (medName == t.Name)
                        break;
                    idxMed++;
                }

                param = methodInfo[idxMed].GetParameters();
                myProperty = new WsdlReader.Properties(param.Length);
                paramTypes = new Type[param.Length];
                for (int i = 0; i < paramTypes.Length; i++)
                {
                    paramTypes[i] = param[i].ParameterType;
                }
                foreach (ParameterInfo temp in param)
                    lstParam.Items.Add(temp.Name);
            }
        }
        private void lstParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (param.Length > 0 && lstParam.SelectedIndex > -1) {
                myProperty.Index = lstParam.SelectedIndex;
                myProperty.Type = param[lstParam.SelectedIndex].ParameterType;
                propMethod.SelectedObject = myProperty;
            }
            else
                propMethod.SelectedObject = null;
        }

        private void initControl() {
            lstMethod.Items.Clear();
            lstParam.Items.Clear();
            propMethod.SelectedObject = null;
            txtResult.Text = string.Empty;
            txtResult.ForeColor = Color.Black;

        }
        private void DynamicInvocation() { 
            try
            {
                Uri uri = new Uri(txtURL.Text);
                WebRequest webRequest = WebRequest.Create(uri);
                System.IO.Stream requestStream = webRequest.GetResponse().GetResponseStream();
                ServiceDescription sd = ServiceDescription.Read(requestStream);
                string sdName = sd.Services[0].Name;

                ServiceDescriptionImporter servImport = new ServiceDescriptionImporter();
                servImport.AddServiceDescription(sd, String.Empty, String.Empty);
                servImport.ProtocolName = "Soap";
                servImport.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;

                CodeNamespace nameSpace = new CodeNamespace();
                CodeCompileUnit codeCompileUnit = new CodeCompileUnit();
                codeCompileUnit.Namespaces.Add(nameSpace);

                ServiceDescriptionImportWarnings warnings = servImport.Import(nameSpace, codeCompileUnit);
                if((warnings==0)||(warnings==System.Web.Services.Description.ServiceDescriptionImportWarnings.OptionalExtensionsIgnored))
                {
                    StringWriter stringWriter = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
                    Microsoft.CSharp.CSharpCodeProvider prov = new Microsoft.CSharp.CSharpCodeProvider();
                    prov.GenerateCodeFromNamespace(nameSpace, stringWriter, new CodeGeneratorOptions());

                    string[] assemblyReferences = new string[2] { "System.Web.Services.dll", "System.Xml.dll" };
                    CompilerParameters param = new CompilerParameters(assemblyReferences);
                    param.GenerateExecutable = false;
                    param.GenerateInMemory = true;
                    param.TreatWarningsAsErrors = false;
                    param.WarningLevel = 4;

                    CompilerResults results = new CompilerResults(new TempFileCollection());
                    results = prov.CompileAssemblyFromDom(param, codeCompileUnit);
                    Assembly assembly = results.CompiledAssembly;
                    service = assembly.GetType(sdName);
                    methodInfo = service.GetMethods();

                    foreach (MethodInfo t in methodInfo)
                    {
                        if (t.Name == "Discover")
                            break;
                        lstMethod.Items.Add(t.Name);
                    }
                
                }
                else
                {
                    MessageBox.Show(warnings.ToString());
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "ERROR!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (param == null) return;
            object[] param1 = new object[param.Length];
            try
            {
                for (int i = 0; i < param.Length; i++)
                    param1[i] = Convert.ChangeType(myProperty.MyValue[i], myProperty.TypeParameter[i]);

                foreach (MethodInfo t in methodInfo)
                    if (t.Name == MethodName)
                    {
                        
                        Object obj = Activator.CreateInstance(service);
                        //((patientservice)obj).Url = txtURL.Text;

                        Type ty = obj.GetType();
                        PropertyInfo p = ty.GetProperty("Url");
                        if (p != null) 
                        {
                            p.SetValue(obj,txtURL.Text, null);
                        }
                        Object response = t.Invoke(obj, param1);
                        txtResult.Text = response.ToString();
                        txtResult.ForeColor = Color.Green;

                        dtt = XMLParser(txtResult.Text);
                        if (dtt == null)
                            btnShowdata.Enabled = false;
                        else
                            btnShowdata.Enabled = true;
                        break;
                    }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
                txtResult.ForeColor = Color.Red;
            }
        }
        DataTable dtt = null;
        private void btnShowdata_Click(object sender, EventArgs e)
        {
            dlgShowData frm = new dlgShowData(dtt);
            frm.ShowDialog();
        }
        private DataTable XMLParser(string xmlcontent)
        {
            try
            {
                XmlDataDocument doc = new XmlDataDocument();
                doc.DataSet.ReadXml(new StringReader(xmlcontent));
                DataSet ds = doc.DataSet;
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}