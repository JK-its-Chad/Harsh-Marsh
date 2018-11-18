using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public int damage = 25;
    public int speed = 25;

    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy E = (Enemy)other.gameObject.GetComponent<Enemy>();
            if (E) E.takeDamage(damage);

            if (other.gameObject.GetComponent<Rigidbody>())
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
            }
        }
        if (other.gameObject.tag != "Player")
        {
            Destroy(gameObject, .15f);
        }
    }
}
