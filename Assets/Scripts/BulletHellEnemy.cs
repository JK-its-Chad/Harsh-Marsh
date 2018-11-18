using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHellEnemy : Enemy {

    public float spinSpeed = 4f;
    public bool spinBackwards = false;

    protected override void Update()
    {
        if(spinBackwards) transform.Rotate(Vector3.up * -spinSpeed);
        else transform.Rotate(Vector3.up * spinSpeed);
        base.Update();
    }
}
