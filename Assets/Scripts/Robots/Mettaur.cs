using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mettaur : Robot
{
    float timer = 0;
    float RESTARTTIME = 3;
    Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    override public void Damage(float Damage, GameObject source)
    {
        health -= Damage;
        if (health < 0)
        {
            Destroy(source);
            LevelManager.instance.player.Health++;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > RESTARTTIME)
        {
            animator.Play("Mettaur", -1, 0f);
            timer = 0f;
        }
    }

}
