using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public static Score singleton;
    Player player;

    void Awake()
    {
        if( singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }
    }

    public float score = 0;

	
	// Update is called once per frame
	void Update ()
    {
		if(player == null)
        {
            if(GameObject.Find("Player"))
            {
                player = GameObject.Find("Player").GetComponent<Player>();
            }
        }

        if(player)
        {
            score = player.score;
        }
	}
}
