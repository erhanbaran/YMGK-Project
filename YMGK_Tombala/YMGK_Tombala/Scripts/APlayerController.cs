using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class APlayerController : MonoBehaviour
{
    public List<Button> operationButtons;
    public GameObject pickNumberPanel;
    private int selectedNumber;
    public List<Button> pickNumbers;
    private List<string> operations;
    private List<int> randomNumbers;
    private int currentOperationIndex;
    public GameObject aplayerCardPanel;
    private int DogruSayisi;
    void Start()
    {
        currentOperationIndex = -1;
        DogruSayisi = 0;
        foreach (Button button in pickNumbers)
        {
            button.onClick.AddListener(delegate { SetSelectedNumber(int.Parse(button.GetComponentInChildren<Text>().text)); });
        }

        // Her bir iþlem düðmesine týklandýðýnda PickNumberPanel'i gösteren bir iþlev atayýn.
        foreach (Button button in operationButtons)
        {
            button.onClick.AddListener(ShowPickNumberPanel);
        }
        foreach (Button button in pickNumbers)
        {
            button.onClick.AddListener(PerformOperation);
        }
    }

    // Ýþlemlerin listesini ayarlar ve randomNumbers dizisini doldurur.
    public void SetOperations(List<string> operations, List<int> randomNumbers)
    {
        this.operations = operations;
        this.randomNumbers = randomNumbers;

        for (int i = 0; i < operationButtons.Count; i++)
        {
            operationButtons[i].GetComponentInChildren<Text>().text = operations[i];
        }
        for (int i = 0; i < pickNumbers.Count; i++)
        {
            pickNumbers[i].GetComponentInChildren<Text>().text = randomNumbers[i].ToString();
        }
    }

    // PickNumberPanel'i gösterir.
    private void ShowPickNumberPanel()
    {
        // Týklanan düðmenin indeksini bulun.
        currentOperationIndex = operationButtons.FindIndex(button => button == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>());
        Debug.Log("currentOperationIndex: " + currentOperationIndex);

        aplayerCardPanel.SetActive(false);
        pickNumberPanel.SetActive(true);

        // PickNumberPanel'deki düðmeler için iþlevleri ayarlayýn.
        for (int i = 0; i < pickNumbers.Count; i++)
        {
            int pickNumberIndex = i;
            pickNumbers[i].onClick.RemoveAllListeners();
            pickNumbers[i].onClick.AddListener(() =>
            {
                SetSelectedNumber(randomNumbers[pickNumberIndex]);
                PerformOperation();
            });
        }
    }

    public void SetSelectedNumber(int selectedNumber)
    {
        this.selectedNumber = selectedNumber;
    }

    // Ýþlemi gerçekleþtirir ve doðru/yanlýþ iþlemi iþler.
    public void PerformOperation()
    {
        string selectedOperation = operationButtons[currentOperationIndex].GetComponentInChildren<Text>().text;
        int result = Game.PerformOperation(selectedOperation);

        Debug.Log(selectedOperation);
        Debug.Log("selectedNumber Result: " + selectedNumber);
        Debug.Log("Result: " + result);
        if (result == selectedNumber)
        {
            // Doðru iþlem gerçekleþtirildi, iþlem düðmesini ve pickNumber düðmesini devre dýþý býrak
            operationButtons[currentOperationIndex].interactable = false;
            pickNumbers.Find(button => button.GetComponentInChildren<Text>().text == selectedNumber.ToString()).interactable = false;
            DogruSayisi++;
            if(DogruSayisi == 9)
            {
                Debug.Log("OYUN BÝTTÝ KAZANAN A OYUNCUSU");
            }
        }


        // pickNumberPanel'i gizle
        aplayerCardPanel.SetActive(true);
        pickNumberPanel.SetActive(false);
    }

    public bool IsPlayerCardActive()
    {
        return aplayerCardPanel.activeInHierarchy;
    }

}
