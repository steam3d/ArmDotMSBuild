﻿using System;

[assembly: ArmDot.Client.HideStrings()]
[assembly: ArmDot.Client.ObfuscateNamesAttribute()]
[assembly: ArmDot.Client.ObfuscateNamespaces()]
[assembly: ArmDot.Client.ObfuscateControlFlow()]

[assembly: ArmDot.Client.VirtualizeCode()]
namespace FullTrust
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hello World";
            Console.WriteLine("This process runs at the full privileges of the user and has access to the entire public desktop API surface");
            Console.WriteLine("\r\nPress any key to exit ...");
            Console.ReadLine();
        }
    }
}
