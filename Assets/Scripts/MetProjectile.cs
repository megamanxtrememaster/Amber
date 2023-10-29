using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetProjectile : Projectile
{
    Animator animator;    

    public override void Spawn()
    {
        animator.Play("MettaurProjectile", -1, 0f);
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();    
        
    }


    void Update()
    {
        rb.velocity = Vector3.left * 20f;
        //Debug.Log("moving forward");
    }

    void OnCollisionEnter(Collision collision)
    {
        
        int layer = collision.gameObject.layer;        
        if (layer == 6)//home
        {
            Destroy(this.gameObject);
            LevelManager.instance.TakeDamageHome(1f);
        }
        if(layer == 3)//Player
        {
            Destroy(this.gameObject);
            LevelManager.instance.player.Damage(1f, this.gameObject);
        }
        if(layer == 7)//Tower
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Robot>().Damage(1f, this.gameObject);
        }
    }
}
