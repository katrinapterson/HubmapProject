using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubmapProject
{
    public class BupInformationProvider
    {
        private string _file;
        private ICollection<BupInfo> _bupInfos;
        public BupInformationProvider(string file)
        {
            _file = file;
        }
        public void GenerateBupInfos()
        {
            using (StreamReader reader = new StreamReader(_file))
            {
                _bupInfos = new List<BupInfo>();
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split(",");

                    double toDouble(string value)
                    {
                        if (double.TryParse(value, out double i))
                        {
                            return i;
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

                    BupInfo aBup = new BupInfo(
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

        public ICollection<BupInfo> GetAccessionBupInfos(string UniprotAccession)
        {
            var list = new List<BupInfo>();

            foreach (var bupInfo in _bupInfos)
            {
                if (bupInfo.UniprotAccession == UniprotAccession)
                {
                    list.Add(bupInfo);
                }
            }
            return list;

        }

        public IEnumerable<BupInfo> GetBupInfos() => (_bupInfos.Where(a => a != null)).Skip(1);


        public IEnumerable<BupInfo> GetTissues(string tissue) => _bupInfos.Where(a => a.CommonTissue == tissue);


        public IEnumerable<string> TissueList()
        {
            var tissues = new List<string>();
            foreach (var bupInfo in _bupInfos.Skip(1))
            {
                if (!(tissues.Contains(bupInfo.CommonTissue)))
                {
                    tissues.Add(bupInfo.CommonTissue);
                }
            }

            if (tissues != null)
            {
                tissues.Sort();
            }

            return tissues;
        }

        public IEnumerable<string> TissueAccessions(IEnumerable<BupInfo> bupInfos)
        {
            var list = new HashSet<string>();
            foreach (var bup in bupInfos)
            {
                list.Add(bup.UniprotAccession);
            }
            return list;
        }
    }
}
