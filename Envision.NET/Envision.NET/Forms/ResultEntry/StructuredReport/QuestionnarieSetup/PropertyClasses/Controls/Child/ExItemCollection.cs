using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.Child
{
    public class ExItemCollection : CollectionBase
    {
        public ExItemCollection()
		{
			
		}

        public int Add(ExItem e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(ExItem[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(ExItem e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(ExItem e)
		{
			return InnerList.Contains(e);
		}

        public ExItem this[int index]
		{
            get { return (ExItem)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
    }
}
