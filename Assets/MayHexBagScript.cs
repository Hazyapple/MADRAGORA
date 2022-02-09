using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayHexBagScript : MonoBehaviour
{

    public bool isCollided;
    public GameObject bigPoofVolcano;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("DestroyThisGiantBag", 5f);

        if (collision.gameObject.CompareTag("HexFoxPlant"))
        {
            isCollided = true;
           // Invoke("DestroyThisGiantBag", 3f);
            PoofOnVolcano();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollided = true;
           // Invoke("DestroyThisGiantBag", 4f);
            PoofOnVolcano();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (!isCollided)
        {
           // Invoke("DestroyThisGiantBag", 2f);
            PoofOnVolcano();
        }

    }

    void DestroyThisGiantBag()
    {
        PoofOnVolcano();
        Destroy(this.gameObject);
        
    }

    void PoofOnVolcano()
    {
        Instantiate(bigPoofVolcano, transform.position, Quaternion.identity);
    }
}
