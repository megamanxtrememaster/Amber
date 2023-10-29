using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : Projectile
{


    float lifeTimer = 0;
    float LIFETIME = 4;
    public override void Spawn()
    {
        //rb = GetComponent<Rigidbody>();
        lifeTimer = 0;
        //rb.AddRelativeForce(Vector3.right * 120);
    }
    Collider collider;

    // Update is called once per frame
    void Update()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= LIFETIME)
        {
            Destroy(this.gameObject);
        }
        rb.velocity = Vector3.right * 120f;
        collider = GetComponent<Collider>();
    }


    void OnTriggerEnter(Collider collider)
    {
        
        int layer = collider.gameObject.layer;
        if (layer == 11)//Ground Enemies
        {
            Robot r = collider.gameObject.GetComponent<Robot>();
            if (r != null)
            {
                collider.gameObject.GetComponent<Robot>().Damage(1f, this.gameObject);
                this.Destroy(this.gameObject);
            }
        }
        if (layer == 10)//Flying Enemies
        {
            Robot r = collider.gameObject.GetComponent<Robot>();
            if (r != null)
            {
                collider.gameObject.GetComponent<Robot>().Damage(1f, this.gameObject);
                this.Destroy(this.gameObject);
            }
        }
    }
}
