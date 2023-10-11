using System;
using System.Reflection;
using EstudioCsharp.src.Domain.classificacion;

namespace EstudioCsharp.enums
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var concept = ConceptType.PROPERTY;
            var classificationAttribute = GetClassificationAttribute(concept);

            Console.WriteLine($"Classification for {concept}: {classificationAttribute.Classification}");
        }

        private static ClassificationAsset GetClassificationAttribute(ConceptType concept)
        {
            var fieldInfo = typeof(ConceptType).GetField(concept.ToString());
            var attribute = (ClassificationAsset)Attribute.GetCustomAttribute(fieldInfo, typeof(ClassificationAsset));

            return attribute;
        }
    }
}