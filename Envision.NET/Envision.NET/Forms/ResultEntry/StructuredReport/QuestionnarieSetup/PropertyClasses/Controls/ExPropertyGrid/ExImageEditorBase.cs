using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid
{
    public class ExImageEditorBase : UITypeEditor
    {
        private IWindowsFormsEditorService edSvc = null;

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc != null)
                {
                    ExImageEditorForm form = CreateForm();
                    form.ImageSource = value as Image;
                    context.OnComponentChanging();
                    if (edSvc.ShowDialog(form) == DialogResult.OK)
                    {
                        value = form.ImageSource;
                        context.OnComponentChanged();
                    }
                }
            }
            return value;
        }

        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override void PaintValue(PaintValueEventArgs e)
        {
            if(e.Value != null)
                e.Graphics.DrawImage(e.Value as Image, e.Bounds);
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
            }
            return base.GetEditStyle(context);
        }

        protected virtual ExImageEditorForm CreateForm()
        {
            return new ExImageEditorForm();
        }
    }
}
