using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FruitManager : MonoBehaviour
{
    public Text text;

    int frutas;
    int frutasActuales;

    private void Start()
    {
        frutas = transform.childCount;
        Mensaje();
    }


    private void Update()
    {
        frutasActuales = transform.childCount;
        Mensaje();
        if (frutasActuales == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }


    void Mensaje()
    {
        text.text = frutasActuales + " / " + frutas ;
    }
}
