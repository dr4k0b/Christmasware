using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MiniGame : MonoBehaviour
{
    private bool win;

    [HideInInspector]
    public float time;

    [HideInInspector]
    public GlobalInformation g;
    private void Awake()
    {
        win = false;
        g = FindAnyObjectByType<GlobalInformation>();
        time = g.startTime;
    }

    public void Timer()
    {
        if (win)
        {
            return;
        }
        if (time > 0)
        {
            time -= Time.deltaTime * (1 + ((float)g.Difficulty / 10));
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
        SceneManager.LoadScene("Intermission");
    }
    public IEnumerator WinDelay(float delay)
    {
        win = true;
        yield return new WaitForSeconds(delay);
        Win();
    }
}
