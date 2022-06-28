using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child
{
    public class ExItemCollectionEditor : ExCollectionEditorBase
    {
        protected override ExCollectionEditorForm CreateForm()
        {
            return new ExItemCollectionEditorForm();
        }
    }

    public class ExItemCollectionEditorForm : ExCollectionEditorForm
    {
        public ExItemCollectionEditorForm()
        {
            this.ImageList = this.imageList1;
        }
        protected override void SetProperties(ExCollectionEditorForm.TItem titem, object reffObject)
        {
            if (reffObject is ExItem)
            {
                ExItem child = (ExItem)reffObject;
                titem.Text = child.Text;
                titem.SelectedImageIndex = 9;
                titem.ImageIndex = 9;
            }
        }
    }

    public class ExCheckItemCollectionEditor : ExCollectionEditorBase
    {
        protected override ExCollectionEditorForm CreateForm()
        {
            return new ExCheckItemCollectionEditorForm();
        }
    }

    public class ExCheckItemCollectionEditorForm : ExCollectionEditorForm
    {
        public ExCheckItemCollectionEditorForm()
        {
            this.ImageList = this.imageList1;
        }
        protected override void SetProperties(ExCollectionEditorForm.TItem titem, object reffObject)
        {
            if (reffObject is ExItem)
            {
                ExItem child = (ExItem)reffObject;
                titem.Text = child.Text;
                titem.SelectedImageIndex = 9;
                titem.ImageIndex = 9;
                child.PropertyCommands["Check"].Visible = true;
            }
        }
    }
}
