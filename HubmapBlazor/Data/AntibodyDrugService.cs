
namespace HubmapBlazor.Data
{

    public class AntibodyDrugService
    {

        private ICollection<AntibodyDrug> _antibodyDrugInfos;
        public AntibodyDrugService(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                _antibodyDrugInfos = new List<AntibodyDrug>();

           
                while (!reader.EndOfStream)
                {
                    var lines = reader.ReadLine();
                    var values = lines.Split("\t");
                    var anAntibody = new AntibodyDrug(
                        values[0],
                        values[1],
                        values[2],
                        values[3],
                        values[16]);
                    _antibodyDrugInfos.Add(anAntibody);
                }
            }
        }


        public IEnumerable<AntibodyDrug> GetAntibodyDrugInfos() => (_antibodyDrugInfos.Where(a => a != null)).Skip(1);

        public IEnumerable<AntibodyDrug> GetAntibodyDrug(string accession)
        {
            return _antibodyDrugInfos.Where(x => x.Accession.Contains(accession));
        }


    }

}
