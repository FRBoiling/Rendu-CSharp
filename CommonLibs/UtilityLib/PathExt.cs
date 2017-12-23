using System;
using System.IO;
using System.Windows.Forms;

namespace UtilityLib
{
    public class PathExt
    {
        static private string _bashPath = string.Empty;
        static private string _dataPath = string.Empty;

        public static void InitPath(string pathString=null)
        {
            string rootPath = string.Empty;
            if (string.IsNullOrWhiteSpace(pathString))
            {
                DirectoryInfo path = new DirectoryInfo(Application.StartupPath);
                if (path.Parent.Exists)
                {
                    rootPath = path.Parent.FullName;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Path is wrong!Please check the input path!");
                }
            }
            else
            {
                rootPath = pathString;
            }
            SetPath(rootPath);
        }

        private static void SetPath(string inputPath)
        {
            _bashPath = inputPath;
            _dataPath = PathCombine(inputPath, "Data");
        }

        private static string PathCombine(string inputPath, string folder)
        {
            string newPath = Path.Combine(inputPath, folder);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            return newPath;
        }

        public static string FullPathFromData(string subDir)
        {
            return PathCombine(_dataPath, subDir);
        }
    }
}
