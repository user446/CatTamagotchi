using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[CreateAssetMenu(menuName = "CatBehaviour")]
public class CatBehaviour : ScriptableObject
{
    [Tooltip("Description of a behaviour")]
    public string description;
    [Tooltip("Behaviour lifetime after what cat will switch on default behaviour")]
    public float lifeTime;
    [Tooltip("Audio clip which will be played when behaviour begins")]
    public AudioClip audio;
    [Tooltip("Animation which will be played during behaviour lifetime")]
    public AnimationClip playClip;
    [Tooltip("A mood to what cat will switch after this behaviour")]
    public CatMood triggerMood;
    [Tooltip("A mood based on what cat will play this behaviour")]
    public CatMood intialMood;
    [Tooltip("A behaviour state of a cat after playing this behaviour")]
    public CatBehaviour triggerBehaviour;
}
