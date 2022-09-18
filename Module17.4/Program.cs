namespace Module17._4
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
    // Поведенческие паттерны
    #region ЦЕПОЧКА ОБЯЗАННОСТЕЙ (CHAIN OF RESPOSIBILITY)
    class Client
    {
        void Main()
        {
            // Первый обработчик
            Handler handlerOne = new HandlerOne();

            // Второй обработчик
            Handler handlerTwo = new HandlerTwo();

            // Передача запроса по цепочке и обработка
            handlerOne.Successor = handlerTwo;
            handlerOne.HandleRequest(2);
        }
    }

    /// <summary>
    /// Базовый интерфейс обработчика
    /// </summary>
    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(int condition);
    }

    /// <summary>
    /// Реализаци первого обработчика
    /// </summary>
    class HandlerOne : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 1)
            {
                // Завершение обработки при выполненном условии
            }
            else if (Successor != null)
            {
                // Условие не выполнено - передаем дальше по цепи
                Successor.HandleRequest(condition);
            }
        }
    }

    /// <summary>
    /// Реализаци второго обработчика
    /// </summary>
    class HandlerTwo : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 2)
            {
                // Завершение обработки при выполненном условии
            }
            else if (Successor != null)
            {
                // Условие не выполнено - передаем дальше по цепи
                Successor.HandleRequest(condition);
            }
        }
    }
    #endregion
    #region СОСТОЯНИЕ (STATE)
    class Program
    {
        static void Main()
        {
            // создаем объет сразу в каким-то состоянии
            var contextObject = new ContextObject(new StateOne());

            contextObject.Switch(); // Переход в состояние StateTwo
            contextObject.Switch();  // Переход в состояние StateOne
        }
    }

    /// <summary>
    ///  Общий интерфейс, определяющий состояния
    /// </summary>
    abstract class State
    {
        public abstract void Handle(ContextObject contextObject);
    }

    /// <summary>
    /// Первое сояние
    /// </summary>
    class StateOne : State
    {
        public override void Handle(ContextObject contextObject)
        {
            contextObject.State = new StateTwo();
        }
    }

    /// <summary>
    /// Второе сояние
    /// </summary>
    class StateTwo : State
    {
        public override void Handle(ContextObject contextObject)
        {
            contextObject.State = new StateOne();
        }
    }

    /// <summary>
    /// Сам объект, поведение которого должно изменяться
    /// </summary>
    class ContextObject
    {
        public State State { get; set; }
        public ContextObject(State state)
        {
            State = state;
        }

        public void Switch()
        {
            State.Handle(this);
        }
    }
    #endregion
    #region НАБЛЮДАТЕЛЬ (OBSERVER)
    /// <summary>
    /// Представляет объект - источник событий
    /// ( Иначе говоря, наблюдаемый объект )
    /// </summary>
    interface IPublisher
    {
        void AddSubscriber(ISubscriber sub);
        void RemoveSubscriber(ISubscriber o);
        void Publish();
    }

    /// <summary>
    /// Конкретная реализация источника событий
    /// ( наблюдаемого объекта )
    /// </summary>
    class ConcretePublisher : IPublisher
    {
        private List<ISubscriber> subscribers;

        public ConcretePublisher()
        {
            subscribers = new List<ISubscriber>();
        }
        public void AddSubscriber(ISubscriber sub)
        {
            subscribers.Add(sub);
        }

        public void RemoveSubscriber(ISubscriber o)
        {
            subscribers.Remove(o);
        }

        public void Publish()
        {
            foreach (ISubscriber subscriber in subscribers)
                subscriber.Update();
        }
    }

    /// <summary>
    /// Тот, кто подписан на события, наблюдаемого объекта
    /// ( иначе говоря, наблюдатель )
    /// </summary>
    interface ISubscriber
    {
        void Update();
    }

    /// <summary>
    /// Конкретная реализация наблюдателя
    /// </summary>
    class ConcreteSubscriber : ISubscriber
    {
        public void Update()
        {
        }
    }
    #endregion
}