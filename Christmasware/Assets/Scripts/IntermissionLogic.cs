using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionLogic : MonoBehaviour
{
    GlobalInformation g;
    public Animator ani;
    public TextMeshProUGUI text;
    void Start()
    {
        g = FindAnyObjectByType<GlobalInformation>();
        if (g.round == 0)
        {
            ani.SetBool("Game", false);
        }
        else if (g.result == GlobalInformation.Result.win)
        {
            ani.SetBool("Win", true);
        }
        else if (g.result == GlobalInformation.Result.lose)
        {
            ani.SetBool("Win", true);
        }
        g.round++;
        if (g.round % 1 == 0)
        {
            g.Difficulty++;
        }

        StartCoroutine(NextScene());
        // start new minigame
    }

    private void Update()
    {
        text.SetText("Score " + g.score.ToString());
        if (g.result == GlobalInformation.Result.start)
        {
            ani.SetBool("Game", true);
        }
        else if (g.result == GlobalInformation.Result.win)
        {
            ani.SetBool("Win", true);
            ani.SetBool("Game", false);
        }
        else if (g.result == GlobalInformation.Result.lose)
        {
            ani.SetBool("Win", false);
            ani.SetBool("Game", false);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);

        g = FindAnyObjectByType<GlobalInformation>();
        if (g.health <= 0)
        {
            SceneManager.LoadScene("Death");
        }
        else
        {
            g.result = GlobalInformation.Result.game;
            SceneManager.LoadScene(Random.Range(3, SceneManager.sceneCountInBuildSettings));
        }
    }
}
