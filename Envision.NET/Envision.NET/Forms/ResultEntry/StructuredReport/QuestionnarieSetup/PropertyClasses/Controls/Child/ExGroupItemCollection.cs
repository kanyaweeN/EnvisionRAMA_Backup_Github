using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child
{
    public class ExGroupItemCollection : CollectionBase
    {
        public ExGroupItemCollection()
		{
			
		}

        public int Add(ExGroupItem e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(ExGroupItem[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(ExGroupItem e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(ExGroupItem e)
		{
			return InnerList.Contains(e);
		}

        public ExGroupItem this[int index]
		{
            get { return (ExGroupItem)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
    }
}
