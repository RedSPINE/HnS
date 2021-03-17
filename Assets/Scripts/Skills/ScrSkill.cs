using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class ScrSkill : ScriptableObject
{
    public Sprite icon;
    public string skillName;
    [TextArea] public string toolTip;
    public AnimationClip animation;
    public float animationSpeed = 1;
    public float skillDuration = -1;

    public bool startupCancelWindow = false;
    [Range(0, 1)] public float startupCancelWindowStart = 0;
    [Range(0, 1)] public float startupCancelWindowEnd = 0;
    public bool recoveryCancelWindow = false;
    [Range(0, 1)] public float recoveryCancelWindowStart = 0;
    [Range(0, 1)] public float recoveryCancelWindowEnd = 0;

    // Implement the State Pattern
    public abstract void HandleInput();
    protected abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public virtual void Enter(PlayerController controller)
    {
        OnEnter(controller);
        controller.PlaySkillAnimation(animation, skillDuration, animationSpeed);
    }

    public virtual void SkillUpdate(PlayerController controller)
    {
        OnUpdate(controller);
    }

    public virtual void Quit(PlayerController controller)
    {
        return;
    }
}