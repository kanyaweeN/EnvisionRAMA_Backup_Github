using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.MultiColumn
{
    public class ExMultiColumnCollection : CollectionBase
    {
        public ExMultiColumnCollection()
		{
			
		}

        public int Add(ExMultiColumn e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(ExMultiColumn[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(ExMultiColumn e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(ExMultiColumn e)
		{
			return InnerList.Contains(e);
		}

        public ExMultiColumn this[int index]
		{
            get { return (ExMultiColumn)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
    }
}
