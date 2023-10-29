using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// State machine Manager for robot behaviors, the only robot that uses it in this prototype is Fishy
/// </summary
public class StateManager
{
    private IState currentState;    
        

    public void changeState(IState newState)
    {
        if(currentState != null)
            currentState.ExitState();
        
        currentState = newState;
        currentState.EnterState();
    }

    public void Update()
    {
        currentState.Update();
    }
}
