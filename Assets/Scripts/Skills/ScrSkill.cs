using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill")]
public class ScrSkill : ScriptableObject
{
    public string skillName;
    [TextArea]
    public string toolTip;
    public Sprite icon;
}
