using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : Enemy
{
    public int damage = 20;
    public float jumpForce = 50f;
    Rigidbody rb;

    protected override void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        base.Start();
    }
    protected override void fire()
    {
        rb.AddForce(transform.forward.x * jumpForce, jumpForce, transform.forward.z * jumpForce);
        fireTimer = fireSpeed;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Player>().takeDamage(damage);
        }
    }
}
