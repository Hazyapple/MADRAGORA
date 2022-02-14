using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolcanoBehavior : MonoBehaviour
{
    private bool islevelcompleted = false;

    [SerializeField] AudioSource hitvolcano;
    [SerializeField] AudioSource finishlvl;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FlaskOfGlory") && !islevelcompleted)
        {
            hitvolcano.Play();
            Destroy(collision.gameObject);
            Invoke("CompleteLevel", 3f);
            finishlvl.Play();
            islevelcompleted = true;
        }
    }

  
    private void CompleteLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        PlayerPrefs.GetInt("PlayerCurrentHealth");
    }
}




