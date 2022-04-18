using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace HubmapProject
{
	public class LiteratureInfoProvider
	{
		private string _file;
		private ICollection<LiteratureInfo> _literatureInfos;
		public LiteratureInfoProvider(string file)
		{
			_file = file;
		}
        public void GenerateLiteratureInfos()
        {
            using (StreamReader reader = new StreamReader(_file))
            {
                _literatureInfos = new List<LiteratureInfo>();
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(",");
                    

                    int toInt(string value)
                    {
                        if (int.TryParse(value, out int i))
                        {
                            return i;
                        }
                        else
                        {
                            return 0;
                        }
                    }


                    var s = new LiteratureInfo(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[4],
                        values[5],
                        toInt(values[6]),
                        values[7],
                        values[8],
                        toInt(values[9]),
                        toInt(values[10]),
                        toInt(values[11]),
                        toInt(values[12]),
                        toInt(values[13]));

                    _literatureInfos.Add(s);
                }
            }
        }

        public IEnumerable<LiteratureInfo> GetLiteratureInfos() => (_literatureInfos.Where(a => a != null)).Skip(1);
           

        public IEnumerable<LiteratureInfo> GetGene(string gene)
        {
            return _literatureInfos.Where(x => x.Gene == gene);
        }

        public IEnumerable<LiteratureInfo> GetAccession(string accession)
        {
            return _literatureInfos.Where(x => x.UniprotAccession == accession);
        }

        public IEnumerable<LiteratureInfo> GetTissueAccessions(IEnumerable<string> accessions)
        {
            var list = new List<LiteratureInfo>();
            foreach (var accession in accessions)
            {
                var proteins = _literatureInfos.Where(x => x.UniprotAccession == accession);
                foreach (var protein in proteins)
                {
                    list.Add(protein);
                }
            }

            return list;
        }
    }
}

