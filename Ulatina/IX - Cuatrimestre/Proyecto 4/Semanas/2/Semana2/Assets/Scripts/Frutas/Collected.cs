using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
  
    [SerializeField]GameObject collected;
    [SerializeField]GameObject Padre;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            collected.gameObject.SetActive(true);
            
            Destroy(Padre, 0.5f);
            //Destroy(gameObject, 0.5f);
            //Destroy(collected, 0.5f);
        }
    }
}
