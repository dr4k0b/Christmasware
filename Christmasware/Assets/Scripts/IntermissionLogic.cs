using UnityEngine;
using UnityEngine.SceneManagement;

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
            g.health--;
        }
        g.result = GlobalInformation.Result.game;


        // start new minigame
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            SceneManager.LoadScene("Present");
        }
    }
}
