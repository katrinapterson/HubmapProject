
namespace HubmapBlazor.Data
{
	public class Tissue
	{
		public Tissue(string name, int proteins, int uniqueProteins)
		{
			Name = name;
			Proteins = proteins;
			UniqueProteins = uniqueProteins;
		}
		public string Name { get; set; }
		public int Proteins { get; set; }
		public int UniqueProteins { get; set; }
	}
}

