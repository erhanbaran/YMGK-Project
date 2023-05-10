using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BPlayerController : MonoBehaviour
{
    public List<Button> operationButtons;
    public List<Button> pickNumbers;
    public GameObject pickNumberPanel;
    private List<int> randomNumbers;
    private List<string> operations;
    private int currentOperationIndex;
    private int selectedNumber;
    public GameObject bplayerCardPanel;
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
    public void SetSelectedNumber(int selectedNumber)
    {
        this.selectedNumber = selectedNumber;
    }

    // Ýþlemlerin listesini ayarlar.
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
        Debug.Log("asd: " + currentOperationIndex);

        bplayerCardPanel.SetActive(false);
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

    // Ýþlemi gerçekleþtirir ve doðru/yanlýþ iþlem sonucunu kontrol eder.
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
            if (DogruSayisi == 9)
            {
                Debug.Log("OYUN BÝTTÝ KAZANAN B OYUNCUSU");
            }
        }

        // pickNumberPanel'i gizle
        bplayerCardPanel.SetActive(true);
        pickNumberPanel.SetActive(false);
    }

    public bool IsPlayerCardActive()
    {
        return bplayerCardPanel.activeInHierarchy;
    }

}
