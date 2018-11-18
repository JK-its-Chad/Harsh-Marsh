using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobScript : MonoBehaviour {

    Vector3 baseSpot;
    float delay = 0;
    float delayTimer = 0;
    int speed = 0;

	// Use this for initialization
	void Start ()
    {
        baseSpot = transform.position;
        delayTimer = Random.Range(2, 7);
	}
	
	// Update is called once per frame
	void Update ()
    {
        delay -= Time.deltaTime;
		if(delay <= 0)
        {
            delay = delayTimer;
            if(speed == 0)
            {
                speed = -2;
            }
            speed *= -1;
        }
        if(transform.position.y > baseSpot.y + .25f)
        {
            speed *= -1;
        }
        if (transform.position.y < baseSpot.y - .25f)
        {
            speed *= -1;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
