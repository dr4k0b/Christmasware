using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
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
    }

    private void Update()
    {
        if (g.gamesLeft.Count == 0)
        {
            for (int i = 3; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                g.gamesLeft.Add(i);
            }
        }
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
            int nextGame = Random.Range(0, g.gamesLeft.Count);
            SceneManager.LoadScene(g.gamesLeft[nextGame]);
            g.gamesLeft.RemoveAt(nextGame);
        }
    }
}
