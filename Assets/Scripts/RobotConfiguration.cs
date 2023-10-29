using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject for Robots, in this prototype we do not use the maxSpeed attribute
/// </summary
[CreateAssetMenu(fileName = "RobotConfiguration.asset", menuName = "TowerDefense/Robot Configuration", order = 1)]
public class RobotConfiguration : ScriptableObject
{        
    public float maxHealth;
    public float maxSpeed;
}
