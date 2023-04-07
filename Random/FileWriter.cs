using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class FileWriter
    {
        public FileWriter() { }
        public void WriteInFile(string path, List<Int32>numbers)
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                numbers.ForEach(line => sr.WriteLine(line));
            }
        }
    }
}
