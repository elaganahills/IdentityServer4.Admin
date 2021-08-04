﻿namespace Skoruba.IdentityServer4.Shared.Configuration.Configuration
{
	public class ConnectionStringsConfiguration
	{
		public string ConfigurationDbConnection { get; set; }

		public string PersistedGrantDbConnection { get; set; }

		public string AdminLogDbConnection { get; set; }

		public string IdentityDbConnection { get; set; }

		public string AdminAuditLogDbConnection { get; set; }

		public string DataProtectionDbConnection { get; set; }

		public string SerilogDbConnection { get; set; }

		public void SetConnections(string commonConnectionString)
		{
			AdminAuditLogDbConnection = commonConnectionString;
			AdminLogDbConnection = commonConnectionString;
			ConfigurationDbConnection = commonConnectionString;
			DataProtectionDbConnection = commonConnectionString;
			IdentityDbConnection = commonConnectionString;
			PersistedGrantDbConnection = commonConnectionString;
			SerilogDbConnection = commonConnectionString;
		}
	}
}
