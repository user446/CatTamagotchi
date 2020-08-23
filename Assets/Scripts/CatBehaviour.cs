using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[CreateAssetMenu(menuName = "CatBehaviour")]
public class CatBehaviour : ScriptableObject
{
    public string description;
    public float lifeTime;
    public AudioClip audio;
    public AnimationClip playClip;
    public CatMood triggerMood;
    public CatMood intialMood;
    public CatBehaviour triggerBehaviour;
}
