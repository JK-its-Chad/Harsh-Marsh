using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public Text HighScoreDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
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
