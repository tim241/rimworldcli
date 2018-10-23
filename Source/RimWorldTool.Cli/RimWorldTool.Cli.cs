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
    class Program
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
            // category settings
            bool mod = false;
            bool run = false;
            bool config = false;
            bool help = false;
            bool category = false;

            foreach (string arg in args)
            {
                counter++;
                /*
                 * Categories
                 */
                if (!category)
                {
                    switch (arg)
                    {
                        case "help":
                            help = true;
                            break; ;
                        case "config":
                            config = true;
                            break; ;
                        case "mod":
                            mod = true;
                            break; ;
                        case "run":
                            run = true;
                            break; ;
                    }

                    if (mod || config || run || help)
                        category = true;
                    else
                        usage();
                }
                else
                {
                    /*
                     * mod options
                     */
                    if (mod)
                        ArgumentOptions.Mod(arg, args);
                    /*
                     * config options
                     */
                    if (config)
                        ArgumentOptions.Config(arg, args);
                    /*
                     * help options
                     */
                    if (help)
                        ArgumentOptions.Help(arg, args);
                }

            }
        }
    }
}
