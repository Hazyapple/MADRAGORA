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

    // close to edge code 
    [SerializeField]
    Transform castPos;  //subcompenent of game object gizmo CastPos
    [SerializeField]
    Transform castPos2;
    [SerializeField]
    float baseCastDist;


    [SerializeField] public bool isGroundedLeft;

    [SerializeField] public bool isGroundedRight;

    [SerializeField] public bool isPlayerToTheRight;

    Vector3 baseScale;

    // Start is called before the first frame update
    void Start()
    {
        
       

        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


        //code to near edge 
        baseScale = transform.localScale;




    }


     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HexFoxPlant"))
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void FixedUpdate()
    {
        //change direction of sprite when near edge

        IsNearEdge();
     
 
    }
    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        isPlayerToTheRight = transform.position.x < player.position.x;

        if (distToPlayer < agroRange && (isGroundedLeft || isPlayerToTheRight) && (isGroundedRight || !isPlayerToTheRight))
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

    void IsNearEdge()
    {
        bool val = true;

        //define the cast distance from left to right

        float castDist = baseCastDist;


        //determine the target destination based on cast distance

        Vector3 targetPos = castPos.position;
        Vector3 targetPos2 = castPos2.position;

        targetPos.y -= baseCastDist;
        targetPos2.y -= baseCastDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);
        Debug.DrawLine(castPos2.position, targetPos2, Color.red); //shoots a ray downwords

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground")))

        {
            val = false;
            isGroundedLeft = true;
        }
        else
        {
            val = true;
            this.isGroundedLeft = false;
            

        }

        if (Physics2D.Linecast(castPos2.position, targetPos2, 1 << LayerMask.NameToLayer("Ground")))

        {
            val = false;
            isGroundedRight = true;
        }
        else
        {
            val = true;
            this.isGroundedRight = false;
            
        }
    }
        
}
