using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;

namespace Sample12.AutoMapperConfig.AttributeMapping
{
    public class MappedValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        private readonly IConfigurationProvider _mapper;

        public MappedValidatorProvider(IConfigurationProvider mapper)
        {
            _mapper = mapper;
        }

        protected override IEnumerable<ModelValidator> GetValidators(
            ModelMetadata metadata,
            ControllerContext context,
            IEnumerable<Attribute> attributes)
        {

            var mappedAttributes =
                metadata.ContainerType == null ?
                attributes :
                _mapper.GetMappedAttributes(metadata.ContainerType, metadata.PropertyName, attributes.ToList());
            return base.GetValidators(metadata, context, mappedAttributes);
        }
    }
}