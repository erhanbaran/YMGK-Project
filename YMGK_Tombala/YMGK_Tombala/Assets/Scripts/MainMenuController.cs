using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingPanel;
    public GameObject InfoPanel;
    public AudioSource musicSource; // AudioSource referansýmýz

    // Müziði açýp kapatan fonksiyon
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
   
    public void MusicOff()
    {
        if (musicSource.isPlaying) // Eðer müzik çalýyorsa
        {
            musicSource.Stop(); // Müziði durdur
        }
    }
    public void MusicOn()
    {
        if (!musicSource.isPlaying) // Eðer müzik çalýyorsa  
        {
            musicSource.Play(); // Müziði baþlat
        }
    }
}
