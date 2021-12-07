using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Util
{
    public static class FileConverter
    {
        public static List<string> FileToStringList(string file)
        {
            var lines = File.ReadAllLines("C:/Users/vaney/source/repos/AdventOfCode2021/AdventOfCode2021/Files/" + file).ToList();
            return lines;
        }

        public static List<int> FileToIntList(string file)
        {
            var lines = File.ReadAllLines("C:/Users/vaney/source/repos/AdventOfCode2021/AdventOfCode2021/Files/" + file).ToList();
            return lines.Select(line => Int32.Parse(line)).ToList();
        }
    }
}
