using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn
{
    public class ExMultiColumnItemCollection : CollectionBase
    {
        public ExMultiColumnItemCollection()
		{
			
		}

        public int Add(ExMultiColumnItem e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(ExMultiColumnItem[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(ExMultiColumnItem e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(ExMultiColumnItem e)
		{
			return InnerList.Contains(e);
		}

        public ExMultiColumnItem this[int index]
		{
            get { return (ExMultiColumnItem)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
    }
}
