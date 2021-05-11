using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn.MutiColumnItem
{
    public class ExMultiColumnItemCollectionEditor : ExCollectionEditorBase
    {
        protected override ExCollectionEditorForm CreateForm()
        {
            return new ExMultiColumnItemCollectionEditorForm();
        }
    }

    public class ExMultiColumnItemCollectionEditorForm : ExCollectionEditorForm
    {
        public ExMultiColumnItemCollectionEditorForm()
        {
            this.ImageList = this.imageList1;
        }
        protected override void SetProperties(ExCollectionEditorForm.TItem titem, object reffObject)
        {
            if (reffObject is ExMultiColumnItem)
            {
                ExMultiColumnItem item = reffObject as ExMultiColumnItem;
                titem.Text = item.Text;
                titem.SelectedImageIndex = 9;
                titem.ImageIndex = 9;
            }
        }
    }
}
