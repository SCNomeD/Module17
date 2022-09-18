namespace Module17._2
{
    #region Program
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello, World!");
    //    }
    //}
    #endregion
    // Порождающие паттерны
    #region ОДИНОЧКА (SINGLETON)
    class Singleton
    {
        // Статическая переменная - ссылка на конкретный экземпдяр объекта
        private static Singleton Instance;

        // Приватный конструктор
        private Singleton()
        { }

        // Здесь конструктор вызывается для создания объекта, если он отсутствует или равен null 
        public static Singleton GetInstance()
        {
            if (Instance == null)
                Instance = new Singleton();

            return Instance;
        }
    }
    #endregion
    #region АБСТРАКТНАЯ ФАБРИКА (ABSTRACT FACTORY)
    abstract class AbstractProductA
    { }

    abstract class AbstractProductB
    { }

    class ProductA1 : AbstractProductA
    { }

    class ProductB1 : AbstractProductB
    { }

    class ProductA2 : AbstractProductA
    { }

    class ProductB2 : AbstractProductB
    { }

    /// <summary>
    /// Базовый интерфейс абстрактной фабрики
    /// </summary>
    interface IAbstractFactory
    {
        // Абстрактный метод для создания продукта  A
        AbstractProductA CreateProductA();

        // Абстрактный метод для создания продукта  B
        AbstractProductB CreateProductB();
    }

    /// <summary>
    ///  Первая конкретная реализация фабрики
    /// </summary>
    class ConcreteFactory1 : IAbstractFactory
    {
        // Конкретная реализация метода для создания продукта  A
        public AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        // Конкретная реализация метода для создания продукта  B
        public AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    /// <summary>
    ///  Вторая конкретная реализация фабрики
    /// </summary>
    class ConcreteFactory2 : IAbstractFactory
    {
        // Конкретная реализация метода для создания продукта  A
        public AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        // Конкретная реализация метода для создания продукта  B
        public AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    /// <summary>
    /// Класс, в котором нам нужно предусмотреть создание объектов фабрикой
    /// </summary>
    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        /// <summary>
        ///  Конструктор класса, в котором происходит создание объектов фабрики
        /// </summary>
        public Client(IAbstractFactory factory)
        {
            _abstractProductB = factory.CreateProductB();
            _abstractProductA = factory.CreateProductA();
        }

        /// <summary>
        ///  Метод с нашей бизнес-логикой, где будут использоваться создаваемые фабрикой объекты
        /// </summary>
        public void Run()
        { }
    }
    #endregion
    #region ФАБРИЧНЫЙ МЕТОД (FACTORY METHOD)
    /// <summary>
    /// Базовый абстрактный класс
    /// </summary>
    abstract class BaseClass
    { }

    /// <summary>
    /// Конкретная реализация A
    /// </summary>
    class ConcreteClassA : BaseClass
    { }

    /// <summary>
    /// Конкретная реализация B
    /// </summary>
    class ConcreteClassB : BaseClass
    { }

    /// <summary>
    /// Абстрактный класс, от которого наследуются конкретные реализации
    /// </summary>
    abstract class Creator
    {
        /// Фабричный метод, который будет переопределен в классах-наследниках
        public abstract BaseClass FactoryMethod();
    }

    /// <summary>
    /// Конкретная реализация A
    /// </summary>
    class ConcreteCreatorA : Creator
    {
        //  Переопределенный Фабричный метод здесь возвращает конкретную реализацию
        public override BaseClass FactoryMethod()
        {
            return new ConcreteClassA();
        }
    }

    /// <summary>
    /// Конкретная реализация B
    /// </summary>
    class ConcreteCreatorB : Creator
    {
        //  Переопределенный Фабричный метод здесь возвращает конкретную реализацию
        public override BaseClass FactoryMethod()
        {
            return new ConcreteClassB();
        }
    }
    #endregion
}