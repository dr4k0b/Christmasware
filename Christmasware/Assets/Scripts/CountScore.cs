using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountScore : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    TextMeshProUGUI text;
    GlobalInformation g;
    
    int scoreCount;
    bool countDone;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        g = FindAnyObjectByType<GlobalInformation>();
        StartCoroutine(count());

        g.GetComponent<AudioManager>().Play("GameOver");
        g.GetComponent<AudioManager>().Stop("Main");
        g.GetComponent<AudioManager>().Stop("Rullband");
    }
    void Update()
    {
        if (countDone && Input.GetKeyUp(KeyCode.Space))
        {
            Restart();
        }

        if(scoreCount > g.highScore)
        {
            g.highScore = scoreCount;
        }

        text.text = "Score " + scoreCount.ToString();
        highScore.text = "High score " + g.highScore.ToString();
    }
    IEnumerator count()
    {
        yield return new WaitForSeconds(0.05f);
        if (g.score > scoreCount)
        {
            scoreCount++;
        }
        else
        {
            countDone = true;
        }
        StartCoroutine(count());
    }
    void Restart()
    {
        g.result = GlobalInformation.Result.start;
        g.health = 3;
        g.score = 0;
        g.round = 0;
        g.Difficulty = 0;
        g.GetComponent<AudioManager>().Play("Main");
        SceneManager.LoadScene("Intermission");
    }
}
