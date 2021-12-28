using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f;
    [SerializeField] private bool isGrounded = false;
    private Animator animator;
    private SpriteRenderer sprite;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("jump", false);
            animator.SetFloat("speed", 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if (other.CompareTag("Ground"))
                isGrounded = false;
    }
    
   
// Update is called once per frame
private void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow) && !PlayerLife.isDead)

        {
            transform.Translate(new Vector3(-2, 0, 0) * Time.deltaTime);
            sprite.flipX = true;
        }



        if (Input.GetKey(KeyCode.RightArrow) && !PlayerLife.isDead)
        {
            transform.Translate(new Vector3(2, 0, 0) * Time.deltaTime);
            sprite.flipX = false;
        }
           
 

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
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

