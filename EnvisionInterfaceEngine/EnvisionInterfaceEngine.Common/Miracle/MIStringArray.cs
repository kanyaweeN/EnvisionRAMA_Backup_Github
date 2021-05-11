using System;
using System.Collections.Generic;

namespace EnvisionInterfaceEngine.Common.Miracle
{
    public class MIStringArray : IDisposable
    {
        private List<string> parameters;
        private bool disposed = false;

        public string this[int index]
        {
            get { return (parameters.Count > index) ? parameters[index] : null; }
            set { parameters[index] = value; }
        }
        public List<string> Values
        {
            get { return parameters; }
            set { parameters = value; }
        }

        public MIStringArray(string[] values)
        {
            Values = new List<string>();
            Values.AddRange(values);
        }
        public MIStringArray(List<string> values) { Values = values; }
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
