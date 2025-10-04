using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("暂停菜单引用")]
    public GameObject pauseMenuCanvas;
    public Button resumeButton;
    public Button restartButton;
    public Button mainMenuButton;

    private bool isPaused = false;

    void Start()
    {
        Debug.Log("PauseManager Started - 检查引用:");
        Debug.Log("PauseMenuCanvas: " + (pauseMenuCanvas != null ? "已设置" : "未设置"));
        Debug.Log("ResumeButton: " + (resumeButton != null ? "已设置" : "未设置"));
        Debug.Log("RestartButton: " + (restartButton != null ? "已设置" : "未设置"));
        Debug.Log("MainMenuButton: " + (mainMenuButton != null ? "已设置" : "未设置"));

        // 关联按钮事件
        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeGame);
        else
            Debug.LogError("ResumeButton未设置!");
            
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);
        else
            Debug.LogError("RestartButton未设置!");
            
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(BackToMainMenu);
        else
            Debug.LogError("MainMenuButton未设置!");

        // 初始隐藏暂停菜单
        if (pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);
        else
            Debug.LogError("PauseMenuCanvas未设置!");
    }

    void Update()
    {
        // 使用ESC键切换暂停
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC键被按下，切换暂停状态");
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Debug.Log("切换暂停状态: " + (isPaused ? "暂停" : "继续"));

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true);
            Debug.Log("暂停菜单已显示");
        }
        else
        {
            Debug.LogError("无法显示暂停菜单: PauseMenuCanvas为null");
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
            Debug.Log("暂停菜单已隐藏");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}