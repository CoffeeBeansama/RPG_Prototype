using UnityEngine;

namespace Samurai
{
    public class Knockback : MonoBehaviour
    {
        [Range(0f,5f) ]public float KnockbackForce;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Enemies"))
            {
                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                

                if(enemy != null)
                {
                 
                    enemy.isKinematic = false; // disables Enemy's rigidbody kinematic property 
                    Vector2 difference = enemy.transform.position - transform.position;
                    difference = difference.normalized * KnockbackForce;
                    enemy.AddForce(difference, ForceMode2D.Impulse);
                    
                     
                    

                }
            }
        }


    }
}