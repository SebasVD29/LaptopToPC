using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveLifePlayer : MonoBehaviour
{
    public int life = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerGranny")
        {
            other.GetComponent<Health>().AddLife(life);
            this.gameObject.AddComponent<Rigidbody>();
            Destroy(this, 1f);
        }
    }
}
