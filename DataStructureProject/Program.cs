// See https://aka.ms/new-console-template for more information
namespace DataStructuresCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SemList<string> list = new SemList<string>(5);
            list[0] = "ahmed";
        }
    }
}

