using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellEnemy : Enemy {

    protected override void Start()
    {
        fireSpeed = 0.01f;
        base.Start();
    }

    protected override void Update()
    {
        transform.Rotate(Vector3.up * 4);
        base.Update();
    }

    protected override void fire()
    {
        base.fire();
    }
}
