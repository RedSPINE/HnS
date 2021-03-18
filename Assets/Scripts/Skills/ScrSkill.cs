using System;
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
    [HideInInspector] public float skillDuration = -1;
    
    [SerializeField] protected bool lookCursor = true;
    [HideInInspector] protected Vector3 direction;

    [SerializeField] protected int startupCancelWindowStart = 0;
    [SerializeField] protected int startupCancelWindowEnd = 0;
    [SerializeField] protected int recoveryCancelWindowStart = 0;
    [SerializeField] protected int recoveryCancelWindowEnd = 0;

    // Implement the State Pattern
    public abstract void HandleInput();
    protected abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public virtual void Enter(PlayerController controller)
    {
        skillDuration = animation.length/animationSpeed;
        if (lookCursor) direction = controller.LookCursor();
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

    public bool IsCancelable(float normalizedTime)
    {
        return false;
    }
}