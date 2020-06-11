using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TypingGameKit
{
    public class EnemyCreator : MonoBehaviour
    {


        #region Variables


        [Header("Typing Game Attributes")]
        [SerializeField] private typerSegmentManager typerSegmentManager;
        [SerializeField] private StringCollection rusherStringCollection;

        #endregion



        /// <Summary>
        /// </Summary>
        private void createSequence_Enemy(EnemyBase anchor)
        {
            InputSequence sequence = typerSegmentManager.createNewSequence(rusherStringCollection, anchor.transform);
            sequence.OnCompleted += delegate{
                // Destroy enemy
            };
        }

        /// <Suummary>
        /// </Summary>
        private void SpawnEnemy()
        {
            Debug.Log("Spawning enemy");
            // Create enemy sequence
        }
    }
}

