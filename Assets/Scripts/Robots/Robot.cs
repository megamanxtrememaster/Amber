using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Robot : MonoBehaviour, IDamageable, IDestroyable, ISpawnable
{

    public RobotConfiguration configuration;
    protected Rigidbody rb;
    protected float health;

    public float Health { get { return health; } set { health = value; } }

    public virtual void Damage(float Damage, GameObject source)
    {
       health -= Damage;
        if (health < 0)
            Destroy(source);
    }

    public void Destroy(GameObject source)
    {
        this.gameObject.SetActive(false);
    }
    
    public virtual void Spawn()
    {
        health = configuration.maxHealth;
        //throw new System.NotImplementedException();
    }
    
    public virtual void Start()
    {
         health = configuration.maxHealth;
         rb = GetComponent<Rigidbody>();
    }       
}
