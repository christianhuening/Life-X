using System.IO;
using LifeX.Components.Data;

namespace LifeX.Initialization
{
    public static class Import
    {
        public static DataGrid<double> FromGreyscaleMap(FileStream fs)
        {
            return new DataGrid<double>();
        }
    }
}