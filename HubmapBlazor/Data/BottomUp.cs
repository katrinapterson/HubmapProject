namespace HubmapBlazor.Data

{
    public class Bup
    {
        public Bup(string uniprotAccession, string uniprotName, string geneDescription,
            string commonTissue, string dataset, double abundance, int rank, double normRank)
        {
            UniprotAccession = uniprotAccession;
            UniprotName = uniprotName;
            GeneDescription = geneDescription;
            CommonTissue = commonTissue;
            Dataset = dataset;
            Abundance = abundance;
            Rank = rank;
            NormRank = normRank;
        }

        public string UniprotAccession { get; set; }
        public string UniprotName { get; set; }
        public string GeneDescription { get; set; }
        public string CommonTissue { get; set; }
        public string Dataset { get; set; }
        public double Abundance { get; set; }
        public int Rank { get; set; }
        public double NormRank { get; set; }
    }
}

