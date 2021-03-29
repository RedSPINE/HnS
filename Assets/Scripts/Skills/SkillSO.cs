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
    [SerializeField] protected AnimationCurve displacement;

    [HideInInspector] public float skillDuration = -1;
    protected Vector3 direction;
    public Vector3 Direction
    {
        get => direction;
    }

    [System.Serializable]
    public struct CancelWindow
    {
        [Tooltip("If this parameter is true, the skill can only be canceled by a dodge.")]
        public bool dodgeOnly;
        [Range(0, 1)] public float start;
        [Range(0, 1)] public float end;
    }

    [System.Serializable]
    public class HitBox
    {
        [Range(0, 1)] public float timeToFire;
        [Range(0, 1)] public float timeToHit;
        public bool noParent;
        public GameObject prefab;
        private GameObject gameObject;
        public GameObject Go { get => gameObject; set => gameObject = value; }
        private bool instanciated;
        public bool IsInstanciated { get => instanciated; set => instanciated = value; }
        private bool hit;
        public bool Hit { get => hit; set => hit = value; }
    }

    [SerializeField] protected CancelWindow[] cancelWindows;
    [SerializeField] protected HitBox[] hitBoxes;

    protected float internalCounter = 0;

    // Implement the State Pattern
    public abstract void HandleInput();
    protected abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public virtual void Enter(PlayerController controller)
    {
        internalCounter = 0;
        skillDuration = animation.length / animationSpeed;
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

        foreach (HitBox hitBox in hitBoxes)
        {
            if (hitBox.IsInstanciated && hitBox.Hit) continue;
            if (internalCounter >= hitBox.timeToHit && hitBox.IsInstanciated && !hitBox.Hit)
            {
                hitBox.Hit = true;
                // TODO: create a hitbox and apply effects damage
            }
            if (!hitBox.IsInstanciated && internalCounter >= hitBox.timeToFire)
            {
                hitBox.IsInstanciated = true;
                Quaternion rotation = hitBox.prefab.transform.rotation;
                rotation.eulerAngles.Set(rotation.x, controller.transform.rotation.y, 0);
                Instantiate(hitBox.prefab, controller.transform.position + hitBox.prefab.transform.position, rotation, controller.transform);
            }
        }

        OnUpdate(controller);
    }

    public virtual void Quit(PlayerController controller)
    {
        Debug.Log("OnQuit !");
        foreach (HitBox hitBox in hitBoxes)
        {
            Destroy(hitBox.Go);
            hitBox.Go = null;
            hitBox.IsInstanciated = false;
            hitBox.Hit = false;
        }
        return;
    }

    public bool IsCancelable(float normalizedTime, bool dodge = false)
    {
        foreach (CancelWindow cancelWindow in cancelWindows)
        {
            if (!dodge && cancelWindow.dodgeOnly) continue;
            if (cancelWindow.start < normalizedTime && normalizedTime < cancelWindow.end) return true;
        }
        return false;
    }


}
