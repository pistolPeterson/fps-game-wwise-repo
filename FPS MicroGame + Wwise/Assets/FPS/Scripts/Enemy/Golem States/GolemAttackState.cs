using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GolemAttackState : MonoBehaviour, IGolemBaseState
{
    [SerializeField] private GolemController gc; //potential problem, what if there is multiple bosses?
    [SerializeField] private GolemIdleState idleState;
    private void Start()
    {
        gc = FindObjectOfType<GolemController>();
    }

    public void Enter()
    {
        gc.GolemAnimation.OnAttack();
    }

    public void Exit()
    {
        
    }

    void IGolemBaseState.DoState()
    {
        //go right back to idle state
        if (gc.PlayerDetect.IsPlayerInCollider())
        {
            //continue
            //some sort of timer system, where you attack every x amount of sec
        }
        else
        {
            gc.ChangeState(idleState);

        }
            
    }
}
