using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemIdleState : MonoBehaviour, IGolemBaseState
{
    [SerializeField] private GolemController gc; //potential problem, what if there is multiple bosses?
    [SerializeField] private GolemAttackState attackState;
    private void Start()
    {
        gc = FindObjectOfType<GolemController>();
    }

    public void Enter()
    {
        //make sure golem is playing idle animation
        
    }

    public void Exit()
    {
        
    }

    void IGolemBaseState.DoState()
    {
        //use player detect to see if player is there, if player is there, go to attack state
        if (gc.PlayerDetect.IsPlayerInCollider())
        {
            //change state to attack 
            gc.ChangeState(attackState);
        }
            
    }
}
