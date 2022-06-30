namespace HubmapBlazor.Data
{
    public class BupService
    {
        private ICollection<TissueBottomUp> _tissueBupInfos = new List<TissueBottomUp>();
        private ICollection<CellLineBottomUp> _cellLineBupInfos = new List<CellLineBottomUp>();
        public BupService(string tissues, string cellLines)
        {
            using (StreamReader reader = new StreamReader(tissues))
            {
                _tissueBupInfos = new List<TissueBottomUp>();
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split("\t");

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

                    TissueBottomUp aBup = new TissueBottomUp(
                        values[0],
                        values[1],
                        values[2],
                        toDouble(values[3]),
                        toInt(values[4]),
                        toDouble(values[5]),
                        values[6],
                        values[7]);

                    _tissueBupInfos.Add(aBup);
                }
            }

            using (StreamReader reader = new StreamReader(cellLines))
            {
                _cellLineBupInfos = new List<CellLineBottomUp>();
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split("\t");

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

                    //TODO: make sure columns are right
                    CellLineBottomUp aBup = new CellLineBottomUp(
                        values[0],
                        values[1],
                        values[2],
                        toDouble(values[3]),
                        toInt(values[4]),
                        toDouble(values[5]),
                        values[6],
                        values[7]);

                    _cellLineBupInfos.Add(aBup);
                }
            }
        }

        public ICollection<TissueBottomUp> GetAccessionTissueBupInfos(string UniprotAccession)
        {
            var list = new List<TissueBottomUp>();

            foreach (var bup in _tissueBupInfos)
            {
                if (bup.UniprotAccession == UniprotAccession)
                {
                    list.Add(bup);
                }
            }
            return list;
        }

        public ICollection<CellLineBottomUp> GetAccessionCellLineBupInfos(string UniprotAccession)
        {
            var list = new List<CellLineBottomUp>();

            foreach (var bup in _cellLineBupInfos)
            {
                if (bup.UniprotAccession == UniprotAccession)
                {
                    list.Add(bup);
                }
            }
            return list;
        }

        public IEnumerable<TissueBottomUp> GetTissueBupInfos() => (_tissueBupInfos.Where(a => a != null)).Skip(1);


        public IEnumerable<TissueBottomUp> GetBupsWithTissue(string tissue) => _tissueBupInfos.Where(a => a.CommonTissue == tissue);


        public IEnumerable<string> TissueList()
        {
            var list = new HashSet<string>();
            foreach (var bupInfo in _tissueBupInfos.Skip(1))
            {
                list.Add(bupInfo.CommonTissue);
            }

            return list;
        }

        public IEnumerable<string> GetAccessions(IEnumerable<IBottomUp> bupInfos)
        {
            var list = new HashSet<string>();
            foreach (var bup in bupInfos)
            {
                list.Add(bup.UniprotAccession);
            }
            return list;
        }

        public IEnumerable<TissueBottomUp> GetAbundantTissueBups(IEnumerable<TissueBottomUp> bupInfos) => bupInfos.Where(a => a.Abundance != 0);

        public IEnumerable<CellLineBottomUp> GetAbundantCellLineBups(IEnumerable<CellLineBottomUp> bupInfos) => bupInfos.Where(a => a.Abundance != 0);       
    }
}
