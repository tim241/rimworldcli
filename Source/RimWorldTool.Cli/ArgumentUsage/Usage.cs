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
using System.Collections.Generic;

namespace RimWorldTool.Cli
{
    public static partial class ArgumentUsage
    {
        public class Usage
        {
            private static List<string> options = new List<string>();
            private static List<string> descriptions = new List<string>();
            /// <summary>
            /// Category name
            /// </summary>
            public string category { get; set; }
            /// <summary>
            /// Adds option with description
            /// </summary>
            /// <param name="option">option, can be split using ','</param>
            /// <param name="description">a description for the option(s)</param>
            public void AddOption(string option, string description)
            {
                if (string.IsNullOrEmpty(option))
                    throw new ArgumentNullException("option");

                if (string.IsNullOrEmpty(description))
                    throw new ArgumentNullException("description");

                options.Add(option);
                descriptions.Add(description);
            }
            /// <summary>
            /// Shows the usage
            /// </summary>
            public void Show()
            {
                if(options.ToArray().Length != descriptions.ToArray().Length)
                    return;

                Console.WriteLine();
                Console.WriteLine($"rtcmd {category}");
                Console.WriteLine();

                for (int i = 0; i < options.ToArray().Length; i++)
                {
                    foreach (string option in options[i].Split(','))
                    {
                        Console.WriteLine($"    {option}");
                    }

                    Console.WriteLine($"    \t{descriptions[i]}");
                    Console.WriteLine();
                }
            }

        }
    }
}