﻿using System.Collections.Generic;
using AutoMapper;
using IdentityServer4.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration;
using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using Skoruba.IdentityServer4.Admin.EntityFramework.Extensions.Common;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Mappers
{
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityResourceMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }


        public static IdentityResourceDto ToModel(this IdentityResource resource)
        {
            return resource == null ? null : Mapper.Map<IdentityResourceDto>(resource);
        }

		public static ClaimValueDto ToModel(this ClaimValue resource)
		{
			return resource == null ? null : Mapper.Map<ClaimValueDto>(resource);
		}

		public static IdentityResourcesDto ToModel(this PagedList<IdentityResource> resource)
        {
            return resource == null ? null : Mapper.Map<IdentityResourcesDto>(resource);
        }

		public static ClaimValuesDto ToModel(this PagedList<ClaimValue> resource)
		{
			return resource == null ? null : Mapper.Map<ClaimValuesDto>(resource);
		}

		public static List<IdentityResourceDto> ToModel(this List<IdentityResource> resource)
        {
            return resource == null ? null : Mapper.Map<List<IdentityResourceDto>>(resource);
        }

        public static IdentityResource ToEntity(this IdentityResourceDto resource)
        {
            return resource == null ? null : Mapper.Map<IdentityResource>(resource);
        }
		
        public static ClaimValue ToEntity(this ClaimValueDto resource)
		{
			return resource == null ? null : Mapper.Map<ClaimValue>(resource);
		}

		public static IdentityResourcePropertiesDto ToModel(this PagedList<IdentityResourceProperty> identityResourceProperties)
        {
            return Mapper.Map<IdentityResourcePropertiesDto>(identityResourceProperties);
        }

        public static IdentityResourcePropertiesDto ToModel(this IdentityResourceProperty identityResourceProperty)
        {
            return Mapper.Map<IdentityResourcePropertiesDto>(identityResourceProperty);
        }

        public static List<IdentityResource> ToEntity(this List<IdentityResourceDto> resource)
        {
            return resource == null ? null : Mapper.Map<List<IdentityResource>>(resource);
        }

        public static List<ClaimValue> ToEntity(this List<ClaimValueDto> resource)
        {
            return resource == null ? null : Mapper.Map<List<ClaimValue>>(resource);
        }

        public static IdentityResourceProperty ToEntity(this IdentityResourcePropertiesDto identityResourceProperties)
        {
            return Mapper.Map<IdentityResourceProperty>(identityResourceProperties);
        }
    }
}