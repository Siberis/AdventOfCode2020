using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class ReadUtils
    {
        public static async Task<string[]> ReadAllLines(string path)
        {
            return await File.ReadAllLinesAsync(path, Encoding.UTF8).ConfigureAwait(false);
        }
    }
}
