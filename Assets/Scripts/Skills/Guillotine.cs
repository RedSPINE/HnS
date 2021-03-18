using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guillotine", menuName = "ScriptableObjects/Skills/Guillotine")]
public class Guillotine : ScrSkill
{
    private float internalCounter = 0;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnter(PlayerController controller)
    {
        var direction = controller.CursorWorldPosition;
        internalCounter = 0;
        controller.transform.rotation = Quaternion.LookRotation(direction);
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        return;
    }
}
