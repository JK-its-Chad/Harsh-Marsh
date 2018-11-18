using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour {

    float fireRate = 0.75f;
    float fireTimer = 0f;

    float ammoCharge = 2f;
    float ammoTimer = 0f;
    public int ammoAmount = 30;

    [SerializeField] GameObject arrow;
    [SerializeField] Transform arrowOut;
    GameObject[] children = new GameObject[2];

    // Use this for initialization
    void Start ()
    {
        int i = 0;
        foreach (MeshRenderer t in GetComponentsInChildren<MeshRenderer>())
        {
            children[i] = t.gameObject;
            children[i].SetActive(false);
            i++;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        fireTimer -= Time.deltaTime;
        ammoTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            foreach (GameObject gm in children)
            {
                gm.SetActive(false);
            }
        }

        if (Input.GetButton("Fire2") && fireTimer <= 0 && ammoAmount > 0)
        {
            ammoAmount--;
            fireTimer = fireRate;
            foreach (GameObject gm in children)
            {
                gm.SetActive(true);
            }
            Instantiate(arrow, arrowOut.position, transform.rotation);
            ammoTimer = ammoCharge;
        }

        if(ammoTimer <= 0 && ammoAmount < 30)
        {
            ammoTimer = ammoCharge;
            ammoAmount++;
        }
	}
}
