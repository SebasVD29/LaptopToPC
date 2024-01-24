using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraManager : MonoBehaviour
{


    [HideInInspector][SerializeField] Rigidbody2D rigidBMira;

    [SerializeField][Range(5,20)] float velocity;

    public float xAxis;
    public float yAxis;

    GameObject cuervo;
    bool collisionCuervo;

    public AudioSource disparoSound;
    public AudioSource cuervoSound;

    // Start is called before the first frame update
    void Start()
    {
        rigidBMira = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        Disparo();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rigidBMira.velocity = new Vector2(xAxis * velocity, 0);
        } 
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rigidBMira.velocity = new Vector2(0, yAxis *velocity);

        }
        else
        {
            rigidBMira.velocity = Vector2.zero;   
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cuervo"))
        {
            cuervo = collision.gameObject;
            collisionCuervo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cuervo"))
        {
            collisionCuervo = false;
        }
    }

    public void Disparo()
    {
        if (Input.GetKey(KeyCode.E))
        {
            disparoSound.Play();
            if (collisionCuervo)
            {
                cuervoSound.Play();
                Destroy(cuervo);
            }
        }
    }
}
