using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
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

        if (Input.GetKey("space") && playerJump.isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed );
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
        }
        else
        { 
            animator.SetBool("isJumping", true);
        }


    }






}
