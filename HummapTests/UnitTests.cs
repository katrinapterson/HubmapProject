using HubmapProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HubmapTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void BuInfoAccessionWithLinqTest()
        {
            var buInformationProvider = new BupInformationProvider(@"../../../../HubmapProject/Resources/bup_data.csv");
            buInformationProvider.GenerateBupInfos();
            var bupInfos = buInformationProvider.GetBupInfos();

            var accessionBupInfos1 = buInformationProvider.GetAccessionBupInfos("A0A096LP01");
            var accessionBupInfos2 = bupInfos.Where(x => x.UniprotAccession == "A0A096LP01");

            Assert.AreEqual(accessionBupInfos1.Count, accessionBupInfos2.Count());

        }

        [TestMethod]
        public void AntibodyCountsTest()
        {
            var antibodyCountProvider = new AntibodyCountProvider(@"../../../../HubmapProject/Resources/antibody_count_unconjugated.tsv");
            antibodyCountProvider.GenerateAntibodyCountInfos();
            var antibodyCountInfos = antibodyCountProvider.GetAntibodyCountInfos();

            var antibodyCounts1 = antibodyCountProvider.GetAntibodyCounts(12);
            var antibodyCounts2 = antibodyCountInfos.Where(x => x.AntibodyCount == 12);

            Assert.AreEqual(antibodyCounts1.Count(), antibodyCounts2.Count());
        }

        [TestMethod]
        public void AntibodyTablesTest()
        {
            var antibodyTableProvider = new AntibodyTableProvider(@"../../../../HubmapProject/Resources/antibody_table_unconjugated.tsv");
            antibodyTableProvider.GenerateAntibodyTableInfos();
            var antibodyTableInfos = antibodyTableProvider.GetAntibodyTableInfo();

            var antibodyGene1 = antibodyTableProvider.GetAntibodyGene("FGR");
            var antibodyGene2 = antibodyTableInfos.Where(x => x.Gene == "FGR");

            Assert.AreEqual(antibodyGene1.Count(), antibodyGene2.Count());
        }

        [TestMethod]
        public void LiteratureInfoTest()
        {
            var literatureInfoProvider = new LiteratureInfoProvider(@"../../../../HubmapProject/Resources/literature_data.csv");
            literatureInfoProvider.GenerateLiteratureInfos();
            var literatureInfos = literatureInfoProvider.GetLiteratureInfos();

            var literatureGene1 = literatureInfoProvider.GetGene("AADACL3");
            var literatureGene2 = literatureInfos.Where(x => x.Gene == "AADACL3");

            Assert.AreEqual(literatureGene1.Count(), literatureGene2.Count());
        }
    }
}