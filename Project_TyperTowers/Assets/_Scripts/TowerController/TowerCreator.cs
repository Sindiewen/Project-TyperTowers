using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypingGameKit
{
    /// <summary>
    /// Creates towers at specified locations in the world based on what nodes exist in the world
    /// At the moment, create tower in location where mouse presses for now
    /// </summary>
    public class TowerCreator : MonoBehaviour
    {
        #region Variables




        [Header("Tower Creation Attributes")]
        [SerializeField] private GameObject towerHolder;    // Holds all of the towers in the scene
        [SerializeField] private List<TowerBase> towers;  // Towers to spawn into the scene
        [SerializeField] private int towerSpawnIndex;       // what tower to spawn in
        [SerializeField] private List<TowerSpawnNode> towerSpawnLocs; // Locations where to spawn in towers
        private TowerBase clone;    // Stores cloned tower object to spawn in

        [Space(10)]
        [Header("Typing Game Attributes")]
        [SerializeField] private SequenceManager sequenceManager;
        [SerializeField] private StringCollection nodeStringCollection;


        // Mouse stuff
        [Space(5)]
        [Header("Mouse Overrides")]
        [SerializeField] private bool spawnTowerMouseOverride = true;
        private Vector2 mousePos;


        #endregion

        #region private functions

        // Start is called before the first frame update
        private void Start()
        {
            // Get the tower nodes in scene
            if(towerHolder != null)
            {
                towerSpawnLocs.AddRange(towerHolder.GetComponentsInChildren<TowerSpawnNode>());
                
                // Assign each node to a sequence and ensure each node can spawn a tower
                for(int i = 0; i < towerSpawnLocs.Count; ++i)
                {
                    towerSpawnLocs[i].TowerSpawnReady = false;      // initally true, when false, the tower spawn is not ready because not it's awaiting input
                    towerSpawnLocs[i].HasTowerSpawned = false;      // If tower exists here already, in this case, no
                    createSequence_Node(towerSpawnLocs[i]);
                }
            }
        }

        // Update is called once per frame
        private void Update()
        {
            // If were using mouse control, only for debug purposes
            if (spawnTowerMouseOverride && Input.GetKeyDown(KeyCode.Mouse0))
            {
                // TODO: check if tower is in legal place to spawn
                spawnTower_Mouse();
            }

            // Create towers via text to node


            // Check if tower in node location is destroyed.
            for(int i = 0; i < towerSpawnLocs.Count; ++i)
            {
                // if destroyed, tower is ready to be spawned in and the tower doesnt exist here anymore.
                // When we get here, tower is set to not ready, now awaiting input
                if (towerSpawnLocs[i].TowerSpawnReady && !towerSpawnLocs[i].HasTowerSpawned)
                {
                    towerSpawnLocs[i].TowerSpawnReady = false;
                    towerSpawnLocs[i].HasTowerSpawned = false;
                    createSequence_Node(towerSpawnLocs[i]);
                }
            }
            
            
        }
        /// <Summary>
        /// Create sequences for each node in the scene
        /// </Summary>
        private void createSequence_Node(TowerSpawnNode anchor)
        {
            InputSequence sequence = sequenceManager.CreateSequence(getNewSequnceText(nodeStringCollection), anchor.transform);
            sequence.OnCompleted += delegate { 
                anchor.TowerSpawnReady = false;
                anchor.HasTowerSpawned = true;
                spawnTower(towerSpawnIndex, anchor);
            };
        }

        /// <Summary>
        /// Returns new string of text sequence by string collection passed in
        /// </Summary>
        private string getNewSequnceText(StringCollection collection)
        {
            return sequenceManager.GetUniquelyTargetableString(collection);
        }

        /// <Summary>
        /// Spawn a tower based on its spawn location passed in, and the current tower to spawn
        /// </Summary>
        private void spawnTower(int towerToSpawn, TowerSpawnNode spawnLoc)
        {
            Debug.Log("Spawning tower: " + towers[towerToSpawn].name);
            clone = Instantiate(towers[towerToSpawn], spawnLoc.transform.position, transform.rotation);
            clone.transform.parent = spawnLoc.transform;
        }


        /// <summary> 
        /// Spawns a tower in by cloning and instantiating tower - mouse version
        /// </summary>
        private void spawnTower_Mouse()
        {
            Debug.Log("Spawn Tower: " + towers[towerSpawnIndex].name);
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clone = Instantiate(towers[towerSpawnIndex], new Vector3(mousePos.x, mousePos.y, 10), transform.rotation);
        }

        #endregion
    }

}
