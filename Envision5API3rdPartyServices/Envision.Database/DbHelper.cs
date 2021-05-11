using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Envision.Database
{
    public static class DbHelper
    {
        public static ValueConverter BooleanToString()
        {
            return new ValueConverter<bool?, string>(m => m == null || m == false ? "N" : "Y", x => x == null || x == "Y" ? true : false);
        }
        public static ValueConverter IntToString()
        {
            return IntToString(true);
        }
        public static ValueConverter IntToString(bool ZeroToNull)
        {
            if (ZeroToNull)
                return new ValueConverter<int?, string>(m => m == null || m == 0 ? null : m.ToString(), x => x == null ? -1 : Convert.ToInt32(x));
            else
                return new ValueConverter<int?, string>(m => m == null ? null : m.ToString(), x => x == null ? -1 : Convert.ToInt32(x));
        }
    }
}
