using System;

[assembly: ArmDot.Client.HideStrings()]
[assembly: ArmDot.Client.ObfuscateNamesAttribute()]
[assembly: ArmDot.Client.ObfuscateNamespaces()]
[assembly: ArmDot.Client.ObfuscateControlFlow()]

//[assembly: ArmDot.Client.VirtualizeCode()]
namespace FullTrust
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hello World";
            Console.WriteLine("This process runs at the full privileges of the user and has access to the entire public desktop API surface");
            var i = UselessMethod();
            var useless = new UselessClass(i, "Main");
            Console.WriteLine($"{useless.Count} =  {useless.Tag}");
            Console.WriteLine("\r\nPress any key to exit ...");
            Console.ReadLine();
        }

        private static int UselessMethod()
        {
            return 5;
        }

        internal class UselessClass
        {
            private int count = 0;

            private string tag = "UselessClass";

            public int Count { get { return count; } }

            public string Tag { get { return tag; } }
            
            public UselessClass(int count, string tag)
            {
                this.count = count;
                this.tag = tag;            
            }
        }
    }
}
