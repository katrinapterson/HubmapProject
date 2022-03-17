using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace HubmapProject
{
	public class AntibodyTableProvider
	{
        private string _file;
        private ICollection<AntibodyTableInfo> _antibodyTableInfos;
        public AntibodyTableProvider(string file)
		{
			_file = file;
		}
        public void GenerateAntibodyTableInfos()
        {
            using (StreamReader reader = new StreamReader(_file))
            {
                _antibodyTableInfos = new List<AntibodyTableInfo>();
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split("\t");
                    var anAntibody = new AntibodyTableInfo(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[4],
                        values[5],
                        values[6],
                        values[7],
                        values[8],
                        values[9]);

                    _antibodyTableInfos.Add(anAntibody);
                }
            }
        }

        public IEnumerable<AntibodyTableInfo> GetAntibodyTableInfo() => (_antibodyTableInfos.Where(a => a != null)).Skip(1);

        public IEnumerable<AntibodyTableInfo> GetAntibodyGene(string gene)
        {
            return _antibodyTableInfos.Where(x => x.Gene == gene);
        }
    }
}

