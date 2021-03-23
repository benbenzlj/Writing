/// <summary>
/// 原型模式
/// </summary>
using System;

namespace DesignPartterns.Prototype
{

    public class Person
    {
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name;
        public IdInfo IdInfo { get; set; }

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);

            //调用p1的浅复制方法复制p1并赋值给p2
            Person p2 = p1.ShallowCopy();
            //调用p1的深复制方法复制p1并赋值给p3
            Person p3 = p1.DeepCopy();

            //显示 p1,p2,p3的原始值 
            Console.WriteLine("Original values of p1,p2,p3");
            Console.WriteLine("p1 instance values:");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("p3 instance values:");
            DisplayValues(p3);

            //修改p1的属性值并显示p1,p2,p3的值 
            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 7878;
            Console.WriteLine("\n values of p1,p2,p3 after values have changed");
            Console.WriteLine("p1 instance values:");
            DisplayValues(p1);
            Console.WriteLine("p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine($"    Name:{p.Name},Age:{p.Age:D},BirthDate:{p.BirthDate:yyyy-MM-dd}");
            Console.WriteLine($"    ID#:{p.IdInfo.IdNumber}");
        }
    }
}
