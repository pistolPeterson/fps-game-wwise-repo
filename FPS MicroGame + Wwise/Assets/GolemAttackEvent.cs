using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttackEvent : MonoBehaviour
{
   public void TryGolemAttackLogicFromAnimation()
   {
      FindObjectOfType<GolemAttackState>().GolemAttackLogic();
   }
}
