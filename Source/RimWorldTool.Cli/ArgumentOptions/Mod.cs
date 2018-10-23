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
using RimWorldTool.Mods;

namespace RimWorldTool.Cli
{
    public static partial class ArgumentOptions
    {
        private static string mod_name = null;
        private static string mod_dir = null;
        private static bool mod_create = false;
        private static bool mod_dir_next = false;
        private static int counter => Program.counter;
        /// <summary>
        /// Mod category
        /// </summary>
        /// <param name="arg">current argument</param>
        /// <param name="args">argument array</param>
        public static void Mod(string arg, string[] args)
        {
            if (mod_create)
            {
                switch (arg)
                {
                    default:
                        if (!arg.StartsWith("-"))
                        {
                            if (!mod_dir_next)
                            {
                                if (mod_name == null)
                                    mod_name = arg;
                                else
                                    ArgumentUsage.Mod("create");
                            }
                            else
                                mod_dir_next = false;
                        }
                        else
                            ArgumentUsage.Mod("create");
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
                        ArgumentUsage.Mod("create");

                    if (mod_name.Contains(' '))
                        throw new ArgumentException("invalid mod name!");

                    Mods.Mod.Create(mod_name, mod_dir);
                    Environment.Exit(0);
                }
            }

            else
            {
                switch (arg)
                {
                    default:
                        ArgumentUsage.Mod();
                        break; ;
                    case "create":
                        mod_create = true;
                        break; ;
                }
            }
        }
    }
}