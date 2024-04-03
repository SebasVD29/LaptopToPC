using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int life = 100;
    public bool invincible = false;
    public float invincibleTime = 1f;
    public float stopTime = 0.2f;

    public void Damage(int damage)
    {
        if (!invincible &&  life > 0)
        {
            life -= damage;
            StartCoroutine(Invicible());
            StartCoroutine(StopVelocity());
        }
    }

    public void AddLife(int cant)
    {
        if (life + cant > 100)
        {
            life = 100;
        }
        else
        {
            life += cant;
        }
    }

    IEnumerator Invicible()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibleTime);
        invincible = false;
    }

    IEnumerator StopVelocity()
    {
        var actualVelocity = GetComponent<PlayerController>().speed;
        GetComponent<PlayerController>().speed = 0;
        yield return new WaitForSeconds(stopTime);
        GetComponent<PlayerController>().speed = actualVelocity;
        
    }

}
