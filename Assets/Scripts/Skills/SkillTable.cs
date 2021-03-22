using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillTable", menuName = "ScriptableObjects/SkillTable")]
public class SkillTable : ScriptableObject
{
    public List<SkillSO> skills;
}
