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
        Mensaje();
        frutas = transform.childCount;
    }


    private void Update()
    {
        Mensaje();
        frutasActuales = transform.childCount;
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
