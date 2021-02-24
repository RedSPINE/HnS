using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    private Vector3 cursorWorldPosition;
    private Plane playerPlane;

    // Animator
    private Animator animator;

    // Walking
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float shootingMovementSpeed = 5f;
    [SerializeField] private ParticleSystem ripples = default;
    private float internalRippleCD = 0f;

    // Shooting
    private bool isShooting;
    [SerializeField] private GameObject Projectile = default;
    [SerializeField] private float internalShootInterval = 0.4f;
    private float internalShootCD = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        playerInput = new PlayerInput();
        playerInput.KeyboardMouse.LeftClick.performed += ctx => OnLeftClickPerformed();
        playerInput.KeyboardMouse.LeftClick.canceled += ctx => OnLeftClickCanceled();
        playerInput.Enable();

        playerPlane = new Plane(Vector3.up, 0f);
    }

    // Update is called once per frame
    private void Update()
    {
        internalRippleCD += Time.deltaTime;
        internalShootCD += Time.deltaTime;
        UpdateCursorWorldPosition();
        LookCursor();
        Move();
        Shoot();
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

    private void LookCursor()
    {
        Vector3 lookAtPoint = cursorWorldPosition;
        Vector3 dir = lookAtPoint - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Move()
    {
        Vector2 direction = playerInput.KeyboardMouse.Move.ReadValue<Vector2>();
        if (direction.magnitude == 0){
            animator.SetBool("IsRunning", false);
            return;
        }
        animator.SetBool("IsRunning", true);
        Vector3 direction3 = new Vector3(direction.x, 0, direction.y);
        characterController.Move(direction3 * (isShooting||internalShootCD<internalShootInterval?shootingMovementSpeed:movementSpeed) * Time.deltaTime);
    }

    private void OnLeftClickPerformed()
    {
        cursorWorldPosition.Set(cursorWorldPosition.x, cursorWorldPosition.y + 0.15f, cursorWorldPosition.z);
        Instantiate(ripples, cursorWorldPosition, ripples.transform.rotation);
        isShooting = true;
    }

    private void OnLeftClickCanceled()
    {
        isShooting = false;
    }

    private void Shoot()
    {
        if (!isShooting || internalShootCD < internalShootInterval) return;
        internalShootCD = 0;
        GameObject projectile = Instantiate(Projectile, transform.position, transform.rotation);
        Vector3 lookAtPoint = cursorWorldPosition;
        Vector3 dir = lookAtPoint - transform.position;
        dir.y = 0;
        projectile.transform.rotation = Quaternion.LookRotation(dir);
    }
}
