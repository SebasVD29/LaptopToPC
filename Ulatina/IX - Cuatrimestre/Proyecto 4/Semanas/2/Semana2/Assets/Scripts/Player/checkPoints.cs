using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkPoints : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //OBTIENE EL NIVEL Y LA POSICION EN X - Y
            string level = SceneManager.GetActiveScene().name;
            float x = collision.transform.position.x;
            float y = collision.transform.position.y;

            collision.GetComponent<playerRespawn>().ReachedCheckPoint(level, x, y);
            GetComponent<Animator>().Play("checkPointOut");


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
