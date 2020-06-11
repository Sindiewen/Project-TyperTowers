using UnityEngine;

namespace TypingGameKit
{
    public class typerSegmentManager : MonoBehaviour
    {
        #region Variables

        [Header("Typing Game Attributes")]
        [SerializeField] private SequenceManager sequenceManager;

        #endregion


        #region Typing Methods

        /// <Summary>
        /// Creates, and returns new text sequence
        /// </Summary>
        public InputSequence createNewSequence(StringCollection newCollection, TowerSpawnNode anchor)
        {
            return sequenceManager.CreateSequence(sequenceManager.GetUniquelyTargetableString(newCollection), anchor.transform);
        }

        #endregion
    }
}


