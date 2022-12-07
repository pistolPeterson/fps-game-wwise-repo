using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A simple script that can check if player is inside the collider, this object must have a collider with is trigger on.
/// </summary>
public class PlayerDetect : MonoBehaviour
{

    private bool playerIsIn = false; 
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return; //if not player, exit out 
        playerIsIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return; 
        playerIsIn = false;

    }

    public bool IsPlayerInCollider()
    {
        return playerIsIn;
    }
}
