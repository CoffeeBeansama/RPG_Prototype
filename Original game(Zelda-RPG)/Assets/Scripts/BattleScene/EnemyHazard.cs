using UnityEngine;

namespace Samurai
{


public class EnemyHazard : MonoBehaviour
{
    public int Damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           other.GetComponent<SlimeHP>().PlayerHP -= Damage;
        }
    }
}
}