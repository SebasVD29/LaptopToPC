using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManage : MonoBehaviour
{
    public GameObject player;
    private Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        move = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + move;
    }
}
