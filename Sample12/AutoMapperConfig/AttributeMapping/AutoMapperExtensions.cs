using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Sample12.AutoMapperConfig.AttributeMapping
{
    public static class AutoMapperExtensions
    {
        public static IEnumerable<Attribute> GetMappedAttributes(
            this IConfigurationProvider mapper,
            Type viewModelType,
            string viewModelPropertyName,
            IList<Attribute> existingAttributes)
        {
            if (viewModelType != null)
            {
                foreach (var typeMap in mapper.GetAllTypeMaps().Where(i => i.DestinationType == viewModelType))
                {
                    var propertyMaps = typeMap.GetPropertyMaps()
                        .Where(propertyMap => !propertyMap.IsIgnored() && propertyMap.SourceMember != null)
                        .Where(propertyMap => propertyMap.DestinationProperty.Name == viewModelPropertyName);

                    foreach (var propertyMap in propertyMaps)
                    {
                        foreach (Attribute attribute in propertyMap.SourceMember.GetCustomAttributes(true))
                        {
                            if (existingAttributes.All(i => i.GetType() != attribute.GetType()))
                            {
                                yield return attribute;
                            }
                        }
                    }
                }
            }

            if (existingAttributes == null)
            {
                yield break;
            }

            foreach (var attribute in existingAttributes)
            {
                yield return attribute;
            }
        }
    }
}