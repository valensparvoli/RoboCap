using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed; //Player Speed
    Rigidbody2D rb; // Rb component
    bool facingRight = true; // booleano right left

    bool isGrounded; // bool if is on the ground
    public Transform groundCheck; // transform that change the bool 
    public float checkRadius; // radius that change the bool 
    public LayerMask whatIsGround; // layerMask for ground 
    public float jumpForce; // force that help jump

    //WallSliding
    bool isTouchingFront;
    public Transform frontCheck;
    bool wallSliding;
    public float wallSlidingSpeed;

    //WallJump
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    //Animation
    public Animator animator;

    //Score levelSistem
    [SerializeField] int score = 0;
    public GameObject canvas;
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

    //
    public AudioClip coin;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        
    }
    private void Awake()
    {
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(input));


        if(input>0 && facingRight == false)
        {
            Flip();
        }
        else if (input<0 && facingRight == true)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
        }

        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if(isTouchingFront==true && isGrounded == false && input != 0)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.Space) && wallSliding == true)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (wallJumping == true)
        {
            rb.velocity = new Vector2(xWallForce * -input, yWallForce);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            speed += 2;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            speed -= 2;
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
        if (collision.collider.CompareTag("Point"))
        {
            score += 1;
            Destroy(collision.gameObject);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

        }
        if (collision.collider.CompareTag("Obj"))
        {
            canvas.SetActive(true);
            if (score == 1)
            {
                btn1.SetActive(true);
                btn2.SetActive(false);
                btn3.SetActive(false);
            }
            if (score == 2)
            {
                btn1.SetActive(false);
                btn2.SetActive(true);
                btn3.SetActive(false);
            }
            if (score == 3)
            {
                btn1.SetActive(false);
                btn2.SetActive(false);
                btn3.SetActive(true);
            }
        }
    }
}
