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

        // Her bir i�lem d��mesine t�kland���nda PickNumberPanel'i g�steren bir i�lev atay�n.
        foreach (Button button in operationButtons)
        {
            button.onClick.AddListener(ShowPickNumberPanel);
        }
        foreach (Button button in pickNumbers)
        {
            button.onClick.AddListener(PerformOperation);
        }
    }

    // ��lemlerin listesini ayarlar ve randomNumbers dizisini doldurur.
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

    // PickNumberPanel'i g�sterir.
    private void ShowPickNumberPanel()
    {
        // T�klanan d��menin indeksini bulun.
        currentOperationIndex = operationButtons.FindIndex(button => button == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>());
        Debug.Log("currentOperationIndex: " + currentOperationIndex);

        aplayerCardPanel.SetActive(false);
        pickNumberPanel.SetActive(true);

        // PickNumberPanel'deki d��meler i�in i�levleri ayarlay�n.
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

    // ��lemi ger�ekle�tirir ve do�ru/yanl�� i�lemi i�ler.
    public void PerformOperation()
    {
        string selectedOperation = operationButtons[currentOperationIndex].GetComponentInChildren<Text>().text;
        int result = Game.PerformOperation(selectedOperation);

        Debug.Log(selectedOperation);
        Debug.Log("selectedNumber Result: " + selectedNumber);
        Debug.Log("Result: " + result);
        if (result == selectedNumber)
        {
            // Do�ru i�lem ger�ekle�tirildi, i�lem d��mesini ve pickNumber d��mesini devre d��� b�rak
            operationButtons[currentOperationIndex].interactable = false;
            pickNumbers.Find(button => button.GetComponentInChildren<Text>().text == selectedNumber.ToString()).interactable = false;
            DogruSayisi++;
            if(DogruSayisi == 9)
            {
                Debug.Log("OYUN B�TT� KAZANAN A OYUNCUSU");
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
