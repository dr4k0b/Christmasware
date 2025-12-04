using UnityEngine;

public class Spin : MiniGame
{
    Animator ani;
    int dir;
    public GameObject knapp;
    public Sprite[] buttons;
    public int spins;
    bool spun;
    void Start()
    {
        dir = 0;
        spins = 0;
        spun = false;
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if (dir == 3)
        {
            if (!spun)
            {
                spins++;
                spun = true;
            }
        }
        else
        {
            spun = false;
        }
        if (dir != -1)
            knapp.GetComponent<SpriteRenderer>().sprite = buttons[dir];

        if (spins >= 5 && dir != -1)
        {
            dir = -1;
            ani.SetTrigger("Win");
            StartCoroutine(WinDelay(2));
        }
        else
        {
            ani.SetInteger("direction", dir);
        }
        Timer();

        if (dir == 0 && Input.GetKeyUp(KeyCode.A))
        {
            dir = 1;
        }
        else if (dir == 1 && Input.GetKeyUp(KeyCode.W))
        {
            dir = 2;
        }
        else if (dir == 2 && Input.GetKeyUp(KeyCode.D))
        {
            dir = 3;
        }
        else if (dir == 3 && Input.GetKeyUp(KeyCode.S))
        {
            dir = 0;
        }

    }
}
