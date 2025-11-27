using UnityEngine;

public class Present : MiniGame
{
    public int presentHealth;

    void Update()
    {
        Timer();
        if (presentHealth <= 0)
        {
            Win();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            presentHealth--;
        }

    }
}
