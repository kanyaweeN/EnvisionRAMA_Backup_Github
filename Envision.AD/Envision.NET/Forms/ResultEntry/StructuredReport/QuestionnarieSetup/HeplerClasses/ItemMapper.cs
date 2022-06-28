using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace 
    Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.HeplerClasses
{
    public class ItemMapper
    {
        private DataRow dataRow;
        public DataRow Row
        {
            get { return dataRow; }
            set { dataRow = value; }
        }

        private object itemControl;
        public object Control
        {
            get { return itemControl; }
            set { itemControl = value; }
        }

        public Type ControlType { get; set; }
    }

    public class ItemMapperCollection : CollectionBase
    {
        public ItemMapperCollection()
		{
			
		}

        public int Add(ItemMapper e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(ItemMapper[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(ItemMapper e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(ItemMapper e)
		{
			return InnerList.Contains(e);
		}

        public ItemMapper this[int index]
		{
            get { return (ItemMapper)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
        
    }
}
