using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float dobleSaltoSpeed = 2.5f;
    private bool canDoubleJump;
    Rigidbody2D player;
    SpriteRenderer playerRender;
    public Jump playerJump;
    Animator animator;

    public bool betterJump;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1;
        



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {

            player.velocity = new Vector2(runSpeed + Time.deltaTime , player.velocity.y);
            playerRender.flipX = false;
            animator.SetFloat("Runing", runSpeed);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            player.velocity = new Vector2 (-runSpeed + Time.deltaTime, player.velocity.y);
            playerRender.flipX = true;
            animator.SetFloat("Runing", runSpeed);
        }
        else
        {
           player.velocity = new Vector2 (0, player.velocity.y);
            animator.SetFloat("Runing", 0);
        }

        if (Input.GetKeyDown("space") )
        {
            if ( playerJump.isGrounded)
            {
                canDoubleJump = true;
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            }
            else
            {
                if (canDoubleJump)
                {
                    canDoubleJump= false;
                    animator.SetBool("DoubleJump", true);
                    player.velocity = new Vector2(player.velocity.x, dobleSaltoSpeed);
                }
            }






        }





        if (betterJump)
        {
            if (player.velocity.y < 0)
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (player.velocity.y < 0 && !Input.GetKey("space"))
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;

            }
        }
        if (playerJump.isGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Fall", false);
        }
        else
        { 
            animator.SetBool("isJumping", true);
        }
        if (player.velocity.y < 0)
        {
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Fall", false);

        }

    }






}
