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
            var buInformationProvider = new BupInformationProvider(@"../../../../bup_data.csv");
            buInformationProvider.GenerateBupInfos();
            var bupInfos = buInformationProvider.GetBupInfos();

            var accessionBupInfos1 = buInformationProvider.GetAccessionBupInfos("A0A096LP01");
            var accessionBupInfos2 = bupInfos.Where(x => x.UniprotAccession == "A0A096LP01");

            Assert.AreEqual(accessionBupInfos1.Count, accessionBupInfos2.Count());
        }
    }
}