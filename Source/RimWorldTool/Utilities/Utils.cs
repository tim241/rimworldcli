/*
 RimWorldCli - https://gitlab.com/tim241/RimWorldCli
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

using System.IO;
using System.Reflection;
using RimWorldTool;
using RimWorldTool.Resources;

namespace RimWorldTool.Utilities
{
    public static class Utils
    {
        private static AssemblyName assemblyName = new AssemblyName("RimWorldTool");
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