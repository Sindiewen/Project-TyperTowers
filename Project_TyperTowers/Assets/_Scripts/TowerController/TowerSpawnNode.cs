using UnityEngine;

///<Summary>
/// Checks values related to spawning a tower in this location
///</Summary>
public class TowerSpawnNode : MonoBehaviour 
{
    [SerializeField] private bool towerSpawnReady = true;
    [SerializeField] private bool hasTowerSpawned = false;
    public bool TowerSpawnReady 
    {
        get { return towerSpawnReady; }
        set { towerSpawnReady = value; }
    }
    
    public bool HasTowerSpawned
    {
        get { return hasTowerSpawned; } 
        set { hasTowerSpawned = value; }
    }

}