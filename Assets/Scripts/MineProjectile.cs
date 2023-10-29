using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProjectile : Projectile
{
    Animator animator;
    State state;
    private float IDLETIME = 3;
    private float EXPLODETIME = 1.3f;
    private float timer = 0f;

    enum State
    {
        IDLE,
        EXPLODE
    }

    public override void Spawn()
    {
        animator.Play("Mine", -1, 0f);
        animator.speed = 0;
        state = State.IDLE;
        timer = 0f;
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        //animator.speed = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {        
        int layer = collision.gameObject.layer;

        Debug.Log(layer);
        if (layer == 3)//player
        {            
            LevelManager.instance.player.Damage(1f, this.gameObject);
            ActivateMine();
        }
        if (layer == 7)//Tower
        {
            collision.gameObject.GetComponent<Robot>().Damage(1f, this.gameObject);
            ActivateMine();
        }
    }

    private void ActivateMine()
    {
        if (state != State.EXPLODE)
        {
            state = State.EXPLODE;
            timer = 0f;
            animator.speed = 1;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        switch (state)
        {
            case State.IDLE:
                
                if (timer > IDLETIME)
                {
                    ActivateMine();
                }
                break;
            case State.EXPLODE:
                if (timer > EXPLODETIME)
                {
                    Destroy(this.gameObject);
                }                
                break;
        }
    }
}
