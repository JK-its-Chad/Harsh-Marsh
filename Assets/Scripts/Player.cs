using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float score = 0;
    public int health = 100;

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y, transform.position.z + Input.GetAxis("Vertical"));
        }
    }
}
