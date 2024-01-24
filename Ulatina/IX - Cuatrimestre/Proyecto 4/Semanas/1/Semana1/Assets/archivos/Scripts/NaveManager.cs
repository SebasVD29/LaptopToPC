using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaveManager : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    public float velocity = 1;

    public Text text;
    public int oroRobado = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 desplazamiento  = new Vector2(horizontal, vertical);

        rigidbody2d.AddForce(desplazamiento * velocity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("latam"))
        {
            oroRobado = oroRobado +1;
            text.text = "Oro Robado: " + oroRobado.ToString();
            Destroy(collision.gameObject);
        }
    }


}
