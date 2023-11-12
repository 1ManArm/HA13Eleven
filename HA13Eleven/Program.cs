namespace HA13Eleven
{
    internal class Program
    {
        public class DataStorage<T>
        {
            private List<T> data;

            public DataStorage()
            {
                data = new List<T>();
            }

            public void AddData(T item)
            {
                data.Add(item);
            }

            public void RemoveData(T item)
            {
                data.Remove(item);
            }

            public bool ContainsData(T item)
            {
                return data.Contains(item);
            }

            public void PrintData()
            {
                foreach (T item in data)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person()
            {
            }

            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}";
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }

            public Product()
            {
            }

            public Product(string name, decimal price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Price: {Price}";
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
            public string Major { get; set; }
            public List<string> Subjects { get; set; }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person("John", 30);
            Person person2 = new Person("Anna", 25);

            Product product1 = new Product("Apple", 1.99m);
            Product product2 = new Product("Banana", 0.99m);

            DataStorage<Person> personDataStorage = new DataStorage<Person>();
            personDataStorage.AddData(person1);
            personDataStorage.AddData(person2);

            DataStorage<Product> productDataStorage = new DataStorage<Product>();
            productDataStorage.AddData(product1);
            productDataStorage.AddData(product2);

            Console.WriteLine("Person Data:");
            personDataStorage.PrintData();

            Console.WriteLine("Product Data:");
            productDataStorage.PrintData();

            Console.WriteLine("Is Anna in personDataStorage: " + personDataStorage.ContainsData(person2));
            Console.WriteLine("Is Banana in productDataStorage: " + productDataStorage.ContainsData(product2));

            personDataStorage.RemoveData(person1);
            productDataStorage.RemoveData(product1);

            Console.WriteLine("Person Data after removal:");
            personDataStorage.PrintData();

            Console.WriteLine("Product Data after removal:");
            productDataStorage.PrintData();

            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    Name = "John",
                    Age = 21,
                    Gender = "Male",
                    Major = "Computer Science",
                    Subjects = new List<string>() { "Math", "Physics", "Programming" }
                },
                new Student()
                {
                    Name = "Alice",
                    Age = 23,
                    Gender = "Female",
                    Major = "Biology",
                    Subjects = new List<string>() { "Biology", "Chemistry" }
                },
                new Student()
                {
                    Name = "Mike",
                    Age = 19,
                    Gender = "Male",
                    Major = "Economics",
                    Subjects = new List<string>() { "Economics", "Statistics" }
                },
                
            };

            
            var maleStudents = students.Where(s => s.Gender == "Male");
            Console.WriteLine("Male Students:");
            foreach (var student in maleStudents)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();

            var youngStudents = students.Where(s => s.Age >= 20 && s.Age <= 25);
            Console.WriteLine("Students aged 20-25:");
            foreach (var student in youngStudents)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine();

            var studentsByMajor = students.GroupBy(s => s.Major);
            Console.WriteLine("Number of students by major:");
            foreach (var group in studentsByMajor)
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
            Console.WriteLine();

            var uniqueSubjects = students.SelectMany(s => s.Subjects).Distinct();
            Console.WriteLine("Unique subjects studied by students:");
            foreach (var subject in uniqueSubjects)
            {
                Console.WriteLine(subject);
            }
            Console.WriteLine();

            var studentWithMostSubjects = students.OrderByDescending(s => s.Subjects.Count).FirstOrDefault();
            Console.WriteLine("Student with the most subjects:");
            Console.WriteLine(studentWithMostSubjects.Name);
        }
    }
}