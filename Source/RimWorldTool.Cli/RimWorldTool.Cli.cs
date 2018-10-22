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

            /*
             * options settings
             */

            // mod creation
            bool mod_create = false;
            bool mod_dir_next = false;
            string mod_dir = null;
            string mod_name = null;

            // counter
            int counter = 0;

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
                    {
                        // mod creation options
                        if (mod_create)
                        {
                            switch (arg)
                            {
                                default:
                                    if (!arg.StartsWith("-"))
                                    {
                                        if (!mod_dir_next)
                                        {
                                            if(mod_name == null)
                                                mod_name = arg;
                                            else
                                                usage("mod", "create");
                                        }
                                        else
                                            mod_dir_next = false;
                                    }
                                    else
                                        usage("mod", "create");
                                    break; ;
                                case "-o":
                                    goto case "--out"; ;
                                case "--out":
                                    if (args.Length >= counter)
                                    {
                                        mod_dir = args[counter];
                                        mod_dir_next = true;
                                    }
                                    break; ;
                            }

                            if (args.Length == counter)
                            {
                                if (mod_name == null)
                                    usage("mod", "create");

                                if (mod_name.Contains(' '))
                                    throw new ArgumentException("invalid mod name!");

                                Mod.Create(mod_name, mod_dir);
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            switch (arg)
                            {
                                default:
                                    usage("mod");
                                    break; ;
                                case "create":
                                    mod_create = true;
                                    break; ;
                            }
                        }
                    }
                    /*
                     * config options
                     */
                    if (config)
                    {
                        switch (arg)
                        {
                            default:
                                usage("config");
                                break; ;
                            case "user.name":
                                // TODO: add config
                                break; ;
                            case "rimworld.dir":
                                // TODO: add config
                                break; ;
                        }
                    }
                    /*
                     * help options
                     */
                    if (help)
                    {
                        if (args.Length > counter)
                            usage(args[counter - 1], args[counter]);
                        else if (args.Length == counter)
                            usage(args[counter - 1]);
                        else
                            usage();
                    }
                }

            }
        }
    }
}
