
namespace HubmapBlazor.Data
{
	public class TissueProvider
	{
        private ICollection<Tissue> tissueInfos = new List<Tissue>();
        public TissueProvider()
		{
            var bupInfos = new BupService(@"../HubmapProject/Resources/NewBupData");

            var Tissues = bupInfos.TissueList();


            foreach (var tissue in Tissues)
            {
                var bupTissues = bupInfos.GetBupsWithTissue(tissue);
                var abundantBups = bupInfos.GetAbundantBups(bupTissues);
                var proteinCount = abundantBups.Count();


                var uniqueCount = bupInfos.GetUniqueProteinCount(tissue, bupInfos.GetAbundantBups(bupInfos.GetBupInfos()));

                Tissue tissue1 = new Tissue(tissue, proteinCount, uniqueCount);

                tissueInfos.Add(tissue1);
            }

        }



        public IEnumerable<Tissue> GetTissueInfos() => tissueInfos.Where(a => a != null);
    }
}

