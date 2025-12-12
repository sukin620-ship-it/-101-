using System;
using System.Linq;

class Programm
{
    static int ConversionToTenNumberSystem(string origNumber, int numSystem )
    {
        string stringOfNumbers = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        int result = 0;
        string reversed = string.Concat(origNumber.Reverse());
        string text = "";
        for (int i = 0; i < origNumber.Length; i++)
        {
            int indexOf = stringOfNumbers.IndexOf(reversed[i]);
            int basisOfNumSystemInidegree = Convert.ToInt32(Math.Pow(numSystem, i));
            result = result + indexOf * basisOfNumSystemInidegree;
            text += $" {indexOf} * {numSystem}^{i} +";
        }

        text = text.Remove(text.Length - 1);
        Console.WriteLine(text + $"= {result}");

        return result;
    }

    static string ConversionFromTheDecimalNumberSystemToNumberSystem(int numberInTenSystem, int toNumSystem)
    {
        string stringOfNumbers = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string resultConversion = "";
        Console.WriteLine($"будем делить полученное число {numberInTenSystem} на {toNumSystem} (% - остаток от деления ; // - деленине нацело)");
        while (numberInTenSystem > 0)
        {
            var indexNumSystem = numberInTenSystem % toNumSystem;
            resultConversion = stringOfNumbers[indexNumSystem] + resultConversion;
            Console.WriteLine($"{numberInTenSystem} % {toNumSystem} = ({indexNumSystem})");
            var text = $"{numberInTenSystem} // {toNumSystem} = ";
            numberInTenSystem /= toNumSystem;
            Console.WriteLine(text + $"{numberInTenSystem}");
        }
        Console.WriteLine("полученные остатки от деления записываем в обратном порядке их получения");
        return resultConversion;
    }

    static string ConversionToNumberSystem(string origNumber, int origNumSystem, int toNumSystem)
    {
        if (origNumSystem != 10)
        {
            Console.WriteLine($"переведем {origNumber} из {origNumSystem} СС в 10 СС");
            int numberInTenSystem = ConversionToTenNumberSystem(origNumber, origNumSystem);
            return ConversionFromTheDecimalNumberSystemToNumberSystem(numberInTenSystem, toNumSystem);
        }
        else
        {
            var origNumberInInt = int.Parse(origNumber);
            return ConversionFromTheDecimalNumberSystemToNumberSystem(origNumberInInt, toNumSystem);
        }
    }

    static string OperationsOnNumbersInNumSystem(string number1, int theNumSystemOfTheNumber1, string operations, string number2, int theNumSystemOfTheNumber2, int toNumSystem)
    {
        Console.WriteLine($"(1) переведем {number1} из {theNumSystemOfTheNumber1} CC в 10 СС");
        int number1INTenSystem = ConversionToTenNumberSystem(number1, theNumSystemOfTheNumber1);
        Console.WriteLine($"(2) переведем {number2} из {theNumSystemOfTheNumber2} CC в 10 СС");
        int number2InTenSystem = ConversionToTenNumberSystem(number2, theNumSystemOfTheNumber2);
        if (operations == "+")
        {
            int additionOpetation = number1INTenSystem + number2InTenSystem;
            Console.WriteLine($"(3) {number1INTenSystem} + {number2InTenSystem} = {additionOpetation}");
            string result = ConversionToNumberSystem($"{additionOpetation}",10,toNumSystem);
            return result;
        }
        else if (operations == "*")
        {
            int multiplicationOperation = number1INTenSystem * number2InTenSystem;
            Console.WriteLine($"(3) {number1INTenSystem} * {number2InTenSystem} = {multiplicationOperation}");
            string result = ConversionToNumberSystem($"{multiplicationOperation}",10,toNumSystem);
            return result;
        }
        
        return "";
    }

    static void EffecOfConvertingToAnotherNumberSystem()
    {
        Console.WriteLine("Введите (через пробел) число; СС, в которой находится число; СС, в которую хотите перевести");
        string text = Console.ReadLine();
        string[] parts = text.Split(' ');
        if (parts.Length == 3)
        {
            string number = parts[0];
            if (int.TryParse(parts[1],out int origNumSystem))
            {
                if (int.TryParse(parts[2],out int toNumSystem))
                {
                    string result = ConversionToNumberSystem(number, origNumSystem, toNumSystem);
                    Console.WriteLine($"Получилось: {result} в {toNumSystem} CC");
                }
                else Console.WriteLine("не допустимое значение для СС, в которую хотите перевести");
            }
            else Console.WriteLine("не допустимое значение для СС, в которой находится число ");
        }
        else Console.WriteLine("Неверный ввод - Не три переменных");
    }
    static void OperationsOnNumbersInNumberSystems()
    {
        Console.WriteLine("Введите (через пробел) 1 число; СС, в которой находится 1 число; знак опрерации + или *; 2 число; СС, в которой находится 2 число; СС, в которую хотите перевести итоговый результат");
        string text = Console.ReadLine();
        string[] parts = text.Split(' ');
        if (parts.Length == 6)
        {
            string number1 = parts[0];
            string number2 = parts[3];
            if (int.TryParse(parts[1],out int theNumSystemOfTheNumber1))
            {
                if (int.TryParse(parts[4],out int theNumSystemOfTheNumber2))
                {
                    if (int.TryParse(parts[5],out int toNumSystem))
                    {
                        string action = parts[2];
                        if (action == "+" || parts[2] == "*")
                        {
                            string result = OperationsOnNumbersInNumSystem(number1, theNumSystemOfTheNumber1, action, number2, theNumSystemOfTheNumber2, toNumSystem);
                            Console.WriteLine($"Получилось: {result}");
                        }
                        else Console.WriteLine("не допустимое значение для знака опрерации");
                    }
                    else Console.WriteLine("не допустимое значение для СС, в которую хотите перевести итоговый результат");
                }
                else Console.WriteLine("не допустимое значение для СС, в которой находится 2 число");
            }
            else Console.WriteLine("не допустимое значение для СС, в которой находится 1 число");
        }
        else Console.WriteLine("неверный ввод - не пять переменных");
    }
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите ? (для перевода числа в СС), +* (для сложения или умножения чисел)");
            string operation = Console.ReadLine();
            
            if (operation == "?")
            {
                EffecOfConvertingToAnotherNumberSystem();
            }
            
            else if (operation == "+*")
            {
                OperationsOnNumbersInNumberSystems();
            }
            else Console.WriteLine("нет такой операции");
            
        }
    }
}
