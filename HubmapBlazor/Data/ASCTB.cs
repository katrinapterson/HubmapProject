using System;
namespace HubmapBlazor.Data
{
	public class ASCTB
	{
		public ASCTB(string organ, string tablr, string reporter)
		{
			Organ = organ;
			Tablr = tablr;
			Reporter = reporter;
		}

		public string Organ { get; set; }
		public string Tablr { get; set; }
		public string Reporter { get; set; }
	}
}

