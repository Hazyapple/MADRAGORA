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

    [SerializeField]
    Transform castPos3;

    [SerializeField]
    Transform castPos4;

    [SerializeField]
    float baseCastDistToPlayer;




    [SerializeField] public bool isGroundedLeft;

    [SerializeField] public bool isGroundedRight;


    [SerializeField] public bool isPlayerNearRight;

    [SerializeField] public bool isPlayerNearLeft;


    Vector3 baseScale;

    // Start is called before the first frame update
    void Start()
    {
        
       

        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


        //code to near edge 
        baseScale = transform.localScale;

        //isPlayerToTheRight = transform.position.x < player.position.x;





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
        
        IsNearEdge();

        IsNearPlayer();

        //agro attack based on raycast 
       if ((isPlayerNearRight || isPlayerNearLeft) && (isGroundedLeft || isGroundedRight))
        {
            ChasePlayer();
        }


       if ((isPlayerNearRight || isPlayerNearLeft) && (!isGroundedLeft || !isGroundedRight))
        {
            StopChasingPlayer();
        }











    }


      void ChasePlayer()
      {
        if (isPlayerNearRight == true)
             {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            animator.SetBool("attack", true);
            animator.SetBool("idle", false);
            sprite.flipX = true;

              }
        if (isPlayerNearLeft == true)
            {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            animator.SetBool("attack", true);
            animator.SetBool("idle", false);
            sprite.flipX = false;
             }
      }


    void StopChasingPlayer()
    {
        if (isPlayerNearRight == false)
        {
            rb2d.velocity = new Vector2(0, 0);
        }

        if (isPlayerNearLeft == false)
        {
            rb2d.velocity = new Vector2(0, 0);
        }


    }
        

    void IsNearEdge()
    {

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
            //val = false;
            isGroundedLeft = true;
        }
        else
        {
            //val = true;
            this.isGroundedLeft = false;
            

        }

        if (Physics2D.Linecast(castPos2.position, targetPos2, 1 << LayerMask.NameToLayer("Ground")))

        {
            //val = false;
            isGroundedRight = true;
        }
        else
        {
           // val = true;
            this.isGroundedRight = false;
            
        }
    }


   void  IsNearPlayer()
    {
        float castDist = baseCastDistToPlayer;
        
        //determine the target destination based on cast distance

        Vector3 targetPos3 = castPos3.position;
        Vector3 targetPos4 = castPos4.position;

        targetPos3.x += baseCastDistToPlayer;
        targetPos4.x -= baseCastDistToPlayer;

        Debug.DrawLine(castPos3.position, targetPos3, Color.blue);
        Debug.DrawLine(castPos4.position, targetPos4, Color.blue); //shoots a ray downwords

        if (Physics2D.Linecast(castPos3.position, targetPos3, 1 << LayerMask.NameToLayer("Player")))

        {
            isPlayerNearRight = true;
            
        }
        else
        {
            this.isPlayerNearRight = false;
        }

        if (Physics2D.Linecast(castPos4.position, targetPos4, 1 << LayerMask.NameToLayer("Player")))

        {
            isPlayerNearLeft = true;
        }
        else
        {
            this.isPlayerNearLeft = false;
        }
    }
}


