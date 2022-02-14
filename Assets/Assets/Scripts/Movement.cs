using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] private bool isGrounded;

   


    private Animator animator;
    private SpriteRenderer sprite;
    public bool isFlipped = false;

    [SerializeField] AudioSource jumping;

    [SerializeField] AudioSource startlvl;
 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        startlvl.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            if(animator.GetBool("jump") == true)
                animator.SetBool("jump", false);
                animator.SetFloat("speed", 0);

            if (isGrounded == false)
            {
                isGrounded = true;
            }
           
                animator.SetBool("jump", false);
                animator.SetFloat("speed", 0);
                isGrounded = true;
            
        }

        if (other.CompareTag("Shelf_Ground"))
        {
            if (animator.GetBool("jump") == true)
                animator.SetBool("jump", false);
            animator.SetFloat("speed", 0);

            if (isGrounded == false)
            {
                isGrounded = true;
            }

            animator.SetBool("jump", false);
            animator.SetFloat("speed", 0);
            isGrounded = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("jump", true);
            //animator.SetFloat("speed", 1);
        }



        if (other.CompareTag("Shelf_Ground"))
        {
            isGrounded = false;
            animator.SetBool("jump", true);
            //animator.SetFloat("speed", 1);
        }
    }
    




    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && !PlayerLife.isDead)

        {
            transform.Translate(new Vector3(-4, 0, 0) * Time.deltaTime);
            sprite.flipX = true;
            isFlipped = true;
        }



        if (Input.GetKey(KeyCode.RightArrow) && !PlayerLife.isDead)
        {
            transform.Translate(new Vector3(4, 0, 0) * Time.deltaTime);
            sprite.flipX = false;
            isFlipped = false;
        }
           
 

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jumping.Play();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            animator.SetBool("jump", true);
            animator.SetFloat("speed", 1);
        }

        //idle
        if (isGrounded && (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)))

        {
            animator.SetFloat("speed", 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("speed", 1);
        }
        
    }
}

