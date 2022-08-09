
namespace HubmapBlazor.Data
{
    public class AntibodyDrug
    {
        public AntibodyDrug(string accession, string internationalName, string brandName, string targetAntigen, string indication)
        {
            Accession = accession;
            InternationalName = internationalName;
            BrandName = brandName;
            TargetAntigen = targetAntigen;
            Indication = indication;
            
        }

        public string Accession { get; set; }
        public string InternationalName { get; set; }
        public string BrandName { get; set; }
        public string TargetAntigen { get; set; }
        public string Indication { get; set; }
        
    }
}

