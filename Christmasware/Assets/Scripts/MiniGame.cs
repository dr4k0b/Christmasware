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
    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
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
        SceneManager.LoadScene("Intermission");
    }
    public void Lose()
    {
        g.result = GlobalInformation.Result.lose;
        SceneManager.LoadScene("Intermission");
    }
}
