using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pursuit", menuName = "ScriptableObjects/Skills/Pursuit")]
public class Pursuit : ScrSkill
{
    public AnimationCurve displacement;
    private float internalCounter = 0;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnter(PlayerController controller)
    {
        internalCounter = 0;
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        controller.Move(direction.normalized * displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime);
        return;
    }
}
