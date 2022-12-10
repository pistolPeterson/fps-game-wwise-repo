using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemChaseState : MonoBehaviour, IGolemBaseState
{
    [SerializeField] private GolemController gc;
    [SerializeField] private Transform playerLocation;
    [SerializeField] private GolemAttackState attackState;
    public NavMeshAgent NavMeshAgent { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GolemController>();
        NavMeshAgent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoState()
    {
        //walk towards player and orient towards player  
        NavMeshAgent.SetDestination(playerLocation.transform.position);

        //if close to a certain distance, go to attack state 
        if (gc.PlayerDetect.IsPlayerInCollider())
        {
            gc.ChangeState(attackState);
        }

    }

    public void Enter()
    {
        gc.GolemAnimation.OnChase();
    }

    public void Exit()
    {
        NavMeshAgent.SetDestination(transform.position);
    }
}
