
namespace HubmapBlazor.Data
{
    
    public class AntibodyService
    {

        private ICollection<Antibody> _antibodyTableInfos;
        public AntibodyService(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                _antibodyTableInfos = new List<Antibody>();

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


                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split("\t");
                    var anAntibody = new Antibody(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[4],
                        values[5],
                        values[6],
                        values[7],
                        values[8],
                        values[9],
                        toInt(values[10]));
                    _antibodyTableInfos.Add(anAntibody);
                }
            }
        }


        public IEnumerable<Antibody> GetAntibodyInfos() => (_antibodyTableInfos.Where(a => a != null)).Skip(1);

        public IEnumerable<Antibody> GetAntibodyGene(string gene)
        {
            return _antibodyTableInfos.Where(x => x.Gene == gene);
        }


    }

}

