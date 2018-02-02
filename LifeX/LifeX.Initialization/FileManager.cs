using System.IO;

namespace LifeX.Initialization
{
    public class FileManager
    {
        public static FileStream Open(string filename)
        {
            return File.Open("some/predefined/path/" + filename, FileMode.Open);
        }
    }
}