using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// A golem state machine AI system, at first will be stationary but will be improved to be able to walk
/// </summary>
public class GolemController : MonoBehaviour
{
    public IGolemBaseState currentState;
    [SerializeField] private Health health; 
    public GolemIdleState golemIdleState;

    [SerializeField] private string DebugState;
    public PlayerDetect PlayerDetect { get; private set; }
    public GolemAnimation GolemAnimation { get; private set; }
    private bool golemDead = false;

    private void OnEnable()
    {
        PlayerDetect = GetComponentInChildren<PlayerDetect>();
        GolemAnimation = GetComponent<GolemAnimation>();
        currentState = golemIdleState;
        currentState.Enter();

        health.OnDie += DisableMovement;
    }

    // Update is called once per frame
    void Update()
    {
        if (golemDead) return;
        currentState.DoState();
        DebugState = currentState.ToString();
    }

    public void ChangeState(IGolemBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        
    }

    void DisableMovement()
    {
        Debug.Log("disabling movement ");
        GetComponent<NavMeshAgent>().isStopped = true;
        golemDead = true;
    }
    
}

public enum GolemStates
{
    Idle,
    GroundAttack,
    AirAttack,
    Death,
}
