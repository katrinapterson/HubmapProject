
namespace HubmapBlazor.Data
{
	public class Tissue
	{
		public Tissue(string name, int proteins, List<string> uniqueProteins)
		{
			Name = name;
			Proteins = proteins;
			UniqueProteins = uniqueProteins;
			UniqueProteinsCount = uniqueProteins.Count();
		}
		public string Name { get; set; }
		public int Proteins { get; set; }

		public int UniqueProteinsCount { get; set; }
		public List<string> UniqueProteins { get; set; }
	}
}

