using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // 关闭面板
    public void ClosePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(false);
    }

    // 打开面板
    public void OpenPanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(true);
    }

    // 切换场景
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 重启场景
    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }
}