using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskOfGloryScript : MonoBehaviour
{

    public GameObject bigPoofVolcano;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Volcano"))
        {
            PoofOnVolcano();
        }
    }

    void PoofOnVolcano()
    {
        Instantiate(bigPoofVolcano, transform.position, Quaternion.identity);
    }
}
