using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;

    public void OptionsPanel()
    {
        Time.timeScale = 0f;
        optionPanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1f;
        optionPanel.SetActive(false);
    }

    public void Options()
    {

    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
