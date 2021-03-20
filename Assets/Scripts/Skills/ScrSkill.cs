using UnityEngine;

public abstract class ScrSkill : ScriptableObject
{
    [Header("Data")]
    public Sprite icon;
    public string skillName;
    [TextArea] public string toolTip;
    public AnimationClip animation;
    public float animationSpeed = 1;

    [Header("Movement and Cancel options")]
    [SerializeField] protected bool lookCursor = true;
    [Tooltip("If this parameter is true, the skill can only be canceled by a dodge.")]
    [SerializeField] protected bool dodgeCancelOnly = false;
    [SerializeField] protected AnimationCurve displacement;

    [HideInInspector] public float skillDuration = -1;
    [HideInInspector] protected Vector3 direction;
    public Vector3 Direction {
        get => direction;
    }
    
    protected float internalCounter = 0;

    

    [SerializeField][Range(0,1)] protected float startupCancelWindowStart = 0;
    [SerializeField][Range(0,1)] protected float startupCancelWindowEnd = 0;
    [SerializeField][Range(0,1)] protected float recoveryCancelWindowStart = 0;
    [SerializeField][Range(0,1)] protected float recoveryCancelWindowEnd = 0;

    // Implement the State Pattern
    public abstract void HandleInput();
    protected abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public virtual void Enter(PlayerController controller)
    {
        internalCounter = 0;
        skillDuration = animation.length/animationSpeed;
        if (lookCursor) 
        {
            direction = controller.LookCursor();
        }
        OnEnter(controller);
        controller.PlaySkillAnimation(animation, skillDuration, animationSpeed);
    }

    public virtual void SkillUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        var dist = displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime * 100;
        controller.Move(direction.normalized * displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime);
        OnUpdate(controller);
    }

    public virtual void Quit(PlayerController controller)
    {
        return;
    }

    public bool IsCancelable(float normalizedTime, bool dodge = false)
    {
        if (dodgeCancelOnly && !dodge) return false;
        return (startupCancelWindowStart < normalizedTime && normalizedTime < startupCancelWindowEnd)
        || (recoveryCancelWindowStart < normalizedTime && normalizedTime < recoveryCancelWindowEnd);
    }
}