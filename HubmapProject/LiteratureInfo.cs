using System;
namespace HubmapProject
{
	public class LiteratureInfo
	{
        public LiteratureInfo(string gene, string ensembl, string uniprotAccession, string geneDescription, string hpaEvidence,
            string rnaTissueSpecificity, int rnaTissueSpecificityScore, string rnaTissueSpecificNX, string uniprotName, int mass,
            int goAnnotations, int geneID, int pubmedCitations, int antibodyCount)
		{
			Gene = gene;
			Ensembl = ensembl;
			UniprotAccession = uniprotAccession;
			GeneDescription = geneDescription;
			HPAEvidence = hpaEvidence;
			RNATissueSpecificity = rnaTissueSpecificity;
            RNATissueSpecificityScore = rnaTissueSpecificityScore;
			RNATissueSpecicNX = rnaTissueSpecificNX;
			UniprotName = uniprotName;
            Mass = mass;
            GOAnnotations = goAnnotations;
            GeneID = geneID;
            PubmedCitations = pubmedCitations;
            AntibodyCount = antibodyCount;
		}
		
		public string Gene { get; set; }
		public string Ensembl { get; set; }
		public string UniprotAccession { get; set; }
		public string GeneDescription { get; set; }
		public string HPAEvidence { get; set; }
		public string RNATissueSpecificity { get; set; }
        public int RNATissueSpecificityScore { get; set; }
		public string RNATissueSpecicNX { get; set; }
		public string UniprotName { get; set; }
        public int Mass { get; set; }
        public int GOAnnotations { get; set; }
        public int GeneID { get; set; }
        public int PubmedCitations { get; set; }
        public int AntibodyCount { get; set; }

	}
}

