using System;

namespace RefactoringGuru.DesignPatterns.FactoryMethod.Conceptual
{

    abstract class Creator
    {
        public abstract IProduct FactorMethod();

        public string SomeOperation()
        {
            var product = FactorMethod();
            var result = "Creator : the same creator‘s code has just worked with " + product.Operation();
            return result;
        }
    }
    public interface IProduct
    {
        string Operation();
    }

    class ConcreteCreator1 : Creator
    {
        public override IProduct FactorMethod()
        {
            return new ConcreteProduct1();
        }
    }
    class ConcreteCreator2 : Creator
    {
        public override IProduct FactorMethod()
        {
            return new ConcreteProduct2();
        }
    }

    class ConcreteProduct1 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct1}";
        }
    }

    class ConcreteProduct2 : IProduct
    {
        public string Operation()
        {
            return "{Result of ConcreteProduct2}";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("App : Launched with then ConcreteCrateor.");
            ClientCode(new ConcreteCreator1());

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ConcreterCreator2");
            ClientCode(new ConcreteCreator2());

        }

        public void ClientCode(Creator creator)
        {
            Console.WriteLine("Client : I'm not aware of then creator's class ,but is still works.\n" + creator.SomeOperation());
        }
    }

    class Programe
    {
        static void Main(String[] args)
        {
            new Client().Main();
        }
    }
}
