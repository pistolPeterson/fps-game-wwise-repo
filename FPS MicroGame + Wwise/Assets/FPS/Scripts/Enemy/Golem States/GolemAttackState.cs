using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.FPS.Game;
using UnityEngine;

public class GolemAttackState : MonoBehaviour, IGolemBaseState
{
    [SerializeField] private GolemController gc; //potential problem, what if there is multiple bosses?
    [SerializeField] private GolemIdleState idleState;

    [SerializeField] private float golemAttackDamage = 10f;
    [SerializeField] private float attackPace = 2f; 
    [Header("Attack box area for golem smash attack")] 
    [SerializeField] private Transform smashAttackCenter;

    [SerializeField] private float attackRadiusSize = 5f;
    [SerializeField] private LayerMask playerLayer;//assumption for now, is that golem can only attack player, will probs be refactored to be able to attack ally robots as well
    private float timer = 0.0f;
    private void Start()
    {
        attackPace = 1 / attackPace; //inverting, so its easier to understand for game design
        gc = FindObjectOfType<GolemController>();
    }

    public void Enter()
    {
        timer = 0; 
        gc.GolemAnimation.OnAttack(); //this starts the animatino that plays with an Event  'GolemAttackLogic' 
    }

    public void Exit()
    {
    }

     void IGolemBaseState.DoState()
     {
         timer += Time.deltaTime; 
       
        //go right back to idle state
        if (gc.PlayerDetect.IsPlayerInCollider() == true)
        {
            Debug.Log("stayin in attack");
            
            //some sort of timer system, where you attack every x amount of sec
            if (timer > attackPace)
            {
                gc.GolemAnimation.OnAttack();
                timer = 0;
            }
        }
        else
        {
            Debug.Log("going to idle state");
            gc.ChangeState(idleState);

        }
            
    }

     public void GolemAttackLogic()
     {
         if ((GolemAttackState)gc.currentState != this) return;
         
         //transform.localScale / 2 is half the size of the scale of the gameobject 
         Collider[] hitColliders = Physics.OverlapBox(smashAttackCenter.position, transform.localScale * attackRadiusSize, Quaternion.identity, playerLayer);
         int i = 0;
         //Check when there is a new collider coming into contact with the box
         while (i < hitColliders.Length)
         {
             if (hitColliders[i].gameObject.CompareTag("Player"))
             {
                 Debug.Log("found the player bro");
                 //go to health componenet, and remove health 
                 var playerHealth = hitColliders[i].gameObject.GetComponent<Health>();
                 if (!playerHealth) return;
                 playerHealth.TakeDamage(golemAttackDamage, null);
             }
             //Increase the number of Colliders in the array
             i++;

            
         }
     }
     
     void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        
             //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
             Gizmos.DrawWireCube(smashAttackCenter.position, transform.localScale * attackRadiusSize);
     }
}
