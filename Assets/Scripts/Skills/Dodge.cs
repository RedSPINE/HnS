using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "Dodge", menuName = "ScriptableObjects/Skills/Dodge")]
public class Dodge : ScrSkill
{
    public float cooldown;
    private float cooldownCounter;
    public float cancelWindow;
    public float invulnerabilityDuration;

    public float speed;
    public AnimationCurve displacement;
    private float internalCounter = 0;

    private Vector3 direction;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        var dist = displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime * 100;
        // Debug.Log("Dist:" + dist.ToString());
        controller.Move(direction.normalized * displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime);
        return;
    }

    protected override void OnEnter(PlayerController controller)
    {
        direction = controller.Direction;
        internalCounter = 0;
        controller.transform.rotation = Quaternion.LookRotation(direction);
        return;
    }
}
