using System;
using System.Collections.Generic;

public class Game
{
    private static System.Random random = new System.Random();

    public static List<int> GenerateRandomNumbers(int count)
    {
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < count)
        {
            numbers.Add(random.Next(1, 101));
        }
        return new List<int>(numbers);
    }

    public static List<string> GenerateOperationsForNumbers(List<int> numbers)
    {
        List<string> operations = new List<string>();

        foreach (int number in numbers)
        {
            operations.Add(GenerateOperationForNumber(number));
        }

        return operations;
    }

    public static string GenerateOperationForNumber(int number)
    {
        var addition = Operations.GenerateAddition(number);
        var subtraction = Operations.GenerateSubtraction(number);
        var multiplication = Operations.GenerateMultiplication(number);
        var division = Operations.GenerateDivision(number);

        int operationIndex = random.Next(4);
        switch (operationIndex)
        {
            case 0:
                return $"{addition.Item1} + {addition.Item2}";
            case 1:
                return $"{subtraction.Item1} - {subtraction.Item2}";
            case 2:
                return $"{multiplication.Item1} * {multiplication.Item2}";
            case 3:
                return $"{division.Item1} / {division.Item2}";
        }
        return "";
    }
    public static int PerformOperation(string operation)
    {
        int result = 0;
        string[] parts = operation.Split(' ');

        if (parts.Length != 3)
        {
            return result;
        }

        int firstNumber = int.Parse(parts[0]);
        string operatorSymbol = parts[1];
        int secondNumber = int.Parse(parts[2]);

        if (operatorSymbol == "+")
        {
            result = firstNumber + secondNumber;
        }
        else if (operatorSymbol == "-")
        {
            result = firstNumber - secondNumber;
        }
        else if (operatorSymbol == "*")
        {
            result = firstNumber * secondNumber;
        }
        else if (operatorSymbol == "/")
        {
            result = firstNumber / secondNumber;
        }

        return result;
    }

}

class Operations
{
    private static System.Random random = new System.Random();

    public static Tuple<int, int> GenerateAddition(int result)
    {
        int firstNumber = random.Next(1, result);
        int secondNumber = result - firstNumber;
        return Tuple.Create(firstNumber, secondNumber);
    }

    public static Tuple<int, int> GenerateSubtraction(int result)
    {
        int firstNumber = random.Next(result, 101);
        int secondNumber = firstNumber - result;
        return Tuple.Create(firstNumber, secondNumber);
    }

    public static Tuple<int, int> GenerateMultiplication(int result)
    {
        int firstNumber = random.Next(1, Math.Min(result + 1, 10));
        while (result % firstNumber != 0)
        {
            firstNumber = random.Next(1, Math.Min(result + 1, 10));
        }
        int secondNumber = result / firstNumber;

        return Tuple.Create(firstNumber, secondNumber);
    }

    public static Tuple<int, int> GenerateDivision(int result)
    {
        int secondNumber = random.Next(1, Math.Min(result + 1, 10));
        int firstNumber = result * secondNumber;
        return Tuple.Create(firstNumber, secondNumber);
    }
}
