using System.Text;
using System.Xml;
using Newtonsoft;
using Newtonsoft.Json;

namespace Homework_7
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            Console.WindowTop = 0;
            Console.WindowLeft = 0;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            Console.OutputEncoding = Encoding.UTF8;

            var filePath = (Directory.GetCurrentDirectory() + "\\Costs.json");

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            UserChoise(filePath);
        }

        private static void ShowCostsHistory(string filePath)
        {
            List<Cost> costList = new List<Cost>();

            using (var sr = new StreamReader(filePath))
            {
                Console.WriteLine("Історія всіх витрат:");
                Console.WriteLine(sr.ReadToEnd());
            }

            UserChoise(filePath);        
        }
        private static void AddCost(string filePath)
        {
            List<Cost> costList = new List<Cost>();

            Cost firstCost = new Cost { id = 3, description = "test desc", sum = 11.11, type = "test type", date = DateTime.Now };
            Cost secondCost = new Cost { id = 4, description = "test desc 2", sum = 22.22, type = "test type 2", date = DateTime.Now };

            using(var sr = new StreamReader(filePath))
            {
                var jsonData = sr.ReadToEnd();
                costList = JsonConvert.DeserializeObject<List<Cost>>(jsonData) ?? new List<Cost>();
            }

            costList.Add(firstCost);
            costList.Add(secondCost);

            using (var sw = new StreamWriter(filePath))
            {
                var jsonData = JsonConvert.SerializeObject(costList);
                sw.WriteLine(jsonData);
            };
        }
        private static void ShowStatistics()
        {
            
        }

        private static void UserChoise(string filePath)
        {
            var checkUserChoise = true;

            do
            {
                Console.WriteLine($"Оберіть тип дії: \n\t 1 - Переглянути історію витрат \n\t 2 - Додати нову витрату \n\t 3 - Вивести статистику");

                string userChoise = Console.ReadLine();

                if (userChoise == "1" || userChoise == "2" || userChoise == "3")
                {
                    checkUserChoise = false;

                    switch (Convert.ToInt32(userChoise))
                    {
                        case 1:
                            ShowCostsHistory(filePath);
                            break;

                        case 2:
                            AddCost(filePath);
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

    }

    //[Serializable]
    public class Cost
    {
        public int id { get; set; }
        public string description { get; set; }
        public double sum { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public Cost()
        {

        }
    }
}