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
        public bool destroyOnQuit;
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

        float normalizedTime = internalCounter/skillDuration;
        float dist = displacement.Evaluate(normalizedTime) * Time.deltaTime;
        controller.Move(direction.normalized * dist);

        foreach (HitBox hitBox in hitBoxes)
        {
            // Don’t need to instantiate or hit ? → Continue
            if (hitBox.IsInstanciated && hitBox.Hit) continue;
            // Instantiate if needed
            if (!hitBox.IsInstanciated && normalizedTime >= hitBox.timeToFire)
            {
                hitBox.IsInstanciated = true;
                Quaternion rotation = hitBox.prefab.transform.rotation;
                rotation.eulerAngles.Set(rotation.x, 0, rotation.y);
                Vector3 position = controller.transform.position + hitBox.prefab.transform.position;
                // Instantiate(hitBox.prefab, hitBox.prefab.transform.position, rotation, controller.transform);
                hitBox.Go = Instantiate(hitBox.prefab, controller.transform, false);
                continue;
            }
            // Hit if needed
            if (normalizedTime >= hitBox.timeToHit && hitBox.IsInstanciated && !hitBox.Hit)
            {
                hitBox.Hit = true;
                // TODO: create a hitbox and apply effects damage
                continue;
            }
        }

        OnUpdate(controller);
    }

    public virtual void Quit(PlayerController controller)
    {
        Debug.Log("OnQuit !");
        foreach (HitBox hitBox in hitBoxes)
        {
            if (hitBox.destroyOnQuit) Destroy(hitBox.Go);
            else if (hitBox.Go != null) hitBox.Go.transform.transform.SetParent(null);
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
