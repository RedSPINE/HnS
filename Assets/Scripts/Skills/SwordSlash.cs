﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dodge", menuName = "ScriptableObjects/Skills/SwordSlash")]
public class SwordSlash : ScrSkill
{
    public AnimationCurve displacement;
    private float internalCounter = 0;
    private Vector3 direction;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnter(PlayerController controller)
    {
        direction = controller.CursorWorldPosition;
        internalCounter = 0;
        controller.transform.rotation = Quaternion.LookRotation(direction);
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        controller.Move(direction.normalized * displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime);
        return;
    }
}
