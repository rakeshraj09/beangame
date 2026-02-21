using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeathScript : MonoBehaviour
{
    public bool gameOver;
    public int finalScore;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] Bean playerScript;

    void Update()
    {
       if(gameOver == true)
        {
            enemySpawner.enabled = false;
            GameObject player = GameObject.Find("Player");
            Destroy(player);
        }

       if(playerScript.hitPoints == 0)
        {
            gameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(playerScript.deathCheat == true)
            {
                collision.gameObject.transform.position = new Vector2(-0.91f, 0);
                playerScript.hitPoints = 30;
                playerScript.healthBar.localScale = new Vector3(3, playerScript.healthBar.localScale.y, playerScript.healthBar.localScale.z);
                playerScript.healthBar.position = new Vector2(-1.27f, playerScript.healthBar.position.y);
                playerScript.deathCheatPS.SetActive(false);
                playerScript.deathCheat = false;
            }
            else
            {
                gameOver = true;
                playerScript.hitPoints = 0;
                playerScript.healthText.text = "Health: 0";
                Destroy(playerScript.healthBar.gameObject);
            }
            
        }
    }
}
