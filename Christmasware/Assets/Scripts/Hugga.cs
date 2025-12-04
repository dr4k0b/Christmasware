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
        if (canHit && Input.GetKeyUp(KeyCode.Space))
        {
            hugga.SetBool("win", true);
            GetComponent<Renderer>().enabled = false;
            StartCoroutine(WinDelay(1.5f));
        }
        Timer();
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
