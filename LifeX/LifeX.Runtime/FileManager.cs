using System.IO;

namespace LifeX.Runtime
{
    public class FileManager
    {
        public static FileStream Open(string filename)
        {
            return File.Open("some/predefined/path/" + filename, FileMode.Open);
        }
    }
}