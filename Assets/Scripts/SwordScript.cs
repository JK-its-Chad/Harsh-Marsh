using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    public int damage = 25;
    public float swingSpeed = 150f;
    public Player player;
    bool swinging = false;
    float fireRate = 0.2f;
    float fireTimer = 0f;
    float swingTimer = 0;
    GameObject[] children = new GameObject[4];

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
	
	void Update ()
    {
        fireTimer -= Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && !swinging && fireTimer <= 0)
        {
            fireTimer = fireRate;
            swinging = true;
            foreach (GameObject gm in children)
            {
                gm.SetActive(true);
            }
            transform.rotation = Quaternion.Euler(0, (player.faceDirection * 45) - 100, 0);
            swingTimer = 0.3f;
        }
        if(swinging)
        {
            GetComponent<BoxCollider>().enabled = true;
            swingTimer -= Time.deltaTime;
            transform.Rotate(0, swingSpeed * Time.deltaTime, 0);
            if (swingTimer <= 0)
            {
                GetComponent<BoxCollider>().enabled = false;
                swinging = false;
                foreach (GameObject gm in children)
                {
                    gm.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && swinging)
        {
            Enemy E = (Enemy)other.gameObject.GetComponent<Enemy>();
            if(E)E.takeDamage(damage);

            if (other.gameObject.GetComponent<Rigidbody>())
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 400);
            }
        }
    }
}
