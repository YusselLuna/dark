﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounds : MonoBehaviour
{
    
    private AudioSource source;
    public AudioClip[] clips;

    public float timeBetweenSoundEffect;
    private float nextSoundEffectTime;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
      
    }


    // Update is called once per frame
    void Update()
    {
         if(Time.time >= nextSoundEffectTime)
         {
            int randomNumber = Random.Range(0,clips.Length);
            source.clip = clips[randomNumber];
            source.Play();
            nextSoundEffectTime = Time.time + timeBetweenSoundEffect;
         }
       
    }
}
