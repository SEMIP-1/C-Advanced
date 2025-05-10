// See https://aka.ms/new-console-template for more information
using System.IO.Pipes;

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

            //list.InsertRange(5,new string[]{"a1","a2","a3","a4","a5"});
            //list.RemoveRange(2,4);
            //list.Insert(13, "Mohamed");

            Person person1 = new Person();
            person1.ID = "1";
            Person person2 = new Person();
            person1.ID = "2";
            SemList<Person> list2 = new SemList<Person>();
            list2.Add(person2);
            list2.Add(person1);
            list2.Sort();
            List<Person> list3 = new List<Person>();
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
            //hello
        }
    }
}

