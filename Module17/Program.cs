namespace Module17
{
    #region 17.1.4
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {

    //    }

    //    public String GetDayOfWeek(int day)
    //    {
    //        if ((day < 1) || (day > 7))
    //            throw new InvalidOperationException("День недели должен быть в диапазоне 1 to 7");

    //        string[] days = {
    //            "Monday",
    //            "Tuesday",
    //            "Wednesday",
    //            "Thursday",
    //            "Friday",
    //            "Saturday",
    //            "Sunday"
    //        };

    //        return days[day - 1];
    //    }

    //    //рефакторинг
    //    public String GetDayOfWeek2(int day)
    //    {
    //        switch (day)
    //        {
    //            case 1:
    //                return "Monday";
    //            case 2:
    //                return "Tuesday";
    //            case 3:
    //                return "Wednesday";
    //            case 4:
    //                return "Thursday";
    //            case 5:
    //                return "Friday";
    //            case 6:
    //                return "Saturday";
    //            case 7:
    //                return "Sunday";
    //            default:
    //                throw new InvalidOperationException("День недели должен быть в диапазоне 1 to 7");
    //        }
    //    }
    //}
    #endregion
    #region 17.1.5
    #region Исходник
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        DailyAverage();
    //        WeeklyAverage();
    //        MonthlyAverage();
    //    }

    //    private static void DailyAverage()
    //    {
    //        Console.WriteLine("Welcome to the daily forecast page");
    //        Console.WriteLine($"The average temperature expects to be around {new Random().Next(10, 30)} C");
    //        Console.WriteLine();
    //    }

    //    private static void WeeklyAverage()
    //    {
    //        Console.WriteLine("Welcome to the weekly forecast page");
    //        Console.WriteLine($"The average temperature expects to be around {new Random().Next(10, 35)} C");
    //        Console.WriteLine();
    //    }

    //    private static void MonthlyAverage()
    //    {
    //        Console.WriteLine("Welcome to the monthly forecast page");
    //        Console.WriteLine($"The average temperature expects to be around {new Random().Next(10, 40)} C");
    //        Console.WriteLine();
    //    }
    //}
    #endregion
    #region Рефакторинг
    public static class Constants
    {
        // Выносим повторяющийся код в константы
        public const string WelcomeString = "Welcome to the forecast page for the";
        public const string ForecastString = "The average temperature expects to be around";
        public const string LineBreak = "\n"; // заменяем лишние вызовы Console.Writeline на символ переноса строки
    }

    public class Program
    {
        static void Main(string[] args)
        {
            DailyAverage();
            WeeklyAverage();
            MonthlyAverage();
        }

        // используем форматирование для подстановки
        private static void DailyAverage()
        {
            Console.WriteLine($"{Constants.WelcomeString} day {Constants.LineBreak}{Constants.ForecastString} {new Random().Next(10, 30)} C {Constants.LineBreak}");
        }

        private static void WeeklyAverage()
        {
            Console.WriteLine($"{Constants.WelcomeString} week {Constants.LineBreak}{Constants.ForecastString} {new Random().Next(10, 30)} C {Constants.LineBreak}");
        }

        private static void MonthlyAverage()
        {
            Console.WriteLine($"{Constants.WelcomeString} month {Constants.LineBreak}{Constants.ForecastString} {new Random().Next(10, 30)} C {Constants.LineBreak}");
        }
    }
    #endregion
    #endregion
}