using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace HubmapProject
{
    public class AntibodyCountProvider
    {
        private string _file;
        private ICollection<AntibodyCountInfo> _AntibodyCountInfo;
        public AntibodyCountProvider(string file)
        {
            _file = file;
        }
        public void GenerateAntibodyCountInfos()
        {
            using (StreamReader reader = new StreamReader(_file))
            {
                _AntibodyCountInfo = new List<AntibodyCountInfo>();
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
                    AntibodyCountInfo anAntibody = new AntibodyCountInfo(
                        values[0],
                        toInt(values[1]));
                    _AntibodyCountInfo.Add(anAntibody);
                }
            }
        }

        public IEnumerable<AntibodyCountInfo> GetAntibodyCountInfos() => _AntibodyCountInfo.Where(a => a != null);


        public IEnumerable<AntibodyCountInfo> GetAntibodyCounts(int antibodyCount)
        {
            return _AntibodyCountInfo.Where(x => x.AntibodyCount == antibodyCount);
        }

    }
}

