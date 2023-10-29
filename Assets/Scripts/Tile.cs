using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TileState
{
    STANDARD,
    CRACKED,
    DESTROYED
}


/// <summary>
/// Tile class with 3 states, regular, destroyed and cracked
/// In this prototype they are all standard, in future versions we plan to add support for the other states
/// </summary
public class Tile : MonoBehaviour, IDestroyable, IDamageable
{

    private TileState state = TileState.STANDARD;

    public void Damage(float amount, GameObject source)
    {
        switch(state)
        {
            case TileState.STANDARD:
                state = TileState.CRACKED;
                break;
            case TileState.CRACKED:
                state = TileState.DESTROYED;
                break;
            case TileState.DESTROYED:
                break;
            
         }
    }

    public void Destroy(GameObject source)
    {
        state = TileState.DESTROYED;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
