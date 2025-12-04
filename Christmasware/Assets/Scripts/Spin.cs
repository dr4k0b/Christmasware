using UnityEngine;

public class Spin : MiniGame
{
    Animator ani;
    int dir;
    void Start()
    {
        dir = 0;
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        ani.SetInteger("direction", dir);

    }
}
