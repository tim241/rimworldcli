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
using RimWorldTool.Cli;

namespace RimWorldTool.Cli
{
    public partial class Program
    {
        public static int counter = 0;
        public static ArgumentCategory category = ArgumentCategory.None;

        static void showBasicUsage()
        {
            ArgumentUsage.Usage usage = new ArgumentUsage.Usage();
            usage.AddOption("help", "displays usage");
            usage.Show();
            Environment.Exit(1);
        }
        static void Main(string[] args)
        {
            bool noNext = false;
            foreach (string arg in args)
            {
                counter++;
                /*
                 * Categories
                 */
                if (category == ArgumentCategory.None)
                {
                    if (args.Length <= counter)
                        noNext = true;

                    switch (arg)
                    {
                        case "help":
                            if (noNext)
                                ArgumentOptions.Help(null, null);
                                
                            category = ArgumentCategory.Help;
                            break; ;
                        case "config":
                            if (noNext)
                                ArgumentOptions.Config(null, null);

                            category = ArgumentCategory.Config;
                            break; ;
                        case "mod":
                            if (noNext)
                                ArgumentOptions.Mod(null, null);

                            category = ArgumentCategory.Mod;
                            break; ;
                        case "run":
                            category = ArgumentCategory.Run;
                            break; ;
                    }

                    if (category == ArgumentCategory.None)
                        showBasicUsage();
                }
                else
                {
                    // mod category
                    if (category == ArgumentCategory.Mod)
                        ArgumentOptions.Mod(arg, args);

                    // config category
                    if (category == ArgumentCategory.Config)
                        ArgumentOptions.Config(arg, args);

                    // help category
                    if (category == ArgumentCategory.Help)
                        ArgumentOptions.Help(arg, args);
                }
            }

            if (counter == 0)
                showBasicUsage();
        }
    }
}
