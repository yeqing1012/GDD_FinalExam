using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Button References")]
    public Button madDriverButton;
    public Button flyLikeBirdButton;
    public Button sumoAndBallButton;
    public Button exitButton;

    void Start()
    {
        // 为按钮添加点击事件
        if (madDriverButton != null)
            madDriverButton.onClick.AddListener(LoadMadDriver);
        
        if (flyLikeBirdButton != null)
            flyLikeBirdButton.onClick.AddListener(LoadFlyLikeBird);
            
        if (sumoAndBallButton != null)
            sumoAndBallButton.onClick.AddListener(LoadSumoAndBall);
            
        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    void LoadMadDriver()
    {
        Debug.Log("Loading Mad Driver...");
        // 使用确切的场景路径
        SceneManager.LoadScene("Challenge 2/Challenge 2");
    }

    void LoadFlyLikeBird()
    {
        Debug.Log("Loading Fly Like Bird...");
        SceneManager.LoadScene("fly/Challenge 1");
    }

    void LoadSumoAndBall()
    {
        Debug.Log("Loading Sumo And Ball...");
        SceneManager.LoadScene("ball/Challenge 5");
    }

    void ExitGame()
    {
        Debug.Log("Exiting game...");
        Application.Quit();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}