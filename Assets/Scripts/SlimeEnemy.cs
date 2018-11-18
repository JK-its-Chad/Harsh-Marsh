﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : Enemy {

    public GameObject target;
    bool grounded = true;
    public GameObject tail;
    public int damage = 5;
    public Material deadRed;

    public float jumpHeight = 100;
    public int movementSpeed = 10;
    public int lookSpeed = 2;
    public int slimeValue = 10;

    private float ITimer = 0.75f;

    Rigidbody rig;

	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        base.Start();
	}

	void FixedUpdate ()
    {

        if (!dead)
        {
            if (gameObject.GetComponent<Rigidbody>().velocity.y <= 0.01f && gameObject.GetComponent<Rigidbody>().velocity.y >= -0.01f)
            {
                grounded = true;
            }

            if (grounded)
            {
                Quaternion playerRotation = Quaternion.LookRotation(
                            (new Vector3(target.transform.position.x, 0, target.transform.position.z))
                            - (new Vector3(transform.position.x, 0, transform.position.z)));

                gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, playerRotation, lookSpeed);

                if (playerRotation == transform.rotation)
                {
                    rig.AddForce(transform.forward.x * movementSpeed, jumpHeight, transform.forward.z * movementSpeed);
                    grounded = false;
                }

            }
        }
        if(dead)
        {
            Destroy(gameObject);
        }
        
    }

    private void Update() //for timer logic
    {
        ITimer -= Time.deltaTime;
    }

    public override void takeDamage(int damage)
    {
        if (ITimer <= 0 && !dead)
        {
            health -= damage;
            ITimer = 0.75f;
            if (health <= 0) Die();
        }
    }

    private void Die()
    {
        Player.GetComponent<Player>().score += pointValue;
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().takeDamage(damage);
        }
    }
}
