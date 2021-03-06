using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public static bool isDead = false;

    public GameObject particleblood;

    //adding player HealthBar logic 
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public bool isFullyHealed;

    [SerializeField] AudioSource hurt;
    [SerializeField] AudioSource death;
    [SerializeField] AudioSource healed; 

    // Start is called before the first frame update
    private void Start()
    {
       

            rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //Health bar logic

        currentHealth = PlayerPrefs.GetInt ("PlayerCurrentHealth");        //PlayerPrefab logic

        healthBar.SetHealth(currentHealth);
    }

    private void Update()
    {

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Volcano"))
        {
            TakeDamage(100);
            Instantiate(particleblood, transform.position, Quaternion.identity);

        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            TakeDamage(10);
            Instantiate(particleblood, transform.position, Quaternion.identity);

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
            Instantiate(particleblood, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.CompareTag("EdgeScreenDeath"))
        {
            TakeDamage(40);
            Instantiate(particleblood, transform.position, Quaternion.identity);

        }

        if (collision.gameObject.CompareTag("EvilEye"))
        {
                if ((currentHealth != 100) == true)                   // isFullyHealed - healing with Evileye with not exceed player's max health. 
                {
                    isFullyHealed = false;
                    RestoreHealth(10);
                    Destroy(collision.gameObject);
                }
                else
                {
                    isFullyHealed = true;

                    Destroy(collision.gameObject);
                }
        }

        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EvilEyeStatic"))
        {
            if ((currentHealth != 100) == true)                   // isFullyHealed - healing with Evileye with not exceed player's max health. 
            {
                isFullyHealed = false;
                RestoreHealth(10);
                Destroy(collision.gameObject);
            }
            else
            {
                isFullyHealed = true;

                Destroy(collision.gameObject);
            }
        }

    }

    void TakeDamage(int damage)
    {
        hurt.Play();

        currentHealth -= damage;

        PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);    //PlayerPrefab logic

        GetComponent<Rigidbody2D>().AddForce((transform.up * 4 + transform.right * 1), ForceMode2D.Impulse);

        //animator.SetBool("damage", true);

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
            Invoke("GameOverScreen", 1f);
        }
    }

    void Die()
    {
        death.Play();

        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        isDead = true;
        currentHealth = 0;
        

    }

    private void GameOverScreen()
    {
        SceneManager.LoadScene(3);

        isDead = false;

    }
    public void RestoreHealth(int health)
    {
        healed.Play();

        currentHealth += health;

        PlayerPrefs.SetInt("PlayerCurrentHealth", currentHealth);    //PlayerPrefab logic

        healthBar.SetHealth(currentHealth);

        //aniamtor.SetBool("healed", true);
    }
    
}
