using System;

namespace DesignPattern.AbstractFactory
{

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    public interface IAbstractProductA
    {
        string UseFulFunctionA();
    }

    public interface IAbstractProductB
    {
        string UseFulFunctionB();
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UseFulFunctionA()
        {
            return "The result of the product A1 .";
        }
    }
    public class ConcreteProductA2 : IAbstractProductA
    {
        public string UseFulFunctionA()
        {
            return "The result of the product A2.";
        }
    }

    public class ConcreteProductB1 : IAbstractProductB
    {
        public string UseFulFunctionB()
        {
            return "The result of the product B1";
        }

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UseFulFunctionA();
            return $"The result of the B1 collaboration with the {result}";
        }
    }

    public class ConcreteProductB2 : IAbstractProductB
    {
        public string UseFulFunctionB()
        {
            return "The result of the product B2.";
        }

        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UseFulFunctionA();
            return $"The result of the B2 collaborator with the  {result}";
        }
    }



    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client ：Testing client code with the first factory type..");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine();

            Console.WriteLine("");
            ClientMethod(new ConcreteFactory2());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();

            Console.WriteLine(productB.UseFulFunctionB());
            Console.WriteLine(productB.AnotherUsefulFunctionB(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}