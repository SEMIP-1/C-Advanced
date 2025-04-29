// See https://aka.ms/new-console-template for more information
namespace DataStructuresCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            SemList<string> list = new SemList<string>();
            list.Add("Salah");
            list.Add("Eldin");
            list.Add("Mohamed");
            list.Add("Hussein");
            list.Add("Ahmed");
            list.Add("Mohamed");
            Console.WriteLine(list.Count);
            Console.WriteLine(list[2]);
            list.RemoveAT(2);
            Console.WriteLine(list.Count);
            Console.WriteLine(list[2]);

        }
    }
}

