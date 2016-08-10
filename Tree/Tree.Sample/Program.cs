using System;
using System.Diagnostics;
using System.IO;

namespace Tree.Sample
{
    static class Program
    {
        private static void Main()
        {
            try
            {
                Sample.Run();
            }
            catch (Exception e)
            {
                const string errorFIle = @"_error.txt";

                File.WriteAllText(errorFIle, e.ToString());
                Process.Start(errorFIle);
            }
        }
    }
}
