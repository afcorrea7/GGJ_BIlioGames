using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] ChangeSceneManager changeSceneManager;
    void Stat(){
        audioSource = GetComponent<AudioSource>();
    }
    public void PlaySoundEffect(AudioClip clip){
        if(audioSource != null){
            audioSource.PlayOneShot(clip);
        }
    }

    public void TriggerCredits(string scene){
        if(changeSceneManager != null){
            changeSceneManager.SetSceneToLoad(scene);
        }
    }

}
