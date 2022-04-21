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
                        toInt(values[9]),
                        toInt(values[10]),
                        toInt(values[11]),
                        toInt(values[12]),
                        toInt(values[13]));

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

            foreach(var literature in _literatures)
            {
                if (accessions.Contains(literature.UniprotAccession))
                    literatureProteins.Add(literature);
            }

            return literatureProteins;
        }
    }
}
