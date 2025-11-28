using UnityEngine;

public class GlobalInformation : MonoBehaviour
{
    public enum Result { start, win, lose, game }
    public Result result;
    public int health;
    public int score;
    public int round;
    public int Difficulty;

    public static GlobalInformation Instance;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
