using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float viewRange = 20f;

    bool targetPlayer = false;
    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) >= viewRange) targetPlayer = true; ;
        if (Vector3.Distance(transform.position, Player.transform.position) >= 100) Destroy(gameObject);

        if(targetPlayer)
        {
            transform.LookAt(Player.transform);
        }
    }
}
