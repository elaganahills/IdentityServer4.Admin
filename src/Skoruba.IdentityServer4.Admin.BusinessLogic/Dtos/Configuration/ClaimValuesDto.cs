using Skoruba.IdentityServer4.Admin.EntityFramework.Entities;
using System.Collections.Generic;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration
{
	public class ClaimValuesDto
	{
		public ClaimValuesDto()
		{
			ClaimValues = new List<ClaimValueDto>();
		}

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public List<ClaimValueDto> ClaimValues { get; set; }
	}
}