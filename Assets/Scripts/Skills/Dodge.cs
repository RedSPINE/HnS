using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Dodge", menuName = "ScriptableObjects/Dodge")]
public class Dodge : ScrSkill
{
    public float cooldown;
    private float cooldownCounter;
    public float invulnerabilityDuration;
    public AnimationCurve displacement;
    private float internalCounter = 0;

    public override void HandleInput()
    {
        return;
    }

    protected override void OnEnter(PlayerController controller)
    {
        direction = controller.Direction;
        Debug.Log("Direction: " + direction.ToString());
        internalCounter = 0;
        controller.transform.rotation = Quaternion.LookRotation(direction);
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        var dist = displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime * 100;
        // Debug.Log("Dist:" + dist.ToString());
        controller.Move(direction.normalized * displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime);
        return;
    }
}
