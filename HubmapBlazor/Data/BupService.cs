namespace HubmapBlazor.Data
{
    public class BupService
    {
        
        private ICollection<Bup> _bupInfos = new List<Bup>();
        public BupService(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                _bupInfos = new List<Bup>();
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(",");

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

                    Bup aBup = new Bup(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[4],
                        toDouble(values[5]),
                        toInt(values[6]),
                        toDouble(values[7]));

                    _bupInfos.Add(aBup);
                }
            }
        }
    

           
        public ICollection<Bup> GetAccessionBupInfos(string UniprotAccession)
        {
            var list = new List<Bup>();

            foreach (var bup in _bupInfos)
            {
                if (bup.UniprotAccession == UniprotAccession)
                {
                    list.Add(bup);
                }
            }
            return list;

        }

        public IEnumerable<Bup> GetBupInfos() => (_bupInfos.Where(a => a != null)).Skip(1);


        public IEnumerable<Bup> GetTissues(string tissue) => _bupInfos.Where(a => a.CommonTissue == tissue);


        public IEnumerable<string> TissueList()
        {
            var list = new List<string>();
            foreach (var bupInfo in _bupInfos.Skip(1))
            {
                if (!(list.Contains(bupInfo.CommonTissue)))
                {
                    list.Add(bupInfo.CommonTissue);
                }
            }

            if (list != null)
            {
                list.Sort();
            }

            return list;
        }

        public IEnumerable<string> TissueAccessions(IEnumerable<Bup> bupInfos)
        {
            var list = new HashSet<string>();
            foreach (var bup in bupInfos)
            {
                list.Add(bup.UniprotAccession);
            }
            return list;
        }


        public IEnumerable<Bup> GetAbundantBups(IEnumerable<Bup> bupInfos) => bupInfos.Where(a => a.Abundance != 0);
    }
}
