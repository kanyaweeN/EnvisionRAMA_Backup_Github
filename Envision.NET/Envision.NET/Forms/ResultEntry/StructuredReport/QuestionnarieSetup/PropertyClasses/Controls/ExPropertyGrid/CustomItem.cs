using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid
{
    public class CustomItem
    {
        private bool _selected = false;
        private string _itemName = string.Empty;

        public string Name
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
    }
}
