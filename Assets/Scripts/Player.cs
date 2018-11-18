using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] GameObject model;
    public float score = 0;
    public int health = 100;
    public int speed = 10;
    public float invulnTime = 2.5f;

    float invulnTimer = 0f;
    int faceDirection = 0; //0=forward 1=45 2=right 3=135 4=back 5=225 6=left 7=315

    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        invulnTimer -= Time.deltaTime;

        Vector3 process = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        rig.AddForce(process * speed);

        CardinalFaceDir();
        OffSetFaceDir();

        rig.velocity = Vector3.zero;
    }

    void CardinalFaceDir()
    {
        if (Input.GetAxis("Vertical") > 0 && faceDirection != 0)
        {
            faceDirection = 0;
            model.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") > 0 && faceDirection != 2)
        {
            faceDirection = 2;
            model.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetAxis("Vertical") < 0 && faceDirection != 4)
        {
            faceDirection = 4;
            model.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetAxis("Horizontal") < 0 && faceDirection != 6)
        {
            faceDirection = 6;
            model.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }
    void OffSetFaceDir()
    {
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0 && faceDirection != 1)
        {
            faceDirection = 1;
            model.transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0 && faceDirection != 3)
        {
            faceDirection = 3;
            model.transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0 && faceDirection != 5)
        {
            faceDirection = 5;
            model.transform.rotation = Quaternion.Euler(0, 225, 0);
        }
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0 && faceDirection != 7)
        {
            faceDirection = 7;
            model.transform.rotation = Quaternion.Euler(0, 315, 0);
        }
    }

    public void takeDamage(int damage)
    {
        if(invulnTimer <= 0)
        {
            health -= damage;
            invulnTimer = invulnTime;

            if (health <= 0) die();
        }
    }

    void die()
    {
        Debug.Log("You're dead, act like it");
    }
}
