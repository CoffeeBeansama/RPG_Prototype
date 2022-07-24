using UnityEngine;

namespace Samurai
{
    [CreateAssetMenu(fileName = "EnemyData")]
    public class EnemyData : ScriptableObject
    {
     
        public Enemies[] Enemies;
  
    }
    public enum EnemyState
    {
        Idle,
        Chase,
        Hurt,
        Attack,
        BackToOriginalPosition,
        Die,

    }




 

}




