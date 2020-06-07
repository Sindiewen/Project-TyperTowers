using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates towers at specified locations in the world based on what nodes exist in the world
/// At the moment, create tower in location where mouse presses for now
/// </summary>
public class TowerCreator : MonoBehaviour
{
    /// Variables
    #region Variables
    public List<TowerBase> towers;  // Towers to spawn in
    public int towerSpawnIndex;


    // public List<TowerSpawnNode> towerSpawnLocs; // Locations where to spawn in towers

    public bool spawnTowerMouseOverride = true;


    // Private variables
    private Vector2 mousePos;
    private TowerBase clone;    // Stores cloned object to spawn in


    #endregion

    #region private functions

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (spawnTowerMouseOverride && Input.GetKeyDown(KeyCode.Mouse0))
        {
            // TODO: check if tower is in legal place to spawn
            spawnTower();
        }
    }

    /// <summary> 
    /// Spawns a tower in by cloning and instantiating tower
    /// </summary>
    private void spawnTower()
    {
        Debug.Log("Spawn Tower: " + towers[towerSpawnIndex].name);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        clone = Instantiate(towers[towerSpawnIndex], new Vector3(mousePos.x, mousePos.y, 10), transform.rotation);
    }

    #endregion
}
