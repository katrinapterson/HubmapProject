
namespace HubmapBlazor.Data
{
	public class Tissue
	{
		public Tissue(string name, int proteins, List<string> uniqueProteins)
		{
			Name = name;
			Proteins = proteins;
			UniqueProteins = uniqueProteins;
		}
		public string Name { get; set; }
		public int Proteins { get; set; }
		public List<string> UniqueProteins { get; set; }
	}
}

