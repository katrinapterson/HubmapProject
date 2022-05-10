
namespace HubmapBlazor.Data
{
	public class TissueProvider
	{
        private ICollection<Tissue> tissueInfos = new List<Tissue>();
        public TissueProvider(BupService bupService, LiteratureProteinService literatureProteinService)
		{
            var tissues = bupService.TissueList();
            var bupInfos = bupService.GetBupInfos();
            var allAbundantBups = bupService.GetAbundantBups(bupInfos);
            var uniqueDict = bupService.GetUniqueDict(allAbundantBups);

            foreach (var tissue in tissues)
            {
                var bupTissues = bupService.GetBupsWithTissue(tissue);
                var abundantBups = bupService.GetAbundantBups(bupTissues);
                var bupAccessions = bupService.TissueAccessions(abundantBups);
                var literatureProteins = literatureProteinService.GetTissueAccessions(bupAccessions);
                var proteinCount = literatureProteins.Count();

                var uniqueProteins = bupService.GetUnique(tissue, uniqueDict);

                Tissue tissue1 = new Tissue(tissue, proteinCount, uniqueProteins);

                tissueInfos.Add(tissue1);
            }
        }

        public IEnumerable<Tissue> GetTissueInfos() => tissueInfos.Where(a => a != null);
    }
}

