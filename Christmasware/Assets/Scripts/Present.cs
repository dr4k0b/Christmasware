using System.Collections;
using UnityEngine;

public class Present : MiniGame
{
    public int presentHealth;
    public Sprite[] sprites;
    public SpriteRenderer hands;
    public GameObject win;
    int clicks;

    void Update()
    {
        hands.sprite = sprites[(presentHealth <= clicks) ? 24 : clicks];
        if (presentHealth <= clicks)
        {
            win.SetActive(true);
            StartCoroutine(WinDelay(1));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            clicks++;
        }
        Timer();
    }
}
