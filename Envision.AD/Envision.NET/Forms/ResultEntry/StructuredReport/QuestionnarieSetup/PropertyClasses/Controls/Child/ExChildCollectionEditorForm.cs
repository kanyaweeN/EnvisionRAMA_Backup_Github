using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;
using System.Windows.Forms;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Enums;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Collection
{
    public class ExChildCollectionEditor : ExCollectionEditorBase
    {
        protected override ExCollectionEditorForm CreateForm()
        {
            return new ExChildCollectionEditorForm();
        }
    }

    public class ExChildCollectionEditorForm : ExCollectionEditorForm
    {
        public ExChildCollectionEditorForm()
        {
            this.ImageList = this.imageList1;
        }
        protected override void SetProperties(ExCollectionEditorForm.TItem titem, object reffObject)
        {
            if (reffObject is ExChild)
            {
                ExChild child = (ExChild)reffObject;
                titem.Text = child.Type.ToString();
                switch (child.Type)
                {
                    case ChildControlTypes.Label:
                        titem.ImageIndex = 4;
                        titem.SelectedImageIndex = 4;
                        child.PropertyCommands[ExChild.P_TEXT].Visible = true;
                        child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = false;
                        child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = false;
                        //child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = false;
                        child.PropertyCommands[ExChild.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExChild.P_MINIMUM].Visible = false;
                        //child.PropertyCommands[ExChild.P_POSITION].Visible = false;
                        child.PropertyCommands[ExChild.P_SIZE].Visible = false;
                        child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = false;

                        break;
                    case ChildControlTypes.TextBox:
                        titem.ImageIndex = 8;
                        titem.SelectedImageIndex = 8;
                        child.PropertyCommands[ExChild.P_TEXT].Visible = false;
                        child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = true;
                        child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = true;
                        //child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = true;
                        child.PropertyCommands[ExChild.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExChild.P_MINIMUM].Visible = false;
                        //child.PropertyCommands[ExChild.P_POSITION].Visible = true;
                        child.PropertyCommands[ExChild.P_SIZE].Visible = true;
                        child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = false;

                        break;
                    case ChildControlTypes.MemoEdit:
                        titem.ImageIndex = 5;
                        titem.SelectedImageIndex =5;
                        child.PropertyCommands[ExChild.P_TEXT].Visible = false;
                        child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = true;
                        child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = false;
                        child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = true;
                        //child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = true;
                        child.PropertyCommands[ExChild.P_MAXIMUM].Visible = false;
                        child.PropertyCommands[ExChild.P_MINIMUM].Visible = false;
                        //child.PropertyCommands[ExChild.P_POSITION].Visible = true;
                        child.PropertyCommands[ExChild.P_SIZE].Visible = true;
                        child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = false;


                        break;
                    case ChildControlTypes.Numeric:
                        titem.ImageIndex = 7;
                        titem.SelectedImageIndex = 7;
                        child.PropertyCommands[ExChild.P_TEXT].Visible = false;
                        child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = false;
                        child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = true;
                        child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = true;
                        //child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = true;
                        child.PropertyCommands[ExChild.P_MAXIMUM].Visible = true;
                        child.PropertyCommands[ExChild.P_MINIMUM].Visible = true;
                        //child.PropertyCommands[ExChild.P_POSITION].Visible = true;
                        child.PropertyCommands[ExChild.P_SIZE].Visible = true;
                        child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = false;

                        break;
                    //case ChildControlTypes.DatePick:
                    //    titem.ImageIndex = 1;
                    //    titem.SelectedImageIndex = 1;
                    //    child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = false;
                    //    child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = true;
                    //    child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_MAXIMUM].Visible = false;
                    //    child.PropertyCommands[ExChild.P_MINIMUM].Visible = false;
                    //    child.PropertyCommands[ExChild.P_POSITION].Visible = false;
                    //    child.PropertyCommands[ExChild.P_SIZE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = false;

                    //    break;
                    //case ChildControlTypes.Group:
                    //    titem.ImageIndex = 2;
                    //    titem.SelectedImageIndex = 2;
                    //    child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = false;
                    //    child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = false;
                    //    child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_MAXIMUM].Visible = false;
                    //    child.PropertyCommands[ExChild.P_MINIMUM].Visible = false;
                    //    child.PropertyCommands[ExChild.P_POSITION].Visible = false;
                    //    child.PropertyCommands[ExChild.P_SIZE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = true;

                    //    break;
                    //case ChildControlTypes.Image:
                    //    titem.ImageIndex = 3;
                    //    titem.SelectedImageIndex = 3;
                    //    child.PropertyCommands[ExChild.P_DEFAULT_TEXT].Visible = false;
                    //    child.PropertyCommands[ExChild.P_DEFAULT_VALUE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_FORCE_INPUT].Visible = false;
                    //    child.PropertyCommands[ExChild.P_IMAGE_SOURCE].Visible = true;
                    //    child.PropertyCommands[ExChild.P_MAXIMUM].Visible = false;
                    //    child.PropertyCommands[ExChild.P_MINIMUM].Visible = false;
                    //    child.PropertyCommands[ExChild.P_POSITION].Visible = true;
                    //    child.PropertyCommands[ExChild.P_SIZE].Visible = false;
                    //    child.PropertyCommands[ExChild.P_GROUP_ITEM].Visible = false;

                    //    break;
                }
                this.RefreshPropertyGrid();
            }
        }
    }
}
