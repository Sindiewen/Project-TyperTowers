using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attack tower base
/// Has multiple attributes that exist mainly to create towers to attack enemies.
///
/// - range type (cone, circle, ranged circle)
/// - Attack type (single, aoe, dot)
/// - Attack Fire Speed
/// </summary>

[RequireComponent(typeof(TowerBase))]
public class TowerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Fires Attack
    /// </summary>
    public void initiateFire()
    {
        Debug.Log("TowerAttack: Fires");
    }
}
