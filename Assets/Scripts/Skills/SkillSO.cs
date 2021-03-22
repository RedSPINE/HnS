using UnityEngine;

public abstract class SkillSO : ScriptableObject
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
    protected Vector3 direction;
    public Vector3 Direction {
        get => direction;
    }

    [System.Serializable]
    public struct CancelWindow { 
        [Tooltip("If this parameter is true, the skill can only be canceled by a dodge.")]
        public bool dodgeOnly;
        [Range(0,1)] public float start;
        [Range(0,1)] public float end;
    }
    [SerializeField] protected CancelWindow[] cancelWindows;
    
    protected float internalCounter = 0;

    // Implement the State Pattern
    public abstract void HandleInput();
    protected abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public virtual void Enter(PlayerController controller)
    {
        internalCounter = 0;
        skillDuration = animation.length/animationSpeed;
        if (lookCursor) 
            direction = controller.LookCursor();
        else
            direction = controller.Direction;
        OnEnter(controller);
        controller.PlaySkillAnimation(animation, skillDuration, animationSpeed);
    }

    public virtual void SkillUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;
        var dist = displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime * 100;
        controller.Move(direction.normalized * displacement.Evaluate(internalCounter / skillDuration) * Time.deltaTime / skillDuration);
        OnUpdate(controller);
    }

    public virtual void Quit(PlayerController controller)
    {
        return;
    }

    public bool IsCancelable(float normalizedTime, bool dodge = false)
    {
        foreach (CancelWindow cancelWindow in cancelWindows)
        {
            if(!dodge && cancelWindow.dodgeOnly) continue;
            if(cancelWindow.start < normalizedTime && normalizedTime < cancelWindow.end) return true;
        }
        return false;
    }
}

