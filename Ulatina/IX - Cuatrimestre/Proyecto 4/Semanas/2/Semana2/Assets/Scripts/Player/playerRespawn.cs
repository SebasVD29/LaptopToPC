using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
 
    Animator animator;
    string actualLevel;
    string level;
    float xPos, yPos;

    // Start is called before the first frame update
    void Start()
    {
        //Asigna el animator al iniciar el nivel 
        animator = GetComponent<Animator>();
        //Obtiene el nivel actual 
        actualLevel = SceneManager.GetActiveScene().name;
        //Obtien las variables del checkpoint 
        level = PlayerPrefs.GetString("checkPointLevel");
        xPos = PlayerPrefs.GetFloat("checkPointX");
        yPos = PlayerPrefs.GetFloat("checkPointY");
        //Valida si el nivel actual es el mismo del ultimo checkpoint 
        if (actualLevel == level)
        {
            transform.position = new Vector2(xPos, yPos);
        }
    }


    public void ReachedCheckPoint(string nivel,float x, float y)
    {
        PlayerPrefs.SetString("checkPointLevel", nivel);
        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointY", y);

    }

    public void PlayerHit()
    {
        animator.Play("Hit");
        Invoke("LoadLevel", 0.5f);

    }

    void LoadLevel()
    {
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("checkPointLevel")))
        {
            //Debug.Log("name == null" + PlayerPrefs.GetString("checkPointLevel"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //Debug.Log("name != null "+PlayerPrefs.GetString("checkPointLevel"));
            SceneManager.LoadScene(PlayerPrefs.GetString("checkPointLevel"));
        }
    }


}
