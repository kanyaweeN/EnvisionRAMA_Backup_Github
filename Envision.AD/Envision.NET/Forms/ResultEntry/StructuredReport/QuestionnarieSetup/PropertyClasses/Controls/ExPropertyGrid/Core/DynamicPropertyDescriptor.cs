using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    public class DynamicPropertyDescriptor : PropertyDescriptor
    {
        private PropertyDescriptor basePropertyDescriptor;
        private Descriptor instance;

        public DynamicPropertyDescriptor(Descriptor instance, PropertyDescriptor basePropertyDescriptor)
            : base(basePropertyDescriptor)
        {
            this.instance = instance;
            this.basePropertyDescriptor = basePropertyDescriptor;
        }

        public override bool CanResetValue(object component)
        {
            return basePropertyDescriptor.CanResetValue(component);
        }

        public override Type ComponentType
        {
            get { return basePropertyDescriptor.ComponentType; }
        }

        public override object GetValue(object component)
        {
            return this.basePropertyDescriptor.GetValue(component);
        }

        public override string Description
        {
            get
            {
                return instance.GetLocalizedDescription(base.Name);
            }
        }
        public override string Category
        {
            get
            {
                return instance.GetLocalizedName(base.Category);
            }
        }

        public override string DisplayName
        {
            get
            {
                return instance.GetLocalizedName(base.Name);
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                PropertyCommand pc = instance.PropertyCommands[this.Name] as PropertyCommand;
                if (pc != null)
                {
                    return pc.ReadOnly;
                }
                else
                {
                    return this.basePropertyDescriptor.IsReadOnly;
                }
            }
        }

        public override Type PropertyType
        {
            get { return this.basePropertyDescriptor.PropertyType; }
        }

        public override void ResetValue(object component)
        {
            this.basePropertyDescriptor.ResetValue(component);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return this.basePropertyDescriptor.ShouldSerializeValue(component);
        }

        public override void SetValue(object component, object value)
        {
            this.basePropertyDescriptor.SetValue(component, value);
        }
    }

}
