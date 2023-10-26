using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string GameSceneName = "GameScene";

    public int GemsToCollect { get; private set; } = 9;

    public void Pause()
    {
        Time.timeScale = 0;
    }

    private void Resume()
    {
        Time.timeScale = 1;
    }

    public void LoadGameScene()
    {
        LoadScene(GameSceneName);
        Resume();
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
