using System;
using System.IO;

using RimWorldCli;

namespace RimWorldUtils
{
    public static class Mod
    {
        public static void Create(string modName, string path = null)
        {
            if (string.IsNullOrEmpty(modName))
                throw new ArgumentNullException("modName");

            if (string.IsNullOrEmpty(path))
                path = modName;

            string aboutDir = Path.Combine(path, "About");
            string sourceDir = Path.Combine(path, "Source");
            string modSourceDir = Path.Combine(path, "Source", modName);
            string propertiesDir = Path.Combine(path, "Source", modName, "Properties");

            Utils.CreateDirectories(new string[] {  aboutDir,
                                                    modSourceDir, propertiesDir,
                                                    Path.Combine(modSourceDir, "Source-DLLs")});

            string aboutXml = Path.Combine(aboutDir, "About.xml");
            string modCs = Path.Combine(modSourceDir, $"{modName}.cs");
            string modCsProj = Path.Combine(modSourceDir, $"{modName}.csproj");
            string modSln = Path.Combine(sourceDir, $"{modName}.sln");
            string modAssemblyInfo = Path.Combine(propertiesDir, "AssemblyInfo.cs");

            Utils.CopyResource("About.xml", aboutXml);
            Utils.CopyResource("@@MOD_NAME@@.cs", modCs);
            Utils.CopyResource("@@MOD_NAME@@.csproj", modCsProj);
            Utils.CopyResource("@@MOD_NAME@@.sln", modSln);
            Utils.CopyResource("AssemblyInfo.cs", modAssemblyInfo);

            foreach (string file in new string[] { aboutXml, modCs, modCsProj, modSln, modAssemblyInfo })
            {
                Utils.ReplaceText(file, "@@MOD_NAME@@", modName);

                // TODO
                Utils.ReplaceText(file, "@@AUTHOR@@", null);
                Utils.ReplaceText(file, "@@URL@@", null);
                Utils.ReplaceText(file, "@@RIMWORLD_VERSION@@", null);
            }
        }

    }
}