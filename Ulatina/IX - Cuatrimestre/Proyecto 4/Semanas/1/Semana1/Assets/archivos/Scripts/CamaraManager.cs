using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{

    public GameObject nave;
    private Vector3 movimiento;
    // Start is called before the first frame update
    void Start()
    {
        movimiento = transform.position - nave.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = nave.transform.position + movimiento;
    }
}
