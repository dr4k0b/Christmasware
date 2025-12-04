using UnityEngine;

public class Hugga : MiniGame
{
    Animator highlight;
    public Animator hugga;
    bool canHit;
    void Start()
    {
        highlight = GetComponent<Animator>();
    }
    void Update()
    {
        highlight.SetBool("Highlight", canHit);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (canHit)
            {
                hugga.SetBool("win", true);
                g.GetComponent<AudioManager>().Play("Hugga");
                GetComponent<Renderer>().enabled = false;
                StartCoroutine(WinDelay(1.5f));
            }
            else
            {
                g.GetComponent<AudioManager>().Play("Fail");
            }
            Timer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canHit = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canHit = false;
    }
}
