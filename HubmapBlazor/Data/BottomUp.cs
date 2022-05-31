namespace HubmapBlazor.Data

{
    public class Bup
    {
        public Bup(string uniprotAccession, 
            string commonTissue, string dataset, double abundance, int rank, double normRank)
        {
            UniprotAccession = uniprotAccession;
            CommonTissue = commonTissue;
            Dataset = dataset;
            Abundance = abundance;
            Rank = rank;
            NormRank = normRank;
        }

        public string UniprotAccession { get; set; }
        public string CommonTissue { get; set; }
        public string Dataset { get; set; }
        public double Abundance { get; set; }
        public int Rank { get; set; }
        public double NormRank { get; set; }
    }
}

