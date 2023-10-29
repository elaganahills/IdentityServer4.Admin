using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Dtos.Configuration
{
	public class ClaimValueDto
	{
		public ClaimValueDto()
		{
		}

        [Required]
		public string Claim { get; set; }

		[Required]
		public string Value { get; set; }

	}
}