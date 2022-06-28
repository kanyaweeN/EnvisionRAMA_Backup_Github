using System;
using System.Collections.Generic;

namespace Envision.Operational.Common
{
    public class MIStringArray : IDisposable
    {
        //public static implicit operator MIStringArray(string[] list) { return new MIStringArray(list); }
        public static implicit operator List<string>(MIStringArray list) { return list.Values; }
        public static implicit operator string[](MIStringArray list) { return list.Values.ToArray(); }

        private List<string> parameters;
        private bool disposed = false;

        public string this[int index]
        {
            get { return (parameters.Count > index) ? parameters[index] : (IsDefaultEmpty ? string.Empty : null); }
            set { parameters[index] = value; }
        }
        public List<string> Values
        {
            get { return parameters; }
            set { parameters = value; }
        }
        public bool IsDefaultEmpty { get; set; }

        public MIStringArray(IEnumerable<string> collection)
        {
            Values = new List<string>(collection);

            IsDefaultEmpty = true;
        }
        public MIStringArray(IEnumerable<string> collection, bool isDefaultEmpty)
        {
            parameters = new List<string>(collection);

            IsDefaultEmpty = isDefaultEmpty;
        }
        ~MIStringArray()
        {
            if (!disposed)
                Dispose();
        }

        public void Dispose()
        {
            parameters = null;
            disposed = true;
        }
    }
}
