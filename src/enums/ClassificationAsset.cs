using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.enums
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class ClassificationAsset : Attribute
    {
        public string Classification { get; }

        public ClassificationAsset(string classification)
        {
            Classification = classification;
        }
    }
}
