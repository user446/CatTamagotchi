using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerAction")]
public class PlayerActions : ScriptableObject
{
    /// <summary>
    /// List of behaviours which are allowed on this player action
    /// </summary>
    public List<CatBehaviour> triggerBehaviours;

    /// <summary>
    /// Select a behaviour using specific cat mood
    /// </summary>
    /// <param name="mood">Cat mood</param>
    /// <returns></returns>
    public CatBehaviour GetBehaviourByMood(CatMood mood)
    {
        return triggerBehaviours.Find(behaviour => behaviour.intialMood.Equals(mood));
    }
}
