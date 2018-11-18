using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text finalScore;
    GameObject FScore;

    public void Awake()
    {
        if (GameObject.Find("GameObject"))
        {
            FScore = GameObject.Find("GameObject");
            EnterNewScoreTwo(Mathf.RoundToInt(FScore.GetComponent<Score>().score));
        }
    }

    private void Update()
    {
        if (GameObject.Find("GameObject"))
        {
            FScore = GameObject.Find("GameObject");
        }

        if (FScore)
        {
            finalScore.text = "Final Score: " + FScore.GetComponent<Score>().score;
        }
    }

    public void EnterNewScoreTwo(int newScore)
    {
        if (newScore >= ScoreManager.HighScore)
        {
            finalScore.text += "/n New High Score!!!";
            ScoreManager.HighScore = newScore;
            ScoreManager.SaveScore();
        }
    }
}
