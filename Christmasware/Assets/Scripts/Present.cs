using UnityEngine;

public class Present : MiniGame
{
    public int presentHealth;

    void Update()
    {
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
