using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour {

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
        if (Input.GetButton("Fire1"))
        {
            transform.rotation = Quaternion.Euler(0, transform.position.y + -90, 0);
            foreach (GameObject gm in children)
            {
                gm.SetActive(true);
            }
            transform.Rotate(0, 10 * Time.deltaTime, 0);
        }
	}
}
