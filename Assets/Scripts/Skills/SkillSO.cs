using UnityEngine;

public abstract class SkillSO : ScriptableObject
{
    [Header("Data")]
    public Sprite icon;
    public string skillName;
    [TextArea] public string toolTip;
    public AnimationClip animation;
    public float animationSpeed = 1;

    public ParticleSystem particleSystem;

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
    public class VFX
    {
        [Range(0, 1)] public float timeToFire;
        public bool destroyOnStateQuit;
        public GameObject prefab;
        private GameObject gameObject;
        public GameObject Go { get => gameObject; set => gameObject = value; }
        private bool instantiated;
        public bool IsInstantiated { get => instantiated; set => instantiated = value; }

        public void Leave()
        {
            if (destroyOnStateQuit) GameObject.Destroy(gameObject);
            else if (Go != null) Go.transform.transform.SetParent(null);
            Go = null;
            IsInstantiated = false;
        }

        public void Instantiate(Transform transform)
        {
            instantiated = true;
            Quaternion rotation = prefab.transform.rotation;
            rotation.eulerAngles.Set(rotation.x, 0, rotation.y);
            Vector3 position = transform.position + prefab.transform.position;
            Go = GameObject.Instantiate(prefab, transform, false);
        }
    }

    [System.Serializable]
    public class Hitbox
    {
        [Range(0, 1)] public float timeToOpen;
        [Range(0, 1)] public float timeToClose;
        public enum HitboxType {
            Damage,
        }
        public HitboxType hitboxType;
        public int baseDamage;
        public GameObject prefab;
        [HideInInspector] public GameObject gameObject = null;

        public void Instantiate(Transform transform)
        {
            Quaternion rotation = prefab.transform.rotation;
            rotation.eulerAngles.Set(rotation.x, 0, rotation.y);
            Vector3 position = transform.position + prefab.transform.position;
            gameObject = GameObject.Instantiate(prefab, transform, false);
            gameObject.GetComponent<HitboxHolder>().skillHit = this;
        }

        public void Destroy()
        {
            if (gameObject == null)
            {
                Debug.LogError("Trying to destroy Hitbox without instantiated gameObject.");
                return;
            }
            GameObject.Destroy(gameObject);
            gameObject = null;
        }
    }

    [SerializeField] protected CancelWindow[] cancelWindows;
    [SerializeField] protected VFX[] VFXArray;
    [SerializeField] protected Hitbox[] Hitboxes;

    [SerializeField] protected float internalCounter = 0;

    // Implement the State Pattern
    public abstract void HandleInput();
    protected abstract void OnUpdate(PlayerController controller);
    protected abstract void OnEnter(PlayerController controller);

    public void Enter(PlayerController controller)
    {
        if (animation == null) Debug.LogError("No animation for Skill " + skillName);
        internalCounter = 0;
        skillDuration = animation.length / animationSpeed;
        Debug.Log("SkillDuration : " + skillDuration);
        if (lookCursor)
            direction = controller.LookCursor();
        else
            direction = controller.Direction;
        OnEnter(controller);
        controller.PlaySkillAnimation(animation, skillDuration, animationSpeed);

        // instantiate all the hitboxes needed
        foreach (Hitbox hitbox in Hitboxes)
        {
            hitbox.Instantiate(controller.transform);

        }
    }

    public void SkillUpdate(PlayerController controller)
    {
        internalCounter += Time.deltaTime;

        float normalizedTime = internalCounter / skillDuration;
        float dist = displacement.Evaluate(normalizedTime) * Time.deltaTime;
        controller.Move(direction.normalized * dist);

        // create VFXs
        foreach (VFX VFX in VFXArray)
        {
            // Don’t need to instantiate or hit ? → Continue
            if (VFX.IsInstantiated) continue;
            // Instantiate if needed
            if (!VFX.IsInstantiated && normalizedTime >= VFX.timeToFire)
            {
                VFX.Instantiate(controller.transform);
                continue;
            }
        }

        // open/close hitboxes
        foreach (Hitbox hitbox in Hitboxes)
        {
            // Open if needed
            if (normalizedTime >= hitbox.timeToOpen && normalizedTime < hitbox.timeToClose)
            {
                hitbox.gameObject.GetComponent<HitboxHolder>().Open();
            }
            // Close if needed
            if (normalizedTime >= hitbox.timeToClose)
            {
                hitbox.gameObject.GetComponent<HitboxHolder>().Close();
            }
        }

        OnUpdate(controller);
    }

    public void Quit(PlayerController controller)
    {
        foreach (VFX vfx in VFXArray)
        {
            vfx.Leave();
        }
        foreach (Hitbox hitbox in Hitboxes)
        {
            hitbox.Destroy();
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
