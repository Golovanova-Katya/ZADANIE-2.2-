using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Parallelepiped
    {
        private int _A = 0;
        private int _B = 0;
        private int _C = 0;
        private string _name = "";

        public Parallelepiped(string name)
        {
            if (name.Length > 0)
            {
                _name = name;
            }
            else
                _name = "NoName";
        }

        static Parallelepiped()
        {
            //Пустое тело 
        }


        public void Print()
        {
            Console.WriteLine("{0}: сторона - {1}см, сторона - {2}см, сторона - {3}см", _name, _A, _B, _C);
        }

        public string Name
        {
            set { _name = Convert.ToString(value); }
            get { return _name; }
        }
        public int A
        {
            set { _A = Math.Abs(value); }
            get { return _A; }
        }

        public int B
        {
            set { _B = Math.Abs(value); }
            get { return _B; }
        }
        public int C
        {
            set { _C = Math.Abs(value); }
            get { return _C; }
        }

        ~Parallelepiped()
        {
            Console.WriteLine("Объект удален!");
        }
    }
}






namespace ConsoleApplication1
{
    class StaticParallelepiped
    {

        public static void PrintList(List<Parallelepiped> Parallelepipeds)
        {
            foreach (Parallelepiped parallelepiped in Parallelepipeds) parallelepiped.Print();
        }
    }
}






namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Parallelepiped> parallelepipedList = new List<Parallelepiped>
        {
            new Parallelepiped ("Прямой") {A = random.Next(1, 100), B = random.Next(1,100),  C = random.Next(1,100) },
            new Parallelepiped ("Прямоугольный") {A = random.Next(1, 100), B = random.Next(1,100),  C = random.Next(1,100) },

        };
            Console.WriteLine("Cписок:");
            StaticParallelepiped.PrintList(parallelepipedList);

            Console.WriteLine("\nCписок в обратном порядке:");
            parallelepipedList.Reverse();
            StaticParallelepiped.PrintList(parallelepipedList);

            Console.WriteLine("\nCписок по ребру А:");
            StaticParallelepiped.PrintList(parallelepipedList.OrderBy(h => h.A).ToList());

            parallelepipedList.Add(new Parallelepiped("Куб") { A = random.Next(1, 100), B = random.Next(1, 100), C = random.Next(1, 100) });

            Console.WriteLine("\nCписок с добавленным в конце элементом");
            StaticParallelepiped.PrintList(parallelepipedList);
            parallelepipedList.Insert(2, new Parallelepiped("Произвольный") { A = random.Next(1, 100), B = random.Next(1, 100), C = random.Next(1, 100) });

            Console.WriteLine("\nCписок со вставленным элементом");
            StaticParallelepiped.PrintList(parallelepipedList);

            parallelepipedList.RemoveAt(2);
            Console.WriteLine("\nCписок с удаленным вставленным элементом");
            StaticParallelepiped.PrintList(parallelepipedList);

            int index = parallelepipedList.FindIndex(h => h.Name == "Куб");
            Console.WriteLine("\nНайденный элемент списка");
            parallelepipedList[index].Print();
            parallelepipedList.Clear();
            Console.WriteLine("\nПустой список");
            StaticParallelepiped.PrintList(parallelepipedList);
            Console.ReadKey();
        }
    }
}