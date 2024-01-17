using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;


    [SerializeField]
    [Range(1f, 10f)]public float velocity = 5;
    [SerializeField] public float xDirection = 1;


    // Start is called before the first frame update
    void Start()
    {
      spriteRenderer = GetComponent<SpriteRenderer>();
      rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() //Se aplica cuando sea el final de los cuadros
    {
        rigidbody2D.velocity = new Vector2(velocity*xDirection*Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        xDirection *= -1;

        if(xDirection < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
