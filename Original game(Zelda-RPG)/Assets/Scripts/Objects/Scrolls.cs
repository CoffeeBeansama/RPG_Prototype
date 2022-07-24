using UnityEngine;

namespace Samurai
{

    [CreateAssetMenu(fileName = "Scroll")]
    public class Scrolls : ScriptableObject
    {

        public string ScrollName;
        public Sprite ScrollSprite;
        public GameObject ScrollPrefab;
    
    }
}