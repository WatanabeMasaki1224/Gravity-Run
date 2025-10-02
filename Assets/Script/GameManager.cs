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
            score += 1;
            UpdateScoreUI();
        }
    }

    void UpdateScoreUI()
    {
      if(scoreText != null)
        {
            scoreText.text = "Score:" + score.ToString();
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
        Time.timeScale = 0; // àÍéûí‚é~
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // åªç›ÇÃÉVÅ[ÉìÇçƒì«Ç›çûÇ›
    }

}
