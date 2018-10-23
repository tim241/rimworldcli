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
using RimWorldTool;
using RimWorldTool.Mods;

namespace RimWorldTool.Cli
{
    partial class Program
    {
        public static int counter = 0;
        static void usage(string catagory = null, string item = null)
        {
            // 
            Console.WriteLine($"{catagory} {item} Hello World");
            Environment.Exit(1);
        }
        static void Main(string[] args)
        {
            ArgumentCategory category = ArgumentCategory.None;

            foreach (string arg in args)
            {
                counter++;
                /*
                 * Categories
                 */
                if (category == ArgumentCategory.None)
                {
                    switch (arg)
                    {
                        case "help":
                            category = ArgumentCategory.Help;
                            break; ;
                        case "config":
                            category = ArgumentCategory.Config;
                            break; ;
                        case "mod":
                            category = ArgumentCategory.Mod;
                            break; ;
                        case "run":
                            category = ArgumentCategory.Run;
                            break; ;
                    }

                    if (category == ArgumentCategory.None)
                        usage();
                }
                else
                {
                    /*
                     * mod options
                     */
                    if (category == ArgumentCategory.Mod)
                        ArgumentOptions.Mod(arg, args);
                    /*
                     * config options
                     */
                    if (category == ArgumentCategory.Config)
                        ArgumentOptions.Config(arg, args);
                    /*
                     * help options
                     */
                    if (category == ArgumentCategory.Help)
                        ArgumentOptions.Help(arg, args);
                }
            }
        }
    }
}
