/*
 RimWorldTool - https://gitlab.com/tim241/RimWorldTool
 Copyright (C) 2018 Tim Wanders <tim241@mailbox.org>
 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.
 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.
 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.IO;

using RimWorldTool;
using RimWorldTool.Utilities;

namespace RimWorldTool.Mods
{
    public static partial class Mod
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