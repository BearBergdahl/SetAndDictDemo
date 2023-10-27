using System.Globalization;

namespace SetAndDictDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First a sortedset");
            SortedSet<int> sortedSet = new SortedSet<int>();
            sortedSet.Add(1);
            sortedSet.Add(2);   
            sortedSet.Add(3);
            sortedSet.Add(4);
            sortedSet.Add(5);
            sortedSet.Add(61);
            sortedSet.Add(74);
            sortedSet.Add(sortedSet.Count);
            sortedSet.Add(3);    
            sortedSet.Add(6);
            sortedSet.Add(sortedSet.Count + 5);    
            sortedSet.Add(7);
            sortedSet.Add(77);
            sortedSet.Add(34);
            foreach (int item in sortedSet)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("Now lets use it for a Person register");
            SortedSet<Person> personSet = new SortedSet<Person>(new PersonComparer());
            personSet.Add(new Person { Id = 2, Name = "Sven" });
            personSet.Add(new Person { Id = 3, Name = "Sven" });
            personSet.Add(new Person { Id = 2, Name = "Svenne" });
            personSet.Add(new Person { Id = 1, Name = "Svenne" });
            personSet.Add(new Person { Id = 7, Name = "Nils" });
            personSet.Add(new Person { Id = 5, Name = "Sven" });
            personSet.Add(new Person { Id = 2, Name = "Sven" });
            List<Person> list = personSet.ToList();
            list.ForEach(person => Console.WriteLine(person.Name +" " + person.Id ));

            Console.WriteLine("Quick Dict");
            Dictionary<int, Person> employees = new Dictionary<int, Person>(); 
            employees.Add(1, list[0]);  
            employees.Add(2, list[1]);
            employees.Add(3, list[3]);
            
            
            Person person1 = employees[1];
            Person person2 = employees[2];

            Dictionary<string, List<Person>> namedListDict = new Dictionary<string, List<Person>>()
            {
                ["mysorted"] = new List<Person> { person1, person2 }
            };
            foreach (List<Person> personList in namedListDict.Values)
            {
                foreach (Person person in personList)
                {
                    Console.WriteLine(person.Name);
                }
            }

        }
        public class Person
        {
            public int Id {  get; set; }
            public string Name { get; set; }

        }
        public class PersonComparer : IComparer<Person>
        {
            int IComparer<Person>.Compare(Person? x, Person? y)
            {
                int compareName = x.Name.CompareTo(y.Name);
                if (compareName == 0)
                {
                    return x.Id.CompareTo(y.Id);
                } 
                return compareName;
            }
        }
    }
}