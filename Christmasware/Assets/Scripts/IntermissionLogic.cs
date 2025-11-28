using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionLogic : MonoBehaviour
{
    GlobalInformation g;
    public Animator ani;
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
        if (g.round % 5 == 0)
        {
            g.Difficulty++;
        }
        
        StartCoroutine(NextScene());
        // start new minigame
    }

    private void Update()
    {
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
        if (Input.GetKey(KeyCode.D))
        {
            SceneManager.LoadScene("Present");
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(1);
        g.result = GlobalInformation.Result.game;
        SceneManager.LoadScene(Random.Range(3, SceneManager.sceneCountInBuildSettings));

    }
}
