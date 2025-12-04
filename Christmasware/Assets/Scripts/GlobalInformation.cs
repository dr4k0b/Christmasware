using System.Collections.Generic;
using UnityEngine;

public class GlobalInformation : MonoBehaviour
{
    public enum Result { start, win, lose, game }
    public Result result;
    public int health;
    public int score;
    public int highScore;
    public int round;
    public float startTime;
    public int Difficulty;
    public Animator pig;

    public List<int> gamesLeft = new List<int>();

    public static GlobalInformation Instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        pig.SetFloat("Speed", 1 + (((float)Difficulty) / 10f));
    }

}
