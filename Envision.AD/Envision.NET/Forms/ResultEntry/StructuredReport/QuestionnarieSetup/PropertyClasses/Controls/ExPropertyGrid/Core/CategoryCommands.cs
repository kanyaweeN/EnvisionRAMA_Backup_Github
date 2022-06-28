using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    public class CategoryCommands : CollectionBase
    {

        private CommandComparer _ComComp;

        public CommandComparer ComComp
        {
            get
            {
                if (_ComComp == null)
                {
                    _ComComp = new CommandComparer();
                }
                return _ComComp;
            }
        }

        public int Add(CategoryCommand cc)
        {
            return this.InnerList.Add(cc);
        }

        public void AddRange(CategoryCommand[] ccs)
        {
            InnerList.AddRange(ccs);
        }

        public void Remove(CategoryCommand cc)
        {
            InnerList.Remove(cc);
        }

        public new void RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }

        public bool Contains(CategoryCommand cc)
        {
            return InnerList.Contains(cc);
        }

        public bool Contains(string Name)
        {
            return this[Name] != null;
        }

        public void Sort()
        {
            InnerList.Sort(ComComp);
        }

        public int BinarySearch(CategoryCommand cc)
        {
            InnerList.Sort(ComComp);
            return InnerList.BinarySearch(cc, ComComp);
        }

        public CategoryCommand this[string Name]
        {
            get
            {
                InnerList.Sort(ComComp);
                int index = InnerList.BinarySearch(Name, ComComp);
                if (index > -1) { return (CategoryCommand)this.InnerList[index]; }
                else { return null; }
            }
        }

        public CategoryCommand this[int index]
        {
            get { return (CategoryCommand)this.InnerList[index]; }
            set { this.InnerList[index] = value; }
        }
    }
}
