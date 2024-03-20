using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform[] positions;
    public float speedPlatform;


    int actualPosition = 0;
    int nextPosition = 1;

    public bool moveToNext = true;
    public float waitTime;

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        if (moveToNext)
        {
            StartCoroutine(WaitForMove(0));
            rb.MovePosition(Vector3.MoveTowards(rb.position, positions[nextPosition].position, speedPlatform * Time.deltaTime));
            
        }

        if (Vector3.Distance(rb.position, positions[nextPosition].position) <= 0)
        {
            StartCoroutine(WaitForMove(waitTime));
            actualPosition = nextPosition;
            nextPosition++;

            if (nextPosition > positions.Length-1)
            {
                nextPosition = 0;
            }
        }
    }
    IEnumerator WaitForMove(float time)
    {
        moveToNext = false;
        yield return new WaitForSeconds(time);
        moveToNext = true;
    }


}
