using System;
using System.Windows.Forms.Design;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel.Design;
using Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnarieSetup;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid
{
    public class ExCollectionEditorBase : UITypeEditor
    {
        public delegate void CollectionChangedEventHandler(object sender, object instance, object value);
        public event CollectionChangedEventHandler CollectionChanged;

        private ITypeDescriptorContext _context;

        private IWindowsFormsEditorService edSvc = null;

        public ExCollectionEditorBase() { }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                object originalValue = value;
                _context = context;
                edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (edSvc != null)
                {
                    ExCollectionEditorForm collEditorFrm = CreateForm();
                    collEditorFrm.ItemAdded += new ExCollectionEditorForm.InstanceEventHandler(ItemAdded);
                    collEditorFrm.ItemRemoved += new ExCollectionEditorForm.InstanceEventHandler(ItemRemoved);

                    collEditorFrm.Collection = (System.Collections.CollectionBase)value;
                    //collEditorFrm.CanMoveItem = FormStates.IsUpdate;

                    context.OnComponentChanging();
                    if (edSvc.ShowDialog(collEditorFrm) == DialogResult.OK)
                    {
                        OnCollectionChanged(context.Instance, value);
                        context.OnComponentChanged();
                    }
                }
            }

            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if (context != null && context.Instance != null)
            {
                return UITypeEditorEditStyle.Modal;
            }
            return base.GetEditStyle(context);
        }


        private void ItemAdded(object sender, object item)
        {

            if (_context != null && _context.Container != null)
            {
                IComponent icomp = item as IComponent;
                if (icomp != null)
                {
                    _context.Container.Add(icomp);
                }
            }

        }


        private void ItemRemoved(object sender, object item)
        {
            if (_context != null && _context.Container != null)
            {
                IComponent icomp = item as IComponent;
                if (icomp != null)
                {
                    _context.Container.Remove(icomp);
                }
            }

        }


        protected virtual void OnCollectionChanged(object instance, object value)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, instance, value);
            }
        }


        protected virtual ExCollectionEditorForm CreateForm()
        {
            return new ExCollectionEditorForm();
        }
    }
}
