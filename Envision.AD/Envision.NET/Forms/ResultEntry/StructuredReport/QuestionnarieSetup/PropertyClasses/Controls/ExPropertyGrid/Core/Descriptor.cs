using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Reflection;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
//using CustomControls.HelperClasses;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    public class Descriptor : ICustomTypeDescriptor, ISupportInitialize
    {
        private PropertyDescriptorCollection dynamicProps;
        private PropertyCommands _PropertyCommands;
        private CategoryCommands _CategoryCommands;




        [Category("Property Control")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ExCollectionEditorForm), typeof(System.Drawing.Design.UITypeEditor))]
        public PropertyCommands PropertyCommands
        {
            get
            {
                if (_PropertyCommands == null)
                {
                    _PropertyCommands = new PropertyCommands();
                }
                return _PropertyCommands;
            }
        }


        [Category("Property Control")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(ExCollectionEditorForm), typeof(System.Drawing.Design.UITypeEditor))]
        public CategoryCommands CategoryCommands
        {
            get
            {
                if (_CategoryCommands == null)
                {
                    _CategoryCommands = new CategoryCommands();
                }
                return _CategoryCommands;
            }
        }

        public Descriptor()
		{
		
		}
	
		public bool ShouldSerializePropertyCommands(){return true;}

		public bool ShouldSerializeCategoryCommands(){return true;}

        protected void FillPropCommColl()
        {
            PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);

            foreach (DynamicPropertyDescriptor oProp in baseProps)
            {
                if (!oProp.DesignTimeOnly && oProp.IsBrowsable && oProp.Category != "Property Control")
                {
                    PropertyCommand pc = new PropertyCommand(oProp.Name, oProp.IsBrowsable, oProp.IsReadOnly);
                    PropertyCommands.Add(pc);
                }
            }
            PropertyCommands.Sort();

        }

        protected void FillCatCommColl()
        {
            PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);

            foreach (DynamicPropertyDescriptor oProp in baseProps)
            {
                if (!oProp.DesignTimeOnly && oProp.IsBrowsable && oProp.Category != "Property Control")
                {
                    CategoryCommand cc = new CategoryCommand(oProp.Category, true);
                    if (CategoryCommands.BinarySearch(cc) < 0)
                    {
                        CategoryCommands.Add(cc);
                    }
                }
            }
            CategoryCommands.Sort();

        }

        public virtual void BeginInit()
        {

        }
        public virtual void EndInit()
        {
            if (PropertyCommands.Count == 0) { FillPropCommColl(); }
            if (CategoryCommands.Count == 0) { FillCatCommColl(); }
        }


        public PropertyCommand[] GetPropertyCommands()
        {
            PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);
            PropertyCommand[] pcs = new PropertyCommand[baseProps.Count];

            for (int i = 0; i < baseProps.Count; i++)
            {
                pcs[i] = new PropertyCommand(baseProps[i].Name, baseProps[i].IsBrowsable, baseProps[i].IsReadOnly);
            }
            return pcs;
        }


        public virtual string GetLocalizedName(string Name)
        {
            return Name;
        }

        public virtual string GetLocalizedDescription(string Description)
        {
            return Description;
        }


        #region "TypeDescriptor Implementation"

        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {

            if (!General.IsInDesignMode())
            {
                PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, attributes, true);
                dynamicProps = new PropertyDescriptorCollection(null);

                foreach (PropertyDescriptor oProp in baseProps)
                {

                    if (oProp.Category != "Property Control")
                    {
                        if ((PropertyCommands[oProp.Name] == null || PropertyCommands[oProp.Name].Visible) && (CategoryCommands[oProp.Category] == null || CategoryCommands[oProp.Category].Visible))
                        {
                            dynamicProps.Add(new DynamicPropertyDescriptor(this, oProp));
                        }
                    }
                }
                return dynamicProps;
            }

            return TypeDescriptor.GetProperties(this, attributes, true);

        }

        public PropertyDescriptorCollection GetProperties()
        {

            if (dynamicProps == null)
            {
                PropertyDescriptorCollection baseProps = TypeDescriptor.GetProperties(this, true);
                dynamicProps = new PropertyDescriptorCollection(null);

                foreach (DynamicPropertyDescriptor oProp in baseProps)
                {

                    dynamicProps.Add(new DynamicPropertyDescriptor(this, oProp));

                }
            }
            return dynamicProps;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        #endregion
    }
}
