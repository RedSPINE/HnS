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

    public int frameCount;
    public int startupCancelWindowStart = 0;
    public int startupCancelWindowEnd = 0;
    public int recoveryCancelWindowStart = 0;
    public int recoveryCancelWindowEnd = 0;

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

    public bool isCancelable(float normalizedTime)
    {
        return false;
    }
}