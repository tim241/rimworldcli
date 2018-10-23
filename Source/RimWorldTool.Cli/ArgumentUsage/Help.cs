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

namespace RimWorldTool.Cli
{
    public static partial class ArgumentUsage
    {
        private static void helpUsage(int exitCode = 0)
        {
            Usage usage = new Usage();
            usage.category = "help";
            usage.AddOption("mod", "shows the help for mod");
            usage.Show();

            Environment.Exit(exitCode);
        }
        public static void Help(string item = null)
        {
            Usage usage = new Usage();
            switch (item)
            {
                default:
                    helpUsage(1);
                    break; ;
                case "mod":
                    ArgumentUsage.Mod(null, 0);
                    break; ;
            }
        }
    }
}