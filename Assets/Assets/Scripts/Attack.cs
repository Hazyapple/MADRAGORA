using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject hexbag;

  
    private Movement movement;
    private CollectibleItem collectibleItem;

    public GameObject flaskofglory;        //

    public GameObject giantmayhexbag;                      //

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
     
        collectibleItem = GetComponent<CollectibleItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ThrowHexBag();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ThrowFlaskOfGlory();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            ThrowGiantMayHexBag();
        }

    }
    void ThrowHexBag()
    {
        if (collectibleItem.hasHaxBags())
        {
            float direction = movement.isFlipped ? -1 : 1;

            GameObject hexbagInstance = Instantiate(hexbag, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            hexbagInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * direction, 3f), ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(hexbagInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            collectibleItem.useHexBag();
        }

    }

    void ThrowFlaskOfGlory()
    {
        if(collectibleItem.hasFlasks())
        {
            float direction = movement.isFlipped ? -1 : 1;

            GameObject flaskofgloryInstance = Instantiate(flaskofglory, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            flaskofgloryInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * direction, 3f), ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(flaskofgloryInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            collectibleItem.useFlaskOfGlory();
        }
    }

    void ThrowGiantMayHexBag()
    {
        if (collectibleItem.hasGiantMayHexbag())
        {
            float direction = movement.isFlipped ? -1 : 1;
            
            GameObject giantmayhexbagInstance = Instantiate(giantmayhexbag, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            giantmayhexbagInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * direction, 5f), ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(giantmayhexbagInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            collectibleItem.useGiantMayHexBag();

        }

    }





}
