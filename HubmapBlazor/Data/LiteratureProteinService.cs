namespace HubmapBlazor.Data
{
    public class LiteratureProteinService
    {
        private ICollection<LiteratureProtein> _literatures = new List<LiteratureProtein>();

        public LiteratureProteinService(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split("\t");

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
                    double toDouble(string value)
                    {
                        if (double.TryParse(value, out double i))
                        {
                            return Math.Round(i, 3);
                        }
                        else
                        {
                            return 0.0;
                        }
                    }

                    
                    var s = new LiteratureProtein(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[4],
                        values[5],
                        toInt(values[6]),
                        values[7],
                        values[8],
                        toDouble(values[9]) / 1000,
                        toInt(values[10]),
                        toInt(values[11]),
                        toInt(values[12]),
                        toInt(values[13]),
                        values[14],
                        values[15],
                        values[16]);

                    _literatures.Add(s);
                }
            }
        }


        public Task<LiteratureProtein[]> GetLiteratureAsync(IEnumerable<string> accessions)
        {
            var literatures = new List<LiteratureProtein>();

            return (Task<LiteratureProtein[]>)Task.Run(() =>
            {
                foreach (var accession in accessions)
                {
                    literatures.AddRange(_literatures.Where(x => x.UniprotAccession == accession));
                }

                literatures.ToArray();
            });
        }

        public IEnumerable<LiteratureProtein> GetTissueAccessions(IEnumerable<string> accessions)
        {
            var literatureProteins = new List<LiteratureProtein>();

            foreach (var literature in _literatures)
            {
                if (accessions.Contains(literature.UniprotAccession))
                    literatureProteins.Add(literature);
            }

            return literatureProteins;
        }


        public IEnumerable<LiteratureProtein> GetProteins()
        {
            return _literatures.Skip(1);
        }

        public string? GetGeneFromAccession(string accession)
        {
            foreach (var literature in _literatures)
            {
                if (literature.UniprotAccession == accession) return literature.Gene;
            }
            return null;
        }


        public string GetASCTBTissues(string accession)
        {
            foreach (var literature in _literatures)
            {
                if (literature.UniprotAccession == accession) return literature.ASCTB_Tissues;
            }
            return null;
        }



    }
}
