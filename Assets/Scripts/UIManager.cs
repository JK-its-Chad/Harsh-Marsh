using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Player player;
    public Text health;
    public Text score;
    public Text arrows;

	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
	}
	
	void Update ()
    {
        health.text = "Health: " + player.health;
        score.text = "Score: " + player.score;
        arrows.text = "Arrows: " + player.bow.ammoAmount;
    }
}
