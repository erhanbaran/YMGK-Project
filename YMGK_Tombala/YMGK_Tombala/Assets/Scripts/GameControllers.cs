using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllers : MonoBehaviour
{
    // UI elements for the random numbers and player operations
    public Text NumbersText;
    public List<Text> PlayerATexts;
    public List<Text> PlayerBTexts;

    private List<int> randomNumbers;
    private List<string> operationsA;
    private List<string> operationsB;

    // Start is called before the first frame update
    void Start()
    {
        // Set up the game
        SetUpGame();
    }

    void SetUpGame()
    {
        // Generate random numbers and operations
        randomNumbers = Game.GenerateRandomNumbers();
        operationsA = new List<string>();
        operationsB = new List<string>();

        for (int i = 0; i < 8; i++)
        {
            operationsA.Add(Game.GenerateOperationForNumber(randomNumbers[i]));
            operationsB.Add(Game.GenerateOperationForNumber(randomNumbers[i]));
        }

        operationsA.Add(Game.GenerateOperationForNumber(randomNumbers[8]));
        operationsB.Add(Game.GenerateOperationForNumber(randomNumbers[9]));

        // Set the text UI elements
        NumbersText.text = string.Join(", ", randomNumbers);
        for (int i = 0; i < PlayerATexts.Count; i++)
        {
            PlayerATexts[i].text = operationsA[i];
        }
        for (int i = 0; i < PlayerBTexts.Count; i++)
        {
            PlayerBTexts[i].text = operationsB[i];
        }
    }
}

class Game
{
    static System.Random random = new System.Random();

    public static List<int> GenerateRandomNumbers()
    {
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < 10)
        {
            numbers.Add(random.Next(1, 101));
        }
        return new List<int>(numbers);
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
}

class Operations
{
    static System.Random random = new System.Random();

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
