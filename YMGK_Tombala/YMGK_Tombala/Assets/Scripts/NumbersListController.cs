using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersListController : MonoBehaviour
{
    public Text numbersText;
    public APlayerController playerControllerA;
    public BPlayerController playerControllerB;

    public void SetNumbers(List<int> numbers)
    {
        numbersText.text = string.Join(", ", numbers);
    }
    public void OnNumberSelected(int selectedNumber)
    {
        // APlayerController ve BPlayerController ile iþlem gerçekleþtirme
        playerControllerA.GetComponent<APlayerController>().PerformOperation();
        playerControllerB.GetComponent<BPlayerController>().PerformOperation();

        // Ayný zamanda, seçilen sayýyý her iki oyuncu için de ayarlayýn
        playerControllerA.GetComponent<APlayerController>().SetSelectedNumber(selectedNumber);
        playerControllerB.GetComponent<BPlayerController>().SetSelectedNumber(selectedNumber);
    }

}
