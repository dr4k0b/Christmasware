using UnityEngine;

public class GlobalInformation : MonoBehaviour
{
    public enum Result { start, win, lose, game }
    public Result result;
    public int health;
    public int score;
    public int round;
    public int Difficulty;
    public Animator pig;

    public static GlobalInformation Instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        pig.SetFloat("Speed", 1 + (((float)Difficulty) / 10f));
    }

}
