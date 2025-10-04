using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public GameObject titleScreen;
    public Button restartButton;

    public List<GameObject> targetPrefabs;

    private int score;
    private float spawnRate = 1.5f;
    public bool isGameActive;
    private float timeRemaining;

    private float spaceBetweenSquares = 2.5f;
    private float minValueX = -3.75f;
    private float minValueY = -3.75f;

    // 开始游戏（由 DifficultyButton 调用）
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty; // 根据难度调整生成速率
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        timeRemaining = 60f; // 倒计时初始化
        StartCoroutine(SpawnTarget());
    }

    // 循环生成目标
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }
        }
    }

    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);
        return new Vector3(spawnPosX, spawnPosY, 0);
    }

    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // 更新分数
    public void UpdateScore(int scoreToAdd)
    {
        if (!isGameActive) return;
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        // 分数 < 0 游戏结束
        if (score < 0)
        {
            GameOver(false);
        }
    }

    // 游戏结束（won = true 表示赢，false 表示输）
    public void GameOver(bool won = false)
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        if (won)
            gameOverText.text = "You Won!";
        else
            gameOverText.text = "Game Over";
    }

    // 重新开始
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 每帧更新倒计时
    void Update()
    {
        if (!isGameActive) return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            // 倒计时结束，根据分数判断输赢
            if (score >= 0)
                GameOver(true);
            else
                GameOver(false);
        }
        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        if (timeText != null)
            timeText.text = "Time: " + Mathf.Round(timeRemaining);
    }
}
