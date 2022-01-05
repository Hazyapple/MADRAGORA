using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject hexbag;
    public SpriteRenderer sprite;
    private Movement movement;
    private CollectibleItem collectibleItem;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        sprite = GetComponent<SpriteRenderer>();
        collectibleItem = GetComponent<CollectibleItem>();
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
        if (collectibleItem.hasHaxBags())
        {
            float direction = movement.isFlipped ? -1 : 1;

            GameObject hexbagInstance = Instantiate(hexbag, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            hexbagInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f * direction, 3f), ForceMode2D.Impulse);
            Physics2D.IgnoreCollision(hexbagInstance.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            collectibleItem.useHexBag();
        }

    }

}