using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.utils
{
    internal class NumberUtils
    {
        public static string FormatLatinAmericanNumber(decimal value)
        {
            return value.ToString("N2", new CultureInfo("es-419"));
        }

    }
}
