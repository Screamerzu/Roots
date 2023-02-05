using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameoverPanel;
    
    public void Play()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Start Game");
    }
    public void Settings()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
    public void Resume()
    {
        SceneManager.LoadScene(1);
        pausePanel.SetActive(false);
    }
    public void Restart()
    {
       	SceneManager.LoadScene(1);
        pausePanel.SetActive(false);
        gameoverPanel.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        pausePanel.SetActive(false);
    }

  


}
