using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
/// <summary>
/// Animation class for the golem enemy. Attempting to use event systems to drive the animations 
/// </summary>
public class GolemAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Health health; 
    
    private const string attackParameter = "Attack"; 
    private const string deathParameter = "Death"; 
    private void Start()
    {
        animator = GetComponent<Animator>();
        DebugUtility.HandleErrorIfNullGetComponent<Animator, GolemAnimation>(animator, this, gameObject);

        health = GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, GolemAnimation>(health, this, gameObject);

        health.OnDie += OnDeath;

    }

   


    private void OnAttack()
    {
        animator.SetTrigger(attackParameter);
    }
    
    private void OnDeath()
    {
        animator.SetTrigger(deathParameter);
    }
}
