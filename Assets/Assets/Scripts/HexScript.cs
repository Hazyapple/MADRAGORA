using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexScript : MonoBehaviour
{

    public GameObject slime;
    public GameObject evileye;
    private Vector3 position;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);

            this.position = transform.position;

            Invoke("createSlime", 0.4f);
            Invoke("createEvileye", 0.8f);
            GetComponent<Renderer>().enabled = false;
            Invoke("destroySelf", 1f);
        }

       else 
        {
            this.position = transform.position;
            GetComponent<Renderer>().enabled = false;
            Invoke("destroySelf", 3f);
        }
    }

    void createSlime()
    {
        Instantiate(slime, new Vector2(this.position.x, transform.position.y), Quaternion.identity);
    }

    void destroySelf()
    {
        Destroy(this.gameObject);
    }
    void createEvileye()
    {
        Instantiate(evileye, new Vector2(this.position.x + 0.2f, transform.position.y), Quaternion.identity);
    }


}
