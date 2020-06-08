using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score => score;

    [SerializeField] private TMP_Text scoreText = null;
    [SerializeField] private TMP_Text highscoreText = null;

    private int score = 0;

    private void Awake()
    {
        score = 0;
        scoreText.text = score.ToString();
        highscoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    
}