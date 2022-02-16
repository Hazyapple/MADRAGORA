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
            GetComponent<Rigidbody2D>().AddForce((transform.up * 1 + transform.right * 2), ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollided = true;
           // Invoke("DestroyThisGiantBag", 4f);
            PoofOnVolcano();
            GetComponent<Rigidbody2D>().AddForce((transform.up * 1 + transform.right * 2), ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            GetComponent<Rigidbody2D>().AddForce((transform.up * 1 + transform.right * 2), ForceMode2D.Impulse);
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
