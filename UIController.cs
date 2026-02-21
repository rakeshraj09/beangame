using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] DeathScript deathScript;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] EnemySpawner scoreHolder;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TMP_Text pauseText;
    public bool isPaused;

    private void Start()
    {
        scoreText.text = "\n    Score: 0";
    }

    void Update()
    {
        ActivateGameOverUI();
        ActivatePauseMenu();
    }

    void ActivateGameOverUI()
    {
        if (deathScript.gameOver == true)
        {
            gameOverUI.SetActive(true);
            scoreText.text = "    You Lost!\n    Score: " + scoreHolder.score;
        }
    }

    void ActivatePauseMenu()
    {
        if(deathScript.gameOver == false)
        {
            if ((Input.GetKeyDown(KeyCode.Escape)) && (isPaused == false))
            {
                Time.timeScale = 0f;
                isPaused = true;
                pauseMenu.SetActive(true);
                pauseText.text = "Game Paused\n    Score: " + scoreHolder.score;
            }
            else if ((Input.GetKeyDown(KeyCode.Escape)) && (isPaused == true))
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
                pauseText.text = "\n    Score: " + scoreHolder.score;
            }
        }
        

    }

    public void PauseMenuExit()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
