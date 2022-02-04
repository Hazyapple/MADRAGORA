using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexScript : MonoBehaviour
{

    public GameObject slime;
    public GameObject evileye;
    public GameObject particlepoof;
    public GameObject particleButt;
    
  

    void OnCollisionEnter2D(Collision2D collision)
    {
       
       
          Instantiate(particlepoof, transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(particleButt, transform.position, Quaternion.identity);
        }

        if (!collision.gameObject.CompareTag("Enemy"))
         {

            GetComponent<Renderer>().enabled = false;

            Invoke("destroySelf", 3f);
                  
        }

        
    }

    
    void createSlime()
    {
        Instantiate(slime, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    void destroySelf()
    {
        Destroy(this.gameObject);
    }
    void createEvileye()
    {
        Instantiate(evileye, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.identity);
    }


}
