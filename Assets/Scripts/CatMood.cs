using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CatMood")]
public class CatMood : ScriptableObject
{
    [Tooltip("Description of a mood")]
    public string description;
}
