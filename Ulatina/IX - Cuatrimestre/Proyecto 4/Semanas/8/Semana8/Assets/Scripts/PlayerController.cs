using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public CharacterController player;
    public Vector3 playerInput;

    public float speed;
    private Vector3 movePlayer;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;


    public Camera camera;
    private Vector3 camForward;
    private Vector3 camRight;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        CameraDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward; 
        player.transform.LookAt(player.transform.position + movePlayer);

        setGravity();
        PlayerSkill();
        player.Move(movePlayer * speed * Time.deltaTime);

    }

    void CameraDirection()
    {
        camForward = camera.transform.forward;
        camRight = camera.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    void setGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }


    public void PlayerSkill()
    {
        if (player.isGrounded && Input.GetButton("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;


        }
    }
}
