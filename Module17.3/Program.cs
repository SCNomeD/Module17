using System.Text;

namespace Module17._3
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
    // Структурные паттерны
    #region АДАПТЕР (ADAPTER)
    // Наш код, где необходимо использование класса-источника
    class Client1
    {
        public void Request(DataSource dataSource)
        {
            dataSource.GetData();
        }
    }

    /// <summary>
    /// Класс - источник ресурса, к которому нужно подключиться
    /// </summary>
    class DataSource
    {
        public virtual void GetData()
        { }
    }

    /// <summary>
    /// Класс - потребитель ресурса
    /// </summary>
    class DataConsumer
    {
        public void GetSpecificData()
        { }
    }

    /// <summary>
    /// Адаптер для подключения
    /// </summary>
    class Adapter : DataSource
    {
        private DataConsumer _dataConsumer = new DataConsumer();

        // метод для получения ресурса
        public override void GetData()
        {
            _dataConsumer.GetSpecificData();
        }
    }
    #endregion
    #region КОМПОНОВЩИК (COMPOSITE)
    /// <summary>
    /// Общий интерфейс для всех компонентов древовидной структуры
    /// </summary>
    abstract class Component
    {
        public readonly string Name;

        protected Component(string name)
        {
            this.Name = name;
        }

        #region Методы для добавления / удаления под-компонентов

        public abstract void Display();
        public abstract void Add(Component c);
        public abstract void Remove(Component c);

        #endregion
    }

    /// <summary>
    /// Представляет компонент самого низкого уровня
    /// Который не может содержать под-компонентов
    /// </summary>
    class File : Component
    {
        public File(string name)
            : base(name)
        { }

        public override void Display()
        {
            Console.WriteLine(Name);
        }

        // Метод для добавления под-компонентов не поддерживается
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        // Метод для удаления под-компонентов не поддерживается
        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Представляет папку - компонент, который может содержать другие компоненты
    /// Здесь реализован механизм для добавления / удаления новых компонентов
    /// </summary>
    class Folder : Component
    {
        List<Component> subFolders = new List<Component>();

        public Folder(string name)
            : base(name)
        { }

        // Метод для добавления новых под-компонентов
        public override void Add(Component component)
        {
            subFolders.Add(component);
            Console.WriteLine($"В {this.Name} добавлено: {component.Name} ");
        }

        // Метод для удаления
        public override void Remove(Component component)
        {
            subFolders.Remove(component);
            Console.WriteLine($"Из {this.Name} удалено: {component.Name} ");
        }

        // Метод для отображения нижестоящих компонентов
        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} содержит:");

            foreach (Component component in subFolders)
                component.Display();
        }
    }

    /// <summary>
    /// Клиентский код 
    /// </summary>
    class Client2
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Создание корневой папки
            Component rootFolder = new Folder("Root");

            // Создание файла - компонента низшего уровня 
            Component myFile = new File("MyFile.txt");

            // Создание папки с документами
            Folder documentsFolder = new Folder("MyDocuments");

            // Добавляем файл в корневую папки
            rootFolder.Add(myFile);

            // Добавляем подпапку для документов в корневую папку
            rootFolder.Add(documentsFolder);

            // показываем контент корневой папки
            rootFolder.Display();
        }
    }
    #endregion
    #region ФАСАД (FACADE)
    public class SystemOne
    {
        public void S1Method()
        { }
    }

    public class SystemTwo
    {
        public void S2Method()
        { }
    }

    public class SystemThree
    {
        public void S3Method()
        { }
    }

    /// <summary>
    /// Фасад, скрывающий от клиентского кода взаимодействие с системами
    /// </summary>
    public class Facade
    {
        private SystemOne _systemOne;
        private SystemTwo _systemTwo;
        private SystemThree _systemThree;

        /// <summary>
        ///  Метод-конструктор принимает системы на вход 
        /// </summary>
        public Facade(SystemOne systemOne, SystemTwo systemTwo, SystemThree systemThree)
        {
            _systemOne = systemOne;
            _systemTwo = systemTwo;
            _systemThree = systemThree;
        }

        // методы для клиента, через которые он взаимодействует с системами
        public void OperationOne()
        {
            _systemOne.S1Method();
            _systemTwo.S2Method();
            _systemThree.S3Method();
        }
        public void OperationTwo()
        {
            _systemTwo.S2Method();
            _systemThree.S3Method();
        }
    }

    /// <summary>
    /// Клиентский код
    /// </summary>
    class Client3
    {
        public void Main()
        {
            // Создание фасада 
            Facade facade = new Facade(new SystemOne(), new SystemTwo(), new SystemThree());

            // Вызовы
            facade.OperationOne();
            facade.OperationTwo();
        }
    }
    #endregion
}