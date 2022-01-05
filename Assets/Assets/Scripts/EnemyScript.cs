using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

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
    }
    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
            animator.SetBool("attack", true);
            animator.SetBool("idle", false);
        }

        else

        {
            //code to stop chasing player
            StopChasingPlayer();
            animator.SetBool("attack", false);
            animator.SetBool("idle", true);
        }

         void ChasePlayer()
        {
            if(transform.position.x < player.position.x)
            {
                //enemy is to the left side of the player, so move right
                rb2d.velocity = new Vector2(moveSpeed, 0);
                sprite.flipX = true;

            }
            else 
            {
                //enemy is to the right side of the player, so move left
                rb2d.velocity = new Vector2(-moveSpeed, 0);
                sprite.flipX = false;
            }

            
           
        }

         void StopChasingPlayer()
        {
            rb2d.velocity = new Vector2(0, 0); 
        }
    }
}
