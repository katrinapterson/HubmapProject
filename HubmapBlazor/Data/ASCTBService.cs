using System;
namespace HubmapBlazor.Data
{
	public class ASCTBService
	{
		private ICollection<ASCTB> _ASCTBs = new List<ASCTB>();
		private Dictionary<string, string>  ASCTBDict = new Dictionary<string, string>();

		public ASCTBService(string file)
		{
			using (StreamReader reader = new StreamReader(file))
			{
				while (!reader.EndOfStream)
				{
					var lines = reader.ReadLine();
					var values = lines.Split("\t");

					var a = new ASCTB(
						values[0],
						values[1],
						values[2]);

					ASCTBDict.Add(values[0], values[2]);

					_ASCTBs.Add(a);
				}
			}
		}

		public IEnumerable<ASCTB> GetTissues(string tissues)
        {
			var list = new List<ASCTB>();

			foreach (var asctb in _ASCTBs)
            {
				if (tissues.Contains(asctb.Organ)){
					list.Add(asctb);
                }
            }

			return list;
        }


		public string GetLink(string tissue)
        {
			if (ASCTBDict.TryGetValue(tissue, out var value)){
				return value;
            }
            else
            {
				return "not a link";
            }
        }

	} 
}
