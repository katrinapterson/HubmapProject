
namespace HubmapBlazor.Data
{
	public class Tissue
	{
		public Tissue(string name, int proteins)
		{
			Name = name;
			Proteins = proteins;
		}
		public string Name { get; set; }
		public int Proteins { get; set; }
	}
}

