using System.Collections.Generic;
using UnityEngine;

class MainController : MonoBehaviour
{

    public APlayerController aPlayerCardController;
    public BPlayerController bPlayerCardController;
    public NumbersListController numbersListController;
    void Start()
    {
        // Rastgele sayýlarý ve iþlemleri oluþtur
        List<int> randomNumbers = Game.GenerateRandomNumbers(10);
        List<string> operationsA = new List<string>();
        List<string> operationsB = new List<string>();

        for (int i = 0; i < 8; i++)
        {
            operationsA.Add(Game.GenerateOperationForNumber(randomNumbers[i]));
            operationsB.Add(Game.GenerateOperationForNumber(randomNumbers[i]));
        }

        operationsA.Add(Game.GenerateOperationForNumber(randomNumbers[8]));
        operationsB.Add(Game.GenerateOperationForNumber(randomNumbers[9]));

        numbersListController.SetNumbers(randomNumbers);
        aPlayerCardController.SetOperations(operationsA,randomNumbers);
        bPlayerCardController.SetOperations(operationsB,randomNumbers);
    }
}
