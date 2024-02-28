using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAttack = 3;
    private Animator animator;
    public GameObject bullet;
    public Transform launchSpawnPoint;
   
    // Start is called before the first frame update
    void Start()
    {
        waitedTime = waitTimeToAttack;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitTimeToAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }


    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bullet, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
