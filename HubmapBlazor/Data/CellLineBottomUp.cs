namespace HubmapBlazor.Data
{
    public class CellLineBottomUp : IBottomUp
    {
        public CellLineBottomUp(string uniprotAccession,string cellLine, string dataset, double abundance, 
            int rank, double normRank, string geneDescription, string uniprotName)
        {
            UniprotAccession = uniprotAccession;
            CellLine = cellLine;
            Dataset = dataset;
            Abundance = abundance;
            Rank = rank;
            NormRank = normRank;
            GeneDescription = geneDescription;
            UniprotName = uniprotName;
        }

        public string UniprotAccession { get; set; }
        public string Dataset { get; set; }
        public double Abundance { get; set; }
        public int Rank { get; set; }
        public double NormRank { get; set; }
        public string GeneDescription { get; set; }
        public string UniprotName { get; set; }
        public string CellLine { get; set; }
    }
}
