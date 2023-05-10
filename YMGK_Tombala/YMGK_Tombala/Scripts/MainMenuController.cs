using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject InfoPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Settings()
    {
        SettingPanel.GetComponent<Animator>().SetTrigger("Pop");
    }
    public void Info()
    {
        InfoPanel.GetComponent<Animator>().SetTrigger("PopInfo");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("TombalaGameScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
