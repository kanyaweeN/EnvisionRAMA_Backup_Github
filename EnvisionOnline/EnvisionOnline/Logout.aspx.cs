using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnvisionOnline.Common.Common;
using System.Collections;

namespace EnvisionOnline
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearApplicationCache();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "CloseForm", "closeWindow();", true);
        }
        private void ClearApplicationCache()
        {
            List<string> keys = new List<string>();

            IDictionaryEnumerator enumerator = Cache.GetEnumerator();

            while (enumerator.MoveNext())
            {
                keys.Add(enumerator.Key.ToString());
            }

            for (int i = 0; i < keys.Count; i++)
            {
                Cache.Remove(keys[i]);
            }
        }
    }
    
}
