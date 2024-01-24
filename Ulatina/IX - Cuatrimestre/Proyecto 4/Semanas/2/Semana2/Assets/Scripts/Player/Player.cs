using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D player;
    Jump playerJump;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerJump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
           player.velocity = new Vector2 (runSpeed, player.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
           player.velocity = new Vector2 (-runSpeed, player.velocity.y);
        }
        else
        {
           player.velocity = new Vector2 (0, player.velocity.y);
        }

        if (Input.GetKey("space") && playerJump.isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }



    }






}
