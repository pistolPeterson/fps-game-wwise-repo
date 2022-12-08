using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GolemAttackState : MonoBehaviour, IGolemBaseState
{
    [SerializeField] private GolemController gc; //potential problem, what if there is multiple bosses?
    [SerializeField] private GolemIdleState idleState;

    [SerializeField] private bool hasGolemAttacked = false; 
    
    [Header("Attack box area for golem smash attack")] 
    [SerializeField] private Transform smashAttackCenter;

    [SerializeField] private LayerMask playerLayer;//assumption for now, is that golem can only attack player, will probs be refactored to be able to attack ally robots as well
    private void Start()
    {
        gc = FindObjectOfType<GolemController>();
    }

    public void Enter()
    {
        gc.GolemAnimation.OnAttack();
        hasGolemAttacked = false;
    }

    public void Exit()
    {
        hasGolemAttacked = false;
    }

     void IGolemBaseState.DoState()
    {
        
        if (!hasGolemAttacked)
        {
            Debug.Log("callin golem attack logic");
            GolemAttackLogic();
            hasGolemAttacked = true;
        }
        Debug.Log("before if statement ");
        //go right back to idle state
        if (gc.PlayerDetect.IsPlayerInCollider() == true)
        {
            Debug.Log("stayin in attack");
            //continue
            //some sort of timer system, where you attack every x amount of sec
        }
        else
        {
            Debug.Log("going to idle state");
            gc.ChangeState(idleState);

        }
            
    }

     private void GolemAttackLogic()
     {
         //transform.localScale / 2 is half the size of the scale of the gameobject 
         Collider[] hitColliders = Physics.OverlapBox(smashAttackCenter.position, transform.localScale * 3, Quaternion.identity, playerLayer);
         int i = 0;
         //Check when there is a new collider coming into contact with the box
         while (i < hitColliders.Length)
         {
             if (hitColliders[i].gameObject.CompareTag("Player"))
             {
                 Debug.Log("found the player bro");
                 //go to health componenet, and remove health 
                 //refactor everything to only work when animation palys at specific point
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
             Gizmos.DrawWireCube(smashAttackCenter.position, transform.localScale * 3);
     }
}
