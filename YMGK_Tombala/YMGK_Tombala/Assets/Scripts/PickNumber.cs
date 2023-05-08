using UnityEngine;
using UnityEngine.UI;

public class PickNumber : MonoBehaviour
{
    public Button[] numberButtons;
    private int selectedNumber;

    private void Start()
    {
        selectedNumber = -1;
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int buttonNumber = i;
            numberButtons[i].onClick.AddListener(() => OnNumberButtonClicked(buttonNumber));
        }
    }

    private void OnNumberButtonClicked(int buttonNumber)
    {
        selectedNumber = buttonNumber;
    }

    public int GetSelectedNumber()
    {
        return selectedNumber;
    }
}
