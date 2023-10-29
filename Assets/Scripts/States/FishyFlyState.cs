using UnityEngine;

public class FishyFlyState : IState
{    

    public Rigidbody rb;
    private int speed = 20;

    public void EnterState()
    {
        
    }

    public void ExitState()
    {
        if (rb != null)
            rb.velocity = Vector3.zero;
    }

    
    public void Update()
    {
        if (rb != null)
            rb.velocity = Vector3.left * speed;
    }
}
