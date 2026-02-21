using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform referencePoint;
    float yValue;
    [SerializeField] GameObject lastEnemy;
    public int score = 0;
    [SerializeField] DeathScript deathScript;
    [SerializeField] Transform player;
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] UIController uiController;
    [SerializeField] GameObject specialEnemyPrefab;
    [SerializeField] GameObject deathCheatPrefab;
    [SerializeField] GameObject dBoostPrefab;
    [SerializeField] GameObject healPrefab;
    [SerializeField] Bean playerScript;
    [SerializeField] GameObject doubleScorePrefab;
    public TMP_Text scoreText;
    void Update()
    {
        if (deathScript.gameOver == false)
        {
            if (uiController.isPaused == false)
            {
                if (lastEnemy.transform.position.x < -10)
                {
                    Destroy(lastEnemy);
                    if (playerScript.isDoubleScore == true)
                    {
                        score += 2;
                    }
                    else
                    {
                        score++;
                    }
                    scoreText.text = "\n    Score: " + score;
                    yValue = Random.Range(-1, 12);
                    if (yValue == 6)
                    {
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        Instantiate(shieldPrefab, referencePoint.position, Quaternion.identity);
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);
                    }
                    else if (yValue == 5)
                    {
                        yValue = player.position.y;
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);
                        score++;
                    }
                    else if (yValue == 7)
                    {
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(specialEnemyPrefab, referencePoint.position, Quaternion.identity);
                        yValue = Random.Range(-1, 5);
                    }
                    else if (yValue == 8)
                    {
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        Instantiate(deathCheatPrefab, referencePoint.position, Quaternion.identity);
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);

                    }
                    else if (yValue == 9)
                    {
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        Instantiate(dBoostPrefab, referencePoint.position, Quaternion.identity);
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);
                    }
                    else if (yValue == 10)
                    {
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        Instantiate(healPrefab, referencePoint.position, Quaternion.identity);
                        yValue = Random.Range(-1, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);
                    }
                    else if (yValue == 11)
                    {
                        yValue = Random.Range(0, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        Instantiate(doubleScorePrefab, referencePoint.position, Quaternion.identity);
                        yValue = Random.Range(0, 5);
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);
                    }
                    else
                    {
                        referencePoint.position = new Vector2(referencePoint.position.x, yValue);
                        lastEnemy = Instantiate(enemyPrefab, referencePoint.position, Quaternion.identity);
                        

                    }

                }

            }

        }
        if (score < 0)
        {
            score = 0;
        }
    }
}
