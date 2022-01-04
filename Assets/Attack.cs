using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject hexbag;
    public SpriteRenderer sprite;
    private Movement movement;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ThrowHexBag();
           
        }
}
    void ThrowHexBag()
    {
        float direction = 1;

        GameObject hexbagInstance = Instantiate(hexbag, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        if (movement.isFlipped)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        hexbagInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * direction, 3f), ForceMode2D.Impulse);
        Physics2D.IgnoreCollision(hexbagInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
