using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Tree.Sample.Models;
using Tree.Sample.Tools;

namespace Tree.Sample
{
    internal static class Sample
    {
        public static void Run()
        {
            Benchmark.Start();
            var links = GetLinks();
            Benchmark.Stop($"GetLinks ({links.Count})");

            Benchmark.Start();
            var data = GetData();
            Benchmark.Stop($"GetData ({data.Count})");

            Benchmark.Start();
            BuildTree(ref links, ref data);
            Benchmark.Stop("Populate tree");

            const string outputFile = @"_output.txt";
            File.WriteAllText(outputFile, Benchmark.GetResult());
            Process.Start(outputFile);
        }

        #region loading ressources

        private static IList<Link> GetLinks()
        {
            const string linksFile = @"json\links.json";

            var json = File.ReadAllText(linksFile);
            return JsonConvert.DeserializeObject<IList<Link>>(json);
        }

        private static Dictionary<long, Data> GetData()
        {
            const string linksFile = @"json\data.json";

            var json = File.ReadAllText(linksFile);
            var data = JsonConvert.DeserializeObject<IEnumerable<JsonData>>(json);

            return data.ToDictionary<JsonData, long, Data>(jsonData => jsonData.Id, jsonData => jsonData);
        }

        #endregion

        #region Tree build

        private static void BuildTree(ref IList<Link> links, ref Dictionary<long, Data> data)
        {
            var tree = new Tree<Data>(data.Count);

            foreach (var link in links)
            {
                AddChild(link, ref tree, ref links, ref data);
            }
        }

        private static void AddChild(
            Link link,
            ref Tree<Data> tree,
            ref IList<Link> links,
            ref Dictionary<long, Data> workitemStat)
        {
            if (tree.Contains(link.Id)) return;

            if (link.ParentId != null && !tree.Contains((int)link.ParentId))
            {
                //find parent and add child to
                var parent = links.FirstOrDefault(x => x.Id == link.ParentId) ??
                             new Link { ParentId = null, Id = (int)link.ParentId };

                AddChild(parent, ref tree, ref links, ref workitemStat);
            }

            tree.AddChild(
                link.ParentId,
                link.Id,
                workitemStat[link.Id]);
        }

        #endregion
    }
}
