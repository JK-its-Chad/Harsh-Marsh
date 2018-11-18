using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text HighScoreDisplay;

    public void Awake()
    {
        if (ScoreManager.LoadScore())
        {
            HighScoreDisplay.text = "High Score: " + ScoreManager.HighScore;
        }
    }

    public void ResetHighScores()
    {
        ScoreManager.HighScore = 0;
        ScoreManager.SaveScore();
        if (ScoreManager.LoadScore())
        {
            HighScoreDisplay.text = "High Score: " + ScoreManager.HighScore;
        }
    }

    public void EnterNewScore(int newScore)
    {
        if(newScore >= ScoreManager.HighScore)
        {
            ScoreManager.HighScore = newScore;
            ScoreManager.SaveScore();
            if (ScoreManager.LoadScore())
            {
                HighScoreDisplay.text = "High Score: " + ScoreManager.HighScore;
            }
        }
    }

    public void IncrementPress()
    {
        ScoreManager.HighScore++;
        ScoreManager.SaveScore();
        if (ScoreManager.LoadScore())
        {
            HighScoreDisplay.text = "High Score: " + ScoreManager.HighScore;
        }
    }

    public void DecrementPress()
    {
        ScoreManager.HighScore--;
        ScoreManager.SaveScore();
        if (ScoreManager.LoadScore())
        {
            HighScoreDisplay.text = "High Score: " + ScoreManager.HighScore;
        }
    }
}
