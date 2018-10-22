using System.IO;
using System.Reflection;
using Resources;

namespace RimWorldCli
{
    public static class Utils
    {
        private static AssemblyName assemblyName = new AssemblyName(nameof(RimWorldCli));
        public static void CopyResource(string fileName, string dest)
        {
            Resource file = new Resource(fileName, assemblyName);
            file.Copy(dest);
        }
        public static void CreateDirectories(string[] dirs)
        {
            foreach(string dir in dirs)
            {
                Directory.CreateDirectory(dir);
            }
        }

        public static void ReplaceText(string file, string replace, string replaceText)
        {
            string text = File.ReadAllText(file).Replace(replace, replaceText);
            File.WriteAllText(file, text);
        }
    }
}