using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float starWithTime;
    private float waitedTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            waitedTime = Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (waitedTime <= 0 )
            {
                effector.rotationalOffset = 180;
                waitedTime = starWithTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }

    }
}
