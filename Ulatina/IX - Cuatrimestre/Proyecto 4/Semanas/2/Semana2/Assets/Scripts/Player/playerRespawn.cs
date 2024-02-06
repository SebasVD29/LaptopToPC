using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
    string nivelActual;
    string checkPointLevel;
    float checkPointX;
    float checkPointY;
    // Start is called before the first frame update
    void Start()
    {
         nivelActual = SceneManager.GetActiveScene().name;

         checkPointLevel = PlayerPrefs.GetString("checkPointLevel");
         checkPointX = PlayerPrefs.GetFloat("checkPointTransformX");
         checkPointY = PlayerPrefs.GetFloat("checkPointTransformY");

        if (nivelActual == checkPointLevel)
        {
            transform.position = new Vector2(checkPointX, checkPointY);
        }
    }
  
   
    public void ReachedCheckPoint(string nivel,float x, float y)
    {
        PlayerPrefs.SetString("checkPointLevel", nivel);
        PlayerPrefs.SetFloat("checkPointTransformX", x);
        PlayerPrefs.SetFloat("checkPointTransformY", y);

  
    }
}
