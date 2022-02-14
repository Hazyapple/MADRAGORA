using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskOfGloryScript : MonoBehaviour
{

    public GameObject bigPoofVolcano;

    [SerializeField] AudioSource flasksound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Volcano"))
        {
            flasksound.Play();
            PoofOnVolcano();
        }
    }

    void PoofOnVolcano()
    {
        Instantiate(bigPoofVolcano, transform.position, Quaternion.identity);
    }
}
