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

            Cost usersCost = new Cost();

            Console.WriteLine("Введіть опис витрати:");
            usersCost.description = Console.ReadLine();


            string tmpString;

            {
                double tmpDouble;

                do
                {
                    Console.WriteLine("Введіть суму витрати:");
                    tmpString = Console.ReadLine();

                }
                while (!double.TryParse(tmpString, out tmpDouble));

                usersCost.sum = tmpDouble;
            }

            Console.WriteLine("Введіть тип витрати:");
            usersCost.type = Console.ReadLine();


            {
                DateTime tmpDateTime;

                do
                {
                    Console.WriteLine("Введіть дату витрати:");
                    tmpString = Console.ReadLine();

                }
                while (!DateTime.TryParse(tmpString, out tmpDateTime));

                usersCost.date = tmpDateTime;
            }



            using (var sr = new StreamReader(filePath))
            {
                var jsonData = sr.ReadToEnd();
                costList = JsonConvert.DeserializeObject<List<Cost>>(jsonData) ?? new List<Cost>();
            }

            costList.Add(usersCost);

            using (var sw = new StreamWriter(filePath))
            {
                var jsonData = JsonConvert.SerializeObject(costList);
                sw.WriteLine(jsonData);
            };

            UserChoise(filePath);
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
        public string description { get; set; }
        public double sum { get; set; }
        public string type { get; set; }
        public DateTime date { get; set; }
        public Cost()
        {

        }
    }
}