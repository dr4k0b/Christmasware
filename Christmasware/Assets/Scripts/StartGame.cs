using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            startGame();
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("Intermission");
    }
}
