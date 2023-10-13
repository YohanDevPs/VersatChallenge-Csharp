using EstudioCsharp.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstudioCsharp.src.Domain.utils
{
    static class EnumUtils
    {
        public static T GetTypeAttribute<T>(this Enum valorEnum) where T : System.Attribute
        {
            var type = valorEnum.GetType();
            var memInfo = type.GetMember(valorEnum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetDescription(this Enum valorEnum)
        {
            return valorEnum.GetTypeAttribute<DescriptionAttribute>().Description;
        }

        public static string GetClassificacionAsset(ConceptType conceptType)
        {
            MemberInfo memberInfo = typeof(ConceptType).GetMember(conceptType.ToString())[0];
            ClassificationAsset classificationAttribute = (ClassificationAsset)Attribute.GetCustomAttribute(memberInfo, typeof(ClassificationAsset));


            return classificationAttribute?.Classification ?? "clasificación no encontrada";
        }
    }
}
