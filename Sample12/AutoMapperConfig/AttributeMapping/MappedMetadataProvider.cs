using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;

namespace Sample12.AutoMapperConfig.AttributeMapping
{
    public class MappedMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IConfigurationProvider _mapper;

        public MappedMetadataProvider(IConfigurationProvider mapper)
        {
            _mapper = mapper;
        }

        protected override ModelMetadata CreateMetadata(
            IEnumerable<Attribute> attributes,
            Type containerType,
            Func<object> modelAccessor,
            Type modelType,
            string propertyName)
        {
            var mappedAttributes =
                containerType == null ?
                attributes :
                _mapper.GetMappedAttributes(containerType, propertyName, attributes.ToList());
            return base.CreateMetadata(mappedAttributes, containerType, modelAccessor, modelType, propertyName);
        }
    }
}