using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameHUD : MonoBehaviour
{
    public GameObject[] miniGameHUDElements;
    public GameObject explosion;
    GlobalInformation g;
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
        foreach (GameObject obj in miniGameHUDElements)
        {
            obj.SetActive(g.result == GlobalInformation.Result.game);
        }
    }
}
