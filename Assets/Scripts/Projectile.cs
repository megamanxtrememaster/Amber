using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour, ISpawnable, IDestroyable
{
    protected Rigidbody rb;

    public void Destroy(GameObject source)
    {
        this.gameObject.SetActive(false);
    }

    public abstract void Spawn();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
