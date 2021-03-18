using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Respiration", menuName = "ScriptableObjects/Skills/Respiration")]
public class Respiration : ScrSkill
{
    private float internalCounter = 0;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnter(PlayerController controller)
    {
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        return;
    }
}
