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
    public float speed;
    public float invulnerabilityDuration;

    private Vector3 direction;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate(PlayerController controller)
    {
        controller.Move(direction.normalized * speed * Time.deltaTime);
        return;
    }

    protected override void OnEnter(PlayerController controller)
    {
        direction = controller.Direction;
        return;
    }
}
