using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntermissionLogic : MonoBehaviour
{
    GlobalInformation g;
    void Start()
    {
        g = FindAnyObjectByType<GlobalInformation>();
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
