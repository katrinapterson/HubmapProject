using System;
using System.IO;
using System.Collections.Generic;

namespace HubmapProject
{
    class BupInfo
    {
        static void Main(string[] args)
        {
            Console.WriteLine();



            var bupInfos = GenerateBupInfos(@"../../../../bup_data.csv");



        }

        public string uniprotAccession { get; set; }
        public string uniprotName { get; set; }
        public string geneDescription { get; set; }
        public string commonTissue { get; set; }
        public string dataset { get; set; }
        public string abundance { get; set; }
        public string rank { get; set; }
        public string normRank { get; set; }


        public static IEnumerable<BupInfo> GenerateBupInfos(string filePath)
        {
            var reader = new StreamReader(filePath);
            var bupInfos = new List<BupInfo>();
            while (!reader.EndOfStream)
            {
                var lines = reader.ReadLine();
                var values = lines.Split(",");
                BupInfo aBup = new BupInfo()
                {
                    uniprotAccession = values[0],
                    uniprotName = values[1],
                    geneDescription = values[2],
                    commonTissue = values[3],
                    dataset = values[4],
                    abundance = values[5],
                    rank = values[6],
                    normRank = values[7]

                };

                bupInfos.Add(aBup);
            }
            return bupInfos;
        }

        public static IEnumerable<BupInfo> GetBupInfos(ICollection<BupInfo> bupInfos, string UniprotAccession)
        {
            var list = new List<BupInfo>();

            foreach (var bupInfo in bupInfos)
            {
                if (bupInfo.uniprotAccession == UniprotAccession)
                {
                    list.Add(bupInfo);
                }
            }
            return list;

        }
    }


}