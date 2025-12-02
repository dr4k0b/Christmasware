using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionLogic : MonoBehaviour
{
    GlobalInformation g;
    public Animator ani;
    public Animator rullband;
    public TextMeshProUGUI text;
    void Start()
    {
        g = FindAnyObjectByType<GlobalInformation>();

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
            rullband.SetBool("Start", true);
        }
        else if (g.result == GlobalInformation.Result.win)
        {
            ani.SetBool("Win", true);
            rullband.SetBool("Win", true);
            ani.SetBool("Game", false);
            rullband.SetBool("Start", false);
        }
        else if (g.result == GlobalInformation.Result.lose)
        {
            ani.SetBool("Win", false);
            rullband.SetBool("Win", false);
            ani.SetBool("Game", false);
            rullband.SetBool("Start", false);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);

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
