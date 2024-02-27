using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerRespawn : MonoBehaviour
{
 
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        string nivelActual = SceneManager.GetActiveScene().name;
        string checkPointLevel = PlayerPrefs.GetString("checkPointLevel");
        float checkPointX = PlayerPrefs.GetFloat("checkPointTransformX");
        float checkPointY = PlayerPrefs.GetFloat("checkPointTransformY");

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

    public void PlayerHit()
    {
        animator.Play("HitFrog");
        Invoke("LoadLevel", 1);

    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
