using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public Text text;
    public string levelLevel;
    public bool inDoor = false;

    private void Update()
    {
        if (inDoor && Input.GetKey("e"))
        {
            SceneManager.LoadScene(levelLevel);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = true;
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inDoor = false;
            text.gameObject.SetActive(false);
        }
    }

}
