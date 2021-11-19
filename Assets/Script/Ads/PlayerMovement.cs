using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;


    public GameObject win;
    Scene thisScene;
    //tutorial
    /*
    bool isGrounded;
    private bool isTouchingLeft;
    private bool isTouchingRigth;
    private bool wallJumping;
    private float touchingLeftOrRight;
    private float jumpSpeed = 100f;

    public LayerMask groundMask;
    */

    private void Start()
    {
        thisScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        
        if (Input.GetButton("Jump"))
        {
            jump = true;
        }
        

        //Tutorial

        /*
        isGrounded = controller.m_Grounded;

        isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f), new Vector2(0.41843f, 0.1f), 0f, groundMask);

        isTouchingLeft = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x - 0.2f , gameObject.transform.position.y ), new Vector2(0.41843f, 0.1f), 0f, groundMask);

        isTouchingRigth = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y ), new Vector2(0.41843f, 0.1f), 0f, groundMask);

        if (isTouchingLeft)
        {
            touchingLeftOrRight = 1;
        }
        else if (isTouchingRigth)
        {
            touchingLeftOrRight = -1;
        }

        if (Input.GetButton("Jump") && (isTouchingLeft || isTouchingRigth) && !isGrounded)
        {
            wallJumping = true;
            jump = true;
            Invoke("SetJumpingToFalse", 0.08f);

        }

        if (wallJumping)
        {
            controller.m_Rigidbody2D.velocity = new Vector2(runSpeed * touchingLeftOrRight, jumpSpeed);
        }
        */
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obj"))
        {
            win.SetActive(true);
            
        }
        if (collision.collider.CompareTag("Restart"))
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f), new Vector2(0.41843f, 0.1f));

        Gizmos.color = Color.black;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y ), new Vector2(0.1f, 0.41843f));

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x + 0.2f, gameObject.transform.position.y ), new Vector2(0.1f, 0.41843f));
    }


    void SetJumpingToFalse()
    {
        wallJumping = false;
    }
    */
}
