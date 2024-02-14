using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public GameObject skinPanel;
    public bool inDoor = false;
    public GameObject playerSkin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinPanel.SetActive(true);
            inDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinPanel.SetActive(false);
            inDoor = false;
        }
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelect", "Frog");
        ResetPlayerSkin();
    }
    public void SetPlayerVirtual()
    {
        PlayerPrefs.SetString("PlayerSelect", "Virtual");
        ResetPlayerSkin();
    }
    public void SetPlayerMask()
    {
        PlayerPrefs.SetString("PlayerSelect", "Mask");
        ResetPlayerSkin();
    }
    public void SetPlayerMan()
    {
        PlayerPrefs.SetString("PlayerSelect", "Man");
        ResetPlayerSkin();
    }


    void ResetPlayerSkin()
    {
        skinPanel.SetActive(false);
        playerSkin.GetComponent<playerSelect>().ChangePlayer();
    }



}
