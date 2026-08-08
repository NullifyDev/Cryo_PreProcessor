/* // file commented out to avoid confliction with Cryo's Program.cs (not to be confused with this project "Cryo_PreProcessor")
﻿using System.Runtime.InteropServices;

namespace Cryo.PreProcessor;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<string> files = new();
        bool interpret = false;
        foreach(var a in args)
        {
            if (a.EndsWith(".clod")) {
                files.Add(a);
                continue;
            }
            else if (a == "interpret") {
                interpret = true;
                continue;
            }

            if (interpret) {
                System.Console.WriteLine(new PreProcessor().GetObject(a));
                interpret = false;
                continue;
            }

            System.Console.WriteLine($"Unknown argument \"{a}\"");
            return;
        }
        foreach (var f in files)
            foreach(var o in new PreProcessor().GetMethods(f))
                System.Console.WriteLine(o.ToString());
    }
}
*/
