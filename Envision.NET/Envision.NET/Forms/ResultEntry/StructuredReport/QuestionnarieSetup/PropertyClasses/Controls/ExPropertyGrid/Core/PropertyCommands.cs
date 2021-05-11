using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Envision.NET.Forms.ResultEntry.StructuredReport.QuestionnaireSetup.PropertyClasses.Controls.ExPropertyGrid.Core
{
    public class PropertyCommands : CollectionBase
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

        public int Add(PropertyCommand pc)
        {
            return this.InnerList.Add(pc);
        }

        public void AddRange(PropertyCommand[] pcs)
        {
            InnerList.AddRange(pcs);
        }

        public void Remove(PropertyCommand pc)
        {
            InnerList.Remove(pc);
        }

        public new void RemoveAt(int index)
        {
            InnerList.RemoveAt(index);
        }

        public void Sort()
        {
            InnerList.Sort(ComComp);
        }

        public bool Contains(PropertyCommand pc)
        {
            return InnerList.Contains(pc);
        }

        public bool Contains(string Name)
        {
            return this[Name] != null;
        }

        public PropertyCommand this[string Name]
        {
            get
            {
                InnerList.Sort(ComComp);
                int index = InnerList.BinarySearch(Name, ComComp);
                if (index > -1) { return (PropertyCommand)this.InnerList[index]; }
                else { return null; }
            }
        }

        public int BinarySearch(PropertyCommand value)
        {
            InnerList.Sort(ComComp);
            return InnerList.BinarySearch(value, ComComp);
        }

        public PropertyCommand this[int index]
        {
            get { return (PropertyCommand)this.InnerList[index]; }
            set { this.InnerList[index] = value; }
        }
    }
}
