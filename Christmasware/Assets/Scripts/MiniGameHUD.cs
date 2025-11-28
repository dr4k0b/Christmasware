using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameHUD : MonoBehaviour
{
    public GameObject[] miniGameHUDElements;
    GlobalInformation g;

    public static MiniGameHUD Instance;
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
    void Update()
    {
        g = FindAnyObjectByType<GlobalInformation>();
        foreach (GameObject obj in miniGameHUDElements)
        {
            obj.SetActive(g.result == GlobalInformation.Result.game);
        }
    }
}
