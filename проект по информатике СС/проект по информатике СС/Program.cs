using System;
using System.Linq;

class Programm
{
    static int ConversionToTenNumSystem(string origNumber, int numSystem , string stringOfNumbers)
    {
        int result = 0;
        string reversed = string.Concat(origNumber.Reverse());
        
        for (int i = 0; i < origNumber.Length; i++)
        {
            int index = stringOfNumbers.IndexOf(reversed[i]);
            int p = Convert.ToInt32(Math.Pow(numSystem, i));
            result = result + index * p;
        }

        return result;
    }

    static string ConversionToNumberSystem(string origNumber, int origNumSystem, int toNumSystem)
    {
        string stringOfNumbers = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        int numberInTenSystem = ConversionToTenNumSystem(origNumber, origNumSystem, stringOfNumbers);
        
        string resultConversion = "";
        while (numberInTenSystem > 0)
        {
            resultConversion = stringOfNumbers[numberInTenSystem % toNumSystem] + resultConversion;
            numberInTenSystem /= toNumSystem;
        }

        return resultConversion;

    }
    
    static void Main()
    {
        Console.WriteLine("введите число:");
        string number = Console.ReadLine();
        
        Console.WriteLine("Введите СС, в которой находится число");
        if (int.TryParse(Console.ReadLine(), out int origNumSystem))
        {
            Console.WriteLine("Введите СС, в которую хотите перевести:");
            if (int.TryParse(Console.ReadLine(), out int toNumSystem))
            {
                string result = ConversionToNumberSystem(number, origNumSystem, toNumSystem);
                Console.WriteLine($"Получилось: {result}");
                Console.WriteLine("Нажмите Enter для повторения программы");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
}