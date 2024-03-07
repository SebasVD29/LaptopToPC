using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision es la colicion del otro objeto

        if (collision.transform.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }


}
