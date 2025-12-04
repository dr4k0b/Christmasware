using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MiniGame : MonoBehaviour
{
    private bool win;
    bool hasWon;
    [HideInInspector]
    public float time;

    [HideInInspector]
    public GlobalInformation g;
    private void Awake()
    {
        hasWon = false;
        win = false;
        g = FindAnyObjectByType<GlobalInformation>();
        time = 7;
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
        Debug.Log(time);
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
        if (hasWon)
            yield break;

        g.GetComponent<AudioManager>().Play("Win");
        hasWon = true;
        win = true;
        yield return new WaitForSeconds(delay);
        Win();
    }
}
