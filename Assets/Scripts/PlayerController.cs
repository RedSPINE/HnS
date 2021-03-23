using UnityEngine;

[DisallowMultipleComponent]
public class PlayerController : MonoBehaviour
{
    // Hidden references
    private PlayerInput playerInput;
    private CharacterController characterController;
    private Vector3 cursorWorldPosition;
    public Vector3 CursorWorldPosition
    {
        get => cursorWorldPosition;
    }
    private Plane playerPlane;
    private Animator animator;
    private AnimatorOverrideController animatorOverrideController;
    private Entity entity;
    
    private Vector3 direction;
    public Vector3 Direction {
        get => direction;
    }
    
    [Header("Animator")]
    [SerializeField] private SkillSO playingSkill = null;
    [SerializeField] private Dodge dodge = default;
    [SerializeField] private float skillRecoveryTimer = 0;
    
    [Header("Combo System")]
    public SkillSO[] skills;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        entity = GetComponent<Entity>();

        playerInput = new PlayerInput();
        playerInput.KeyboardMouse.LeftClick.performed += ctx => OnClickPerformed(1);
        playerInput.KeyboardMouse.RightClick.performed += ctx => OnClickPerformed(2);
        playerInput.KeyboardMouse.Space.performed += ctx => OnSpacePerformed();
        playerInput.Enable();

        playerPlane = new Plane(Vector3.up, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateCursorWorldPosition();
        Move();
        if (playingSkill != null) // A skill is being used
        {
            playingSkill.SkillUpdate(this);
            skillRecoveryTimer -= Time.deltaTime;
            if (skillRecoveryTimer <= 0)
            {
                UseSkill(null);
                animator.SetTrigger("StopSkill");
            }
        } 
        else
        {
            animator.ResetTrigger("StopSkill");
        }
    }

    private void UpdateCursorWorldPosition()
    {
        var mousePosition = playerInput.KeyboardMouse.Mouse.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        float enter = 0.0f;
        if (playerPlane.Raycast(ray, out enter))
        {
            cursorWorldPosition = ray.GetPoint(enter);
        }   
    }

    public Vector3 LookCursor()
    {
        Vector3 lookAtPoint = cursorWorldPosition;
        Vector3 dir = lookAtPoint - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        direction = dir;
        return dir;
    }

    private void Move()
    {
        Vector2 direction = playerInput.KeyboardMouse.Move.ReadValue<Vector2>();
        if(direction != Vector2.zero)
            this.direction = new Vector3(direction.x, 0, direction.y);
        if (playingSkill != null) return;
        if (direction.magnitude == 0){
            animator.SetBool("IsRunning", false);
            return;
        }
        animator.SetBool("IsRunning", true);
        Move(this.direction * entity.MovementSpeed * Time.deltaTime);
        // Look at Direction
        transform.rotation = Quaternion.LookRotation(this.direction);
    }

    public void Move(Vector3 motion)
    {
        characterController.Move(motion);
    }

    private void OnClickPerformed(int slot)
    {
        // LOCKED IF PERFORMING A SKILL
        if (playingSkill != null && !playingSkill.IsCancelable(this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime)) return;
        UseSkill(skills[slot-1]);
    }

    private void OnSpacePerformed()
    {
        if (playingSkill != null && !playingSkill.IsCancelable(this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime, true)) return;
        if (playingSkill != null && playerInput.KeyboardMouse.Move.ReadValue<Vector2>() == Vector2.zero) this.direction = playingSkill.Direction;
        UseSkill(dodge);
    }

    public void PlaySkillAnimation(AnimationClip clip, float time, float speed = 1)
    {
        animatorOverrideController["Skill"] = clip;
        animator.speed = speed;
        if (time==-1) time = clip.length;
        skillRecoveryTimer = time;
        animator.SetTrigger("PlaySkill");
    }

    public void UseSkill(SkillSO skill)
    {
        if (playingSkill != null)
            playingSkill.Quit(this);
        animator.speed = 1;
        this.playingSkill = skill;
        if (playingSkill != null)
            playingSkill.Enter(this);
    }
}
