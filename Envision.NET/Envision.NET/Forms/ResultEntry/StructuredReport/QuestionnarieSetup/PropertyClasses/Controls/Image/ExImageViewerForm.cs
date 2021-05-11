using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExImageViewer : ExImageEditorBase
    {
        protected override ExImageEditorForm CreateForm()
        {
            return new ExImageViewerForm();
        }
    }

    public class ExImageViewerForm : ExImageEditorForm
    {

    }
}
