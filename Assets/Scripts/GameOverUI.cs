using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text finalScore;
    GameObject FScore;
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
}
