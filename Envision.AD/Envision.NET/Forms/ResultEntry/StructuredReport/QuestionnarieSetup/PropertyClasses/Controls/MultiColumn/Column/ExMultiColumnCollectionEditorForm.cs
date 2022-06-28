using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn
{
    public class ExMultiColumnCollectionEditor : ExCollectionEditorBase
    {
        protected override ExCollectionEditorForm CreateForm()
        {
            return new ExMultiColumnCollectionEditorForm();
        }
    }
    public class ExMultiColumnCollectionEditorForm : ExCollectionEditorForm
    {
        public ExMultiColumnCollectionEditorForm() 
        {
            this.ImageList = this.imageList1;
        }
        protected override void SetProperties(ExCollectionEditorForm.TItem titem, object reffObject)
        {
            if (reffObject is ExMultiColumn)
            {
                titem.Text = "Column";
                titem.ImageIndex = 10;
                titem.SelectedImageIndex = 10;
            }
        }
    }
}
