using UnityEngine;

public class IntermissionLogic : MonoBehaviour
{
    GlobalInformation g;
    void Start()
    {
        g = FindAnyObjectByType<GlobalInformation>();

        if (g.result == GlobalInformation.Result.win)
        {
            g.score++;
        }
        if (g.result == GlobalInformation.Result.lose)
        {
            g.health++;
        }
        g.result = GlobalInformation.Result.game;

        // start new minigame
    }
}
