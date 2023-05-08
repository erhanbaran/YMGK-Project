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
        // APlayerController ve BPlayerController ile i�lem ger�ekle�tirme
        playerControllerA.GetComponent<APlayerController>().PerformOperation();
        playerControllerB.GetComponent<BPlayerController>().PerformOperation();

        // Ayn� zamanda, se�ilen say�y� her iki oyuncu i�in de ayarlay�n
        playerControllerA.GetComponent<APlayerController>().SetSelectedNumber(selectedNumber);
        playerControllerB.GetComponent<BPlayerController>().SetSelectedNumber(selectedNumber);
    }

}
