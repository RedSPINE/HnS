using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dodge", menuName = "ScriptableObjects/Skills/Sword Slash")]
public class SwordSlash : ScrSkill
{
    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnUpdate(PlayerController controller)
    {
        
    }

    protected override void OnEnter(PlayerController controller)
    {
        controller.LookCursor();
        return;
    }
}
