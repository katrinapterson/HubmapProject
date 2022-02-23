using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace HubmapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            var bupInformationProvider = new BupInformationProvider(@"../../../../bup_data.csv");
            bupInformationProvider.GenerateBupInfos();
            var bupInfos = bupInformationProvider.GetBupInfos();

            var accessionBupInfos1 = bupInformationProvider.GetAccessionBupInfos("A0A096LP01");

            //linq
            var accessionBupInfos2 = bupInfos.Where(x => x.UniprotAccession == "A0A096LP01");
        }
    }


}