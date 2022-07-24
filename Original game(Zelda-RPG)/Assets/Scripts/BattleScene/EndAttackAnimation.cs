using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Samurai

{
public class EndAttackAnimation : MonoBehaviour
{
   public bool EndofAttack;
   
   
   public void finAttack()
   {
       EndofAttack = true;
   }
}
}