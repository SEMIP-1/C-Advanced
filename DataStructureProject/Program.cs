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
            
            SemList<string> list1 = new SemList<string>();
            list1.Add("Salah1");
            list1.Add("Eldin1");
            list1.Add("Mohamed1");
            list1.Add("Hussein1");
            list1.Add("Ahmed1");
            list1.Add("Mohamed1");

           list.AddRange(new string[]{"a1","a2","a3","a4","a5","a6"});
        }
    }
}

