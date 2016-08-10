using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Tree.Sample.Tools
{
    internal static class Benchmark
    {
        private static readonly List<string> LOGS = new List<string>();

        private const string OUTPUT_FILE = @"output.txt";

        private static readonly Stopwatch WATCH = new Stopwatch();

        public static void Start()
        {
            WATCH.Restart();
        }

        public static void Stop(string title)
        {
            WATCH.Stop();
            var msg = $"{title}. Duration: {WATCH.ElapsedMilliseconds} ms.";
            LOGS.Add($"[{DateTime.Now.ToString("yyy-MM-dd HH:mm:s")}] {msg}");
            Debug.WriteLine(msg);
        }

        public static string GetResult()
        {
            return string.Join("\r\n", LOGS);
        }
    }
}
