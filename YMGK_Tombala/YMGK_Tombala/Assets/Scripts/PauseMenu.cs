using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource musicSource; // AudioSource referansýmýz
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("TombalaGameScene");
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("GameMainScene");
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
