using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Guillotine", menuName = "ScriptableObjects/Skills/Guillotine")]
public class Guillotine : SkillSO
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
