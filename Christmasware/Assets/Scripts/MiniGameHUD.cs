using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameHUD : MonoBehaviour
{
    public GameObject[] miniGameHUDElements;
    public GameObject explosion;
    GlobalInformation g;
    public Animator ani;


    public static MiniGameHUD Instance;
    void Awake()
    {
        g = FindAnyObjectByType<GlobalInformation>();
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
    void Update()
    {
        ani.SetBool("Start", g.result != GlobalInformation.Result.game);
        foreach (GameObject obj in miniGameHUDElements)
        {
            obj.SetActive(g.result == GlobalInformation.Result.game);
        }
    }
}
