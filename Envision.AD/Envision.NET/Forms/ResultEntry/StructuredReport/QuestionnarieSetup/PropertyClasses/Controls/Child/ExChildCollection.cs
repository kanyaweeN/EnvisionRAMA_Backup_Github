using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls
{
    public class ExChildCollection :CollectionBase
    {
        public ExChildCollection()
		{
			
		}

        public int Add(ExChild e)
		{
			return this.InnerList.Add(e);
		}

        public void AddRange(ExChild[] es)
		{
			this.InnerList.AddRange(es);	
		}

        public void Remove(ExChild e)
		{
			InnerList.Remove(e);
		}

		public new void RemoveAt(int index)
		{
			InnerList.RemoveAt(index);
		}

        public bool Contains(ExChild e)
		{
			return InnerList.Contains(e);
		}

		public ExChild this[int index]
		{
            get { return (ExChild)this.InnerList[index]; }
			set{this.InnerList[index]= value;}
		}
    }
}
