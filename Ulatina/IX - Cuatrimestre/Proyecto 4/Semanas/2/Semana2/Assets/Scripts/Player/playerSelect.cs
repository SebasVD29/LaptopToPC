using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSelect : MonoBehaviour
{
    public enum player { Frog, Mask, Man, Virtual};
    public player playSelect;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playersControllers;
    public Sprite[] playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        switch (playSelect)
        {
            case player.Frog:
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playersControllers[0];
                break;
            case player.Mask:
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playersControllers[1];
                break;
            case player.Man:
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playersControllers[2];
                break;
            case player.Virtual:
                spriteRenderer.sprite = playerRenderer[3];
                animator.runtimeAnimatorController = playersControllers[3];
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
