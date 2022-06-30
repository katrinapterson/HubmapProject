
namespace HubmapBlazor.Data
{
	public class TissueProvider
	{
        private ICollection<Tissue> tissueInfos = new List<Tissue>();
        public TissueProvider(BupService bupService, LiteratureProteinService literatureProteinService)
		{
            var tissues = bupService.TissueList();
            var bupInfos = bupService.GetTissueBupInfos();
            var allAbundantBups = bupService.GetAbundantTissueBups(bupInfos);

            foreach (var tissue in tissues)
            {
                var bupTissues = bupService.GetBupsWithTissue(tissue);
                var abundantBups = bupService.GetAbundantTissueBups(bupTissues);
                var bupAccessions = bupService.GetAccessions(abundantBups);
                var literatureProteins = literatureProteinService.GetTissueAccessions(bupAccessions);
                var proteinCount = literatureProteins.Count();

                Tissue tissue1 = new Tissue(tissue, proteinCount);

                tissueInfos.Add(tissue1);
            }
        }

        public IEnumerable<Tissue> GetTissueInfos() => tissueInfos.Where(a => a != null);
    }
}

