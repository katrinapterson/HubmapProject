namespace HubmapBlazor.Data

{
    public interface IBottomUp
    {
        //public BottomUp(string uniprotAccession, string commonTissue, string dataset, double abundance, int rank, 
        //    double normRank, string geneDescription, string uniprotName)
        //{
        //    UniprotAccession = uniprotAccession;
        //    CommonTissue = commonTissue;
        //    Dataset = dataset;
        //    Abundance = abundance;
        //    Rank = rank;
        //    NormRank = normRank;
        //    GeneDescription = geneDescription;
        //    UniprotName = uniprotName;
        //}

        public string UniprotAccession { get; set; }
        //public string CommonTissue { get; set; }
        public string Dataset { get; set; }
        public double Abundance { get; set; }
        public int Rank { get; set; }
        public double NormRank { get; set; }
        public string GeneDescription { get; set; }
        public string UniprotName { get; set; }
    }
}

