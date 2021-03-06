using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject hexbag;

  
    private Movement movement;
    private CollectibleItem collectibleItem;

    public GameObject flaskofglory;        //

    public GameObject giantmayhexbag;

    [SerializeField] AudioSource gianthexsound;
    [SerializeField] AudioSource hexbagsound;
    [SerializeField] AudioSource flasksound; 


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
     
        collectibleItem = GetComponent<CollectibleItem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ThrowHexBag();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ThrowGiantMayHexBag();
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
           
            ThrowFlaskOfGlory();
        }

    }
    void ThrowHexBag()
    {
        if (collectibleItem.hasHaxBags())
        {
            hexbagsound.Play();

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
            flasksound.Play();

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
            gianthexsound.Play();

            float direction = movement.isFlipped ? -1 : 1;
            
            GameObject giantmayhexbagInstance = Instantiate(giantmayhexbag, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            giantmayhexbagInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f * direction, 2f), ForceMode2D.Impulse);

            //giantmayhexbagInstance.GetComponent<Rigidbody2D>().AddForce((transform.up * 3 + transform.right * 1), ForceMode2D.Impulse);

            Physics2D.IgnoreCollision(giantmayhexbagInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());



            collectibleItem.useGiantMayHexBag();

        }

    }





}
