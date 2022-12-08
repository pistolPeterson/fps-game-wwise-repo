using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A golem state machine AI system, at first will be stationary but will be improved to be able to walk
/// </summary>
public class GolemController : MonoBehaviour
{
    private IGolemBaseState currentState;

    public GolemIdleState golemIdleState;

    [SerializeField] private string DebugState;
    public PlayerDetect PlayerDetect { get; private set; }
    public GolemAnimation GolemAnimation { get; private set; }

    private void OnEnable()
    {
        PlayerDetect = GetComponentInChildren<PlayerDetect>();
        GolemAnimation = GetComponent<GolemAnimation>();
        currentState = golemIdleState;
        currentState.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.DoState();
        DebugState = currentState.ToString();
    }

    public void ChangeState(IGolemBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
        
    }
    
}

public enum GolemStates
{
    Idle,
    GroundAttack,
    AirAttack,
    Death,
}
