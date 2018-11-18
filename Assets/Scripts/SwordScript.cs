using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

    public int damage = 25;
    public float swingSpeed = 150f;
    public Player player;
    bool swinging = false;
    float swingTimer = 0;
    GameObject[] children = new GameObject[3];

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
        if (Input.GetButton("Fire1") && !swinging)
        {
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
            swingTimer -= Time.deltaTime;
            transform.Rotate(0, swingSpeed * Time.deltaTime, 0);
            if (swingTimer <= 0)
            {
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
            Debug.Log("REEEEEEEEEEEEEEEEEEEEEEEEEE");
            Enemy E = (Enemy)other.gameObject.GetComponent<Enemy>();
            if(E)E.takeDamage(damage);

            if (other.gameObject.GetComponent<Rigidbody>())
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 400);
            }
        }
    }
}
