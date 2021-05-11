using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTestService
{
    public class ClassChild : ClassAbstract
    {
        public override string StringPublic
        {
            get { return "Child" + base.StringPublic; }
            set { base.StringPublic = value; }
        }
        public ClassChild()
            : base()
        {
        }
        ~ClassChild()
        {
            if (!disposed)
                Dispose();
        }

        public override void Dispose()
        {
            StringPublic = string.Empty;

            base.Dispose();
        }

        public override void WritePublic(string p1)
        {
            base.WriteProtected(p1);
            Console.WriteLine(StringPublic + p1);
        }
    }
    public abstract class ClassAbstract : IDisposable
    {
        public string StringProtected { get { return this.ToString(); } }
        public virtual string StringPublic { get; set; }
        public bool disposed = false;

        public ClassAbstract()
        {
            StringPublic = "StringPublic";
        }
        ~ClassAbstract()
        {
            if (!disposed)
                Dispose();
        }

        public virtual void Dispose()
        {
            disposed = true;
        }
        protected virtual void WriteProtected(string p1)
        {
            Console.WriteLine(StringProtected + p1);
        }
        public virtual void WritePublic(string p1)
        {
            Console.WriteLine(StringPublic + p1);
        }
    }
}
