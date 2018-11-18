using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 100;
    public int pointValue = 10;
    public float viewRange = 20f;
    public float moveSpeed = 10f;
    public float fireSpeed = 1f;
    public bool facePlayer = true;
    public bool followPlayer = true;
    public GameObject bullet;
    public GameObject firePoint;

    protected bool dead = false;
    protected float fireTimer = 2f;
    bool targetPlayer = false;
    protected GameObject Player;

	// Use this for initialization
	protected virtual void Start () {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= viewRange) targetPlayer = true; ;
        //if (Vector3.Distance(transform.position, Player.transform.position) >= 100) Destroy(gameObject);

        if(targetPlayer)
        {
            if(facePlayer) transform.LookAt(Player.transform);
            if (followPlayer) transform.position = transform.position + (transform.forward * moveSpeed / 100);
            if(fireTimer <= 0) fire();
        }
        fireTimer -= Time.deltaTime;
    }

    protected virtual void fire()
    {
        Instantiate(bullet, firePoint.transform.position, transform.rotation);
        fireTimer = fireSpeed;
    }

    public virtual void takeDamage(int TDamage)
    {
        health -= TDamage;
        if(health <= 0)
        {
            die();
        }
    }

    void die()
    {
        Player.GetComponent<Player>().score += pointValue;
        Destroy(gameObject);
    }
}
