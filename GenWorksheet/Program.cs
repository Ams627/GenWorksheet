using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenWorksheet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var sheet = new WorkSheet();
            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
