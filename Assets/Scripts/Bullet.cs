using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody rb;
    public float lifeTime = 5f;
	// Use this for initialization
	void Start ()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.forward * 10;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(gameObject);
	}
}
