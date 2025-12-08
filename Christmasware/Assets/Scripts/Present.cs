using System.Collections;
using UnityEngine;

public class Present : MiniGame
{
    public int presentHealth;
    public Sprite[] sprites;
    public SpriteRenderer hands;
    public GameObject win;
    int clicks;

    private void Start()
    {
        g.GetComponent<AudioManager>().Play("Cry");

    }
    void Update()
    {
        hands.sprite = sprites[(presentHealth <= clicks) ? 24 : clicks];
        if (presentHealth <= clicks)
        {
            win.SetActive(true);
            g.GetComponent<AudioManager>().Stop("Cry");
            StartCoroutine(WinDelay(1));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            g.GetComponent<AudioManager>().Play("Open");
            clicks++;
        }
        if(time - Time.deltaTime <= 0)
        {
            g.GetComponent<AudioManager>().Stop("Cry");
        }
        Timer();
    }
}
