using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMove : MonoBehaviour
{

   // public Animator animator;
   // public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    private float waitTime;
    public float startWaitTime = 2;
    private int contardor = 0;

    private Vector2 actualPosition;

    public Transform[] positions;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemiyMove());
        transform.position = Vector2.MoveTowards(transform.position, positions[contardor].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, positions[contardor].position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (positions[contardor] != positions[positions.Length - 1])
                {
                    contardor++;
                }
                else
                {
                    contardor = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator EnemiyMove()
    {
        actualPosition = transform.position;
        yield return new WaitForSeconds(0.5f);
        if (transform.position.x > actualPosition.x)
        {
            //spriteRenderer.flipX = true;
            //animator.SetBool("Idel", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
           // spriteRenderer.flipX = false;
           // animator.SetBool("Idel", false);
        }
        else if (transform.position.x == actualPosition.x)
        {

           // animator.SetBool("Idel", true);
        }
    }
}
