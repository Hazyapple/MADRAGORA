using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexFoxScript : MonoBehaviour
{
    //agro away from player
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;
    public GameObject mayapple;                       // mayhexbag logic



    public GameObject hexbag;    //prefab hexbag collectible item

    private Vector3 position;

    private SpriteRenderer sprite;

    private Animator animator;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HexFoxPlant"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }


        if (collision.gameObject.CompareTag("Player"))
        {

            this.position = transform.position;

            Invoke("createHexBag", 0.3f);

            GetComponent<Renderer>().enabled = false;

            Invoke("destroySelf", 0.5f);
        }

        if (collision.gameObject.CompareTag("MayHexBag"))                        //mayhexbag logic
            {

            this.position = transform.position;

            Invoke("createHexBag", 0.2f);

            Invoke("createMayapple", 0.3f);

            GetComponent<Renderer>().enabled = false;

            Invoke("destroySelf", 0.4f);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void createHexBag()
    {
        Instantiate(hexbag, new Vector2(this.position.x, transform.position.y), Quaternion.identity);
    }

    void createMayapple()                                                   //mayhexbag logic
    {
        Instantiate(mayapple, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }

    void destroySelf()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            //code to run from player
            RunFromPlayer();
            animator.SetBool("run", true);
            animator.SetBool("idle", false);

        }

        else

        {
            //code to stop stop running from player
            StopRunningFromPlayer();
            animator.SetBool("run", false);
            animator.SetBool("idle", true);
        }


        void RunFromPlayer()
        {
            if (transform.position.x < player.position.x)
            {
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                sprite.flipX = false;
            }

            else
            {
                rb2d.velocity = new Vector2(moveSpeed, 0);
                sprite.flipX = true;
            }
        }

        void StopRunningFromPlayer()
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
