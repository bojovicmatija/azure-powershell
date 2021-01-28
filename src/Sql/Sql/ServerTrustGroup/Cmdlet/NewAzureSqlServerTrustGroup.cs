﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Cmdlet
{
	/// <summary>
	/// Cmdlet to create a new Azure Server Trust Group
	/// </summary>
	[Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerTrustGroup"), OutputType(typeof(AzureSqlServerTrustGroupModel))]
	public class NewAzureSqlServerTrustGroup : AzureSqlServerTrustGroupCmdletBase
	{
		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 1,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[LocationCompleter("Microsoft.Sql/locations/serverTrustGroups")]
		[ValidateNotNullOrEmpty]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 2,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = true,
			Position = 3,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public List<String> GroupMembers { get; set; }

		/// <summary>
		/// Gets or sets the name of the InstanceFailoverGroup to use.
		/// </summary>
		[Parameter(Mandatory = false,
			Position = 4,
			HelpMessage = "The name of the Instance Failover Group to retrieve.")]
		[ValidateNotNullOrEmpty]
		public List<String> TrustScope { get; set; }

		protected override IEnumerable<AzureSqlServerTrustGroupModel> GetEntity()
		{
			//try
			//{
			//	ModelAdapter.GetServerTrustGroup(this.ResourceGroupName, this.Location, this.Name);
			//}
			//catch (CloudException)
			//{
				//if(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
				//{
					return null;
				//}

				//throw;
			//}

			//throw new PSArgumentException("Already exists");
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerTrustGroupModel> model)
		{
			List<AzureSqlServerTrustGroupModel> newEntity = new List<AzureSqlServerTrustGroupModel>();
			newEntity.Add(new AzureSqlServerTrustGroupModel()
			{
				ResourceGroupName = this.ResourceGroupName,
				Location = this.Location,
				Name = this.Name,
				TrustScope = this.TrustScope,
				GroupMembers = this.GroupMembers
			});
			return newEntity;
		}

		protected override IEnumerable<AzureSqlServerTrustGroupModel> PersistChanges(IEnumerable<AzureSqlServerTrustGroupModel> entity)
		{
			return new List<AzureSqlServerTrustGroupModel>()
			{
				ModelAdapter.CreateServerTrustGroup(entity.First())
			};
		}
	}
}
