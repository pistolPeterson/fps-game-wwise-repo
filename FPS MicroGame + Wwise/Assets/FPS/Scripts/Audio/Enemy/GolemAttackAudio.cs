using System.Collections;
using System.Collections.Generic;
using GameAudioScriptingEssentials;
using UnityEngine;

public class GolemAttackAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private GolemAttackEvent gae;
    
    // Start is called before the first frame update
    void Start()
    {
        gae = FindObjectOfType<GolemAttackEvent>();
        gae.onGolemAttackSfx += PlayGolemAttackSfx;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGolemAttackSfx()
    {
        GetComponent<AudioClipRandomizer>().PlaySFX();
    }
}
