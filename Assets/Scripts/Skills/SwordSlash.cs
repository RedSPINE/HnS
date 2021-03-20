using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SwordSlash", menuName = "ScriptableObjects/Skills/SwordSlash")]
public class SwordSlash : ScrSkill
{
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
        return;
    }
}
