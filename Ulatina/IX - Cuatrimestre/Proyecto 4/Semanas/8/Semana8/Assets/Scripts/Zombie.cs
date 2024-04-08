using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerGranny")
        {
            animator.Play("Attack");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerGranny")
        {
            animator.Play("Walk");
        }
    }
}
