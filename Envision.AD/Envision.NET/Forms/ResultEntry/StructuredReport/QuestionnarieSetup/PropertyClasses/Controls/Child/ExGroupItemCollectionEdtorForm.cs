using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child
{
    public class ExGroupItemCollectionEdtor : ExCollectionEditorBase
    {
        protected override ExCollectionEditorForm CreateForm()
        {
            return new ExGroupItemCollectionEdtorForm();
        }
    }
    public class ExGroupItemCollectionEdtorForm : ExCollectionEditorForm
    {
        public ExGroupItemCollectionEdtorForm()
        {
            this.ImageList = this.imageList1;
        }
        protected override void SetProperties(ExCollectionEditorForm.TItem titem, object reffObject)
        {
            if (reffObject is ExGroupItem)
            {
                ExGroupItem child = (ExGroupItem)reffObject;
                titem.Text = child.Type.ToString() + "1";
                switch (child.Type)
                {
                    case GroupChildControlType.Label:
                        titem.ImageIndex = 4;
                        titem.SelectedImageIndex = 4;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_TEXT].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_FORCE_INPUT].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_IMAGE_SOURCE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MINIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_POSITION].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_SIZE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_TEXT].Visible = true;
                        break;
                    case GroupChildControlType.TextBox:
                        titem.ImageIndex = 8;
                        titem.SelectedImageIndex = 8;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_TEXT].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_FORCE_INPUT].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_IMAGE_SOURCE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MINIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_POSITION].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_SIZE].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_TEXT].Visible = false;
                        break;
                    case GroupChildControlType.Multiline:
                        titem.ImageIndex = 5;
                        titem.SelectedImageIndex = 5;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_TEXT].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_FORCE_INPUT].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_IMAGE_SOURCE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MINIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_POSITION].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_SIZE].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_TEXT].Visible = false;
                        break;
                    case GroupChildControlType.Numeric:
                        titem.ImageIndex = 7;
                        titem.SelectedImageIndex = 7;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_TEXT].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_VALUE].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_FORCE_INPUT].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_IMAGE_SOURCE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MAXIMUM].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_MINIMUM].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_POSITION].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_SIZE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_TEXT].Visible = false;
                        break;
                    case GroupChildControlType.Image:
                        titem.ImageIndex = 3;
                        titem.SelectedImageIndex = 3;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_TEXT].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_FORCE_INPUT].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_IMAGE_SOURCE].Visible = true;
                        child.PropertyCommands[ExGroupItem.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_MINIMUM].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_POSITION].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_SIZE].Visible = false;
                        child.PropertyCommands[ExGroupItem.P_TEXT].Visible = false;
                        break;
                }
                this.RefreshPropertyGrid();
            }
        }
    }
}
