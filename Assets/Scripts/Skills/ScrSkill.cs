using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScrSkill : ScriptableObject
{
    public Sprite icon;
    public string skillName;
    [TextArea]
    public string toolTip;
    public AnimationClip animation;
    public float animationSpeed = 1;

    public float time = -1;
    private float timeCounter;
    
    // Implement the State Pattern
    public abstract void HandleInput();
    public abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public virtual void Enter(PlayerController controller)
    {
        OnEnter(controller);
        timeCounter = time;
        controller.PlayAnimation(animation, animationSpeed);
    }

    public virtual void SkillUpdate(PlayerController controller)
    {
        if (time > 0)
        {
            timeCounter -= Time.deltaTime;
            if (timeCounter <= 0)
                controller.UseSkill(null);
        }
        OnUpdate(controller);
    }

    public virtual void Quit(PlayerController controller)
    {
        return;
    }
}
