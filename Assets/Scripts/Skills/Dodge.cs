using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Dodge", menuName = "ScriptableObjects/Dodge")]
public class Dodge : SkillSO
{
    public float invulnerabilityDuration;

    public override void HandleInput()
    {
        return;
    }

    protected override void OnEnter(PlayerController controller)
    {
        direction = controller.Direction;
        controller.transform.rotation = Quaternion.LookRotation(direction);
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        return;
    }
}
