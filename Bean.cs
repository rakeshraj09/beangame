using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bean : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    bool isJumping;
    [SerializeField] EnemySpawner enemySpawner;
    bool shieldActive;
    [SerializeField] GameObject shield;
    public int hitPoints = 100;
    public Transform healthBar;
    public TMP_Text healthText;
    public bool deathCheat;
    public GameObject deathCheatPS;
    bool isBoost;
    [SerializeField] GameObject dBoostPS;
    bool dBoostRight;
    bool dBoostLeft;
    [SerializeField] int dBoostForce = 5;
    [SerializeField] GameObject healPS;
    public bool isDoubleScore;
    [SerializeField] GameObject doubleScorePS;
    [SerializeField] float jumpForce = 1.5f;
    [SerializeField] SFXManager sfxManager;

    void Update()
    {
        BeanInput();
        HealthUpdater();
    }

    void FixedUpdate()
    {
        BeanMovement();
    }

    void BeanInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (transform.position.y > -2 && transform.position.y < 3 && transform.position.x > -7.3f && transform.position.x < 9)
            {
                isJumping = true;
            }
        }

        if(isBoost == true)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                dBoostRight = true;
                isBoost = false;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                dBoostLeft = true;
                isBoost = false;
                
            }
        }

    }

    void BeanMovement()
    {
        if (isJumping == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            sfxManager.PlaySFX("Jump");
            isJumping = false;
        }

        if(dBoostRight == true)
        {
            rb.AddForce(Vector2.right * dBoostForce, ForceMode2D.Impulse);
            sfxManager.PlaySFX("Jump");
            dBoostRight = false;
            dBoostPS.SetActive(false);
        }
        if (dBoostLeft == true)
        {
            rb.AddForce(Vector2.left * dBoostForce, ForceMode2D.Impulse);
            sfxManager.PlaySFX("Jump");
            dBoostLeft = false;
            dBoostPS.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy")
        {
            if(shieldActive == true)
            {
                GameObject.Find("Isometric Diamond").GetComponent<SpriteRenderer>().enabled = false;
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                shield.SetActive(false);
                shieldActive = false;
            }
            else
            {
                enemySpawner.score -= 1;
                hitPoints -= 5;
                healthBar.localScale = new Vector3(healthBar.localScale.x - 0.5f, healthBar.localScale.y, healthBar.localScale.z);
                healthBar.position = new Vector2(healthBar.position.x - 0.25f, healthBar.position.y);
                enemySpawner.scoreText.text = "\n    Score: " + enemySpawner.score;
                sfxManager.PlaySFX("Hit");
            }
        }
        if (collision.collider.tag == "SpecialEnemy")
        {
            if (shieldActive == true)
            {
                enemySpawner.score -= 1;
                hitPoints -= 10;
                healthBar.localScale = new Vector3(healthBar.localScale.x - 1, healthBar.localScale.y, healthBar.localScale.z);
                healthBar.position = new Vector2(healthBar.position.x - 0.5f, healthBar.position.y);
                shield.SetActive(false);
                shieldActive = false;
                enemySpawner.scoreText.text = "\n    Score: " + enemySpawner.score;
                sfxManager.PlaySFX("Hit");
            }
            else
            {
                enemySpawner.score -= 1;
                hitPoints -= 20;
                healthBar.localScale = new Vector3(healthBar.localScale.x - 2, healthBar.localScale.y, healthBar.localScale.z);
                healthBar.position = new Vector2(healthBar.position.x - 1, healthBar.position.y);
                enemySpawner.scoreText.text = "\n    Score: " + enemySpawner.score;
                sfxManager.PlaySFX("Hit");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            shieldActive = true;
            shield.SetActive(true);
            sfxManager.PlaySFX("Powerup");
        }

        if(collision.CompareTag("DeathCheat"))
        {
            Destroy(collision.gameObject);
            deathCheat = true;
            deathCheatPS.SetActive(true);
            sfxManager.PlaySFX("Powerup");
        }

        if(collision.CompareTag("DirectionalBoost"))
        {
            Destroy(collision.gameObject);
            isBoost = true;
            dBoostPS.SetActive(true);
            sfxManager.PlaySFX("Powerup");
        }
        
        if(collision.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            hitPoints += 20;
            healthBar.localScale = new Vector3(healthBar.localScale.x + 2, healthBar.localScale.y, healthBar.localScale.z);
            healthBar.position = new Vector2(healthBar.position.x + 1, healthBar.position.y);
            StartCoroutine(HealProcess());
            sfxManager.PlaySFX("Powerup");
        }

        if(collision.CompareTag("DoubleScore"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(DoubleScoreProcess());
            sfxManager.PlaySFX("Powerup");
        }
    }

    void HealthUpdater()
    {
        if(hitPoints < 0)
        {
            hitPoints = 0;
        }
        healthText.text = "HP: " + hitPoints;
        if(hitPoints > 60)
        {
            healthBar.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if(hitPoints <= 60 && hitPoints > 30)
        {
            healthBar.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (hitPoints <= 30 && hitPoints > 0)
        {
            healthBar.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(hitPoints <= 0)
        {
            try
            {
                Destroy(healthBar.gameObject);
            }
            catch
            {
                
            }
            
        }
        if(hitPoints > 100)
        {
            hitPoints = 100;
            healthBar.localScale = new Vector3(10, healthBar.localScale.y, healthBar.localScale.z);
            healthBar.position = new Vector2(2.23f, healthBar.position.y);
        }
    }

    IEnumerator HealProcess()
    {
        healPS.SetActive(true);
        yield return new WaitForSeconds(2);
        healPS.SetActive(false);
    }

    IEnumerator DoubleScoreProcess()
    {
        isDoubleScore = true;
        doubleScorePS.SetActive(true);
        yield return new WaitForSeconds(10);
        isDoubleScore = false;
        doubleScorePS.SetActive(false);
    }
}
