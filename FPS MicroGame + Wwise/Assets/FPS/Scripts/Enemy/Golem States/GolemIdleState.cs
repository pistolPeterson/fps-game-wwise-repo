using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemIdleState : MonoBehaviour, IGolemBaseState
{
    [SerializeField] private GolemController gc; //potential problem, what if there is multiple bosses?
    [SerializeField] private GolemAttackState attackState;
    [SerializeField] private GolemChaseState chaseState;

    [SerializeField] private float idleDuration = 1.25f;
    
    private float timer = 0; 
    private void Start()
    {
        gc = FindObjectOfType<GolemController>();
    }

    public void Enter()
    {
        //make sure golem is playing idle animation
        timer = 0; 
    }

    public void Exit()
    {
        
    }

    void IGolemBaseState.DoState()
    {
        timer += Time.deltaTime; 
        //use player detect to see if player is there, if player is there, go to attack state
        if (gc.PlayerDetect.IsPlayerInCollider())
        {
            gc.ChangeState(attackState);
        }

        if (timer > idleDuration)
        {
            gc.ChangeState(chaseState);
        }
            
    }
}
