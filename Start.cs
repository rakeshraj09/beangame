using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    [SerializeField] GameObject StartCanvas;
    [SerializeField] GameObject HelpCanvas;
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
    
    public void GameHelp()
    {
        StartCanvas.SetActive(false);
        HelpCanvas.SetActive(true);
    }
    public void BackToStart()
    {
        HelpCanvas.SetActive(false);
        StartCanvas.SetActive(true);
    }
}
