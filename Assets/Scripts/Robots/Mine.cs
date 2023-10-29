using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine: Robot {

    override public void Damage(float Damage, GameObject source)
    {
        health -= Damage;
        if (health < 0)
        {
            Destroy(source);
            LevelManager.instance.player.Health++;
        }
    }
}
