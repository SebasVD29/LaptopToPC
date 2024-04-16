using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
   public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerGranny")
        {
            other.GetComponent<Health>().Damage(damage);
        }   
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlayerGranny")
        {
            other.GetComponent<Health>().Damage(damage);
        }
    }
}
