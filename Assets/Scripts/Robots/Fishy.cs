using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishy : Robot
{

    private FishyFlyState flyState;
    private StateManager stateM;

    public override void Start()
    {
        base.Start();
        flyState = new FishyFlyState();
        flyState.rb = rb;
        stateM = new StateManager();
        stateM.changeState(flyState);
    }

    void Update()
    {
        stateM.Update();
    }

    public override void Spawn()
    {
        health = configuration.maxHealth;
    }

    void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        if (layer == 6)//home
        {
            Destroy(this.gameObject);
            LevelManager.instance.TakeDamageHome(1f);
            LevelManager.instance.player.Health++;
        }
        if (layer == 7)//Tower
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Robot>().Damage(1f, this.gameObject);
        }
    }
}
