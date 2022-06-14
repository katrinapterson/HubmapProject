namespace HubmapBlazor.Data
{
    public class LiteratureProtein
    {
        public LiteratureProtein(string gene, string ensembl, string uniprotAccession, string geneDescription, string hpaEvidence,
            string rnaTissueSpecificity, int rnaTissueSpecificityScore, string rnaTissueSpecificNX, string uniprotName, double mass,
            int goAnnotations, int geneID, int pubmedCitations, int antibodyCount, string hgnc, string asctb_tissues, string asctb_uberon)
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
            HGNC = hgnc;
            ASCTB_Tissues = asctb_tissues;
            ASCT_Uberon = asctb_uberon;
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
        public double Mass { get; set; }
        public int GOAnnotations { get; set; }
        public int GeneID { get; set; }
        public int PubmedCitations { get; set; }
        public int AntibodyCount { get; set; }
        public string HGNC { get; set; }
        public string ASCTB_Tissues { get; set; }
        public string ASCT_Uberon { get; set; }
    }
}
