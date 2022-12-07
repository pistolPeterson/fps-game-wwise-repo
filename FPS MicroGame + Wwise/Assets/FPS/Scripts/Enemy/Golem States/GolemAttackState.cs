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
        //make sure golem is playing idle animation
        FindObjectOfType<GolemAnimation>().OnAttack();
    }

    public void Exit()
    {
        
    }

    void IGolemBaseState.DoState()
    {
        //go right back to idle state
        gc.ChangeState(idleState);
            
    }
}
