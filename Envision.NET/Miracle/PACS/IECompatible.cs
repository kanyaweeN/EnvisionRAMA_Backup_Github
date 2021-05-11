using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Miracle.PACS
{
    public class IECompatible
    {
        public IECompatible()
        { 
        
        }

        //public void OpenSynapseAccession(string accession)
        //{
        //    string url = @"http://miracleonline/SynapseManageLink/AccessionNOpacsurl.html?AccessionNo="+accession;
        //    System.Diagnostics.Process.Start(url,"");
        //}
        public bool OpenSynapseLink(string url)
        {
            bool resultOpenPACS = true;
            bool foundIE = false;
            foreach (SHDocVw.InternetExplorer ieInst in new SHDocVw.ShellWindowsClass())
            {
                if (ieInst.LocationURL.ToString().StartsWith("http://synapse"))
                {
                    object Empty = 0;
                    ieInst.Visible = true;
                    try
                    {
                        ieInst.Navigate(url, ref Empty, ref Empty, ref Empty, ref Empty);

                        int val = ieInst.HWND;
                        IntPtr hwnd = new IntPtr(val);
                        SetForegroundWindow(hwnd);

                    }
                    catch (Exception ex)
                    {
                        resultOpenPACS = false;
                    }
                    foundIE = true;
                    break;
                }
            }

            if (foundIE == false)
            {
                System.Diagnostics.Process.Start(url);
            }
            return resultOpenPACS;
        }
        public bool OpenLink(string checkLocationURL,string url)
        {
            bool resultOpenPACS = true;
            bool foundIE = false;
            foreach (SHDocVw.InternetExplorer ieInst in new SHDocVw.ShellWindowsClass())
            {
                if (ieInst.LocationURL.ToString().StartsWith(checkLocationURL))
                {
                    object Empty = 0;
                    ieInst.Visible = true;
                    try
                    {
                        ieInst.Navigate(url, ref Empty, ref Empty, ref Empty, ref Empty);

                        int val = ieInst.HWND;
                        IntPtr hwnd = new IntPtr(val);
                        SetForegroundWindow(hwnd);

                    }
                    catch (Exception ex)
                    {
                        resultOpenPACS = false;
                    }
                    foundIE = true;
                    break;
                }
            }

            if (foundIE == false)
            {
                System.Diagnostics.Process.Start(url);
            }
            return resultOpenPACS;
        }
        
        public void RegistryKeySetting()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser;
                reg = reg.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
                reg.SetValue("AllowWindowReuse ", 1, RegistryValueKind.DWord);
                reg.Flush();
            }
            catch { }
        }

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);
    }
}
