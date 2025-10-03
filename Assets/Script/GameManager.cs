using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    public Text scoreText;
    public GameObject gameOverUI;
    private bool isGameOver = false;
    private float timer = 0;
    public GameObject retryButton;
    public Text resultScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
        UpdateScoreUI();
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                score += 1;
                timer = 0f;
                UpdateScoreUI();
            }
          
        }
    }

    void UpdateScoreUI()
    {
        Debug.Log("UpdateScoreUI called, score: " + score);
        if (scoreText != null)
        {
            scoreText.text = "Score:" + score.ToString();
        }
        else
        {
            Debug.Log("a");
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0; // 一時停止
        gameOverUI.SetActive(true);
        resultScore.gameObject.SetActive(true); // スコア表示
        resultScore.text = "Score: " + score.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 現在のシーンを再読み込み
    }

  
}
