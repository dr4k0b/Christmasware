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
            StartCoroutine(WinDelay());
        }
        else
        {
            Timer();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            clicks++;
        }
    }
    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(1);
        Win();
    }
}
