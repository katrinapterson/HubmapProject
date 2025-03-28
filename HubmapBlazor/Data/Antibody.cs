﻿
namespace HubmapBlazor.Data
{
    public class Antibody
    {
		public Antibody(string gene, string antibodyID, string antibodyName, string targetAntigen, string clonality,
			string reference, string cloneID, string hostOrganism, string vendor, string catNum, int refCount)
		{
			Gene = gene;
			AntibodyID = antibodyID;
			AntibodyName = antibodyName;
			TargetAntigen = targetAntigen;
			Clonality = clonality;
			Reference = reference;
			CloneID = cloneID;
			HostOrganism = hostOrganism;
			Vendor = vendor;
			CatNum = catNum;
			RefCount = refCount;
		}

		public string Gene { get; set; }
		public string AntibodyID { get; set; }
		public string AntibodyName { get; set; }
		public string TargetAntigen { get; set; }
		public string Clonality { get; set; }
		public string Reference { get; set; }
		public string CloneID { get; set; }
		public string HostOrganism { get; set; }
		public string Vendor { get; set; }
		public string CatNum { get; set; }
		public int RefCount { get; set; }
	}
}


