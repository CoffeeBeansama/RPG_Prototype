using UnityEngine;

namespace Samurai
{
    [CreateAssetMenu(fileName = "ChestData")]
    public class ChestData : ScriptableObject
    {
        [Header("Chest Properties")]
        public GameObject[] Chests;
        public bool[] IsOpened;
        


        public AudioClip NormalChestItemAcquired;
        public AudioClip GoldChestItemAcquired;
    }

}

