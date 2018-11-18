using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : Enemy
{
    int i = 0;

    protected override void Update()
    {
        firePoint.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z));
        base.Update();
    }
    protected override void fire()
    {
        if (i < 5)
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            fireTimer = 0.2f;
            i++;
        }
        else
        {
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            fireTimer = fireSpeed;
            i = 0;
        }
        
    }

}
