using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Funciones : MonoBehaviour
{

    public GameObject menuPanel;
    public GameObject continueButton;
    public GameObject restartButton;

    public void Pause()
    {
        Time.timeScale = 0;
        menuPanel.SetActive(true);
        continueButton.SetActive(true);
    }

    public void Continuar()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        //SceneManager.LoadScene();
    }
}
