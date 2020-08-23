using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerAction")]
public class PlayerActions : ScriptableObject
{
    public List<CatBehaviour> triggerBehaviours;

    public CatBehaviour GetBehaviourByMood(CatMood mood)
    {
        return triggerBehaviours.Find(behaviour => behaviour.intialMood.Equals(mood));
    }
}
