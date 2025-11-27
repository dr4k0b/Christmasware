using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MiniGame : MonoBehaviour
{
    public float startTime;
    private float time;

    [HideInInspector]
    public GlobalInformation g;
    private void Awake()
    {
        g = FindAnyObjectByType<GlobalInformation>();
        time = startTime;
    }

    public void Timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime * (1 + (g.Difficulty / 10));
            Debug.Log(time);
        }
        else
        {
            time = 0;
            Lose();
        }
    }
    public void Win()
    {
        g.result = GlobalInformation.Result.win;
        g.score++;
        SceneManager.LoadScene("Intermission");
    }
    public void Lose()
    {
        g.result = GlobalInformation.Result.lose;
        g.health--;
        SceneManager.LoadScene((g.health <= 0) ? "Death" : "Intermission");
    }
}
