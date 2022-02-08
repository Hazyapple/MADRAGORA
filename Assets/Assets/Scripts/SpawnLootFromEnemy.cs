using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLootFromEnemy : MonoBehaviour
{

    public GameObject slime;
    public GameObject evileye;
    public GameObject mayapple;          // mayhexbag logic
    private bool isSpawned = false;
    public GameObject particleButt;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HexBag") && !this.isSpawned)
        {
           
            
            Instantiate(particleButt, transform.position, Quaternion.identity);
            
            Destroy(collision.gameObject);

            Invoke("createSlime", 0.2f);
            Invoke("createEvileye", 0.3f);
            
            Invoke("destroySelf", 0.4f);
            isSpawned = true;
        }

        if (collision.gameObject.CompareTag("MayHexBag") && !this.isSpawned)      // mayhexbag logic
        {


            Instantiate(particleButt, transform.position, Quaternion.identity);

            Invoke("createSlime", 0.2f);
            Invoke("createEvileye", 0.3f);
            Invoke("createMayapple", 0.4f);

            Invoke("destroySelf", 0.4f);
            isSpawned = true;
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

    void createMayapple()                                                   //mayhexbag logic
    {
        Instantiate(mayapple, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
