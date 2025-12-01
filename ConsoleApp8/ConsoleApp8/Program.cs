using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BuckwheatPriceTracker
{
    public static void Main(string[] args)
    {
        List<BuckwheatPrice> priceData = GenerateBuckwheatPriceData(2005, 2025);

        string filePath = "C:\\Users\\ALFA\\Downloads\\dsds\\buckwheat_prices.csv";
        WritePriceDataToCsv(priceData, filePath);

        Console.WriteLine($"Данные о ценах записаны в файл: {filePath}");

        Console.WriteLine("\nПервые 5 строк данных:");
        foreach (var price in priceData.Take(5))
        {
            Console.WriteLine($"{price.Year},{price.Price:F2}"); 
        }

        Console.WriteLine("\nПрограмма завершена.");
    }

    static List<BuckwheatPrice> GenerateBuckwheatPriceData(int startYear, int endYear)
    {
        List<BuckwheatPrice> data = new List<BuckwheatPrice>();
        Random random = new Random();
        double currentPrice = 50; 

        for (int year = startYear; year <= endYear; year++)
        {
            double priceChange = random.NextDouble() * 0.2 - 0.1; 
            currentPrice += currentPrice * priceChange;
            currentPrice = Math.Max(10, currentPrice);

            data.Add(new BuckwheatPrice { Year = year, Price = currentPrice });
        }

        return data;
    }
    static void WritePriceDataToCsv(List<BuckwheatPrice> data, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Year,Price");

            foreach (var price in data)
            {
                writer.WriteLine($"{price.Year},{price.Price:F2}"); 
            }
        }
    }

    class BuckwheatPrice
    {
        public int Year { get; set; }
        public double Price { get; set; }
    }
}
