using Newtonsoft;
using Newtonsoft.Json;

namespace Homework_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var checkUserChoise = true;

            do
            {
                Console.WriteLine($"Оберіть тип дії: \n\t 1 - Переглянути історію витрат \n\t 2 - Додати нову витрату \n\t 3 - Вивести статистику");
                string userChoise = Console.ReadLine();

                if(userChoise == "1" || userChoise == "2" || userChoise == "3")
                {
                    checkUserChoise = false;

                    switch(Convert.ToInt32(userChoise))
                    {
                        case 1:
                            ShowCostsHistory();
                            break;

                        case 2:
                            AddCost();
                            break;

                        case 3:
                            ShowStatistics();
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Недопустиме значення.");
                }
            }
            while (checkUserChoise);
        }

        private static void ShowCostsHistory()
        {
            using (FileStream fs = new FileStream("Costs.json", FileMode.OpenOrCreate))
            {
                Console.WriteLine(51);
                JsonSerializer jsonreader = new JsonSerializer();
                

            }
        }
        private static void AddCost()
        {
            
        }
        private static void ShowStatistics()
        {
            
        }
    }

    public class Cost
    {
        decimal sum;
        DateTime date;
        string type;
    }
}