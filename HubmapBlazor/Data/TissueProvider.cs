
namespace HubmapBlazor.Data
{
	public class TissueProvider
	{
        private ICollection<Tissue> tissueInfos = new List<Tissue>();
        public TissueProvider(BupService bupService)
		{
            var tissues = bupService.TissueList();
            var bupInfos = bupService.GetBupInfos();

            foreach (var tissue in tissues)
            {
                var bupTissues = bupService.GetBupsWithTissue(tissue);
                var abundantBups = bupService.GetAbundantBups(bupTissues);
                var proteinCount = abundantBups.Count();

                var uniqueCount = bupService.GetUniqueProteins(tissue, bupService.GetAbundantBups(bupInfos));

                Tissue tissue1 = new Tissue(tissue, proteinCount, uniqueCount);

                tissueInfos.Add(tissue1);
            }
        }

        public IEnumerable<Tissue> GetTissueInfos() => tissueInfos.Where(a => a != null);
    }
}

