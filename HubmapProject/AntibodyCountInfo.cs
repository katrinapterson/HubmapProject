using System;
namespace HubmapProject
{
	public class AntibodyCountInfo
	{
		public AntibodyCountInfo(string gene, int antibodyCount)
		{
			Gene = gene;
			AntibodyCount = antibodyCount;
		}

		public string Gene { get; set; }
		public int AntibodyCount { get; set; }
	}
}

