using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GolemAttackEvent : MonoBehaviour
{
   public UnityAction onGolemAttackSfx;
   public void TryGolemAttackLogicFromAnimation()
   {
      FindObjectOfType<GolemAttackState>().GolemAttackLogic();
   }

   public void GolemAttackSfx()
   {
      onGolemAttackSfx?.Invoke();
   }
}
